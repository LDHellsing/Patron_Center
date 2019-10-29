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
                name: "Calificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAlumno = table.Column<int>(nullable: false),
                    IdUnidad = table.Column<int>(nullable: false),
                    IdCurso = table.Column<int>(nullable: false),
                    Fecha = table.Column<string>(nullable: true),
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
                    DocenteId = table.Column<int>(nullable: false),
                    PreguntaId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    UnidadId = table.Column<int>(nullable: false),
                    RespuestaDesarrollo = table.Column<string>(nullable: true),
                    PuntajeObtenido = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaAlumno", x => x.Id);
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
                    { 1, "Administrador", "1", false, "admin@patroncenter.com", "Administrador", "YWRtaW4=", 2 },
                    { 2, "Docente", "2", false, "docente@patroncenter.com", "Docente", "YWRtaW4=", 1 },
                    { 3, "Alumno", "3", false, "alumno@patroncenter.com", "Alumno", "YWRtaW4=", 0 },
                    { 4, "Alumno", "4", true, "alumno@patroncenter.com", "Alumno Eliminado", "YWRtaW4=", 0 },
                    { 5, "Docente", "5", true, "docente@patroncenter.com", "Docecente Eliminado", "YWRtaW4=", 1 }
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "AlumnosId", "Descripcion", "DocenteId", "Eliminado", "FechaFinalizacion", "Nombre" },
                values: new object[] { 1, null, "Aqui se dicta un curso destinado al manejo y el aprendisaje de patrones de diseño.", 2, false, new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrones de Diseño" });

            migrationBuilder.InsertData(
                table: "CursoUsuario",
                columns: new[] { "Id", "CursoId", "UsuarioId" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Unidad",
                columns: new[] { "Id", "CursoId", "Descripcion", "Eliminado", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Unidadad introductoria para Patrones de diseño.", false, "1- Introduccion" },
                    { 2, 1, "En esta unidad se describe al Patron Singleton, sus funciones, sus características y para que se usa.", false, "2- Patrón Singleton" },
                    { 3, 1, "En esta unidad se describe al Patron Facade, sus funciones, sus características y para que se usa.", false, "3- Patrón Facade" }
                });

            migrationBuilder.InsertData(
                table: "Diapositiva",
                columns: new[] { "Id", "Eliminado", "Orden", "Texto", "UnidadId", "UrlVideo" },
                values: new object[,]
                {
                    { 1, false, 1, "Introducción a Patrones de Diseño", 1, "bx5WqFEndoo" },
                    { 16, false, 1, @"Solución:

                Crear una clase Facade que provea todos los métodos necesarios para ejecutar operaciones del subsistema.", 3, null },
                    { 15, false, 1, @"
                Problema:

                - Se necesita una interfaz de métodos unificados que provean un punto de acceso a un subsistema.

                - Se desea bajar el acoplamiento entre clases de un subsistema y las clases externas que la utilizan.

                - Mejorar la separación de capas entre subsistemas.", 3, null },
                    { 14, false, 1, "Patrón Facade", 3, null },
                    { 13, false, 5, @"Ejemplo:

                En un parque de diversiones se desea contar los números de las entradas. Para esto se debe realizar un generador que adicionalmente brinda funcionalidades como:
                - Generar un número nuevo mayor a los anteriores

                - Dada una hora devolver la cantidad de números generados en la hora parámetro.", 2, null },
                    { 12, false, 4, @"Consecuencias:

                - Se garantiza acceso a una única instancia de la clase (objeto).

                - La instancia es visible en todo el sistema (global).

                - Se mantiene el polimorfismo en la clase, es decir, no todos lo métodos son estáticos y por lo tanto pueden ser sobrescritos en clases derivadas.", 2, null },
                    { 11, false, 3, @"Solución:

                1- El constructor de la clase debe ser privado.

                2- Se declara un atributo privado y estático del mismo tipo de la clase.

                3- Se declara un método público y estático que permite acceso a la instancia privada de la clase.", 2, null },
                    { 10, false, 2, @"Problema:

                - Debemos tener una única instancia de la clase y esta debe ser accesible desde todo el sistema.

                - Se debe poder extender dicha clase por medio de herencia.", 2, null },
                    { 17, false, 1, @"Motivación:

                - Estructurar un sistema en subsistemas ayuda a reducir la complejidad.

                - Una meta común de diseño es reducir el número de dependencias entre subsistemas.

                - Una forma de lograr esto es introducir un objeto fachada, una única y simple fachada de servicios generales del subsistemas.", 3, null },
                    { 9, false, 1, "Patrón Singleton", 2, "gocJeOHtj9w" },
                    { 8, false, 8, @"ESTRUCTURA DE PATRONES:

                1) Nombre
                2) Intención –> Que resuelve.
                3) Motivación –> Caso ilustrando el problema.
                4) Aplicabilidad –> Cuando aplicarlo.
                5) Estructura –> Diagrama de clases.
                6) Participantes –> Que objetos interactúan.
                7) Colaboraciones –> Secuencia de mensajes.
                8) Consecuencias –> Ventajas y desventajas.
                9) Técnica de implementación.
                10) Usos conocidos –> En que sistemas se usa.
                11) Patrones relacionados.", 1, null },
                    { 7, false, 7, @"CLASIFICACION DE PATRONES:

                1) De Creación:
                Participan en el momento de crear objetos, en general abstrayendo la forma en que se crean, y haciendo abstracta la referencia a que clase es que que se instancia. Ej: Singleton, Factory.

                2) Estructurales:
                Tienen que ver con la forma en que las clases y los objetos son agrupados para formar grandes estructuras.Ej: Facade, Composite.

                3) De Comportamiento:
                Se utilizan para modelar diferentes formas de interactuar entre los objetos para mejorar la performance del sistema.Ej: Observer, Strategy.", 1, null },
                    { 6, false, 6, @"TIPOS DE PATRONES:

                1) Arquitectónicos:
                Básicos, representan esquemas estructurales para la construcción de los sistemas (en muchos casos apoyan el cumplimiento de requerimientos no funcionales).

                2) Diseño:
                Apoyan en la definición de estructuras de diseño y sus relaciones (implementación).

                3) Dialectos:
                Patrones específicos de un lenguaje.

                4) Interacción:
                Patrones para diseñar interfaces web de usuario.", 1, null },
                    { 5, false, 5, @"OBJETIVOS:

                Que persiguen?
                - Crear una biblioteca de módulos.
                - Elementos reutilizables.
                - No reinventar la rueda.
                - Tener soluciones a problemas ya conocidos.
                - Hablar un lenguaje común entre diseñadores y arquitectos.
                - Estandarizar diseños.
                - Facilitar el aprendizaje de técnicas a los nuevos diseñadores.

                Que no buscan?
                - Imponer una solución como la mejor.
                - Eliminar la creatividad o el uso de otras opciones.

                No es obligación utilizarlos pero simplifican el trabajo de diseño.", 1, null },
                    { 4, false, 4, @"DEFINICION DE PATRONES:

                Los Patrones Definen soluciones a problemas comunes del desarrollo de software.
                Estos deben cumplir con dos cosas:
                1) Debe comprobarse como efectivo en la resolución de un problema.
                2) Debe ser reutilizable.

                Existen diferencias entre patrones de diseño y arquitectónicos las cuales son:
                1) Los patrones arquitectónicos son mas abstractos.
                2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad (rendimiento, disponibilidad, etc).", 1, null },
                    { 3, false, 3, @"HISTORIA:

                Surgen inspirados en los patrones arquitectónicos, que aparecen a fines de los años 70, con el fin de organizar y sistematizar las soluciones que diferentes arquitectos e ingenieros iban encontrando a problemas constructivos similares.

                Se formalizan a partir del libro “Design Patterns” de los autores Gamma, Helm, Johnsony Vlisides, llamados “la pandilla de los 4” (Gang Of Four, o simplificado GoF), en 1995.

                En el libro se detalla la estructura que recomiendan emplear para la descripción de los patrones(estructura un poco más compleja de la que empleamos en este curso), y se formalizan más de 20 patrones de diseño, identificados por GoF en ese momento y todavía altamente vigentes al día de hoy.", 1, null },
                    { 2, false, 2, @"TEMARIO:

                - Historia
                - Definición de patrones
                - Tipos de patrones
                - Clasificación de patrones
                - Objetivos", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Quiz",
                columns: new[] { "Id", "Ejercicio", "Eliminado", "Evaluacion", "Nombre", "Puntaje", "UnidadId" },
                values: new object[,]
                {
                    { 1, 0, false, 0, "Introducción a Patrones de diseño", 10, 1 },
                    { 2, 1, false, 0, "Patrón Singleton", 10, 2 },
                    { 4, 0, false, 1, "Ejercicio Introducción a Patrones de diseño", 10, 1 },
                    { 3, 1, false, 0, "Patrón Singleton", 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "Pregunta",
                columns: new[] { "Id", "Eliminado", "Enunciado", "Orden", "Puntaje", "QuizId" },
                values: new object[,]
                {
                    { 1, false, "¿Que persiguen los patrones de diseño?", 1, 25, 1 },
                    { 2, false, "¿Cual de los siguientes tipos NO es un tipo de patrón de diseño?", 2, 25, 1 },
                    { 3, false, "Los patrones de Creación participan en el momento de crear objetos...", 3, 25, 1 },
                    { 4, false, "Los patrones de Comportamiento empeoran la performance del sistema...", 4, 25, 1 },
                    { 11, false, "¿en que décadas aparecen los primeros patrones de diseño?", 1, 20, 4 },
                    { 12, false, "¿Que no persigue un patrón de diseño?", 2, 40, 4 },
                    { 13, false, "¿Que debe cumplir un patron de diseño?", 3, 40, 4 },
                    { 5, false, "¿Que soluciona el patron Singleton?", 4, 50, 2 },
                    { 6, false, "¿Que garantiza el patron Singleton?", 4, 25, 2 },
                    { 7, false, "Describa brevemente un ejemplo de utilización del patron Singleton", 4, 25, 2 },
                    { 8, false, "¿Que soluciona el patron Facade?", 4, 50, 3 },
                    { 9, false, "¿Que motiva utilizar el patron Facade?", 4, 25, 3 },
                    { 10, false, "¿Mejora la separación en capas el patron Facade? Explique", 4, 25, 3 }
                });

            migrationBuilder.InsertData(
                table: "Respuesta",
                columns: new[] { "Id", "Eliminado", "Enunciado", "PreguntaId", "RespuestaCorrecta" },
                values: new object[,]
                {
                    { 1, false, "Estandarizar diseños", 1, true },
                    { 19, false, "Ser reutilizable y comprobarse como efectivo en la resolución de un problema", 13, true },
                    { 18, false, "Estandarizar diseños", 12, false },
                    { 17, false, "Imponer una solución como la mejor", 12, false },
                    { 16, false, "Eliminar la creatividad, uso de otras opciones", 12, true },
                    { 15, false, "90", 11, false },
                    { 14, false, "80", 11, false },
                    { 13, false, "70", 11, true },
                    { 12, false, "Verdadero", 4, false },
                    { 20, false, "No importa si es reutilizable, solo debe ser efectivo en la resolución de un problema", 13, false },
                    { 11, false, "Falso", 4, true },
                    { 9, false, "Verdadero", 3, true },
                    { 8, false, "Interacción", 2, false },
                    { 7, false, "Dialectos", 2, false },
                    { 6, false, "Arquitectónico", 2, false },
                    { 5, false, "Definición", 2, true },
                    { 4, false, "Reinventar la rueda", 1, false },
                    { 3, false, "Eliminar la creatividad, uso de otras opciones", 1, false },
                    { 2, false, "Imponer una solución como la mejor", 1, false },
                    { 10, false, "Falso", 3, false },
                    { 21, false, "Debe ser reutilizable, e imponer una solución como la mejor", 13, false }
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
                name: "Calificacion");

            migrationBuilder.DropTable(
                name: "CursoUsuario");

            migrationBuilder.DropTable(
                name: "Diapositiva");

            migrationBuilder.DropTable(
                name: "Respuesta");

            migrationBuilder.DropTable(
                name: "RespuestaAlumno");

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
