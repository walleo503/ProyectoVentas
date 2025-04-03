using Microsoft.AspNetCore.Mvc;

namespace ProyectoVentas.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult EditarDatosPersonales(int idUsuario)
        {
            return View();
        }

        public IActionResult EditarInicioSesion()
        {
            return View();
        }
    }
}
