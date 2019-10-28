using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class CorreccionDesarrolloViewModel
    {
        public string NombreQuiz { get; set; }
        public string NombreAlumno { get; set; }
        public List<CorreccionDesarrollo> Correcciones { get; set; }

        public CorreccionDesarrolloViewModel()
        {
            this.Correcciones = new List<CorreccionDesarrollo>();
        }
    }

    public class CorreccionDesarrollo
    {
        public int Id { get; set; }
        public string EnunciadoPregunta { get; set; }
        public string RespuestaAlumno { get; set; }
        [Required(ErrorMessage = "No todas las respuestas fueron corregidas")]
        public int PuntajeAsignado { get; set; }
    }
}
