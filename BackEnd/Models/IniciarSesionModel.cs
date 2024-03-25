using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class IniciarSesionModel
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string? Contrasena { get; set; }
    }
}
