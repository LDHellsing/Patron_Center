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
    [Migration("20190628152557_cursoUsuario2")]
    partial class cursoUsuario2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Descripcion");

                    b.Property<int>("DocenteId");

                    b.Property<bool>("Eliminado");

                    b.Property<DateTime>("FechaFinalizacion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("AlumnosId");

                    b.HasIndex("DocenteId");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Patron_Center.Models.CursoUsuario", b =>
                {
                    b.Property<int>("CursoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("CursoId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CursoUsuario");
                });

            modelBuilder.Entity("Patron_Center.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Documento");

                    b.Property<bool>("Eliminado");

                    b.Property<string>("Email");

                    b.Property<string>("Nombre");

                    b.Property<string>("Password");

                    b.Property<int>("TipoUsuario");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
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
#pragma warning restore 612, 618
        }
    }
}
