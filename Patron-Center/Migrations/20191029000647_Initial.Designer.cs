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
    [Migration("20191029000647_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Fecha");

                    b.Property<int>("IdAlumno");

                    b.Property<int>("IdCurso");

                    b.Property<int>("IdUnidad");

                    b.Property<int>("Nota");

                    b.HasKey("Id");

                    b.ToTable("Calificacion");
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
                            FechaFinalizacion = new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
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
                            Texto = "Introducción a Patrones de Diseño",
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
- Tipos de patrones
- Clasificación de patrones
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
1) Debe comprobarse como efectivo en la resolución de un problema.
2) Debe ser reutilizable.

Existen diferencias entre patrones de diseño y arquitectónicos las cuales son:
1) Los patrones arquitectónicos son mas abstractos.
2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad (rendimiento, disponibilidad, etc).",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 5,
                            Eliminado = false,
                            Orden = 5,
                            Texto = @"OBJETIVOS:

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

No es obligación utilizarlos pero simplifican el trabajo de diseño.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 6,
                            Eliminado = false,
                            Orden = 6,
                            Texto = @"TIPOS DE PATRONES:

1) Arquitectónicos:
Básicos, representan esquemas estructurales para la construcción de los sistemas (en muchos casos apoyan el cumplimiento de requerimientos no funcionales).

2) Diseño:
Apoyan en la definición de estructuras de diseño y sus relaciones (implementación).

3) Dialectos:
Patrones específicos de un lenguaje.

4) Interacción:
Patrones para diseñar interfaces web de usuario.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 7,
                            Eliminado = false,
                            Orden = 7,
                            Texto = @"CLASIFICACION DE PATRONES:

1) De Creación:
Participan en el momento de crear objetos, en general abstrayendo la forma en que se crean, y haciendo abstracta la referencia a que clase es que que se instancia. Ej: Singleton, Factory.

2) Estructurales:
Tienen que ver con la forma en que las clases y los objetos son agrupados para formar grandes estructuras.Ej: Facade, Composite.

3) De Comportamiento:
Se utilizan para modelar diferentes formas de interactuar entre los objetos para mejorar la performance del sistema.Ej: Observer, Strategy.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 8,
                            Eliminado = false,
                            Orden = 8,
                            Texto = @"ESTRUCTURA DE PATRONES:

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
11) Patrones relacionados.",
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 9,
                            Eliminado = false,
                            Orden = 1,
                            Texto = "Patrón Singleton",
                            UnidadId = 2,
                            UrlVideo = "gocJeOHtj9w"
                        },
                        new
                        {
                            Id = 10,
                            Eliminado = false,
                            Orden = 2,
                            Texto = @"Problema:

- Debemos tener una única instancia de la clase y esta debe ser accesible desde todo el sistema.

- Se debe poder extender dicha clase por medio de herencia.",
                            UnidadId = 2
                        },
                        new
                        {
                            Id = 11,
                            Eliminado = false,
                            Orden = 3,
                            Texto = @"Solución:

1- El constructor de la clase debe ser privado.

2- Se declara un atributo privado y estático del mismo tipo de la clase.

3- Se declara un método público y estático que permite acceso a la instancia privada de la clase.",
                            UnidadId = 2
                        },
                        new
                        {
                            Id = 12,
                            Eliminado = false,
                            Orden = 4,
                            Texto = @"Consecuencias:

- Se garantiza acceso a una única instancia de la clase (objeto).

- La instancia es visible en todo el sistema (global).

- Se mantiene el polimorfismo en la clase, es decir, no todos lo métodos son estáticos y por lo tanto pueden ser sobrescritos en clases derivadas.",
                            UnidadId = 2
                        },
                        new
                        {
                            Id = 13,
                            Eliminado = false,
                            Orden = 5,
                            Texto = @"Ejemplo:

En un parque de diversiones se desea contar los números de las entradas. Para esto se debe realizar un generador que adicionalmente brinda funcionalidades como:
- Generar un número nuevo mayor a los anteriores

- Dada una hora devolver la cantidad de números generados en la hora parámetro.",
                            UnidadId = 2
                        },
                        new
                        {
                            Id = 14,
                            Eliminado = false,
                            Orden = 1,
                            Texto = "Patrón Facade",
                            UnidadId = 3
                        },
                        new
                        {
                            Id = 15,
                            Eliminado = false,
                            Orden = 1,
                            Texto = @"
Problema:

- Se necesita una interfaz de métodos unificados que provean un punto de acceso a un subsistema.

- Se desea bajar el acoplamiento entre clases de un subsistema y las clases externas que la utilizan.

- Mejorar la separación de capas entre subsistemas.",
                            UnidadId = 3
                        },
                        new
                        {
                            Id = 16,
                            Eliminado = false,
                            Orden = 1,
                            Texto = @"Solución:

Crear una clase Facade que provea todos los métodos necesarios para ejecutar operaciones del subsistema.",
                            UnidadId = 3
                        },
                        new
                        {
                            Id = 17,
                            Eliminado = false,
                            Orden = 1,
                            Texto = @"Motivación:

- Estructurar un sistema en subsistemas ayuda a reducir la complejidad.

- Una meta común de diseño es reducir el número de dependencias entre subsistemas.

- Una forma de lograr esto es introducir un objeto fachada, una única y simple fachada de servicios generales del subsistemas.",
                            UnidadId = 3
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            Enunciado = "¿Que persiguen los patrones de diseño?",
                            Orden = 1,
                            Puntaje = 25,
                            QuizId = 1
                        },
                        new
                        {
                            Id = 2,
                            Eliminado = false,
                            Enunciado = "¿Cual de los siguientes tipos NO es un tipo de patrón de diseño?",
                            Orden = 2,
                            Puntaje = 25,
                            QuizId = 1
                        },
                        new
                        {
                            Id = 3,
                            Eliminado = false,
                            Enunciado = "Los patrones de Creación participan en el momento de crear objetos...",
                            Orden = 3,
                            Puntaje = 25,
                            QuizId = 1
                        },
                        new
                        {
                            Id = 4,
                            Eliminado = false,
                            Enunciado = "Los patrones de Comportamiento empeoran la performance del sistema...",
                            Orden = 4,
                            Puntaje = 25,
                            QuizId = 1
                        },
                        new
                        {
                            Id = 11,
                            Eliminado = false,
                            Enunciado = "¿en que décadas aparecen los primeros patrones de diseño?",
                            Orden = 1,
                            Puntaje = 20,
                            QuizId = 4
                        },
                        new
                        {
                            Id = 12,
                            Eliminado = false,
                            Enunciado = "¿Que no persigue un patrón de diseño?",
                            Orden = 2,
                            Puntaje = 40,
                            QuizId = 4
                        },
                        new
                        {
                            Id = 13,
                            Eliminado = false,
                            Enunciado = "¿Que debe cumplir un patron de diseño?",
                            Orden = 3,
                            Puntaje = 40,
                            QuizId = 4
                        },
                        new
                        {
                            Id = 5,
                            Eliminado = false,
                            Enunciado = "¿Que soluciona el patron Singleton?",
                            Orden = 4,
                            Puntaje = 50,
                            QuizId = 2
                        },
                        new
                        {
                            Id = 6,
                            Eliminado = false,
                            Enunciado = "¿Que garantiza el patron Singleton?",
                            Orden = 4,
                            Puntaje = 25,
                            QuizId = 2
                        },
                        new
                        {
                            Id = 7,
                            Eliminado = false,
                            Enunciado = "Describa brevemente un ejemplo de utilización del patron Singleton",
                            Orden = 4,
                            Puntaje = 25,
                            QuizId = 2
                        },
                        new
                        {
                            Id = 8,
                            Eliminado = false,
                            Enunciado = "¿Que soluciona el patron Facade?",
                            Orden = 4,
                            Puntaje = 50,
                            QuizId = 3
                        },
                        new
                        {
                            Id = 9,
                            Eliminado = false,
                            Enunciado = "¿Que motiva utilizar el patron Facade?",
                            Orden = 4,
                            Puntaje = 25,
                            QuizId = 3
                        },
                        new
                        {
                            Id = 10,
                            Eliminado = false,
                            Enunciado = "¿Mejora la separación en capas el patron Facade? Explique",
                            Orden = 4,
                            Puntaje = 25,
                            QuizId = 3
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
                            Evaluacion = 0,
                            Nombre = "Introducción a Patrones de diseño",
                            Puntaje = 10,
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 4,
                            Ejercicio = 0,
                            Eliminado = false,
                            Evaluacion = 1,
                            Nombre = "Ejercicio Introducción a Patrones de diseño",
                            Puntaje = 10,
                            UnidadId = 1
                        },
                        new
                        {
                            Id = 2,
                            Ejercicio = 1,
                            Eliminado = false,
                            Evaluacion = 0,
                            Nombre = "Patrón Singleton",
                            Puntaje = 10,
                            UnidadId = 2
                        },
                        new
                        {
                            Id = 3,
                            Ejercicio = 1,
                            Eliminado = false,
                            Evaluacion = 0,
                            Nombre = "Patrón Singleton",
                            Puntaje = 10,
                            UnidadId = 3
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

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuesta");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Eliminado = false,
                            Enunciado = "Estandarizar diseños",
                            PreguntaId = 1,
                            RespuestaCorrecta = true
                        },
                        new
                        {
                            Id = 2,
                            Eliminado = false,
                            Enunciado = "Imponer una solución como la mejor",
                            PreguntaId = 1,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 3,
                            Eliminado = false,
                            Enunciado = "Eliminar la creatividad, uso de otras opciones",
                            PreguntaId = 1,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 4,
                            Eliminado = false,
                            Enunciado = "Reinventar la rueda",
                            PreguntaId = 1,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 5,
                            Eliminado = false,
                            Enunciado = "Definición",
                            PreguntaId = 2,
                            RespuestaCorrecta = true
                        },
                        new
                        {
                            Id = 6,
                            Eliminado = false,
                            Enunciado = "Arquitectónico",
                            PreguntaId = 2,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 7,
                            Eliminado = false,
                            Enunciado = "Dialectos",
                            PreguntaId = 2,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 8,
                            Eliminado = false,
                            Enunciado = "Interacción",
                            PreguntaId = 2,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 9,
                            Eliminado = false,
                            Enunciado = "Verdadero",
                            PreguntaId = 3,
                            RespuestaCorrecta = true
                        },
                        new
                        {
                            Id = 10,
                            Eliminado = false,
                            Enunciado = "Falso",
                            PreguntaId = 3,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 11,
                            Eliminado = false,
                            Enunciado = "Falso",
                            PreguntaId = 4,
                            RespuestaCorrecta = true
                        },
                        new
                        {
                            Id = 12,
                            Eliminado = false,
                            Enunciado = "Verdadero",
                            PreguntaId = 4,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 13,
                            Eliminado = false,
                            Enunciado = "70",
                            PreguntaId = 11,
                            RespuestaCorrecta = true
                        },
                        new
                        {
                            Id = 14,
                            Eliminado = false,
                            Enunciado = "80",
                            PreguntaId = 11,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 15,
                            Eliminado = false,
                            Enunciado = "90",
                            PreguntaId = 11,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 16,
                            Eliminado = false,
                            Enunciado = "Eliminar la creatividad, uso de otras opciones",
                            PreguntaId = 12,
                            RespuestaCorrecta = true
                        },
                        new
                        {
                            Id = 17,
                            Eliminado = false,
                            Enunciado = "Imponer una solución como la mejor",
                            PreguntaId = 12,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 18,
                            Eliminado = false,
                            Enunciado = "Estandarizar diseños",
                            PreguntaId = 12,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 19,
                            Eliminado = false,
                            Enunciado = "Ser reutilizable y comprobarse como efectivo en la resolución de un problema",
                            PreguntaId = 13,
                            RespuestaCorrecta = true
                        },
                        new
                        {
                            Id = 20,
                            Eliminado = false,
                            Enunciado = "No importa si es reutilizable, solo debe ser efectivo en la resolución de un problema",
                            PreguntaId = 13,
                            RespuestaCorrecta = false
                        },
                        new
                        {
                            Id = 21,
                            Eliminado = false,
                            Enunciado = "Debe ser reutilizable, e imponer una solución como la mejor",
                            PreguntaId = 13,
                            RespuestaCorrecta = false
                        });
                });

            modelBuilder.Entity("Patron_Center.Models.RespuestaAlumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId");

                    b.Property<int>("DocenteId");

                    b.Property<int>("PreguntaId");

                    b.Property<int?>("PuntajeObtenido");

                    b.Property<string>("RespuestaDesarrollo");

                    b.Property<int>("UnidadId");

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
                            Nombre = "2- Patrón Singleton"
                        },
                        new
                        {
                            Id = 3,
                            CursoId = 1,
                            Descripcion = "En esta unidad se describe al Patron Facade, sus funciones, sus características y para que se usa.",
                            Eliminado = false,
                            Nombre = "3- Patrón Facade"
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
