using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class EstatusEntrega
{
    [Key]
    public int IdEstatusEntrega { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreEstatusEntrega { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioCreacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaActualiazacion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioActualizacion { get; set; }

    public bool? Activo { get; set; }

    [InverseProperty("IdEstatusEntregaNavigation")]
    public virtual ICollection<Entrega> Entrega { get; set; } = new List<Entrega>();
}
