using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class CanalEN
{
    public int IdCanal { get; set; }

    public int? IdTipoCanal { get; set; }

    public string? NombreCanal { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }
}
