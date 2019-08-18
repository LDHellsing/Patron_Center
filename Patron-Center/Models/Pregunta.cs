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
        public int Puntaje { get; set; }
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Eliminado")]
        public bool Eliminado { get; set; }
        [DisplayName("Comentario")]
        public string ComentarioDocente { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }
        [DisplayName("¿Multiple Opción?")]
        public bool MultipleOpcion { get; set; }
        //testear si el orden se reinicia a 0 cuando se crea un nuevo quiz
        [Required(ErrorMessage = "El campo orden de pregunta es requerido")]
        public int Orden { get; set; }
        [Required(ErrorMessage = "El enunciado es un campo requerido")]
        public string Enunciado { get; set; }
    }
}
