using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class RespuestaAlumno
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PreguntaId { get; set; }
        public int RespuestaId { get; set; }
        public string RespuestaDesarrollo { get; set; }
    }
}
