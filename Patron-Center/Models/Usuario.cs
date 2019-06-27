using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Usuario
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [DisplayName("Documento")]
        public String Documento { get; set; }

        [DisplayName("Nombre")]
        public String Nombre { get; set; }

        [DisplayName("Apellido")]
        public String Apellido { get; set; }

        [DisplayName("Email")]
        public String Email { get; set; }

        [DisplayName("Password")]
        public String Password { get; set; }

        [DisplayName("Tipo de Usuario")]
        public TipoUsuario TipoUsuario { get; set; }

        [DisplayName("Eliminado")]
        public Boolean Eliminado { get; set; }

    }
}
