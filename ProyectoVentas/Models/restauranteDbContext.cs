using Microsoft.EntityFrameworkCore;

namespace ProyectoVentas.Models
{
    public class restauranteDbContext:DbContext
    {
        public restauranteDbContext(DbContextOptions options) : base(options)
        {


        }
    }
}
