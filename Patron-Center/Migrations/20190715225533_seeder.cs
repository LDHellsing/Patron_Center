using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Documento", "Eliminado", "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[] { 1, "Administrador", "1", false, "admin@patroncenter.com", "Usuario", "admin", 2 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Documento", "Eliminado", "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[] { 2, "Docente", "2", false, "docente@patroncenter.com", "Usuario", "admin", 1 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Documento", "Eliminado", "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[] { 3, "Alumno", "3", false, "alumno@patroncenter.com", "Usuario", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "AlumnosId", "Descripcion", "DocenteId", "Eliminado", "FechaFinalizacion", "Nombre" },
                values: new object[] { 1, null, "Descripción de curso de prueba", 2, false, new DateTime(2019, 7, 15, 19, 55, 32, 786, DateTimeKind.Local).AddTicks(2503), "Curso de Prueba" });

            migrationBuilder.InsertData(
                table: "CursoUsuario",
                columns: new[] { "Id", "CursoId", "UsuarioId" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Unidad",
                columns: new[] { "Id", "CursoId", "Descripcion", "Eliminado", "Nombre" },
                values: new object[] { 1, 1, "Descripción de Unidad de prueba 1", false, "1- Unidad de prueba 1" });

            migrationBuilder.InsertData(
                table: "Unidad",
                columns: new[] { "Id", "CursoId", "Descripcion", "Eliminado", "Nombre" },
                values: new object[] { 2, 1, "Descripción de Unidad de prueba 2", false, "2- Unidad de prueba 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CursoUsuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Unidad",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Unidad",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
