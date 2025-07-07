using System;
using System.Collections.Generic;

namespace PedidosBackNet.EN.Modelos;

public partial class ProductoEN
{
    public int IdProducto { get; set; }

    public string? NombreProducto { get; set; }

    public string? DescripcionProducto { get; set; }

    public int? IdUnidadMedida { get; set; }

    public int? CantidadMedidaUnitaria { get; set; }

    public long? ValorUnitario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }

}
