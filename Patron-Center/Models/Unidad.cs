using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Unidad
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [DisplayName("Curso")]
        [Required(ErrorMessage = "Curso es un campo requerido")]
        public int CursoId { get; set; }

        public Curso Curso { get; set; }

        [Required(ErrorMessage = "Nombre es un campo requerido")]
        [DisplayName("Nombre")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Descripción es un campo requerido")]
        [DisplayName("Descripción")]
        public String Descripcion { get; set; }

        [DisplayName("Inactivo")]
        public bool Eliminado { get; set; }


    }
}
