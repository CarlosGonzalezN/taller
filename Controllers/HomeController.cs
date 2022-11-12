using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Taller.Model;
using Taller.Model.ViewModels;

namespace Taller.Controllers
{
    public class HomeController : Controller

    {
        private readonly tallerMecanicoContext _DBContext;

        public HomeController(tallerMecanicoContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Auto> lista = _DBContext.Autos.Include(t => t.oTecnico).Include(e=>e.oEstado).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Auto_Detalle(int Id)
        {
            AutoVM oAutoVM = new AutoVM()
            {
                oAuto = new Auto(),

                oListaTecnico = _DBContext.Tecnicos.Select(tecnico => new SelectListItem()
                {
                    Text = tecnico.Apellido,
                    Value = tecnico.Id.ToString()
                }).ToList(),
                oListaEstado = _DBContext.Estados.Select(estado => new SelectListItem()
                {
                    Text = estado.Descripcion,
                    Value = estado.Id.ToString()
                }).ToList()

            };
            if (Id !=0) {
                oAutoVM.oAuto = _DBContext.Autos.Find(Id);
            }
            return View(oAutoVM);

        }
       
        [HttpPost]
        public IActionResult Auto_Detalle(AutoVM oAutoVM)
        {
            if (oAutoVM.oAuto.Id == 0)
            {
                _DBContext.Autos.Add(oAutoVM.oAuto);
            }
            else
            {
                _DBContext.Autos.Update(oAutoVM.oAuto);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");


        }
        [HttpGet]
        public IActionResult Eliminar(int Id)
        {
            Auto oAuto = _DBContext.Autos.Include(t => t.oTecnico).Include(e => e.oEstado).Where(a => a.Id == Id).FirstOrDefault();

            return View(oAuto);
        }

        [HttpPost]
        public IActionResult Eliminar(Auto oAuto)
        {
            
            _DBContext.Autos.Remove(oAuto);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}