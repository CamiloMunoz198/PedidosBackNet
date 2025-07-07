using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

[PrimaryKey("CodigoEntrega", "IdOrden")]
public partial class Entrega
{
    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string CodigoEntrega { get; set; } = null!;

    [Key]
    public int IdOrden { get; set; }

    [Unicode(false)]
    public string? JsonSolicitudApiEntrega { get; set; }

    [Unicode(false)]
    public string? JsonRespuestaApiEntrega { get; set; }

    public int? IdEstatusEntrega { get; set; }

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

    [ForeignKey("IdEstatusEntrega")]
    [InverseProperty("Entrega")]
    public virtual EstatusEntrega? IdEstatusEntregaNavigation { get; set; }

    [ForeignKey("IdOrden")]
    [InverseProperty("Entrega")]
    public virtual Orden IdOrdenNavigation { get; set; } = null!;
}
