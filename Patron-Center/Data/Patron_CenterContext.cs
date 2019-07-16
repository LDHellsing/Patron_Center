using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Patron_Center.Models;

namespace Patron_Center.Models
{
    public class Patron_CenterContext : DbContext
    {
        public Patron_CenterContext (DbContextOptions<Patron_CenterContext> options)
            : base(options)
        {
        }

        public DbSet<Patron_Center.Models.Usuario> Usuario { get; set; }
        public DbSet<Patron_Center.Models.Curso> Curso { get; set; }
        public DbSet<CursoUsuario> CursoUsuario { get; set; }

        //FindUserByDocument(string document)
        public async Task<Usuario> FindUserByDocumentAsync(string document)
        {
            Usuario user = null;
            try
            {
                user = await Usuario.Where(u => u.Documento == document).FirstAsync();
                Debug.WriteLine($"Objeto obtenido --------------> {user}");
                return user;
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e);
                return user = null;
            };
        }

        //Validar Usuario
        public async Task<UsuarioValidoDTO> ValidarUsuario(LoginViewModel usuario)
        {
            Usuario user = null;
            UsuarioValidoDTO usuaruoDTO = null;
            user = await FindUserByDocumentAsync(usuario.User);

            if (user != null && user.Password == usuario.Password && user.Eliminado == false)
            {
                //El usuario existe en la BD
                usuaruoDTO = new UsuarioValidoDTO(user.Id, user.Nombre, user.Documento, user.TipoUsuario.ToString(), true);
            }
            else
            {
                //El usuario NO existe en la BD
                usuaruoDTO = new UsuarioValidoDTO(false);
            }
            return usuaruoDTO;
        }

        //Relacion muchos a muchos Curso Usuario

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<CursoUsuario>()
                    .HasKey(cu => new {cu.Id});

            modelBuilder.Entity<CursoUsuario>()
                    .HasOne<Usuario>(sc => sc.Usuario)
                    .WithMany(s => s.CursoUsuario)
                    .HasForeignKey(sc => sc.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<CursoUsuario>()
                    .HasOne<Curso>(sc => sc.Curso)
                    .WithMany(s => s.CursoUsuario)
                    .HasForeignKey(sc => sc.CursoId)
                    .OnDelete(DeleteBehavior.Cascade);

            //Seeding de datos
            //Creación de Usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Documento = "1",
                    Nombre = "Administrador",
                    Apellido = "Administrador",
                    Email = "admin@patroncenter.com",
                    Password = "admin",
                    TipoUsuario = TipoUsuario.Administrador,
                    Eliminado = false                    
                }
                );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 2,
                    Documento = "2",
                    Nombre = "Docecente",
                    Apellido = "Docente",
                    Email = "docente@patroncenter.com",
                    Password = "admin",
                    TipoUsuario = TipoUsuario.Docente,
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 3,
                    Documento = "3",
                    Nombre = "Alumno",
                    Apellido = "Alumno",
                    Email = "alumno@patroncenter.com",
                    Password = "admin",
                    TipoUsuario = TipoUsuario.Alumno,
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Usuario>().HasData(
              new Usuario
              {
                  Id = 4,
                  Documento = "4",
                  Nombre = "Alumno Eliminado",
                  Apellido = "Alumno",
                  Email = "alumno@patroncenter.com",
                  Password = "admin",
                  TipoUsuario = TipoUsuario.Alumno,
                  Eliminado = true
              }
              );
            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                   Id = 5,
                   Documento = "5",
                   Nombre = "Docecente Eliminado",
                   Apellido = "Docente",
                   Email = "docente@patroncenter.com",
                   Password = "admin",
                   TipoUsuario = TipoUsuario.Docente,
                   Eliminado = true
               }
               );
            //Creación de Cursos
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    Id = 1,
                    Nombre = "Curso de Prueba",
                    Descripcion = "Descripción de curso de prueba",
                    FechaFinalizacion = DateTime.Now,
                    Eliminado = false,
                    DocenteId = 2
                }
                );
            //Creación de Unidades
            modelBuilder.Entity<Unidad>().HasData(
                new Unidad
                {
                    Id = 1,
                    CursoId = 1,
                    Nombre = "1- Unidad de prueba 1",
                    Descripcion = "Descripción de Unidad de prueba 1",
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Unidad>().HasData(
                new Unidad
                {
                    Id = 2,
                    CursoId = 1,
                    Nombre = "2- Unidad de prueba 2",
                    Descripcion = "Descripción de Unidad de prueba 2",
                    Eliminado = false
                }
                );
            //Creación de relacion Alumno Curso
            modelBuilder.Entity<CursoUsuario>().HasData(
                new CursoUsuario
                {
                    Id = 1,
                    CursoId = 1,
                    UsuarioId = 3
                }
                );
        }        

        public DbSet<Patron_Center.Models.Unidad> Unidad { get; set; }
        
    }
}
