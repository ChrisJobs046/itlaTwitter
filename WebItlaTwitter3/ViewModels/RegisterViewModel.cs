using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebItlaTwitter3.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Correo { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string NUsuario { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [Compare("Password", ErrorMessage = "Las contraseñas ingresadas no coinciden")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
