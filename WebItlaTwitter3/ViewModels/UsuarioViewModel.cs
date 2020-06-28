using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebItlaTwitter3.ViewModels
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Display(Name = "Usuario")]
        public string NUsuario { get; set; }

        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
