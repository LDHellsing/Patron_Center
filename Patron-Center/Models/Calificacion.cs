using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public int CursoId { get; set; }
        public string Fecha { get; set; }
        //Calificacion final de la evaluacion
        public int Nota { get; set; }
    }
}
