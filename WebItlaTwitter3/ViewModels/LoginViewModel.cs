using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebItlaTwitter3.ViewModels
{
    public class LoginViewModel
    {
        public int IdUsuario { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string NUsuario { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
