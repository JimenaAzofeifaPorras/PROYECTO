using System;
using System.Collections.Generic;

namespace BackEnd.Entities;

public partial class Piscina
{
    public int PiscinaId { get; set; }

    public int ClienteId { get; set; }

    public int? ServicioId { get; set; }

    public string Nombre { get; set; } = null!;

    public byte[] Imagen { get; set; } = null!;

    public string Comentario { get; set; } = null!;

    public DateTime? FechaHoraComentario { get; set; }

    public int? EmpleadoId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; }

    public virtual Servicio? Servicio { get; set; }
}
