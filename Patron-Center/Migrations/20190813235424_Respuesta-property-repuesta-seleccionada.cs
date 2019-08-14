using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class Respuestapropertyrepuestaseleccionada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsSeleccionada",
                table: "Respuesta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 8, 13, 20, 54, 22, 300, DateTimeKind.Local).AddTicks(8721));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsSeleccionada",
                table: "Respuesta");

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 8, 10, 18, 26, 36, 799, DateTimeKind.Local).AddTicks(1577));
        }
    }
}
