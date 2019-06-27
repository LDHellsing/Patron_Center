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
    }
}
