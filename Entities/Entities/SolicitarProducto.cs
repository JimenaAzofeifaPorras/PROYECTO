using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class SolicitarProducto
    {
    public int IdProducto { get; set; }
    public DateTime Fecha { get; set; }
    public string? Nombre { get; set; }
    public string? NumeroTelefono { get; set; }
    public string? Correo { get; set; }
    public string? TamanoPiscina { get; set; }
    public string? Direccion { get; set; }
    public string? TipoProducto { get; set; }
    public string? DescripcionProblema { get; set; }
    }
}
