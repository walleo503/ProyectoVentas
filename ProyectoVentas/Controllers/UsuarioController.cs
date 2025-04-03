using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoVentas.Models;
using ProyectoVentas.Models.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoVentas.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly restauranteDbContext _context;

        public UsuarioController(restauranteDbContext context)
        {
            _context = context;
        }

        public IActionResult Perfil()
        {
            var cliente = _context.clientes.FirstOrDefault(c => c.clienteid == 1);
            if (cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            var login_cliente = _context.login_cliente.FirstOrDefault(lc => lc.loginid == cliente.loginid);

            if (login_cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            UsuarioDto clienteDto = new UsuarioDto
            {
                cliente = cliente,
                Login = login_cliente
            };

            return View(clienteDto);
        }

        public IActionResult EditarDatosPersonales(int clienteid)
        {
            var cliente = _context.clientes.FirstOrDefault(c => c.clienteid == clienteid);
            if (cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult EditarDatosPersonales(int clienteid, string nombre, string telefono, string direccion)
        {
            var cliente = _context.clientes.FirstOrDefault(c => c.clienteid == clienteid);
            if (cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            if(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(direccion))
            {
                ViewBag.Error = "Todod los campos son obligatorios.";
                return View(cliente);
            }

            cliente.nombre = nombre;
            cliente.telefono = telefono;
            cliente.direccion = direccion;

            _context.clientes.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Perfil");
        }

        public IActionResult EditarInicioSesion(int clienteid)
        {
            var cliente = _context.clientes.FirstOrDefault(c => c.clienteid == clienteid);
            if (cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            var login_cliente = _context.login_cliente.FirstOrDefault(lc => lc.loginid == cliente.loginid);
            if (login_cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            return View(login_cliente);
        }

        [HttpPost]
        public IActionResult EditarInicioSesion(int loginid, string correo, string contrasena)
        {
            var login_cliente = _context.login_cliente.FirstOrDefault(lc => lc.loginid == loginid);
            if (login_cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                ViewBag.Error = "Todod los campos son obligatorios.";
                return View(login_cliente);
            }

            login_cliente.correo = correo;
            login_cliente.contrasena = contrasena;

            _context.login_cliente.Entry(login_cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Perfil");
        }
    }
}
