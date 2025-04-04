using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class Pedido_Local
    {
        [Key]
        public int id_pedido { get; set; }
        public int id_mesa { get; set; }    
        public string? nombre_cliente { get; set; }
        public DateTime fechaApertura { get; set; }
        public string? estado { get; set; }
        public int id_mesero { get; set; }

        // Propiedad de navegación (una orden puede tener muchos detalles)
        public virtual ICollection<Detalle_Pedido> DetallePedidos { get; set; } = new List<Detalle_Pedido>();
    }
}
