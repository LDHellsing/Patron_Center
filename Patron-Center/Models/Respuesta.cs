﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Respuesta
    {
        [HiddenInput(DisplayValue = false)]
        [Editable(false)]
        [Key]
        public int Id { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int IdPregunta { get; set; }
        public bool EsRespuestaCorrecta { get; set; }
        public bool EsRespuestaUnica { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool EsEliminado { get; set; }
        [Required(ErrorMessage = "El enunciado es un campo requerido")]
        public string Enunciado { get; set; }
    }
}
