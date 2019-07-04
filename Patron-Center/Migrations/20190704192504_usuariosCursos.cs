using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class usuariosCursos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlumnosId",
                table: "Curso",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CursoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_AlumnosId",
                table: "Curso",
                column: "AlumnosId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoUsuario_CursoId",
                table: "CursoUsuario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoUsuario_UsuarioId",
                table: "CursoUsuario",
                column: "UsuarioId");

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

            migrationBuilder.DropTable(
                name: "CursoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Curso_AlumnosId",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "AlumnosId",
                table: "Curso");
        }
    }
}
