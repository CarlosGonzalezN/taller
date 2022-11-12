using Microsoft.AspNetCore.Mvc.Rendering;

namespace Taller.Model.ViewModels
{
    public class AutoVM
    {
        public Auto oAuto { get; set; }
        public List<SelectListItem> oListaTecnico { get; set; }
        public List<SelectListItem> oListaEstado{ get; set; }
    }
}
