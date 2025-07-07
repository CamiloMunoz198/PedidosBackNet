using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class OrdenEN
{
    public int IdOrden { get; set; }

    public long? IdCliente { get; set; }

    public int IdProducto { get; set; }

    public int IdAlmacenamiento { get; set; }

    public int? IdCanal { get; set; }

    public int? Cantidad { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }

}
