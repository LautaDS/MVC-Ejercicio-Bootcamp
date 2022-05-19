using Microsoft.AspNetCore.Mvc;
using MVC1.Datos;
using MVC1.Models;
namespace MVC1.Controllers
{
    public class MantenedorController : Controller
    {
        AutomovilDatos _AutomovilDatos = new AutomovilDatos();
        public IActionResult ListarAutos()
        {
            // Mostrar lista de autos
            var aLista = _AutomovilDatos.ListarAutos();
            return View(aLista);
        }

        public IActionResult ObtenerAutoPorID()
        {
            // Obtener auto especifico por id
            return View();
        }

        public IActionResult GuardarAuto()
        {
            // Guardar auto

            return View();
        }
       
        [HttpPost]
        public IActionResult GuardarAuto(Automovil auto)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
            // Guardar auto
            var respuesta = _AutomovilDatos.GuardarAuto(auto);
            if (respuesta)
            {
                return RedirectToAction("ListarAutos");
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult EliminarAuto()
        {
            return View();
        }
    }
}
