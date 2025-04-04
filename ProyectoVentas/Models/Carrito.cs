using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Azure.Core.HttpHeader;

namespace ProyectoVentas.Models
{
    public class Carrito
    {
        [Key]
        public int venta_lineaId { get; set; }

        // Clave foránea para Pedido_Online
        [ForeignKey("PedidoOnline")]
        public int pedido_id { get; set; }
        public virtual Pedido_Online PedidoOnline { get; set; }  // Relación con Pedido_Online

        // Claves foráneas para Plato y Combo
        public int? plato_id { get; set; }  // Nullable porque un item puede ser un plato o un combo
        public int? combo_id { get; set; }

        [ForeignKey("plato_id")]
        public virtual platos? Plato { get; set; } // Relación con Plato

        [ForeignKey("combo_id")]
        public virtual combos? Combo { get; set; } // Relación con Combo

        public int cantidad { get; set; }
        public decimal total { get; set; }
        public int metodo_pago_id { get; set; }
        public string? estado { get; set; }
        public DateTime fecha_venta { get; set; } = DateTime.Now;
    }
}
