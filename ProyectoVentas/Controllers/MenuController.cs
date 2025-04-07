using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoVentas.Models;

namespace ProyectoVentas.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly restauranteDbContext _context;

        public MenuController(restauranteDbContext context)
        {
            _context = context;
        }

        public IActionResult ObtenerCombos()
        {
            var combos = _context.combos
                .Where(c => c.estado == 1)
                .Select(c => new combos
                {
                    nombre = c.nombre,
                    descripcion = c.descripcion,
                    precio = c.precio,
                    //imagen = c.imagen ?? "~/img/combo.png"
                })
                .ToList();

            return Json(combos);
        }


        public IActionResult ObtenerPlatos()
        {
            var ahora = DateTime.Now;
            var horaActual = ahora.TimeOfDay;
            var fechaActual = ahora.Date;

            var platos = _context.menu_plato
                .Where(mp => mp.estado == 1 &&
                             mp.menu.estado == 1 &&
                             mp.menu.tipo_venta == "online" &&
                             (
                                 // Menús por tiempo (desayuno, almuerzo, cena)
                                 (
                                     (mp.menu.tipo_menu == "desayuno" ||
                                      mp.menu.tipo_menu == "almuerzo" ||
                                      mp.menu.tipo_menu == "cena")
                                     &&
                                     mp.menu.hora_inicio <= horaActual &&
                                     mp.menu.hora_fin >= horaActual
                                 )
                                 ||
                                 // Menús por temporada
                                 (
                                     mp.menu.tipo_menu == "temporada"
                                     &&
                                     mp.menu.fecha_inicio <= fechaActual &&
                                     mp.menu.fecha_fin >= fechaActual
                                 )
                             )
                        )
                .Select(mp => new
                {
                    mp.plato.nombre,
                    mp.plato.descripcion,
                    mp.plato.precio,
                    mp.plato.imagen
                    
                })
                .ToList();

            return Json(platos);
        }


        //public IActionResult ObtenerPlatos()
        //{
        //    var platos = _context.platos
        //        .Where(p => p.estado == 1) // Activos
        //        .Select(p => new platos
        //        {
        //            nombre = p.nombre,
        //            descripcion = p.descripcion,
        //            precio = p.precio,
        //            imagen = p.imagen /*?? "~/img/placeholder.png"*/
        //        })
        //        .ToList();

        //    return Json(platos);
        //}

        public IActionResult ObtenerPromociones()
        {
            DateTime hoy = DateTime.Today;

            var promociones = _context.promociones
                .Where(p => p.estado == 1)
                .Select(p => new
                {
                    p.nombre,
                    p.descripcion,
                    p.descuento,
                    Combos = _context.combo_promocion
                                .Where(cp => cp.promocion_id == p.id &&
                                             cp.estado == 1 &&
                                             cp.fecha_inicio <= hoy &&
                                             cp.fecha_fin >= hoy)
                                .Join(_context.combos,
                                      cp => cp.combo_id,
                                      c => c.id,
                                      (cp, c) => new
                                      {
                                          c.nombre,
                                          c.descripcion,
                                          c.precio
                                      }).ToList()
                })
                .Where(p => p.Combos.Any()) // Solo incluir promociones que tienen combos vigentes
                .ToList();

            return Json(promociones);
        }


        public IActionResult ObtenerPostres()
        {
            int idCategoriaPostres = 4; // Cambia este valor si tu categoría "Postres" tiene otro ID

            var postres = _context.platos
                .Where(p => p.estado == 1 && p.categoria_id == idCategoriaPostres)
                .Select(p => new
                {
                    p.nombre,
                    p.descripcion,
                    p.precio,
                    p.imagen
                })
                .ToList();

            return Json(postres);
        }


        public IActionResult ObtenerBebidas()
        {
            int idCategoriaBebidas = 5;

            var bebidas = _context.platos
                .Where(p => p.estado == 1 && p.categoria_id == idCategoriaBebidas)
                .Select(p => new
                {
                    p.nombre,
                    p.descripcion,
                    p.precio,
                    p.imagen
                })
                .ToList();

            return Json(bebidas);
        }

    }
}
