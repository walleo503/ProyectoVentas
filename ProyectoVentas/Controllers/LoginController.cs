using Microsoft.AspNetCore.Mvc;

namespace ProyectoVentas.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }
    }
}
