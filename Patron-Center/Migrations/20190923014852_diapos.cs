using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class diapos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 9, 22, 22, 48, 51, 161, DateTimeKind.Local).AddTicks(3842));

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 2,
                column: "Texto",
                value: @"TEMARIO: 
 Historia,
 Definicion de patrones, 
 Tipos, 
 Clasificacion, 
 Objetivos");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 3,
                column: "Texto",
                value: "HISTORIA: Surgen inspirados en los patrones arquitectónicos, que aparecen a fines de los años 70, con el fin de organizar y sistematizar las soluciones que diferentes arquitectos e ingenieros iban encontrando a problemas constructivos similares.     Se formalizan a partir del libro “Design Patterns” de los autores Gamma, Helm, Johnsony Vlisides, llamados “la pandilla de los 4” (Gangof Four, o simplificado GoF),en1995.     En el libro se detalla la estructura que recomiendan emplear para la descripción de los patrones(estructura un poco más compleja de la que empleamos en este curso), y se formalizan más de 20 patrones de diseño, identificados por GoF en ese momento y todavía altamente vigentes al dia de hoy.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 4,
                column: "Texto",
                value: @"DEFINICION DE PATRONES: Los Patrones Definen soluciones a problemas comunes del desarrollo de software Estos deben cumplir con dos cosas: 1) Debe comprobarse como efectivo en la resolución de un problema 2) Debe ser reutilizable. 
 Existen diferencias entre patrones de diseño y arquitectónicos las cuales son: (1) Los patrones arquitectónicos son mas abstractos (2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad(Rendimiento, disponibilidad,etc).");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 5,
                column: "Texto",
                value: "OBJETIVOS: Que persiguen: Crear una biblioteca de módulos, elementos reutilizables, No reinventar la rueda, tener soluciones a problemas ya conocidos, Hablar un lenguaje común entre diseñadores, arquitectos, Estandarizar diseños, Facilitar el aprendizaje de técnicas a los nuevos diseñadores. Que no buscan: Imponer una solución como la mejor, Eliminar la creatividad, uso de otras opciones. No es obligación utilizarlos pero simplifican el trabajo de diseño");

            migrationBuilder.InsertData(
                table: "Diapositiva",
                columns: new[] { "Id", "Eliminado", "Orden", "Texto", "UnidadId", "UrlVideo" },
                values: new object[,]
                {
                    { 7, false, 7, "CLASIFICACION DE PATRONES: 1) De Creación: participan en el momento de crear objetos, en general abstrayendo la forma en que se crean, y haciendo abstracta la referencia a que clase es que que se instancia. Ej: Singleton, Factory. 2) Estructurales: tienen que ver con la forma en que las clases y los objetos son agrupados para formar grandes estructuras.Ej: Facade, Composite. 3) De Comportamiento: se utilizan para modelar diferentes formas de interactuar entre los objetos para mejorar la performance del sistema.Ej: Observer, Strategy", 1, null },
                    { 8, false, 8, "ESTRUCTURA DE PATRONES: 1) Nombre 2) Intención – Que resuelve 3) Motivación – Caso ilustrando el problema 4) Aplicabilidad – Cuando aplicarlo 5) Estructura – Diagrama de clases 6) Participantes – Que objetos interactúan 7) Colaboraciones – Secuencia de mensajes 8) Consecuencias – Ventajas y desventajas 9) Técnica de implementación 10) Usos conocidos – En que sistemas se usa 11) Patrones relacionados", 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 9, 22, 22, 27, 28, 786, DateTimeKind.Local).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 2,
                column: "Texto",
                value: @"Temario: 
 Historia, 
 Clasificacion, 
 Definicion de patrones, 
 Tipos, 
 Objetivos");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 3,
                column: "Texto",
                value: "Historia: Surgen inspirados en los patrones arquitectónicos, que aparecen a fines de los años 70, con el fin de organizar y sistematizar las soluciones que diferentes arquitectos e ingenieros iban encontrando a problemas constructivos similares.     Se formalizan a partir del libro “Design Patterns” de los autores Gamma, Helm, Johnsony Vlisides, llamados “la pandilla de los 4” (Gangof Four, o simplificado GoF),en1995.     En el libro se detalla la estructura que recomiendan emplear para la descripción de los patrones(estructura un poco más compleja de la que empleamos en este curso), y se formalizan más de 20 patrones de diseño, identificados por GoF en ese momento y todavía altamente vigentes al dia de hoy.");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 4,
                column: "Texto",
                value: @"Definicicion de Patrones: Los Patrones Definen soluciones a problemas comunes del desarrollo de software Estos deben cumplir con dos cosas: 1) Debe comprobarse como efectivo en la resolución de un problema 2) Debe ser reutilizable. 
 Existen diferencias entre patrones de diseño y arquitectónicos las cuales son: (1) Los patrones arquitectónicos son mas abstractos (2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad(Rendimiento, disponibilidad,etc).");

            migrationBuilder.UpdateData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 5,
                column: "Texto",
                value: "Objertivos: Que persiguen: Crear una biblioteca de módulos, elementos reutilizables, No reinventar la rueda, tener soluciones a problemas ya conocidos, Hablar un lenguaje común entre diseñadores, arquitectos, Estandarizar diseños, Facilitar el aprendizaje de técnicas a los nuevos diseñadores. Que no buscan: Imponer una solución como la mejor, Eliminar la creatividad, uso de otras opciones. No es obligación utilizarlos pero simplifican el trabajo de diseño");
        }
    }
}
