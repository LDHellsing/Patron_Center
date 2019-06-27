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
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Fecha de Finalización")]
        public DateTime FechaFinalizacion { get; set; }

        [DisplayName("Eliminado")]
        public Boolean Eliminado { get; set; }

        [DisplayName("Docente")]
        public int DocenteId { get; set; }

        [DisplayName("Docente")]
        public virtual Usuario Docente { get; set; }
    }
}
