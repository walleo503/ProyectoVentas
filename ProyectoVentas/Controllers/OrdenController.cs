using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoVentas.Models;
using System.Globalization;

namespace ProyectoVentas.Controllers
{
    public class OrdenController : Controller
    {
        private readonly restauranteDbContext _context;

        public OrdenController(restauranteDbContext restauranteDBContext)
        {
            _context = restauranteDBContext;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Orden");
        }

        public IActionResult Orden()
        {
            int clienteId = 1; // Cliente estático con ID = 1

            var ordenes = _context.pedido_Online
                .Where(p => p.id_pedido == clienteId)
                .Include(p => p.Carrito)
                    .ThenInclude(c => c.Plato)  // Incluir la relación con Platos
                .Include(p => p.Carrito)
                    .ThenInclude(c => c.Combo)  // Incluir la relación con Combos
                .AsEnumerable()
                .Select(p => new OrdenViewModel
                {
                    NumRecibo = "OL" + p.id_pedido.ToString("D6"),
                    Estado = p.estado,
                    FechaPedido = p.fecha_pedido,
                    Items = p.Carrito
                        .Select(d => (d.Plato != null ? $"{d.Plato.nombre} x{d.cantidad}" :
                                      d.Combo != null ? $"{d.Combo.nombre} x{d.cantidad}" :
                                      "Desconocido x" + d.cantidad))
                        .ToList(), // Convertimos en lista para evitar el error de conversión
                    Total = p.Carrito.Sum(d => (decimal?)d.total) ?? 0  // Forzar decimal? para evitar errores con ??
                })
                .ToList();

            return View(ordenes);
        }


    }
}
