using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            user = await Usuario.Where(u => u.Documento == document).FirstAsync();
            return user;
        }

        //Validar Usuario
        public async Task<UsuarioValidoDTO> ValidarUsuario(LoginViewModel usuario)
        {
            Usuario user = null;
            UsuarioValidoDTO usuaruoDTO = null;
            user = await FindUserByDocumentAsync(usuario.User);

            if (user != null)
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
        }
        
    }
}
