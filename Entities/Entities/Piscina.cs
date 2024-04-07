using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Piscina
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public int? ServicioId { get; set; }
    public Servicio Servicio { get; set; }
    public string Nombre { get; set; }
    public byte[] Imagen { get; set; }
    public string Comentario { get; set; }
    public string EmpleadoComentario { get; set; }
    public DateTime? FechaHoraComentario { get; set; }
}
