using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class Cliente
    {
        [Key]
        public int clienteId { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public decimal latitud { get; set; }
        public decimal longitud { get; set; }
        public int loginid { get; set; }

        // Relación con Pedido_Online (Un cliente puede tener varios pedidos)
        public ICollection<Pedido_Online> PedidosOnline { get; set; }
    }
}
