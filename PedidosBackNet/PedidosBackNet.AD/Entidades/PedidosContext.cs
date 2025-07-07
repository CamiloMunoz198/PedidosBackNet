using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackNet.AD.Entidades;

public partial class PedidosContext : DbContext
{
    public PedidosContext()
    {
    }

    public PedidosContext(DbContextOptions<PedidosContext> options)
        : base(options)
    {
    }




}
