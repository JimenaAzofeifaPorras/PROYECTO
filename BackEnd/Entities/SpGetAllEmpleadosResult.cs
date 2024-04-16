using System;
using System.Collections.Generic;

namespace BackEnd.Entities;

public partial class SpGetAllEmpleadosResult
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? Correo { get; set; }

    public string? NumeroTelefonico { get; set; }

    public string? Contrasena { get; set; }
}
