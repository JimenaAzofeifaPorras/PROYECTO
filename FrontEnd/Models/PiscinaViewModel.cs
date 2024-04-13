using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class PiscinaViewModel
    {
        public int PiscinaId { get; set; }

        [Display(Name = "Cliente Id")]
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int ClienteId { get; set; }

        public string? ClienteNombre { get; set; } // Para mostrar el nombre del cliente en lugar de solo su Id

        [Display(Name = "Servicio Id")]
        public int? ServicioId { get; set; }

        public string? ServicioNombre { get; set; } // Para mostrar el nombre del servicio en lugar de solo su Id

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }

        public byte[]? Imagen { get; set; }

        [Display(Name = "Id Empleado")]
        public int? EmpleadoId { get; set; }

        [Display(Name = "Comentario")]
        public string? Comentario { get; set; }

        [Display(Name = "Fecha y Hora del Comentario")]
        public DateTime? FechaHoraComentario { get; set; }

    }
}
