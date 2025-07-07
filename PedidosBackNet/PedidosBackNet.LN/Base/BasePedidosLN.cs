using PedidosBackNet.AD.Procedimientos;
using PedidosBackNet.EN.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBackNet.LN.Base
{
    public class BasePedidosLN : BaseGeneralLN
    {
        public async Task<SP_CrearPedidoAD> CargarSP_CrearPedidoLN()
        {
            // Aquí puedes implementar la lógica para cargar el procedimiento almacenado SP_CrearPedido.
            // Por ejemplo, podrías usar un contexto de base de datos para ejecutar el procedimiento almacenado.
            // Este es un ejemplo básico y deberías adaptarlo a tu contexto y necesidades específicas.
            // return await _context.Database.ExecuteSqlRawAsync("EXEC SP_CrearPedido");
            return  new SP_CrearPedidoAD(); // Reemplaza esto con la llamada real al procedimiento almacenado.
        }
    }
}
