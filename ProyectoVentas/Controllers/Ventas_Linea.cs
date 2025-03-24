using Microsoft.AspNetCore.Mvc;
using ProyectoVentas.Models;

namespace ProyectoVentas.Controllers
{
    public class Ventas_Linea : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CambiarContra()
        {
            return View();
             
        }
        
    }
}
