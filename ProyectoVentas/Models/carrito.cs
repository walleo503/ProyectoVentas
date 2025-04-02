using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class carrito
    {
        [Key]
        public int carritoid { get; set; }
        public int? pedido_id { get; set; }
        public int? plato_id { get; set; }
        public int? combo_id { get; set; }
        public int cantidad { get; set; }
        public decimal? total { get; set; }
        [Required]
        public EstadoPedido estado { get; set; } = EstadoPedido.Pendiente;
        public DateTime? fecha_venta { get; set; }

    }
}
