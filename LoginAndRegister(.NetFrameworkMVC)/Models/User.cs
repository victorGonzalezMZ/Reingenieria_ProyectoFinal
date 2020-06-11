//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginAndRegister_.NetFrameworkMVC_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int Id { get; set; }

        [DisplayName("Usuario")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Username { get; set; }

        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Password { get; set; }
        
        public string LoginErrorMessage { get; set; }
    }
}
