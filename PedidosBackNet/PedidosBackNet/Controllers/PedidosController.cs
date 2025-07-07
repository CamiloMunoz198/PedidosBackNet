using Microsoft.AspNetCore.Mvc;
using PedidosBackNet.EN.Modelos;
using PedidosBackNet.SV.Servicios;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PedidosBackNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : PedidosSV
    {
        public PedidosController(IConfiguration configuration, IHostEnvironment environment) : base(configuration, environment)
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }


        // Crear el Pedido
        [HttpPost("CrearOrden")]
        public override async Task<IActionResult> CrearOrdenSV(OrdenEN pedidoEN)
            => await base.CrearOrdenSV(pedidoEN);

        [HttpGet("ObtenerProductos")]
        public override async Task<IActionResult> ObtenerProductosSV()
            => await base.ObtenerProductosSV();

        [HttpGet("ObtenerClientes")]
        public override async Task<IActionResult> ObtenerClientesSV()
            => await base.ObtenerClientesSV();
        [HttpGet("ObtenerInventario")]
        public override async Task<IActionResult> ObtenerInventarioSV()
            => await base.ObtenerInventarioSV();
    }
}
