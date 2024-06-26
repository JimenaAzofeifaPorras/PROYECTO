﻿using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Piscina
{
    public int PiscinaId { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public int? ServicioId { get; set; }
    public Servicio? Servicio { get; set; }
    public string? Nombre { get; set; }
    public byte[]? Imagen { get; set; }
    public int? EmpleadoId { get; set; } // Id del empleado que realizó el comentario
    public Empleado? Empleado { get; set; } // Referencia a la entidad Empleado
    public string? Comentario { get; set; }
    public DateTime? FechaHoraComentario { get; set; }
}
