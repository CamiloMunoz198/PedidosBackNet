using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PedidosBackNet.AD.Contextos;
using PedidosBackNet.LN.Base;



namespace PedidosBackNet.LN.Utilidades
{
    public class AccesoDatosLN
    {
        public PedidosDBContextAD ObtenerCadenaPedidos(IConfiguration configuration, IHostEnvironment environtment)
            => environtment.IsDevelopment() ? new PedidosDBContextAD("Data Source=DARKKOH-PC\\SQLEXPRESS;Initial Catalog=Pedidos;User ID=usr_pedidos;Password=Pedidos2025*;Trust Server Certificate=True") : new PedidosDBContextAD(configuration.GetConnectionString("ConeccionSQLPedidosDB"));
    }             
}
