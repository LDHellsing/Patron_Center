using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class RespuestaAlumno
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int DocenteId { get; set; }
        public int PreguntaId { get; set; }
        public int CursoId { get; set; }
        public int UnidadId { get; set; }
        public string RespuestaDesarrollo { get; set; }
        [DisplayName("Puntaje")]
        public int? PuntajeObtenido { get; set; }
    }
}
