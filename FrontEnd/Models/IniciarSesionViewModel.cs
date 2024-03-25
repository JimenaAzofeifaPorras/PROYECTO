using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class IniciarSesionViewModel
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string? Contrasena { get; set; }
    }
}
