using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class CursoUsuario
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [DisplayName("Alumno")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [DisplayName("Curso")]
        public int CursoId { get; set; }

        public Curso Curso { get; set; }
    }
}
