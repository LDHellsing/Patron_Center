using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Documento = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.UniqueConstraint("Documento", x => x.Documento);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    DocenteId = table.Column<int>(nullable: false),
                    AlumnosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curso_Usuario_AlumnosId",
                        column: x => x.AlumnosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curso_Usuario_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CursoId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidad_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
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
                    UrlVideo = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    UnidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diapositiva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diapositiva_Unidad_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Unidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnidadId = table.Column<int>(nullable: false),
                    Puntaje = table.Column<int>(nullable: false),
                    Evaluacion = table.Column<int>(nullable: false),
                    Ejercicio = table.Column<int>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quiz_Unidad_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Unidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pregunta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuizId = table.Column<int>(nullable: false),
                    Puntaje = table.Column<int>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    ComentarioDocente = table.Column<string>(nullable: true),
                    MultipleOpcion = table.Column<bool>(nullable: false),
                    Orden = table.Column<int>(nullable: false),
                    Enunciado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregunta_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuesta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PreguntaId = table.Column<int>(nullable: false),
                    RespuestaCorrecta = table.Column<bool>(nullable: false),
                    Seleccionada = table.Column<bool>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    Enunciado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuesta_Pregunta_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Pregunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Documento", "Eliminado", "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "Administrador", "1", false, "admin@patroncenter.com", "Administrador", "admin", 2 },
                    { 2, "Docente", "2", false, "docente@patroncenter.com", "Docecente", "admin", 1 },
                    { 3, "Alumno", "3", false, "alumno@patroncenter.com", "Alumno", "admin", 0 },
                    { 4, "Alumno", "4", true, "alumno@patroncenter.com", "Alumno Eliminado", "admin", 0 },
                    { 5, "Docente", "5", true, "docente@patroncenter.com", "Docecente Eliminado", "admin", 1 }
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "AlumnosId", "Descripcion", "DocenteId", "Eliminado", "FechaFinalizacion", "Nombre" },
                values: new object[] { 1, null, "Descripción de curso de prueba", 2, false, new DateTime(2019, 8, 20, 19, 43, 10, 275, DateTimeKind.Local).AddTicks(6649), "Curso de Prueba" });

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

            migrationBuilder.InsertData(
                table: "Diapositiva",
                columns: new[] { "Id", "Eliminado", "Orden", "Texto", "UnidadId", "UrlVideo" },
                values: new object[,]
                {
                    { 1, false, 1, "La diapositiva, transparencia, filmina o slide es una fotografía positiva (de colores reales) creada en un soporte transparente por medios fotoquímicos. Comparación entre los formatos fotográficos: Fotografía(propiamente dicha), foto, impresión fotográfica o positivo: Imagen opaca y positiva(de colores reales).Negativo: Imagen transparente y negativa(de colores invertidos). Diapositiva, filmina y película de cine: Imagen transparente y positiva(de colores reales). A las diapositivas se las llama también filminas porque se obtienen de recortar los cuadros de una filmina y colocarlos en sendos marcos cuadrados(en el caso de película de 35 mm, los marcos son de 5 cm de lado).", 1, null },
                    { 2, false, 2, "El proceso más antiguo de la fotografía en color fue el Autocromo. Este era un método de síntesis aditiva que producía diapositivas en colores, pero con baja definición y una resolución cromática limitada. Por el contrario, el proceso de síntesis sustractiva Kodachrome brindaba transparencias de colores brillantes. La película constaba de tres emulsiones, cada una de ellas sensible a una zona del espectro cromático. Y después del proceso aparecían los colorantes amarillo, magenta y cían. Introducido en 1935, fue ofrecido en un formato de 16 milímetros para películas cinematográficas, 35 mm para diapositivas y 8 mm para películas caseras. Aunque se utilizó originalmente para reportajes, ganó popularidad gradualmente. A comienzos de los años 1940, algunos aficionados usaban Kodachrome para tomar fotografías familiares, otros utilizaban adaptadores de rollos de película con cámaras de 4x5 pulgadas. En esta época, las películas en color tenían muchos defectos, eran costosas y las impresiones no duraban mucho tiempo.", 1, null },
                    { 3, false, 3, "Emulsiones más eficaces como Ektachrome y Fujichrome fueron sustituyendo a las de Kodachrome. Los aficionados las utilizaron hasta los años 1970, en que la impresión de copias en colores comenzó a desplazarla.En los últimos años del siglo XX, las transparencias en color fueron extensamente utilizadas en la fotografía publicitaria, documental, deportiva, de stock y de naturaleza. Los medios digitales han reemplazado gradualmente las transparencias en muchas de estas aplicaciones y su uso es, en la actualidad, infrecuente.", 1, null },
                    { 4, false, 4, "Por lo general, las diapositivas son preferidas por profesionales y muchos aficionados al momento de trabajar con la fotografía tradicional. Esto se debe, en parte, a su nitidez y a su reproducción cromática. La duración de las transparencias es mayor a las impresiones en color, de hecho, el proceso Kodachrome es reconocido por sus cualidades archivísticas y por brindar colores que no se atenúan con el tiempo. El proceso K-14 de Kodachrome es extremadamente difícil de llevar a cabo, ya que una mínima desviación de las especificaciones puede afectar la calidad del producto final. Es un método naturalmente imperfecto. Pequeñas cantidades de contaminación en las capas de color producen un efecto específico e irreproducible.", 1, null },
                    { 5, false, 1, "Esta unidad tiene solo una diapositiva.", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Quiz",
                columns: new[] { "Id", "Ejercicio", "Eliminado", "Evaluacion", "Nombre", "Puntaje", "UnidadId" },
                values: new object[] { 1, 0, false, 1, "Quiz de Prueba", 5, 1 });

            migrationBuilder.InsertData(
                table: "Pregunta",
                columns: new[] { "Id", "ComentarioDocente", "Eliminado", "Enunciado", "MultipleOpcion", "Orden", "Puntaje", "QuizId" },
                values: new object[] { 1, null, false, "Esta pregunta no es mas que una prueba", true, 1, 5, 1 });

            migrationBuilder.InsertData(
                table: "Pregunta",
                columns: new[] { "Id", "ComentarioDocente", "Eliminado", "Enunciado", "MultipleOpcion", "Orden", "Puntaje", "QuizId" },
                values: new object[] { 2, null, false, "Esta pregunta no es mas que otra una prueba", true, 2, 10, 1 });

            migrationBuilder.InsertData(
                table: "Respuesta",
                columns: new[] { "Id", "Eliminado", "Enunciado", "PreguntaId", "RespuestaCorrecta", "Seleccionada" },
                values: new object[,]
                {
                    { 1, false, "Esta respuesta no es correcta y no esta seleccionada", 1, false, false },
                    { 2, false, "Esta respuesta es correcta y esta seleccionada", 1, true, true },
                    { 3, false, "Esta respuesta es correcta y no esta seleccionada", 2, true, false },
                    { 4, false, "Esta respuesta no es correcta y esta seleccionada", 2, false, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_AlumnosId",
                table: "Curso",
                column: "AlumnosId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_DocenteId",
                table: "Curso",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoUsuario_CursoId",
                table: "CursoUsuario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoUsuario_UsuarioId",
                table: "CursoUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Diapositiva_UnidadId",
                table: "Diapositiva",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_QuizId",
                table: "Pregunta",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UnidadId",
                table: "Quiz",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_PreguntaId",
                table: "Respuesta",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidad_CursoId",
                table: "Unidad",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correccion");

            migrationBuilder.DropTable(
                name: "CursoUsuario");

            migrationBuilder.DropTable(
                name: "Diapositiva");

            migrationBuilder.DropTable(
                name: "Respuesta");

            migrationBuilder.DropTable(
                name: "Pregunta");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Unidad");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
