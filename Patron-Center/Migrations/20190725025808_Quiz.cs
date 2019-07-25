using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class Quiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDCurso = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pregunta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDQuiz = table.Column<int>(nullable: false),
                    TipoPregunta = table.Column<bool>(nullable: false),
                    Orden = table.Column<int>(nullable: false),
                    Enunciado = table.Column<string>(nullable: false),
                    QuizID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregunta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pregunta_Quiz_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quiz",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respuesta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDPregunta = table.Column<int>(nullable: false),
                    RespuestaCorrecta = table.Column<bool>(nullable: false),
                    RespuestaUnica = table.Column<bool>(nullable: false),
                    Enunciado = table.Column<string>(nullable: false),
                    PreguntaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuesta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Respuesta_Pregunta_PreguntaID",
                        column: x => x.PreguntaID,
                        principalTable: "Pregunta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 24, 23, 58, 7, 514, DateTimeKind.Local).AddTicks(816));

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_QuizID",
                table: "Pregunta",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_PreguntaID",
                table: "Respuesta",
                column: "PreguntaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respuesta");

            migrationBuilder.DropTable(
                name: "Pregunta");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 24, 23, 55, 13, 240, DateTimeKind.Local).AddTicks(7592));
        }
    }
}
