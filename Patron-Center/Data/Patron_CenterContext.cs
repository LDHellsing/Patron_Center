using System;
using System.Collections.Generic;
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
