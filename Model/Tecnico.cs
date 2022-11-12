using System;
using System.Collections.Generic;

namespace Taller.Model
{
    public partial class Tecnico
    {
        public Tecnico()
        {
            Autos = new HashSet<Auto>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Rol { get; set; }

        public virtual ICollection<Auto> Autos { get; set; }
    }
}
