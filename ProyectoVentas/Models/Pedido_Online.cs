using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoVentas.Models
{
    public class Pedido_Online
    {
        [Key]
        public int id_pedido { get; set; }

        // Clave foránea para Cliente
        [ForeignKey("Cliente")]
        public int id_cliente { get; set; }

        public DateTime fecha_pedido { get; set; } = DateTime.Now;
        public string estado { get; set; }

        // Relación con Cliente
        public virtual Cliente Cliente { get; set; }

        // Relación con Carrito (Un pedido tiene varios ítems en el carrito)
        public virtual ICollection<Carrito> Carrito { get; set; }
    }
}
