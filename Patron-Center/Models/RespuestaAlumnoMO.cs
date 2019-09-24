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
		public List<PreguntaViewModel> Preguntas { get; set; }
        public int IdUnidad { get; set; }
		public RespuestaAlumnoMO()
		{
			this.Preguntas = new List<PreguntaViewModel>();
		}
	}
	public class PreguntaViewModel
	{
		public int IdPregunta { get; set; }
		public string Enunciado { get; set; }
		public string Seleccionada { get; set; }
		public List<RespuestaViewModel> Respuestas { get; set; }
		public PreguntaViewModel()
		{
			this.Respuestas = new List<RespuestaViewModel>();
		}
	}

	public class RespuestaViewModel
	{
		public int IdRespuesta { get; set; }
		public string Enunciado { get; set; }

	}
}

