using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class DepartamentoEN
{
    public string CodigoDepartamento { get; set; } = null!;

    public string? NombreDepartamento { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }
}
