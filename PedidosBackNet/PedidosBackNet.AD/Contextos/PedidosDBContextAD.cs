using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBackNet.AD.Contextos
{
    public partial class PedidosDBContextAD :DbContext
    {
        public readonly string cadenaConexion;

        public PedidosDBContextAD(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(cadenaConexion);
    }
}
