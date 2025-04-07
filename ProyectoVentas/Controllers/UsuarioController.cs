using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoVentas.Models;
using ProyectoVentas.Models.Dtos;

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
            var cliente = _context.Cliente.FirstOrDefault(c => c.clienteId == 1);

            if (cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            var login_cliente = _context.Login_Clientes.FirstOrDefault(lc => lc.loginid == cliente.loginid);

            if (login_cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            ClienteViewModel clienteDto = new ClienteViewModel
            {
                Cliente = cliente,
                Login_Cliente = login_cliente
            };

            return View(clienteDto);
        }

        public IActionResult EditarDatosPersonales(int clienteId)
        {
            var cliente = _context.Cliente.FirstOrDefault(c => c.clienteId == clienteId);
            if (cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult EditarDatosPersonales(int clienteId, string nombre, string telefono, string direccion)
        {
            var cliente = _context.Cliente.FirstOrDefault(c => c.clienteId == clienteId);
            if (cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(direccion))
            {
                ViewBag.Error = "Todod los campos son obligatorios.";
                return View(cliente);
            }

            cliente.nombre = nombre;
            cliente.telefono = telefono;
            cliente.direccion = direccion;

            _context.Cliente.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Perfil");
        }

        public IActionResult EditarInicioSesion(int loginId)
        {
            var login_cliente = _context.Login_Clientes.FirstOrDefault(lc => lc.loginid == loginId);
            if (login_cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            EditarInicioSesionViewModel editarInicioSesionDto = new EditarInicioSesionViewModel
            {
                loginId = login_cliente.loginid,
                correo = login_cliente.correo
            };

            return View(editarInicioSesionDto);
        }

        [HttpPost]
        public IActionResult EditarInicioSesion(EditarInicioSesionViewModel model)
        {
            var login_cliente = _context.Login_Clientes.FirstOrDefault(lc => lc.loginid == model.loginId);
            if (login_cliente == null)
            {
                RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrEmpty(model.correo) || string.IsNullOrEmpty(model.contrasenaActual) || string.IsNullOrEmpty(model.contrasenaNueva) || string.IsNullOrEmpty(model.contrasenaNuevaConfirmacion))
            {
                ViewBag.Error = "Todod los campos son obligatorios.";
                return View(model);
            }

            if(!login_cliente.contrasena.Equals(model.contrasenaActual))
            {
                ViewBag.Error = "Contraseña actual incorrecta.";
                return View(model);
            }

            if(!model.contrasenaNueva.Equals(model.contrasenaNuevaConfirmacion))
            {
                ViewBag.Error = "La contraseña no coincide con la confirmacion de contraseña.";
                return View(model);
            }

            login_cliente.correo = model.correo;
            login_cliente.contrasena = model.contrasenaNueva;

            _context.Login_Clientes.Entry(login_cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Perfil");
        }
    }
}
