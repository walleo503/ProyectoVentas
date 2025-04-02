using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoVentas.Models
{
    [Table("login_Cliente")]
    [Index(nameof(correo),IsUnique =true)]

    public class login_Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int loginid { get; set; }
        
        public string? correo  { get; set; }
        public string? contraseña { get; set; }
    }
}
