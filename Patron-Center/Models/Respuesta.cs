﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Respuesta
    {
        [Key]
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public bool RespuestaCorrecta { get; set; }
        public bool RespuestaUnica { get; set; }
        [Required]
        public string Enunciado { get; set; }
    }
}
