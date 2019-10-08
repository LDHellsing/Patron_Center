using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class quiz1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 10, 7, 22, 34, 56, 245, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 1,
                column: "Texto",
                value: "Introducción a Patrones de Diseño");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 2,
                column: "Texto",
                value: @"TEMARIO:

- Historia
- Definición de patrones
- Tipos de patrones
- Clasificación de patrones
- Objetivos");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 3,
                column: "Texto",
                value: @"HISTORIA:

Surgen inspirados en los patrones arquitectónicos, que aparecen a fines de los años 70, con el fin de organizar y sistematizar las soluciones que diferentes arquitectos e ingenieros iban encontrando a problemas constructivos similares.

Se formalizan a partir del libro “Design Patterns” de los autores Gamma, Helm, Johnsony Vlisides, llamados “la pandilla de los 4” (Gang Of Four, o simplificado GoF), en 1995.

En el libro se detalla la estructura que recomiendan emplear para la descripción de los patrones(estructura un poco más compleja de la que empleamos en este curso), y se formalizan más de 20 patrones de diseño, identificados por GoF en ese momento y todavía altamente vigentes al día de hoy.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 4,
                column: "Texto",
                value: @"DEFINICION DE PATRONES:

Los Patrones Definen soluciones a problemas comunes del desarrollo de software.
Estos deben cumplir con dos cosas:
1) Debe comprobarse como efectivo en la resolución de un problema.
2) Debe ser reutilizable.

Existen diferencias entre patrones de diseño y arquitectónicos las cuales son:
1) Los patrones arquitectónicos son mas abstractos.
2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad (rendimiento, disponibilidad, etc).");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 5,
                column: "Texto",
                value: @"OBJETIVOS:

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

No es obligación utilizarlos pero simplifican el trabajo de diseño.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 6,
                column: "Texto",
                value: @"TIPOS DE PATRONES:

1) Arquitectónicos:
Básicos, representan esquemas estructurales para la construcción de los sistemas (en muchos casos apoyan el cumplimiento de requerimientos no funcionales).

2) Diseño:
Apoyan en la definición de estructuras de diseño y sus relaciones (implementación).

3) Dialectos:
Patrones específicos de un lenguaje.

4) Interacción:
Patrones para diseñar interfaces web de usuario.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 7,
                column: "Texto",
                value: @"CLASIFICACION DE PATRONES:

1) De Creación:
Participan en el momento de crear objetos, en general abstrayendo la forma en que se crean, y haciendo abstracta la referencia a que clase es que que se instancia. Ej: Singleton, Factory.

2) Estructurales:
Tienen que ver con la forma en que las clases y los objetos son agrupados para formar grandes estructuras.Ej: Facade, Composite.

3) De Comportamiento:
Se utilizan para modelar diferentes formas de interactuar entre los objetos para mejorar la performance del sistema.Ej: Observer, Strategy.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 8,
                column: "Texto",
                value: @"ESTRUCTURA DE PATRONES:

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
11) Patrones relacionados.");

            migrationBuilder.UpdateData(
                table: "Pregunta",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Enunciado", "Puntaje" },
                values: new object[] { "¿Que persiguen los patrones de diseño?", 25 });

            migrationBuilder.UpdateData(
                table: "Pregunta",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Enunciado", "Puntaje" },
                values: new object[] { "¿Cual de los siguientes tipos NO es un tipo de patrón de diseño?", 25 });

            migrationBuilder.InsertData(
                table: "Pregunta",
                columns: new[] { "Id", "ComentarioDocente", "Eliminado", "Enunciado", "Orden", "Puntaje", "QuizId" },
                values: new object[,]
                {
                    { 3, null, false, "Los patrones de Creación particicipan en el momento de crear obejetos...", 2, 25, 1 },
                    { 4, null, false, "Los patrones de Comportamiento empeoran la performance del sistema...", 2, 25, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Quiz",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nombre", "Puntaje" },
                values: new object[] { "Introducción a Patrones de diseño", 10 });

            migrationBuilder.UpdateData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Enunciado", "RespuestaCorrecta" },
                values: new object[] { "Estandarizar diseños", true });

            migrationBuilder.UpdateData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Enunciado", "RespuestaCorrecta", "Seleccionada" },
                values: new object[] { "Imponer una solución como la mejor", false, false });

            migrationBuilder.UpdateData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Enunciado", "PreguntaId", "RespuestaCorrecta" },
                values: new object[] { "Eliminar la creatividad, uso de otras opciones", 1, false });

            migrationBuilder.UpdateData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Enunciado", "PreguntaId", "Seleccionada" },
                values: new object[] { "Reinventar la rueda", 1, false });

            migrationBuilder.InsertData(
                table: "Respuesta",
                columns: new[] { "Id", "Eliminado", "Enunciado", "PreguntaId", "RespuestaCorrecta", "Seleccionada" },
                values: new object[,]
                {
                    { 5, false, "Definicón", 2, true, false },
                    { 6, false, "Arquitectónico", 2, false, false },
                    { 7, false, "Dialectos", 2, false, false },
                    { 8, false, "Interacción", 2, false, false }
                });

            migrationBuilder.InsertData(
                table: "Respuesta",
                columns: new[] { "Id", "Eliminado", "Enunciado", "PreguntaId", "RespuestaCorrecta", "Seleccionada" },
                values: new object[,]
                {
                    { 9, false, "Verdadero", 3, true, false },
                    { 10, false, "Falso", 3, false, false },
                    { 11, false, "Falso", 4, true, false },
                    { 12, false, "Verdadero", 4, false, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pregunta",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pregunta",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 9, 26, 21, 48, 2, 245, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 1,
                column: "Texto",
                value: "Introduccion a Patrones de Diseño");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 2,
                column: "Texto",
                value: @"TEMARIO: 

 - Historia
 - Definición de patrones
 - Tipos 
 - Clasificación 
 - Objetivos");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 3,
                column: "Texto",
                value: @"HISTORIA:

Surgen inspirados en los patrones arquitectónicos, que aparecen a fines de los años 70, con el fin de organizar y sistematizar las soluciones que diferentes arquitectos e ingenieros iban encontrando a problemas constructivos similares.
Se formalizan a partir del libro “Design Patterns” de los autores Gamma, Helm, Johnsony Vlisides, llamados “la pandilla de los 4” (Gang Of Four, o simplificado GoF), en 1995.
En el libro se detalla la estructura que recomiendan emplear para la descripción de los patrones(estructura un poco más compleja de la que empleamos en este curso), y se formalizan más de 20 patrones de diseño, identificados por GoF en ese momento y todavía altamente vigentes al día de hoy.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 4,
                column: "Texto",
                value: @"DEFINICION DE PATRONES:

Los Patrones Definen soluciones a problemas comunes del desarrollo de software.
Estos deben cumplir con dos cosas:
 1) Debe comprobarse como efectivo en la resolución de un problema
 2) Debe ser reutilizable. 

Existen diferencias entre patrones de diseño y arquitectónicos las cuales son: 
 (1) Los patrones arquitectónicos son mas abstractos 
 (2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad(Rendimiento, disponibilidad,etc).");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 5,
                column: "Texto",
                value: @"OBJETIVOS:

Que persiguen:
Crear una biblioteca de módulos, elementos reutilizables, No reinventar la rueda, tener soluciones a problemas ya conocidos, Hablar un lenguaje común entre diseñadores y arquitectos, Estandarizar diseños, Facilitar el aprendizaje de técnicas a los nuevos diseñadores. 

Que no buscan: 
Imponer una solución como la mejor, Eliminar la creatividad o el uso de otras opciones. 

No es obligación utilizarlos pero simplifican el trabajo de diseño.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 6,
                column: "Texto",
                value: @"TIPOS DE PATRONES:


 1)Arquitectónicos: Básicos, representan esquemas estructurales para la construcción de los sistemas(en muchos casos apoyan el cumplimiento de requerimientos no funcionales).


 2)Diseño: Apoyan en la definición de estructuras de diseño y sus relaciones(implementación). 


 3)Dialectos: Patrones específicos de un lenguaje. 

4) Interacción: Patrones para diseñar interfaces web de usuario.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 7,
                column: "Texto",
                value: @"CLASIFICACION DE PATRONES:

1) De Creación: participan en el momento de crear objetos, en general abstrayendo la forma en que se crean, y haciendo abstracta la referencia a que clase es que que se instancia. Ej: Singleton, Factory.

2) Estructurales: tienen que ver con la forma en que las clases y los objetos son agrupados para formar grandes estructuras.Ej: Facade, Composite.

3) De Comportamiento: se utilizan para modelar diferentes formas de interactuar entre los objetos para mejorar la performance del sistema.Ej: Observer, Strategy.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 8,
                column: "Texto",
                value: @"ESTRUCTURA DE PATRONES:

 1) Nombre
 2) Intención –> Que resuelve
 3) Motivación –> Caso ilustrando el problema
 4) Aplicabilidad –> Cuando aplicarlo
 5) Estructura –> Diagrama de clases 
 6) Participantes –> Que objetos interactúan
 7) Colaboraciones –> Secuencia de mensajes
 8) Consecuencias –> Ventajas y desventajas
 9) Técnica de implementación
 10) Usos conocidos –> En que sistemas se usa 
 11) Patrones relacionados");

            migrationBuilder.UpdateData(
                table: "Pregunta",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Enunciado", "Puntaje" },
                values: new object[] { "Esta pregunta no es mas que una prueba", 5 });

            migrationBuilder.UpdateData(
                table: "Pregunta",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Enunciado", "Puntaje" },
                values: new object[] { "Esta pregunta no es mas que otra una prueba", 10 });

            migrationBuilder.UpdateData(
                table: "Quiz",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nombre", "Puntaje" },
                values: new object[] { "Quiz de Prueba", 5 });

            migrationBuilder.UpdateData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Enunciado", "RespuestaCorrecta" },
                values: new object[] { "Esta respuesta no es correcta y no esta seleccionada", false });

            migrationBuilder.UpdateData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Enunciado", "RespuestaCorrecta", "Seleccionada" },
                values: new object[] { "Esta respuesta es correcta y esta seleccionada", true, true });

            migrationBuilder.UpdateData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Enunciado", "PreguntaId", "RespuestaCorrecta" },
                values: new object[] { "Esta respuesta es correcta y no esta seleccionada", 2, true });

            migrationBuilder.UpdateData(
                table: "Respuesta",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Enunciado", "PreguntaId", "Seleccionada" },
                values: new object[] { "Esta respuesta no es correcta y esta seleccionada", 2, true });
        }
    }
}
