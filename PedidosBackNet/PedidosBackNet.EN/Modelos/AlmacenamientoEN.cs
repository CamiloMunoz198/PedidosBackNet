using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class AlmacenamientoEN
{
    public int IdAlmacenamiento { get; set; }

    public int? IdTipoAlmacenamiento { get; set; }

    public string? NombreAlmacenamiento { get; set; }

    public string? CodigoCiudad { get; set; }

    public string? CodigoDepartamento { get; set; }

    public string? DireccionAlmacenamiento { get; set; }

    public decimal? NumeroContactoAlmacenamiento { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }

}
