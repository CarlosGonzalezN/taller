using System;
using System.Collections.Generic;

namespace Taller.Model
{
    public partial class Estado
    {
        public Estado()
        {
            Autos = new HashSet<Auto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Auto> Autos { get; set; }
    }
}
