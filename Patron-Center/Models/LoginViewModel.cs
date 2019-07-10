using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Usuario es un campo requerido")]
        public string User { get; set; }
        [Required(ErrorMessage = "Password es un campo requerido")]
        public string Password { get; set; }
    }
}
