using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class cursoUsuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlumnosId",
                table: "Curso",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curso_AlumnosId",
                table: "Curso",
                column: "AlumnosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Usuario_AlumnosId",
                table: "Curso",
                column: "AlumnosId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Usuario_AlumnosId",
                table: "Curso");

            migrationBuilder.DropIndex(
                name: "IX_Curso_AlumnosId",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "AlumnosId",
                table: "Curso");
        }
    }
}
