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
        public int IdAlumno { get; set; }
        [DisplayName("Unidad")]
        public int IdUnidad { get; set; }
        [DisplayName("Curso")]
        public int IdCurso { get; set; }
        [DisplayName("Fecha de evalución")]
        public string Fecha { get; set; }
        //Calificacion final de la evaluacion
        [DisplayName("Nota")]
        public int Nota { get; set; }

    }
}
