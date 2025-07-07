using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class TipoAlmacenamientoEN
{
    public int IdTipoAlmacenamiento { get; set; }

    public string? NombreTipoAlmacenamiento { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }

}
