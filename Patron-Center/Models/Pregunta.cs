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
    public class Pregunta
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }
        [DisplayName("Ejercicio")]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        [Range(1, 100, ErrorMessage = "El puntaje debe ser entre 1 y 100")]
        [Required(ErrorMessage = "El campo Puntaje de pregunta es requerido")]
        public int Puntaje { get; set; }
        [DisplayName("Inactivo")]
        public bool Eliminado { get; set; }
		[BindProperty]
		public List<Respuesta> Respuestas { get; set; }
        //testear si el orden se reinicia a 0 cuando se crea un nuevo quiz
        [Required(ErrorMessage = "El campo Orden es requerido")]
        [Range(1, 1000, ErrorMessage = "El Orden debe ser entre 1 y 1000")]
        public int Orden { get; set; }
        [Required(ErrorMessage = "El Enunciado es un campo requerido")]
        public string Enunciado { get; set; }
    }
}
