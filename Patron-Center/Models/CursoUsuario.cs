using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class CursoUsuario
    {
        [DisplayName("Alumno")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [DisplayName("Curso")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
