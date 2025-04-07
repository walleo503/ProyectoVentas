using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class menu
    {
        [Key]
        public int id { get; set; }
        public string? tipo_menu { get; set; }
        public  string? tipo_venta {  get; set; }    
        public TimeSpan hora_inicio { get; set; }
         public TimeSpan hora_fin {  get; set; }
         public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get;  set; }
        public int estado {  get; set; }

        public ICollection<menu_plato> MenuPlatos { get; set; }
    }
}
