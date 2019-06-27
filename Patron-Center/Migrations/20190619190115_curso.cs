using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class curso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Usuario",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaFinalizacion = table.Column<DateTime>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    DocenteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curso_Usuario_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CursoId",
                table: "Usuario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_DocenteId",
                table: "Curso",
                column: "DocenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Curso_CursoId",
                table: "Usuario",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Curso_CursoId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_CursoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Usuario");
        }
    }
}
