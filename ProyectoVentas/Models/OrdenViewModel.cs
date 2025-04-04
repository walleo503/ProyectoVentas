namespace ProyectoVentas.Models
{
    public class OrdenViewModel
    {
        public string NumRecibo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPedido { get; set; }
        public List<string> Items { get; set; }
        public decimal? Total { get; set; } = 0;
    }
}
