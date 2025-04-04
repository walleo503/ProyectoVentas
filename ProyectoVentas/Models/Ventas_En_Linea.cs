using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class Ventas_En_Linea
    {
        [Key]
        public int VentasLineaId { get; set; }
        public int MenuId { get; set; }
        public int ClienteId { get; set; }
        public int CarritoId { get; set; }
        public int PedidoId { get; set; }
        public int HistorialId { get; set; }
    }
}
