using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class EstatusEntregaEN
{
    public int IdEstatusEntrega { get; set; }

    public string? NombreEstatusEntrega { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualiazacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }

}
