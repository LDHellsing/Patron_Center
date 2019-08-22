using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Curso
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Nombre es un campo requerido")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Descripción es un campo requerido")]
        public string Descripcion { get; set; }

        [DisplayName("Fecha de Finalización")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Fecha de Finalización es un campo requerido")]
        public DateTime FechaFinalizacion { get; set; }

        [DisplayName("Inactivo")]
        public Boolean Eliminado { get; set; }

        [DisplayName("Docente")]
        public int DocenteId { get; set; }

        [DisplayName("Docente")]
        public virtual Usuario Docente { get; set; }

        [DisplayName("Alumnos")]
        public List<CursoUsuario> CursoUsuario { get; set; }

        [DisplayName("Alumnos")]
        public virtual Usuario Alumnos { get; set; }
    }
}
