using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class Orden
{
    [Key]
    public int IdOrden { get; set; }

    public long? IdCliente { get; set; }

    public int IdProducto { get; set; }

    public int IdAlmacenamiento { get; set; }

    public int? IdCanal { get; set; }

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

    [InverseProperty("IdOrdenNavigation")]
    public virtual ICollection<Entrega> Entrega { get; set; } = new List<Entrega>();

    [ForeignKey("IdAlmacenamiento")]
    [InverseProperty("Orden")]
    public virtual Almacenamiento IdAlmacenamientoNavigation { get; set; } = null!;

    [ForeignKey("IdCanal")]
    [InverseProperty("Orden")]
    public virtual Canal? IdCanalNavigation { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("Orden")]
    public virtual Cliente? IdClienteNavigation { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("Orden")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
