using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PedidosBackNet.EN.Modelos;
using PedidosBackNet.LN.Logica;


namespace PedidosBackNet.SV.Servicios
{
    public class PedidosSV(IConfiguration configuration, IHostEnvironment environment) : ControllerBase
    {
        private readonly IConfiguration configuration = configuration;
        private readonly IHostEnvironment environment = environment;
        private  PedidosLN? pedidosLN;

        public virtual async Task<IActionResult> CrearOrdenSV(OrdenEN pedidoEN)
        {
            try
            {
                pedidosLN = new PedidosLN(configuration, environment);
                await pedidosLN.CrearOrdenLN(pedidoEN);
                return StatusCode(pedidosLN.respuestas.Estado, pedidosLN.respuestas);
            }
            catch (Exception ex)
            {
                //Agregar un log de error aquí si es necesario con mensajes más detallados por correo
                return StatusCode(500, new Dictionary<string, object>() { {"Mensaje",$"Error al crear el pedido CrearPedidoSV:{ex.Message}" } });
            }
        }

        public virtual async Task<IActionResult> ObtenerProductosSV()
        {
            try
            {
                pedidosLN = new PedidosLN(configuration, environment);
                await pedidosLN.ObtenerProductosLN();
                return StatusCode(pedidosLN.respuestas.Estado, pedidosLN.respuestas);
            }
            catch (Exception ex)
            {
                //Agregar un log de error aquí si es necesario con mensajes más detallados por correo
                return StatusCode(500, new Dictionary<string, object>() { { "Mensaje", $"Error al consultar Productos ObtenerProductosSV:{ex.Message}" } });
            }
        }

        public virtual async Task<IActionResult> ObtenerInventarioSV()
        {
            try
            {
                pedidosLN = new PedidosLN(configuration, environment);
                await pedidosLN.ObtenerInventarioLN();
                return StatusCode(pedidosLN.respuestas.Estado, pedidosLN.respuestas);
            }
            catch (Exception ex)
            {
                //Agregar un log de error aquí si es necesario con mensajes más detallados por correo
                return StatusCode(500, new Dictionary<string, object>() { { "Mensaje", $"Error al consultar el Inventario ObtenerInventarioSV:{ex.Message}" } });
            }
        }


        public virtual async Task<IActionResult> ObtenerClientesSV()
        {
            try
            {
                pedidosLN = new PedidosLN(configuration, environment);
                await pedidosLN.ObtenerClientesLN();
                return StatusCode(pedidosLN.respuestas.Estado, pedidosLN.respuestas);
            }
            catch (Exception ex)
            {
                //Agregar un log de error aquí si es necesario con mensajes más detallados por correo
                return StatusCode(500, new Dictionary<string, object>() { { "Mensaje", $"Error al consultar Clientes ObtenerClientesSV:{ex.Message}" } });
            }
        }
    }
}
