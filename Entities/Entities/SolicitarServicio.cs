using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class SolicitarServicio
    {
        public int IdServicio { get; set; }
        public DateTime Fecha { get; set; }
        public string? Nombre { get; set; }
        public int NumeroTelefono { get; set; }
        public string? Correo { get; set; }
        public string? TamanoPiscina { get; set; }
        public string? Direccion { get; set; }
        public string? TipoServicio { get; set; }
        public string? DescripcionProblema { get; set; }
    }
}
