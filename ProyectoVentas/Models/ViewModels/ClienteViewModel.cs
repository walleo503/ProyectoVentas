using Microsoft.EntityFrameworkCore;

namespace ProyectoVentas.Models.Dtos
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }
        public Login_Cliente Login_Cliente { get; set; }
    }
}
