using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class Departamento
{
    [Key]
    [StringLength(2)]
    [Unicode(false)]
    public string CodigoDepartamento { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? NombreDepartamento { get; set; }

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

    [InverseProperty("CodigoDepartamentoNavigation")]
    public virtual ICollection<Ciudad> Ciudad { get; set; } = new List<Ciudad>();
}
