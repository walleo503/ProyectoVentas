using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class pedidos_en_linea
    {
        [Key]
        public int pedido_id { get; set; }
        public string? tipoItem { get; set; }
        public int itemId { get; set; }
        public int cantidad { get; set; }
        public string? estado { get; set; }
    }
}
