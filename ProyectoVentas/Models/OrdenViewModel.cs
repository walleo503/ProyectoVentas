namespace ProyectoVentas.Models
{
    public class OrdenViewModel
    {
        public string NumRecibo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPedido { get; set; }
        public List<ItemOrdenViewModel> Items { get; set; }  // Cambiar de List<string> a List<ItemOrdenViewModel>
        public decimal? Total { get; set; } = 0;
        public int IdPedido { get; set; } = 1; // Agregar esta propiedad
    }
}
