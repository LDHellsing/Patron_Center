using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class documentoUnique : Migration
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

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 16, 22, 53, 14, 283, DateTimeKind.Local).AddTicks(2405));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2019, 7, 16, 21, 9, 52, 311, DateTimeKind.Local).AddTicks(5636));
        }
    }
}
