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
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
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
                            FechaFinalizacion = new DateTime(2019, 7, 16, 21, 9, 52, 311, DateTimeKind.Local).AddTicks(5636),
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

                    b.Property<int>("TeoricoId");

                    b.Property<string>("Texto")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TeoricoId");

                    b.ToTable("Diapositiva");
                });

            modelBuilder.Entity("Patron_Center.Models.Teorico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Eliminado");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Teorico");
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
                    b.HasOne("Patron_Center.Models.Teorico", "Teorico")
                        .WithMany()
                        .HasForeignKey("TeoricoId")
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
