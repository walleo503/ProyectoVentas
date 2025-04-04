namespace ProyectoVentas.Models
{
    public class ItemOrdenViewModel
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }  // Agregar la propiedad Descripción
    }
}
