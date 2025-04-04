using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ProyectoVentas.Models
{
    public class combos
    {
        [Key]
        public int id { get; set; }  // Clave primaria

        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public decimal precio { get; set; }
        public int? categoria_id { get; set; }
        public int estado { get; set; }

    }
}
