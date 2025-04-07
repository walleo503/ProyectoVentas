using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class menu_plato
    {
        [Key]
        public int id { get; set; }
        public int? menu_id{ get; set; }
        public int? plato_id { get; set; }
        public int estado { get; set; }

        
        public menu menu { get; set; }         
        public platos plato { get; set; }
    }
}
