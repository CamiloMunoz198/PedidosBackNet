using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class ClienteEN
{
    public long IdCliente { get; set; }

    public int? IdTipoCliente { get; set; }

    public string? NombresCliente { get; set; }

    public string? DireccionCliente { get; set; }

    public decimal? CelularCliente { get; set; }

    public string? BarrioCliente { get; set; }

    public string? CodigoDepartamento { get; set; }

    public string? CodigoCiudad { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }
}
