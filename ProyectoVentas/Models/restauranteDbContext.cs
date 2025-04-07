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
            public DbSet<promociones> promociones { get; set; }
            public DbSet<platos_combos> platos_combos { get; set; }
            public DbSet<menu_combo> menu_combo { get; set; }
            public DbSet<menu_plato> menu_plato { get; set; }
            public DbSet<combo_promocion> combo_promocion { get; set; }
            public DbSet<Pedido_Online> pedido_Online { get; set; }
            public DbSet<Cliente> Cliente { get; set; }
            public DbSet<Login_Cliente> Login_Cliente { get; set; }
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

            modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Login_Cliente)
            .WithOne(p => p.Cliente)
            .HasForeignKey<Login_Cliente>(l => l.clienteId);


            modelBuilder.Entity<menu_plato>()
                    .HasOne(mp => mp.menu)
                    .WithMany() // Puedes crear una lista en el modelo menu si lo deseas
                    .HasForeignKey(mp => mp.menu_id)
                    .HasConstraintName("FK_menu_plato_menu");

                modelBuilder.Entity<menu_plato>()
                    .HasOne(mp => mp.plato)
                    .WithMany() // Igualmente, puedes crear una lista en platos si lo necesitas
                    .HasForeignKey(mp => mp.plato_id)
                    .HasConstraintName("FK_menu_plato_platos");

            base.OnModelCreating(modelBuilder);
            }

        }
    }
