using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Quiz
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }
        [DisplayName("Unidad")]
        public int UnidadId { get; set; }
        public Unidad Unidad { get; set; }
        [DisplayName("Nota")]
        public int Puntaje { get; set; }
        [Required(ErrorMessage = "El tipo de evaluacion es un campo requerido")]
        [DisplayName("Tipo de Evaluación")]
        public TipoQuiz Evaluacion { get; set; }
        [Required(ErrorMessage = "El tipo de práctico un campo requerido")]
        [DisplayName("Tipo de Ejercicio")]
        public TipoEjercicio Ejercicio { get; set; }
        [DisplayName("Inactivo")]
        public bool Eliminado { get; set; }
		[BindProperty]
		public List<Pregunta> Preguntas { get; set; }
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        public string Nombre { get; set; }
        [NotMapped]
        public Boolean EvalucionCursada { get; set; }

        // Crear el CRUD de nuevo para que tome esta nueva property
        // [Required(ErrorMessage = "El minimo de aprobacion es un campo requerido")]
        // public int MinimoAprobacion { get; set; }

    }
}
