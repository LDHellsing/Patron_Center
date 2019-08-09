using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Correccion
    {
        [HiddenInput(DisplayValue = false)]
        [Editable(false)]
        public int Id { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Editable(false)]
        public int IdQuiz { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Editable(false)]
        public int IdAlumno { get; set; }
        [Required(ErrorMessage = "El resultado es un campo requerido")]
        public string Resultado { get; set; }
    }
}
