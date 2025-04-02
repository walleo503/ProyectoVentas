using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class cliente
    {
        [Key]
        public int clienteid { get; set; }
        public string? nombre { get; set; }
        public string? telefono { get; set; }
        public string? direccion {  get; set; }
        public decimal? latitud { get; set; }
        public decimal? lonitud { get; set; }
        public int? loginid { get; set; }
    }
}
