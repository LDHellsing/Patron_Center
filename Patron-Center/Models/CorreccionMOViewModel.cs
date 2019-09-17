using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class CorreccionMOViewModel
    {
        public string EnunciadoPregunta { get; set; }
        public int OrdenPregunta { get; set; }
        public int IdRespuesta { get; set; }
        public bool RespuestaCorrecta { get; set; }
        public CorreccionMOViewModel()
        {

        }
    }
}
