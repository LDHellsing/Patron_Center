﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Patron_Center.Models;

namespace Patron_Center.Migrations
{
    [DbContext(typeof(Patron_CenterContext))]
    [Migration("20190726041249_video-diapo2")]
    partial class videodiapo2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Patron_Center.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlumnosId");

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<int>("DocenteId");

                    b.Property<bool>("Eliminado");

                    b.Property<DateTime>("FechaFinalizacion");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AlumnosId");

                    b.HasIndex("DocenteId");

                    b.ToTable("Curso");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Descripción de curso de prueba",
                            DocenteId = 2,
                            Eliminado = false,
                            FechaFinalizacion = new DateTime(2019, 7, 26, 1, 12, 49, 381, DateTimeKind.Local).AddTicks(6651),
                            Nombre = "Curso de Prueba"
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.CursoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CursoUsuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CursoId = 1,
                            UsuarioId = 3
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.Diapositiva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Eliminado");

                    b.Property<int>("Orden");

                    b.Property<string>("Texto")
                        .IsRequired();

                    b.Property<int>("UnidadId");

                    b.Property<string>("UrlVideo");

                    b.HasKey("Id");

                    b.HasIndex("UnidadId");

                    b.ToTable("Diapositiva");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Eliminado = false,
                            Orden = 1,
                            Texto = "La diapositiva, transparencia, filmina o slide es una fotografía positiva (de colores reales) creada en un soporte transparente por medios fotoquímicos. Comparación entre los formatos fotográficos: Fotografía(propiamente dicha), foto, impresión fotográfica o positivo: Imagen opaca y positiva(de colores reales).Negativo: Imagen transparente y negativa(de colores invertidos). Diapositiva, filmina y película de cine: Imagen transparente y positiva(de colores reales). A las diapositivas se las llama también filminas porque se obtienen de recortar los cuadros de una filmina y colocarlos en sendos marcos cuadrados(en el caso de película de 35 mm, los marcos son de 5 cm de lado).",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 2,
                            Eliminado = false,
                            Orden = 2,
                            Texto = "El proceso más antiguo de la fotografía en color fue el Autocromo. Este era un método de síntesis aditiva que producía diapositivas en colores, pero con baja definición y una resolución cromática limitada. Por el contrario, el proceso de síntesis sustractiva Kodachrome brindaba transparencias de colores brillantes. La película constaba de tres emulsiones, cada una de ellas sensible a una zona del espectro cromático. Y después del proceso aparecían los colorantes amarillo, magenta y cían. Introducido en 1935, fue ofrecido en un formato de 16 milímetros para películas cinematográficas, 35 mm para diapositivas y 8 mm para películas caseras. Aunque se utilizó originalmente para reportajes, ganó popularidad gradualmente. A comienzos de los años 1940, algunos aficionados usaban Kodachrome para tomar fotografías familiares, otros utilizaban adaptadores de rollos de película con cámaras de 4x5 pulgadas. En esta época, las películas en color tenían muchos defectos, eran costosas y las impresiones no duraban mucho tiempo.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 3,
                            Eliminado = false,
                            Orden = 3,
                            Texto = "Emulsiones más eficaces como Ektachrome y Fujichrome fueron sustituyendo a las de Kodachrome. Los aficionados las utilizaron hasta los años 1970, en que la impresión de copias en colores comenzó a desplazarla.En los últimos años del siglo XX, las transparencias en color fueron extensamente utilizadas en la fotografía publicitaria, documental, deportiva, de stock y de naturaleza. Los medios digitales han reemplazado gradualmente las transparencias en muchas de estas aplicaciones y su uso es, en la actualidad, infrecuente.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 4,
                            Eliminado = false,
                            Orden = 4,
                            Texto = "Por lo general, las diapositivas son preferidas por profesionales y muchos aficionados al momento de trabajar con la fotografía tradicional. Esto se debe, en parte, a su nitidez y a su reproducción cromática. La duración de las transparencias es mayor a las impresiones en color, de hecho, el proceso Kodachrome es reconocido por sus cualidades archivísticas y por brindar colores que no se atenúan con el tiempo. El proceso K-14 de Kodachrome es extremadamente difícil de llevar a cabo, ya que una mínima desviación de las especificaciones puede afectar la calidad del producto final. Es un método naturalmente imperfecto. Pequeñas cantidades de contaminación en las capas de color producen un efecto específico e irreproducible.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 5,
                            Eliminado = false,
                            Orden = 1,
                            Texto = "Esta unidad tiene solo una diapositiva.",
                            UnidadId = 2
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Enunciado")
                        .IsRequired();

                    b.Property<bool>("EsMultipleOpcion");

                    b.Property<int>("IdQuiz");

                    b.Property<int>("Orden");

                    b.Property<int?>("QuizId");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Pregunta");
                });

            modelBuilder.Entity("Patron_Center.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCurso");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("Patron_Center.Models.Respuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Enunciado")
                        .IsRequired();

                    b.Property<int>("IdPregunta");

                    b.Property<int?>("PreguntaId");

                    b.Property<bool>("RespuestaCorrecta");

                    b.Property<bool>("RespuestaUnica");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuesta");
                });

            modelBuilder.Entity("Patron_Center.Models.Unidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId");

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<bool>("Eliminado");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Unidad");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CursoId = 1,
                            Descripcion = "Descripción de Unidad de prueba 1",
                            Eliminado = false,
                            Nombre = "1- Unidad de prueba 1"
                        },
                        new
                        {
                            Id = 2,
                            CursoId = 1,
                            Descripcion = "Descripción de Unidad de prueba 2",
                            Eliminado = false,
                            Nombre = "2- Unidad de prueba 2"
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired();

                    b.Property<string>("Documento")
                        .IsRequired();

                    b.Property<bool>("Eliminado");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("TipoUsuario");

                    b.HasKey("Id");

                    b.HasAlternateKey("Documento")
                        .HasName("Documento");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Administrador",
                            Documento = "1",
                            Eliminado = false,
                            Email = "admin@patroncenter.com",
                            Nombre = "Administrador",
                            Password = "admin",
                            TipoUsuario = 2
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Docente",
                            Documento = "2",
                            Eliminado = false,
                            Email = "docente@patroncenter.com",
                            Nombre = "Docecente",
                            Password = "admin",
                            TipoUsuario = 1
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "Alumno",
                            Documento = "3",
                            Eliminado = false,
                            Email = "alumno@patroncenter.com",
                            Nombre = "Alumno",
                            Password = "admin",
                            TipoUsuario = 0
                        },
                        new
                        {
                            Id = 4,
                            Apellido = "Alumno",
                            Documento = "4",
                            Eliminado = true,
                            Email = "alumno@patroncenter.com",
                            Nombre = "Alumno Eliminado",
                            Password = "admin",
                            TipoUsuario = 0
                        },
                        new
                        {
                            Id = 5,
                            Apellido = "Docente",
                            Documento = "5",
                            Eliminado = true,
                            Email = "docente@patroncenter.com",
                            Nombre = "Docecente Eliminado",
                            Password = "admin",
                            TipoUsuario = 1
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.Curso", b =>
                {
                    b.HasOne("Patron_Center.Models.Usuario", "Alumnos")
                        .WithMany()
                        .HasForeignKey("AlumnosId");

                    b.HasOne("Patron_Center.Models.Usuario", "Docente")
                        .WithMany()
                        .HasForeignKey("DocenteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Patron_Center.Models.CursoUsuario", b =>
                {
                    b.HasOne("Patron_Center.Models.Curso", "Curso")
                        .WithMany("CursoUsuario")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Patron_Center.Models.Usuario", "Usuario")
                        .WithMany("CursoUsuario")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Patron_Center.Models.Diapositiva", b =>
                {
                    b.HasOne("Patron_Center.Models.Unidad", "Unidad")
                        .WithMany()
                        .HasForeignKey("UnidadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Patron_Center.Models.Pregunta", b =>
                {
                    b.HasOne("Patron_Center.Models.Quiz")
                        .WithMany("Preguntas")
                        .HasForeignKey("QuizId");
                });

            modelBuilder.Entity("Patron_Center.Models.Respuesta", b =>
                {
                    b.HasOne("Patron_Center.Models.Pregunta")
                        .WithMany("Respuestas")
                        .HasForeignKey("PreguntaId");
                });

            modelBuilder.Entity("Patron_Center.Models.Unidad", b =>
                {
                    b.HasOne("Patron_Center.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
