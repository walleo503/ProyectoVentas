using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoVentas.Models;
using System.Linq;

namespace ProyectoVentas.Controllers
{
    public class LoginController : Controller
    {


    private readonly restauranteDbContext _context;

    public LoginController(restauranteDbContext restauranteDBContext)
    {
        _context = restauranteDBContext;
    }

    public IActionResult Index()
    {
        return View("Login");
    }

    [HttpPost]
    public IActionResult ValidarLogin(int loginid, string contraseña)
    {
        var usuario = _context.Login_Clientes.FirstOrDefault(l => l.loginid == loginid);

        if (usuario == null)
        {
            ViewBag.Mensaje = "Usuario no registrado.";
            return View("Login");
        }

        if (usuario.contrasena != contraseña)
        {
            ViewBag.Mensaje = "Contraseña incorrecta.";
            return View("Login");
        }

        // Login exitoso
        ViewBag.Mensaje = "Bienvenido";

        return RedirectToAction("Index", "Home"); 
    }
   }
}
