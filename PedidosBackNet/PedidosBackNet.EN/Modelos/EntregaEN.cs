using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class EntregaEN
{
    public string CodigoEntrega { get; set; } = null!;

    public int IdOrden { get; set; }

    public string? JsonSolicitudApiEntrega { get; set; }

    public string? JsonRespuestaApiEntrega { get; set; }

    public int? IdEstatusEntrega { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }
}
