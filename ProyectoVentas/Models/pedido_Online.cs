using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoVentas.Models
{
    public enum EstadoPedido
    {
        Pendiente,
        Cancelado
    }
    public class pedido_Online
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_pedido { get; set; }

        [Required]
        public int id_cliente { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime fecha_pedido { get; set; } = DateTime.Now;

        [Required]
        public EstadoPedido estado { get; set; } = EstadoPedido.Pendiente;

        // Relación con cliente
        [ForeignKey("id_cliente")]
        public virtual cliente cliente { get; set; }

    }
}
