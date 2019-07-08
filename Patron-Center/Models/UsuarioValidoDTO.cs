using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patron_Center.Models
{
    public class UsuarioValidoDTO
    {
        public UsuarioValidoDTO(int idUsuario, string nombreUsuario, string documento, string rol, bool usuarioValido)
        {
            this.IdUsuario = idUsuario;
            this.NombreUsuario = nombreUsuario;
            this.Documento = documento;
            this.Rol = rol;
            this.UsuarioValido = usuarioValido;
        }
        //Este constructor solo se va a utilizar para los usuarios que no existen
        public UsuarioValidoDTO(bool usuarioValido)
        {
            this.NombreUsuario = "";
            this.Documento = "";
            this.Rol = "";
            this.UsuarioValido = usuarioValido;
        }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Documento { get; set; }
        public string Rol { get; set; }
        public bool UsuarioValido { get; set; }
    }
}
