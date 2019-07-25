using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }
        [Required]
        public string Nombre { get; set; }

    }
}
