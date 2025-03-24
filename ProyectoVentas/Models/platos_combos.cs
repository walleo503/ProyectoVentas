using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class platos_combos
    {
        [Key]
        public int Id { get; set; }
        public int? combo_id { get; set; }
        public int? plato_id { get; set; }
        public int estado { get; set; }
    }
}
