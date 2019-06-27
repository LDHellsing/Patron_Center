using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class curso3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Usuario_DocenteId",
                table: "Curso");

            migrationBuilder.DropIndex(
                name: "IX_Curso_DocenteId",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "DocenteId",
                table: "Curso");

            migrationBuilder.AddColumn<int>(
                name: "CursoId1",
                table: "Usuario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CursoId1",
                table: "Usuario",
                column: "CursoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Curso_CursoId1",
                table: "Usuario",
                column: "CursoId1",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Curso_CursoId1",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_CursoId1",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CursoId1",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "DocenteId",
                table: "Curso",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curso_DocenteId",
                table: "Curso",
                column: "DocenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Usuario_DocenteId",
                table: "Curso",
                column: "DocenteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
