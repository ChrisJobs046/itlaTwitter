using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            AmigoIdUsuarioNavigation = new HashSet<Amigo>();
            AmigoNUsuario1Navigation = new HashSet<Amigo>();
            Comentario = new HashSet<Comentario>();
            Publicaciones = new HashSet<Publicaciones>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string NUsuario { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Amigo> AmigoIdUsuarioNavigation { get; set; }
        public virtual ICollection<Amigo> AmigoNUsuario1Navigation { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Publicaciones> Publicaciones { get; set; }
    }
}
