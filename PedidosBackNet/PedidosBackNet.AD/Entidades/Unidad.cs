using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class Unidad
{
    [Key]
    public int IdUnidadMedida { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreUnidad { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? NomenclarutaUnidad { get; set; }

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

    [InverseProperty("IdUnidadMedidaNavigation")]
    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
