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
                    // Aquí cambiamos para utilizar ItemOrdenViewModel en lugar de strings
                    Items = p.Carrito
                        .Select(d => new ItemOrdenViewModel
                        {
                            Nombre = d.Plato != null ? d.Plato.nombre : (d.Combo != null ? d.Combo.nombre : "Desconocido"),
                            Cantidad = d.cantidad,
                            Precio = d.Plato != null ? d.Plato.precio : (d.Combo != null ? d.Combo.precio : 0),
                            Total = d.total
                        })
                        .ToList(), // Ahora estamos generando una lista de ItemOrdenViewModel
                    Total = p.Carrito.Sum(d => (decimal?)d.total) ?? 0  // Calculamos el total correctamente
                })
                .ToList();

            return View(ordenes);
        }


        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound(); // Manejo de error si el ID es 0
            }

            // Recuperar el pedido específico por ID
            var pedido = _context.pedido_Online
                .Include(p => p.Carrito)
                    .ThenInclude(c => c.Plato)  // Incluir Platos en la relación Carrito
                .Include(p => p.Carrito)
                    .ThenInclude(c => c.Combo)  // Incluir Combos en la relación Carrito
                .FirstOrDefault(p => p.id_pedido == id);  // Obtener el pedido por ID

            if (pedido == null)
            {
                return NotFound();  // Si no se encuentra el pedido, se maneja el error
            }

            // Mapeamos los datos del pedido a un modelo de vista
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
                    // Asignar la descripción del plato o combo
                    Descripcion = d.Plato != null ? d.Plato.descripcion : (d.Combo != null ? d.Combo.descripcion : "Sin descripción")
                })
                .ToList(),
                        Total = pedido.Carrito.Sum(d => (decimal?)d.total) ?? 0,
                        IdPedido = pedido.id_pedido
            };

            // Devolver la vista de detalles con el modelo
            return View(model);
        }


    }
}
