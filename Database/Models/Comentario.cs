using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Comentario
    {
        public int IdComentario { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPublicaciones { get; set; }
        public string NComentario1 { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Publicaciones IdPublicacionesNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
