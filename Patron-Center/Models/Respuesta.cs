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
    public class Respuesta
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }
        [DisplayName("Pregunta")]
        [HiddenInput(DisplayValue = false)]
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }
        [DisplayName("¿Respuesta Correcta?")]
        public bool RespuestaCorrecta { get; set; }
        //Esta property va a ser true si es la respuesta que el alumno eligio (solo para MultipleOpcion)
        [HiddenInput(DisplayValue = false)]
		[BindProperty, Required]
		public bool Seleccionada { get; set; }
        [DisplayName("Inactivo")]
        public bool Eliminado { get; set; }
        [Required(ErrorMessage = "El enunciado es un campo requerido")]
        public string Enunciado { get; set; }
    }
}
