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
            int clienteId = 1;

            var ordenes = _context.pedido_Online
                .Where(p => p.id_pedido == clienteId)
                .Include(p => p.Carrito)
                    .ThenInclude(c => c.Plato)
                .Include(p => p.Carrito)
                    .ThenInclude(c => c.Combo)
                .AsEnumerable()
                .Select(p => new OrdenViewModel
                {
                    NumRecibo = "OL" + p.id_pedido.ToString("D6"),
                    Estado = p.estado,
                    FechaPedido = p.fecha_pedido,
                    Items = p.Carrito
                        .Select(d => new ItemOrdenViewModel
                        {
                            Nombre = d.Plato != null ? d.Plato.nombre : (d.Combo != null ? d.Combo.nombre : "Desconocido"),
                            Cantidad = d.cantidad,
                            Precio = d.Plato != null ? d.Plato.precio : (d.Combo != null ? d.Combo.precio : 0),
                            Total = d.total,
                            Descripcion = d.Plato != null ? d.Plato.descripcion : (d.Combo != null ? d.Combo.descripcion : "Sin descripción"),
                            ImagenUrl = d.Plato != null ? d.Plato.imagen : "~/img/combo-icon.png"  // Imagen por defecto para combos
                        })
                        .ToList(),
                    Total = p.Carrito.Sum(d => (decimal?)d.total) ?? 0
                })
                .ToList();

            return View(ordenes);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
                return NotFound();

            var pedido = _context.pedido_Online
                .Include(p => p.Carrito)
                    .ThenInclude(c => c.Plato)
                .Include(p => p.Carrito)
                    .ThenInclude(c => c.Combo)
                .FirstOrDefault(p => p.id_pedido == id);

            if (pedido == null)
                return NotFound();

            var model = new OrdenViewModel
            {
                NumRecibo = "OL" + pedido.id_pedido.ToString("D6"),
                Estado = pedido.estado,
                FechaPedido = pedido.fecha_pedido,
                Items = pedido.Carrito
                    .Select(d => new ItemOrdenViewModel
                    {
                        Nombre = d.Plato != null ? d.Plato.nombre : (d.Combo != null ? d.Combo.nombre : "Desconocido"),
                        Cantidad = d.cantidad,
                        Precio = d.Plato != null ? d.Plato.precio : (d.Combo != null ? d.Combo.precio : 0),
                        Total = d.total,
                        Descripcion = d.Plato != null ? d.Plato.descripcion : (d.Combo != null ? d.Combo.descripcion : "Sin descripción"),
                        ImagenUrl = d.Plato != null ? d.Plato.imagen : "~/img/combo-icon.png"
                    })
                    .ToList(),
                Total = pedido.Carrito.Sum(d => (decimal?)d.total) ?? 0,
                IdPedido = pedido.id_pedido
            };

            return View(model);
        }
    }
}
