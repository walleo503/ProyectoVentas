using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoVentas.Models
{
    [Table("ventas_en_linea")]
    public class ventas_en_linea
    {
        [Key ]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ventas_linea_id")]
        public int Id { get; set; }
        [Required]
        [Column("plato_id")] 
        public int PlatoId { get; set; }

        [Required]
        [Column("client_id")]
        public int ClienteId { get; set; }

        [Required]
        [Column("carrito_id")]
        public int CarritoId { get; set; }

        [Required]
        [Column("pedido_id")]
        public int PedidoId { get; set; }

        [Required]
        [Column("historical_pedido")]
        public int HistoricalPedido { get; set; }

        
    }
}
