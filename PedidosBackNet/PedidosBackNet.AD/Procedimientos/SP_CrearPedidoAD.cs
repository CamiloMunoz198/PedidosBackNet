using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PedidosBackNet.AD.Contextos;
using PedidosBackNet.EN.Modelos;

namespace PedidosBackNet.AD.Procedimientos
{
    public class SP_CrearPedidoAD
    {


        public Task <int> EjecutarProcedimiento_SP_CrearPedidoAD(PedidosDBContextAD pedidosDBContextAD, OrdenEN pedidoEN)
            => pedidosDBContextAD.Database.ExecuteSqlRawAsync("EXEC SP_CrearPedido @IdPedido, @FechaPedido, @IdCliente, @Total",
                new SqlParameter("@IdPedido", pedidoEN.IdCliente),
                new SqlParameter("@FechaPedido", pedidoEN.IdProducto),
                new SqlParameter("@IdCliente", pedidoEN.IdAlmacenamiento),
                new SqlParameter("@Total", pedidoEN.IdCanal));

    }
}
