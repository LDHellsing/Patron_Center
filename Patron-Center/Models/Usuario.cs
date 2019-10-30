using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Patron_Center.Models
{
    public class Usuario
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [DisplayName("Documento")]
        [Required(ErrorMessage = "Documento es un campo requerido")]
        public String Documento { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Nombre es un campo requerido")]
        public String Nombre { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "Apellido es un campo requerido")]
        public String Apellido { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email es un campo requerido")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email con formato valido")]
        public String Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Contraseña es un campo requerido")]
        public String Password { get; set; }

        [DisplayName("Tipo de Usuario")]
        public TipoUsuario TipoUsuario { get; set; }

        [DisplayName("Inactivo")]
        public Boolean Eliminado { get; set; }

        public List<CursoUsuario> CursoUsuario { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1} ({2})", Nombre, Apellido, Documento);
            }
        }
    }
}
