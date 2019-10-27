﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Diapositiva
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Texto es un campo requerido")]
        [DisplayName("Texto")]
        [DataType(DataType.MultilineText)]
        public String Texto { get; set; }

        [DisplayName("ID de Video de Youtube")]
        [DataType(DataType.Text)]
        public String UrlVideo { get; set; }

        [Required(ErrorMessage = "Orden es un campo requerido")]
        [Range(1, 1000, ErrorMessage = "El Orden debe ser entre 1 y 1000")]
        [DisplayName("Orden")]
        public int Orden { get; set; }

        [DisplayName("Inactivo")]
        public bool Eliminado { get; set; }

        [DisplayName("Unidad")]
        [Required(ErrorMessage = "Unidad es un campo requerido")]
        public int UnidadId { get; set; }

        public Unidad Unidad { get; set; }
    }
}
