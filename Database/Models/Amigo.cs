using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Amigo
    {
        public int IdUsuario { get; set; }
        public int NUsuario1 { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Usuario NUsuario1Navigation { get; set; }
    }
}
