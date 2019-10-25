using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class LoginViewModel
    {
        [DisplayName("Documento")]
        [Required(ErrorMessage = "Documento es un campo requerido")]
        public string User { get; set; }
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Contraseña es un campo requerido")]
        public string Password { get; set; }
    }
}
