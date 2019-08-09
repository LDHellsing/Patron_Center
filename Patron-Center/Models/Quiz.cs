using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Quiz
    {
        [HiddenInput(DisplayValue = false)]
        [Editable(false)]
        [Key]
        public int Id { get; set; }
        [Editable(false)]
        public int IdCurso { get; set; }
        public int Puntaje { get; set; }
        [DisplayName("¿Evaluación?")]
        public bool EsEvaluacion { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool EsEliminado { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        public string Nombre { get; set; }

    }
}
