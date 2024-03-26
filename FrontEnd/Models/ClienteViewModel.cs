using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El segundo apellido es obligatorio")]
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string? NumeroTelefonico { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string? Contrasena { get; set; }
    }
}
