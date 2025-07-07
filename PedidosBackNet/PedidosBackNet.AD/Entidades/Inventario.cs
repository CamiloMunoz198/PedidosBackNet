using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

[PrimaryKey("IdProducto", "IdAlmacenamiento")]
public partial class Inventario
{
    [Key]
    public int IdProducto { get; set; }

    [Key]
    public int IdAlmacenamiento { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioCreacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaActualizacion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }

    [ForeignKey("IdAlmacenamiento")]
    [InverseProperty("Inventario")]
    public virtual Almacenamiento IdAlmacenamientoNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("Inventario")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
