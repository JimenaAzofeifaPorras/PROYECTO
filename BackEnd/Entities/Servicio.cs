using System;
using System.Collections.Generic;

namespace BackEnd.Entities;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? Nombre { get; set; }

    public string? Precio { get; set; }

    public string? Estado { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<Piscina> Piscinas { get; set; } = new List<Piscina>();
}
