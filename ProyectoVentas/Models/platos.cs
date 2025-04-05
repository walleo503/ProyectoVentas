using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class platos
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion {  get; set; }
        public decimal precio { get; set; }
        public string? imagen { get; set; }
        public int? categoria_id { get; set; }
        public int estado { get; set; }
    }
}
