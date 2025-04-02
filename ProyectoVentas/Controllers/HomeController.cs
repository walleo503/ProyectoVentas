using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoVentas.Models;

namespace ProyectoVentas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly restauranteDbContext _context;

        public HomeController(ILogger<HomeController> logger, restauranteDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CambiarContra()
        {
            return View();
        }

        public async Task<IActionResult> Menu()
        {
            //Obtener platos y combos
            var platos = await _context.Platos.ToListAsync();
            var combos = await _context.Combos
                .Include(c => c.PlatosCombos)
                .ThenInclude(pc => pc.Plato)
                .ToListAsync();

            ViewBag.Platos = platos;
            ViewBag.Combos = combos;
            return View();
        }

        public IActionResult contacto()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }
    }
}
