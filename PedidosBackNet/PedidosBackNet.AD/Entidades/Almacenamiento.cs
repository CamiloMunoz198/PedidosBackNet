using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class Almacenamiento
{
    [Key]
    public int IdAlmacenamiento { get; set; }

    public int? IdTipoAlmacenamiento { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreAlmacenamiento { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? CodigoCiudad { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? CodigoDepartamento { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DireccionAlmacenamiento { get; set; }

    [Column(TypeName = "numeric(10, 0)")]
    public decimal? NumeroContactoAlmacenamiento { get; set; }

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
    [InverseProperty("Almacenamiento")]
    public virtual Ciudad? Ciudad { get; set; }

    [ForeignKey("IdTipoAlmacenamiento")]
    [InverseProperty("Almacenamiento")]
    public virtual TipoAlmacenamiento? IdTipoAlmacenamientoNavigation { get; set; }

    [InverseProperty("IdAlmacenamientoNavigation")]
    public virtual ICollection<Inventario> Inventario { get; set; } = new List<Inventario>();

    [InverseProperty("IdAlmacenamientoNavigation")]
    public virtual ICollection<Orden> Orden { get; set; } = new List<Orden>();
}
