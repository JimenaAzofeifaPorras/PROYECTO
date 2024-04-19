namespace FrontEnd.Models
{
    public class SolicitarServicioViewModel
    {
        public int IdServicio { get; set; }
        public DateTime Fecha { get; set; }
        public string? Nombre { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? Correo { get; set; }
        public string? TamanoPiscina { get; set; }
        public string? Direccion { get; set; }
        public string? TipoServicio { get; set; }
        public string? DescripcionProblema { get; set; }
    }
}
