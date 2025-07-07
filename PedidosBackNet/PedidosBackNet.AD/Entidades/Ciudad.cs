using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

[PrimaryKey("CodigoCiudad", "CodigoDepartamento")]
public partial class Ciudad
{
    [Key]
    [StringLength(3)]
    [Unicode(false)]
    public string CodigoCiudad { get; set; } = null!;

    [Key]
    [StringLength(2)]
    [Unicode(false)]
    public string CodigoDepartamento { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? NombreCiudad { get; set; }

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

    [InverseProperty("Ciudad")]
    public virtual ICollection<Almacenamiento> Almacenamiento { get; set; } = new List<Almacenamiento>();

    [InverseProperty("Ciudad")]
    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

    [ForeignKey("CodigoDepartamento")]
    [InverseProperty("Ciudad")]
    public virtual Departamento CodigoDepartamentoNavigation { get; set; } = null!;
}
