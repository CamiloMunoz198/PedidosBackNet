using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class Cliente
{
    [Key]
    public long IdCliente { get; set; }

    public int? IdTipoCliente { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NombresCliente { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? DireccionCliente { get; set; }

    [Column(TypeName = "numeric(10, 0)")]
    public decimal? CelularCliente { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? BarrioCliente { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? CodigoDepartamento { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? CodigoCiudad { get; set; }

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

    [ForeignKey("CodigoCiudad, CodigoDepartamento")]
    [InverseProperty("Cliente")]
    public virtual Ciudad? Ciudad { get; set; }

    [ForeignKey("IdTipoCliente")]
    [InverseProperty("Cliente")]
    public virtual TipoCliente? IdTipoClienteNavigation { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Orden> Orden { get; set; } = new List<Orden>();
}
