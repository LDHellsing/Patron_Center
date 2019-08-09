using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class QuizPreguntaRespuestaCorreccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RespuestaUnica",
                table: "Respuesta",
                newName: "EsRespuestaUnica");

            migrationBuilder.RenameColumn(
                name: "RespuestaCorrecta",
                table: "Respuesta",
                newName: "EsRespuestaCorrecta");

            migrationBuilder.AddColumn<bool>(
                name: "EsEliminado",
                table: "Respuesta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EsEliminado",
                table: "Quiz",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EsEvaluacion",
                table: "Quiz",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Puntaje",
                table: "Quiz",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ComentarioDocente",
                table: "Pregunta",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EsEliminado",
                table: "Pregunta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Puntaje",
                table: "Pregunta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Correccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdQuiz = table.Column<int>(nullable: false),
                    IdAlumno = table.Column<int>(nullable: false),
                    Resultado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correccion", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 8, 8, 21, 54, 38, 297, DateTimeKind.Local).AddTicks(7219));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correccion");

            migrationBuilder.DropColumn(
                name: "EsEliminado",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "EsEliminado",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "EsEvaluacion",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "Puntaje",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "ComentarioDocente",
                table: "Pregunta");

            migrationBuilder.DropColumn(
                name: "EsEliminado",
                table: "Pregunta");

            migrationBuilder.DropColumn(
                name: "Puntaje",
                table: "Pregunta");

            migrationBuilder.RenameColumn(
                name: "EsRespuestaUnica",
                table: "Respuesta",
                newName: "RespuestaUnica");

            migrationBuilder.RenameColumn(
                name: "EsRespuestaCorrecta",
                table: "Respuesta",
                newName: "RespuestaCorrecta");

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 26, 1, 40, 1, 521, DateTimeKind.Local).AddTicks(8973));
        }
    }
}
