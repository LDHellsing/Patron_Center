using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Teorico
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es un campo requerido")]
        [DisplayName("Nombre")]
        public String Nombre { get; set; }

        [DisplayName("Eliminado")]
        public bool Eliminado { get; set; }
    }
}
