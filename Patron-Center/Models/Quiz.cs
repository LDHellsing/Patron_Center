﻿using Microsoft.AspNetCore.Mvc;
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
        [Key]
        public int Id { get; set; }
        public int UnidadId { get; set; }
        public Unidad Unidad { get; set; }
        public int Puntaje { get; set; }
        [Required(ErrorMessage = "El tipo de evaluacion es un campo requerido")]
        public TipoQuiz Evaluacion { get; set; }
        [Required(ErrorMessage = "El tipo de ejercicio un campo requerido")]
        public TipoEjercicio Ejercicio { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool Eliminado { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        public string Nombre { get; set; }

    }
}
