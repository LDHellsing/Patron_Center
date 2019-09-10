using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
	public class RespuestaAlumnoMO
	{
		public int IdQuiz { get; set; }
		public string QuizName { get; set; }
		public List<Pregunta> Preguntas { get; set; }
		public int IdRespuesta { get; set; }

    }
}
