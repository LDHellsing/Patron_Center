using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class ModificacionTabalaRespuestaAlumno2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PuntajeObtenido",
                table: "RespuestaAlumno",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 10, 8, 21, 35, 8, 445, DateTimeKind.Local).AddTicks(1785));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PuntajeObtenido",
                table: "RespuestaAlumno",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 10, 8, 20, 28, 26, 874, DateTimeKind.Local).AddTicks(2350));
        }
    }
}
