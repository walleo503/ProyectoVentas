using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoVentas.Models
{
    public class Login_Cliente
    {
        [Key]
        public int loginid { get; set; }
        public string correo { get; set; }
        public string? contraseña { get; set; }
        
        public int clienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
     }
}
