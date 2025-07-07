using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class TipoCliente
{
    [Key]
    public int IdTipoCliente { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CodigoTipoCliente { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreTipoCliente { get; set; }

    [InverseProperty("IdTipoClienteNavigation")]
    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();
}
