using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoVentas.Models
{
    public class Detalle_Pedido
    {
        [Key]
        public int id_detalle_pedido { get; set; }
        [ForeignKey("Pedido_Local")]
        public int encabezado_id { get; set; }
        public string? tipo_venta { get; set; }
        public string? tipo_item { get; set; }
        public int item_id { get; set; }
        public int cantidad { get; set; }
        public string? comentarios { get; set; }
        public string? estado { get; set; }
        public decimal subtotal { get; set; }

        // Propiedad de navegación a Pedido_Local
        public virtual Pedido_Local PedidoLocal { get; set; }
    }
}
