using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class Producto
{
    [Key]
    public int IdProducto { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreProducto { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? DescripcionProducto { get; set; }

    public int? IdUnidadMedida { get; set; }

    public int? CantidadMedidaUnitaria { get; set; }

    public long? ValorUnitario { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? UsuarioCreacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaActualizacion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }

    [ForeignKey("IdUnidadMedida")]
    [InverseProperty("Producto")]
    public virtual Unidad? IdUnidadMedidaNavigation { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<Inventario> Inventario { get; set; } = new List<Inventario>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<Orden> Orden { get; set; } = new List<Orden>();
}
