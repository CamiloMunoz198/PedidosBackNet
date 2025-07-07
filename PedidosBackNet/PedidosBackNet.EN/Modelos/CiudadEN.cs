using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class CiudadEN
{
    public string CodigoCiudad { get; set; } = null!;

    public string CodigoDepartamento { get; set; } = null!;

    public string? NombreCiudad { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }

}
