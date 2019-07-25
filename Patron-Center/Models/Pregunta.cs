using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Pregunta
    {
        public int Id { get; set; }
        public int IdQuiz { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }
        [Required]        
        public bool EsMultipleOpcion { get; set; }
        [Required]
        public int Orden { get; set; }
        [Required]
        public string Enunciado { get; set; }
    }
}
