using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class categoria
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public int estado { get; set; }
    }
}
