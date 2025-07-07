using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class TipoCanal
{
    [Key]
    public int IdTipoCanal { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreTipoCanal { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioCreacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioModificacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    public bool? Activo { get; set; }

    [InverseProperty("IdTipoCanalNavigation")]
    public virtual ICollection<Canal> Canal { get; set; } = new List<Canal>();
}
