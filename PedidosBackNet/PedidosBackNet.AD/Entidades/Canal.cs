using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class Canal
{
    [Key]
    public int IdCanal { get; set; }

    public int? IdTipoCanal { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreCanal { get; set; }

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

    [ForeignKey("IdTipoCanal")]
    [InverseProperty("Canal")]
    public virtual TipoCanal? IdTipoCanalNavigation { get; set; }

    [InverseProperty("IdCanalNavigation")]
    public virtual ICollection<Orden> Orden { get; set; } = new List<Orden>();
}
