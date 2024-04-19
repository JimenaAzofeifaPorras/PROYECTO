namespace BackEnd.Models
{
    public class SolicitarProductoModel
    {
        public int IdProducto { get; set; } 
        public DateTime Fecha { get; set; } 
        public string Nombre { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string TamanoPiscina { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string TipoProducto { get; set; } = null!;
        public string DescripcionProblema { get; set; } = null!;
    }
}

