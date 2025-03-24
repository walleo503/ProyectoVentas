using Microsoft.AspNetCore.Mvc;

namespace ProyectoVentas.Controllers
{
    public class OrdenController : Controller
    {
        public IActionResult Index()
        {
            return View("Orden");
        }
    }
}
