using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class CalificacionesViewModel
    {
        public int Id { get; set; }
        [DisplayName("Alumno")]
        public string NombreCompletoAlumno { get; set; }
        [DisplayName("Curso")]
        public string NombreCurso { get; set; }
        [DisplayName("Unidad")]
        public string NombreUnidad { get; set; }
        [DisplayName("Fecha de evaluación")]
        public string Fecha { get; set; }
        [DisplayName("Nota")]
        public int Nota { get; set; }
    }
}
