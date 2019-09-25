﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Patron_Center.Models;

namespace Patron_Center.Migrations
{
    [DbContext(typeof(Patron_CenterContext))]
    partial class Patron_CenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Patron_Center.Models.Calificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("Nota");

                    b.Property<int>("UnidadId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("Calificacion");
                });

            modelBuilder.Entity("Patron_Center.Models.Correccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calificacion");

                    b.Property<int>("IdProfesor");

                    b.Property<int>("PreguntaId");

                    b.Property<int>("QuizId");

                    b.Property<int?>("RespuestaAlumnoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("RespuestaAlumnoId");

                    b.ToTable("Correccion");
                });

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
                            Descripcion = "Aqui se dicta un curso destinado al manejo y el aprendisaje de patrones de diseño.",
                            DocenteId = 2,
                            Eliminado = false,
                            FechaFinalizacion = new DateTime(2019, 9, 25, 3, 0, 44, 110, DateTimeKind.Local).AddTicks(4382),
                            Nombre = "Patrones de Diseño"
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
                        },
                        new
                        {
                            Id = 2,
                            CursoId = 1,
                            UsuarioId = 6
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
                            Texto = "Introduccion a Patrones de Diseño",
                            UnidadId = 1,
                            UrlVideo = "bx5WqFEndoo"
                        },
                        new
                        {
                            Id = 2,
                            Eliminado = false,
                            Orden = 2,
                            Texto = @"TEMARIO: 

 - Historia
 - Definición de patrones
 - Tipos 
 - Clasificación 
 - Objetivos",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 3,
                            Eliminado = false,
                            Orden = 3,
                            Texto = @"HISTORIA:

Surgen inspirados en los patrones arquitectónicos, que aparecen a fines de los años 70, con el fin de organizar y sistematizar las soluciones que diferentes arquitectos e ingenieros iban encontrando a problemas constructivos similares.
Se formalizan a partir del libro “Design Patterns” de los autores Gamma, Helm, Johnsony Vlisides, llamados “la pandilla de los 4” (Gang Of Four, o simplificado GoF), en 1995.
En el libro se detalla la estructura que recomiendan emplear para la descripción de los patrones(estructura un poco más compleja de la que empleamos en este curso), y se formalizan más de 20 patrones de diseño, identificados por GoF en ese momento y todavía altamente vigentes al día de hoy.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 4,
                            Eliminado = false,
                            Orden = 4,
                            Texto = @"DEFINICION DE PATRONES:

Los Patrones Definen soluciones a problemas comunes del desarrollo de software.
Estos deben cumplir con dos cosas:
 1) Debe comprobarse como efectivo en la resolución de un problema
 2) Debe ser reutilizable. 

Existen diferencias entre patrones de diseño y arquitectónicos las cuales son: 
 (1) Los patrones arquitectónicos son mas abstractos 
 (2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad(Rendimiento, disponibilidad,etc).",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 5,
                            Eliminado = false,
                            Orden = 5,
                            Texto = @"OBJETIVOS:

Que persiguen:
Crear una biblioteca de módulos, elementos reutilizables, No reinventar la rueda, tener soluciones a problemas ya conocidos, Hablar un lenguaje común entre diseñadores y arquitectos, Estandarizar diseños, Facilitar el aprendizaje de técnicas a los nuevos diseñadores. 

Que no buscan: 
Imponer una solución como la mejor, Eliminar la creatividad o el uso de otras opciones. 

No es obligación utilizarlos pero simplifican el trabajo de diseño.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 6,
                            Eliminado = false,
                            Orden = 6,
                            Texto = @"TIPOS DE PATRONES:


 1)Arquitectónicos: Básicos, representan esquemas estructurales para la construcción de los sistemas(en muchos casos apoyan el cumplimiento de requerimientos no funcionales).


 2)Diseño: Apoyan en la definición de estructuras de diseño y sus relaciones(implementación). 


 3)Dialectos: Patrones específicos de un lenguaje. 

4) Interacción: Patrones para diseñar interfaces web de usuario.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 7,
                            Eliminado = false,
                            Orden = 7,
                            Texto = @"CLASIFICACION DE PATRONES:

1) De Creación: participan en el momento de crear objetos, en general abstrayendo la forma en que se crean, y haciendo abstracta la referencia a que clase es que que se instancia. Ej: Singleton, Factory.

2) Estructurales: tienen que ver con la forma en que las clases y los objetos son agrupados para formar grandes estructuras.Ej: Facade, Composite.

3) De Comportamiento: se utilizan para modelar diferentes formas de interactuar entre los objetos para mejorar la performance del sistema.Ej: Observer, Strategy.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 8,
                            Eliminado = false,
                            Orden = 8,
                            Texto = @"ESTRUCTURA DE PATRONES:

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
 11) Patrones relacionados",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 9,
                            Eliminado = false,
                            Orden = 1,
                            Texto = "Patron Singleton",
                            UnidadId = 2,
                            UrlVideo = "gocJeOHtj9w"
                        },
                        new
                        {
                            Id = 10,
                            Eliminado = false,
                            Orden = 2,
                            Texto = @"Problema:

 -> Debemos tener una única instancia de la clase y esta debe ser accesible desde todo el sistema.

 ->Se debe poder extender dicha clase por medio de herencia.",
                            UnidadId = 2
                        },
                        new
                        {
                            Id = 11,
                            Eliminado = false,
                            Orden = 3,
                            Texto = @"Solución:


 -> El constructor de la clase debe ser privado.
 -> Se declara un atributo privado y estático del mismo tipo de la clase.
 -> Se declara un método público y estático que permite acceso a la instancia privada de la clase.",
                            UnidadId = 2
                        },
                        new
                        {
                            Id = 12,
                            Eliminado = false,
                            Orden = 4,
                            Texto = @"Consecuencias:

 -> Se garantiza acceso a una única instancia de la clase(objeto).

 -> La instancia es visible en todo el sistema(global).

 -> Se mantiene el polimorfismo en la clase, es decir, no todos lo métodos son estáticos y por lo tanto pueden ser sobrescritos en clases derivadas.",
                            UnidadId = 2
                        },
                        new
                        {
                            Id = 13,
                            Eliminado = false,
                            Orden = 5,
                            Texto = @"Ejemplo:

En un parque de diversiones se desea contar los números de las entradas. Para esto se debe realizar un generador que adicionalmente brinda funcionalidades como: 
 -> Generar un número nuevo mayor a los anteriores
 -> Dada una hora devolver la cantidad de números generados en la hora parámetro.",
                            UnidadId = 2
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComentarioDocente");

                    b.Property<bool>("Eliminado");

                    b.Property<string>("Enunciado")
                        .IsRequired();

                    b.Property<int>("Orden");

                    b.Property<int>("Puntaje");

                    b.Property<int>("QuizId");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Pregunta");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Eliminado = false,
                            Enunciado = "Esta pregunta no es mas que una prueba",
                            Orden = 1,
                            Puntaje = 5,
                            QuizId = 1
                        },
                        new
                        {
                            Id = 2,
                            Eliminado = false,
                            Enunciado = "Esta pregunta no es mas que otra una prueba",
                            Orden = 2,
                            Puntaje = 10,
                            QuizId = 1
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ejercicio");

                    b.Property<bool>("Eliminado");

                    b.Property<int>("Evaluacion");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<int>("Puntaje");

                    b.Property<int>("UnidadId");

                    b.HasKey("Id");

                    b.HasIndex("UnidadId");

                    b.ToTable("Quiz");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ejercicio = 0,
                            Eliminado = false,
                            Evaluacion = 1,
                            Nombre = "Quiz de Prueba",
                            Puntaje = 5,
                            UnidadId = 1
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.Respuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Eliminado");

                    b.Property<string>("Enunciado")
                        .IsRequired();

                    b.Property<int>("PreguntaId");

                    b.Property<bool>("RespuestaCorrecta");

                    b.Property<bool>("Seleccionada");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuesta");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Eliminado = false,
                            Enunciado = "Esta respuesta no es correcta y no esta seleccionada",
                            PreguntaId = 1,
                            RespuestaCorrecta = false,
                            Seleccionada = false
                        },
                        new
                        {
                            Id = 2,
                            Eliminado = false,
                            Enunciado = "Esta respuesta es correcta y esta seleccionada",
                            PreguntaId = 1,
                            RespuestaCorrecta = true,
                            Seleccionada = true
                        },
                        new
                        {
                            Id = 3,
                            Eliminado = false,
                            Enunciado = "Esta respuesta es correcta y no esta seleccionada",
                            PreguntaId = 2,
                            RespuestaCorrecta = true,
                            Seleccionada = false
                        },
                        new
                        {
                            Id = 4,
                            Eliminado = false,
                            Enunciado = "Esta respuesta no es correcta y esta seleccionada",
                            PreguntaId = 2,
                            RespuestaCorrecta = false,
                            Seleccionada = true
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.RespuestaAlumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PreguntaId");

                    b.Property<string>("RespuestaDesarrollo");

                    b.Property<int>("RespuestaId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("RespuestaAlumno");
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
                            Descripcion = "Unidadad introductoria para Patrones de diseño.",
                            Eliminado = false,
                            Nombre = "1- Introduccion"
                        },
                        new
                        {
                            Id = 2,
                            CursoId = 1,
                            Descripcion = "En esta unidad se describe al Patron Singleton, sus funciones, sus características y para que se usa.",
                            Eliminado = false,
                            Nombre = "2- Patron Singleton"
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
                            Password = "YWRtaW4=",
                            TipoUsuario = 2
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Docente",
                            Documento = "2",
                            Eliminado = false,
                            Email = "docente@patroncenter.com",
                            Nombre = "Docente",
                            Password = "YWRtaW4=",
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
                            Password = "YWRtaW4=",
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
                            Password = "YWRtaW4=",
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
                            Password = "YWRtaW4=",
                            TipoUsuario = 1
                        },
                        new
                        {
                            Id = 6,
                            Apellido = "Gonzalez",
                            Documento = "49077339",
                            Eliminado = false,
                            Email = "agustingonzalezata@gmail.com",
                            Nombre = "Agustin",
                            Password = "YWRtaW4=",
                            TipoUsuario = 0
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.Correccion", b =>
                {
                    b.HasOne("Patron_Center.Models.RespuestaAlumno", "RespuestaAlumno")
                        .WithMany()
                        .HasForeignKey("RespuestaAlumnoId");
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
                    b.HasOne("Patron_Center.Models.Quiz", "Quiz")
                        .WithMany("Preguntas")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Patron_Center.Models.Quiz", b =>
                {
                    b.HasOne("Patron_Center.Models.Unidad", "Unidad")
                        .WithMany()
                        .HasForeignKey("UnidadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Patron_Center.Models.Respuesta", b =>
                {
                    b.HasOne("Patron_Center.Models.Pregunta", "Pregunta")
                        .WithMany("Respuestas")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade);
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
