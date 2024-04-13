namespace FrontEnd.Models
{
    public class PiscinaViewModel
    {
        public int PiscinaId { get; set; }
        public int ClienteId { get; set; }
        public string? ClienteNombre { get; set; } // Para mostrar el nombre del cliente en lugar de solo su Id
        public int? ServicioId { get; set; }
        public string? ServicioNombre { get; set; } // Para mostrar el nombre del servicio en lugar de solo su Id
        public string? Nombre { get; set; }
        public byte[]? Imagen { get; set; }
        public int? EmpleadoId { get; set; }
        public string? Comentario { get; set; }
        public DateTime? FechaHoraComentario { get; set; }

    }
}
