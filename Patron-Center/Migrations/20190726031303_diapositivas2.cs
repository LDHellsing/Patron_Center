using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patron_Center.Migrations
{
    public partial class diapositivas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 26, 0, 13, 3, 366, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.InsertData(
                table: "Diapositiva",
                columns: new[] { "Id", "Eliminado", "Orden", "Texto", "UnidadId" },
                values: new object[,]
                {
                    { 1, false, 1, "La diapositiva, transparencia, filmina o slide es una fotografía positiva (de colores reales) creada en un soporte transparente por medios fotoquímicos. Comparación entre los formatos fotográficos: Fotografía(propiamente dicha), foto, impresión fotográfica o positivo: Imagen opaca y positiva(de colores reales).Negativo: Imagen transparente y negativa(de colores invertidos). Diapositiva, filmina y película de cine: Imagen transparente y positiva(de colores reales). A las diapositivas se las llama también filminas porque se obtienen de recortar los cuadros de una filmina y colocarlos en sendos marcos cuadrados(en el caso de película de 35 mm, los marcos son de 5 cm de lado).", 1 },
                    { 2, false, 2, "El proceso más antiguo de la fotografía en color fue el Autocromo. Este era un método de síntesis aditiva que producía diapositivas en colores, pero con baja definición y una resolución cromática limitada. Por el contrario, el proceso de síntesis sustractiva Kodachrome brindaba transparencias de colores brillantes. La película constaba de tres emulsiones, cada una de ellas sensible a una zona del espectro cromático. Y después del proceso aparecían los colorantes amarillo, magenta y cían. Introducido en 1935, fue ofrecido en un formato de 16 milímetros para películas cinematográficas, 35 mm para diapositivas y 8 mm para películas caseras. Aunque se utilizó originalmente para reportajes, ganó popularidad gradualmente. A comienzos de los años 1940, algunos aficionados usaban Kodachrome para tomar fotografías familiares, otros utilizaban adaptadores de rollos de película con cámaras de 4x5 pulgadas. En esta época, las películas en color tenían muchos defectos, eran costosas y las impresiones no duraban mucho tiempo.", 1 },
                    { 3, false, 3, "Emulsiones más eficaces como Ektachrome y Fujichrome fueron sustituyendo a las de Kodachrome. Los aficionados las utilizaron hasta los años 1970, en que la impresión de copias en colores comenzó a desplazarla.En los últimos años del siglo XX, las transparencias en color fueron extensamente utilizadas en la fotografía publicitaria, documental, deportiva, de stock y de naturaleza. Los medios digitales han reemplazado gradualmente las transparencias en muchas de estas aplicaciones y su uso es, en la actualidad, infrecuente.", 1 },
                    { 4, false, 4, "Por lo general, las diapositivas son preferidas por profesionales y muchos aficionados al momento de trabajar con la fotografía tradicional. Esto se debe, en parte, a su nitidez y a su reproducción cromática. La duración de las transparencias es mayor a las impresiones en color, de hecho, el proceso Kodachrome es reconocido por sus cualidades archivísticas y por brindar colores que no se atenúan con el tiempo. El proceso K-14 de Kodachrome es extremadamente difícil de llevar a cabo, ya que una mínima desviación de las especificaciones puede afectar la calidad del producto final. Es un método naturalmente imperfecto. Pequeñas cantidades de contaminación en las capas de color producen un efecto específico e irreproducible.", 1 },
                    { 5, false, 1, "Esta unidad tiene solo una diapositiva.", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diapositiva",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaFinalizacion",
                value: new DateTime(2019, 7, 25, 21, 12, 4, 912, DateTimeKind.Local).AddTicks(9564));
        }
    }
}
