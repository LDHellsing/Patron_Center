using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Documento { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Boolean Eliminado { get; set; }
    }
}
