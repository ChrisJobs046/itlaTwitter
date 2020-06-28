using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Publicaciones
    {
        public Publicaciones()
        {
            Comentario = new HashSet<Comentario>();
        }

        public int IdPublicaciones { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
    }
}
