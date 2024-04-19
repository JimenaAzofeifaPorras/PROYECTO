namespace FrontEnd.Models
{
    public class SolicitarProductoViewModel
    {
        public int IdProducto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Nombre { get; set; }
        public int NumeroTelefono { get; set; }
        public string? Correo { get; set; }
        public string? TamanoPiscina { get; set; }
        public string? Direccion { get; set; }
        public string? TipoProducto { get; set; }
        public string? DescripcionProblema { get; set; }
    }
}
