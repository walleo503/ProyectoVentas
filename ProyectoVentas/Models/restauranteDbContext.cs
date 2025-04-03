using Microsoft.EntityFrameworkCore;

namespace ProyectoVentas.Models
{
    public class restauranteDbContext:DbContext
    {
        public restauranteDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<cliente> clientes { get; set; }
        public DbSet<login_Cliente> login_cliente { get; set;}
    }
}
