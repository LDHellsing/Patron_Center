using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class teorico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "Documento",
                table: "Usuario",
                column: "Documento");

            migrationBuilder.CreateTable(
                name: "Teorico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    UnidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teorico_Unidad_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Unidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diapositiva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(nullable: false),
                    Orden = table.Column<int>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    TeoricoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diapositiva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diapositiva_Teorico_TeoricoId",
                        column: x => x.TeoricoId,
                        principalTable: "Teorico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 22, 21, 28, 17, 394, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.CreateIndex(
                name: "IX_Diapositiva_TeoricoId",
                table: "Diapositiva",
                column: "TeoricoId");

            migrationBuilder.CreateIndex(
                name: "IX_Teorico_UnidadId",
                table: "Teorico",
                column: "UnidadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diapositiva");

            migrationBuilder.DropTable(
                name: "Teorico");

            migrationBuilder.DropUniqueConstraint(
                name: "Documento",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 15, 21, 24, 7, 577, DateTimeKind.Local).AddTicks(979));
        }
    }
}
