using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class RespuestaAlumnoDesarrollo
    {
        public int IdQuiz { get; set; }
        public string QuizName { get; set; }
        public List<PreguntaViewModelDesarrollo> Preguntas { get; set; }
        public int IdUnidad { get; set; }
        public RespuestaAlumnoDesarrollo()
        {
            this.Preguntas = new List<PreguntaViewModelDesarrollo>();
        }
    }

    public class PreguntaViewModelDesarrollo
    {
        public int IdPregunta { get; set; }
        public string Enunciado { get; set; }
        [MaxLength(5000)]
        public string Respuesta { get; set; }
    }
}
