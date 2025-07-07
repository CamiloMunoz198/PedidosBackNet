using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class TipoAlmacenamiento
{
    [Key]
    public int IdTipoAlmacenamiento { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreTipoAlmacenamiento { get; set; }

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

    [InverseProperty("IdTipoAlmacenamientoNavigation")]
    public virtual ICollection<Almacenamiento> Almacenamiento { get; set; } = new List<Almacenamiento>();
}
