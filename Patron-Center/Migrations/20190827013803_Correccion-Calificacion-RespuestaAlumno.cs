using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class CorreccionCalificacionRespuestaAlumno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MultipleOpcion",
                table: "Pregunta");

            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "Correccion");

            migrationBuilder.RenameColumn(
                name: "IdQuiz",
                table: "Correccion",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdAlumno",
                table: "Correccion",
                newName: "QuizId");

            migrationBuilder.AddColumn<int>(
                name: "Calificacion",
                table: "Correccion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProfesor",
                table: "Correccion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreguntaId",
                table: "Correccion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RespuestaAlumnoId",
                table: "Correccion",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Calificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    UnidadId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nota = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaAlumno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    PreguntaId = table.Column<int>(nullable: false),
                    RespuestaId = table.Column<int>(nullable: false),
                    RespuestaDesarrollo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaAlumno", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 8, 26, 22, 38, 2, 812, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.CreateIndex(
                name: "IX_Correccion_RespuestaAlumnoId",
                table: "Correccion",
                column: "RespuestaAlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Correccion_RespuestaAlumno_RespuestaAlumnoId",
                table: "Correccion",
                column: "RespuestaAlumnoId",
                principalTable: "RespuestaAlumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Correccion_RespuestaAlumno_RespuestaAlumnoId",
                table: "Correccion");

            migrationBuilder.DropTable(
                name: "Calificacion");

            migrationBuilder.DropTable(
                name: "RespuestaAlumno");

            migrationBuilder.DropIndex(
                name: "IX_Correccion_RespuestaAlumnoId",
                table: "Correccion");

            migrationBuilder.DropColumn(
                name: "Calificacion",
                table: "Correccion");

            migrationBuilder.DropColumn(
                name: "IdProfesor",
                table: "Correccion");

            migrationBuilder.DropColumn(
                name: "PreguntaId",
                table: "Correccion");

            migrationBuilder.DropColumn(
                name: "RespuestaAlumnoId",
                table: "Correccion");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Correccion",
                newName: "IdQuiz");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Correccion",
                newName: "IdAlumno");

            migrationBuilder.AddColumn<bool>(
                name: "MultipleOpcion",
                table: "Pregunta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Resultado",
                table: "Correccion",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 8, 21, 22, 29, 34, 910, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Pregunta",
                keyColumn: "Id",
                keyValue: 1,
                column: "MultipleOpcion",
                value: true);

            migrationBuilder.UpdateData(
                table: "Pregunta",
                keyColumn: "Id",
                keyValue: 2,
                column: "MultipleOpcion",
                value: true);
        }
    }
}
