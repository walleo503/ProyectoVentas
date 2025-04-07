using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoVentas.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ProyectoVentas.Controllers
{
    public class LoginController : Controller
    {
        private readonly restauranteDbContext _context;

        public LoginController(restauranteDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> ValidarLogin(string correo, string contraseña)
        {
            // Validación básica
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                ViewBag.Mensaje = "Por favor ingrese correo y contraseña";
                return View("Login");
            }

            // Verificar si el usuario existe
            var usuarioValido = await _context.Login_Cliente
                .AnyAsync(l => l.correo == correo && l.contraseña == contraseña);

            if (!usuarioValido)
            {
                ViewBag.Mensaje = "Credenciales incorrectas";
                return View("Login");
            }

            // Redirigir al Home si las credenciales son correctas
            return RedirectToAction("Index", "Home");
        }
    }
}