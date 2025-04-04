using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class Historial_Pedido
    {
        [Key]
        public int HistorialId { get; set; }
        public string TipoItem { get; set; }
        public int ItemId { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
    }
}
