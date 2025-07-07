using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class TipoCanalEN
{
    public int IdTipoCanal { get; set; }

    public string? NombreTipoCanal { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool? Activo { get; set; }
}
