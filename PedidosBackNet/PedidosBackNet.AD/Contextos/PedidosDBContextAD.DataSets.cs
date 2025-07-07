using Microsoft.EntityFrameworkCore;
using PedidosBackNet.AD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBackNet.AD.Contextos
{
    public partial class PedidosDBContextAD :DbContext
    {

        public virtual DbSet<Almacenamiento> Almacenamiento { get; set; }

        public virtual DbSet<Canal> Canal { get; set; }

        public virtual DbSet<Ciudad> Ciudad { get; set; }

        public virtual DbSet<Cliente> Cliente { get; set; }

        public virtual DbSet<Departamento> Departamento { get; set; }

        public virtual DbSet<Entrega> Entrega { get; set; }

        public virtual DbSet<EstatusEntrega> EstatusEntrega { get; set; }

        public virtual DbSet<Inventario> Inventario { get; set; }

        public virtual DbSet<Orden> Orden { get; set; }

        public virtual DbSet<Producto> Producto { get; set; }

        public virtual DbSet<TipoAlmacenamiento> TipoAlmacenamiento { get; set; }

        public virtual DbSet<TipoCanal> TipoCanal { get; set; }

        public virtual DbSet<TipoCliente> TipoCliente { get; set; }

        public virtual DbSet<Unidad> Unidad { get; set; }
    }
}
