    using Microsoft.EntityFrameworkCore;

    namespace ProyectoVentas.Models
    {
        public class restauranteDbContext : DbContext
        {
            public restauranteDbContext(DbContextOptions options) : base(options)
            {


            }

            public DbSet<Pedido_Local> Pedido_Local { get; set; }
            public DbSet<Detalle_Pedido> Detalle_Pedido { get; set; }
            public DbSet<Facturas> Facturas { get; set; }
            public DbSet<empleados> empleados { get; set; }
            public DbSet<platos> platos { get; set; }
            public DbSet<combos> combos { get; set; }
            public DbSet<Pedido_Online> pedido_Online { get; set; }
            public DbSet<Cliente> Cliente { get; set; }
            public DbSet<Login_Cliente> Login_Clientes { get; set; }
            public DbSet<Carrito> Carrito { get; set; }
            public DbSet<Historial_Pedido> Historial_Pedido { get; set; }
            public DbSet<Ventas_En_Linea> Ventas_En_Linea { get; set; }















            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configuración de relaciones

                modelBuilder.Entity<Detalle_Pedido>()
                    .HasOne(dp => dp.PedidoLocal)
                    .WithMany(pl => pl.DetallePedidos)
                    .HasForeignKey(dp => dp.encabezado_id)
                    .HasConstraintName("FK_DetallePedido_PedidoLocal");

                modelBuilder.Entity<Pedido_Online>()
                    .HasOne(p => p.Cliente)  // Relación con Cliente
                    .WithMany(c => c.PedidosOnline)  // Relación inversa
                    .HasForeignKey(p => p.id_cliente)  // Clave foránea
                    .HasConstraintName("FK_PedidoOnline_Cliente");

                modelBuilder.Entity<Carrito>()
                    .HasOne(c => c.PedidoOnline)
                    .WithMany(p => p.Carrito)
                    .HasForeignKey(c => c.plato_id)
                    .HasConstraintName("FK_Carrito_PedidoOnline");

                base.OnModelCreating(modelBuilder);
            }

    }
    }
