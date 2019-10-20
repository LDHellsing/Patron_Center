using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        [DisplayName("Alumno")]
        public int UsuarioId { get; set; }
        [DisplayName("Unidad")]
        public int UnidadId { get; set; }
        [DisplayName("Curso")]
        public int CursoId { get; set; }
        [DisplayName("Fecha de evalución")]
        public string Fecha { get; set; }
        //Calificacion final de la evaluacion
        [DisplayName("Nota")]
        public int Nota { get; set; }
        public Curso Curso { get; set; }
        public Unidad Unidad { get; set; }
        public Usuario Usuario { get; set; }

    }
}
