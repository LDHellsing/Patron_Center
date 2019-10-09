using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class ModificacionTabalaRespuestaAlumno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RespuestaId",
                table: "RespuestaAlumno",
                newName: "PuntajeObtenido");

            migrationBuilder.AddColumn<int>(
                name: "DocenteId",
                table: "RespuestaAlumno",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 10, 8, 20, 28, 26, 874, DateTimeKind.Local).AddTicks(2350));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocenteId",
                table: "RespuestaAlumno");

            migrationBuilder.RenameColumn(
                name: "PuntajeObtenido",
                table: "RespuestaAlumno",
                newName: "RespuestaId");

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 10, 7, 22, 34, 56, 245, DateTimeKind.Local).AddTicks(734));
        }
    }
}
