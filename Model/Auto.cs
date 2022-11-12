using System;
using System.Collections.Generic;

namespace Taller.Model
{
    public partial class Auto
    {
        public int Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Patente { get; set; }
        public int? Año { get; set; }
        public string? Color { get; set; }
        public string? NChasis { get; set; }
        public string? TitularNombre { get; set; }
        public string? TitularApellido { get; set; }
        public string? Celular { get; set; }
        public int? Km { get; set; }
        public string? Problema { get; set; }
        public string? Solucion { get; set; }
        public int? IdTecnico { get; set; }
        public int? IdEstado { get; set; }

        public virtual Estado? oEstado { get; set; }
        public virtual Tecnico? oTecnico { get; set; }
    }
}
