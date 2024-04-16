using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Keyless]
    public class sp_AddServicio_Result
    {
        public int IdServicio { get; set; }

        public string? Nombre { get; set; }

        public string? Precio { get; set; }

        public string? Estado { get; set; }

        public byte[]? Imagen { get; set; }
    }
}
