using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class diapositivas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diapositiva_Teorico_TeoricoId",
                table: "Diapositiva");

            migrationBuilder.DropTable(
                name: "Teorico");

            migrationBuilder.RenameColumn(
                name: "TeoricoId",
                table: "Diapositiva",
                newName: "UnidadId");

            migrationBuilder.RenameIndex(
                name: "IX_Diapositiva_TeoricoId",
                table: "Diapositiva",
                newName: "IX_Diapositiva_UnidadId");

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 25, 21, 12, 4, 912, DateTimeKind.Local).AddTicks(9564));

            migrationBuilder.AddForeignKey(
                name: "FK_Diapositiva_Unidad_UnidadId",
                table: "Diapositiva",
                column: "UnidadId",
                principalTable: "Unidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diapositiva_Unidad_UnidadId",
                table: "Diapositiva");

            migrationBuilder.RenameColumn(
                name: "UnidadId",
                table: "Diapositiva",
                newName: "TeoricoId");

            migrationBuilder.RenameIndex(
                name: "IX_Diapositiva_UnidadId",
                table: "Diapositiva",
                newName: "IX_Diapositiva_TeoricoId");

            migrationBuilder.CreateTable(
                name: "Teorico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Eliminado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 25, 20, 49, 52, 95, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.CreateIndex(
                name: "IX_Teorico_UnidadId",
                table: "Teorico",
                column: "UnidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diapositiva_Teorico_TeoricoId",
                table: "Diapositiva",
                column: "TeoricoId",
                principalTable: "Teorico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
