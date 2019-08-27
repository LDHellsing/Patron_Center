using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Correccion
    {
        public int Id { get; set; }
        // Alumno
        public int UsuarioId { get; set; }
        public int QuizId { get; set; }
        public int PreguntaId { get; set; }
        public int IdProfesor { get; set; }
        public RespuestaAlumno RespuestaAlumno { get; set; }
        [Required(ErrorMessage = "Calificacion es un campo requerido")]
        public int Calificacion { get; set; }
    }
}
