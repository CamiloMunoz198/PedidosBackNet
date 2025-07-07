using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PedidosBackNet.AD.Contextos;
using PedidosBackNet.AD.Entidades;
using PedidosBackNet.EN.Modelos;
using PedidosBackNet.LN.Base;
using System.Diagnostics.CodeAnalysis;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;


namespace PedidosBackNet.LN.Logica
{
    public class PedidosLN : BasePedidosLN
    {
        // Aquí puedes agregar métodos y propiedades para la lógica de negocio relacionada con los pedidos.
        // Por ejemplo, podrías tener métodos para crear, actualizar, eliminar y obtener pedidos.
        private readonly IConfiguration configuration;
        private readonly IHostEnvironment environment;
        public PedidosLN(IConfiguration configuration, IHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public Task CrearOrdenLN(OrdenEN pedidoEN)
        {
            // Lógica para crear un pedido
            try
            {
                using (PedidosDBContextAD pedidosDBContextAD = accesoDatos.ObtenerCadenaPedidos(configuration, environment))
                {
                    // Ejecutar el procedimiento almacenado
                    //int resultado = await CargarSP_CrearPedidoLN().Result.EjecutarProcedimiento_SP_CrearPedidoAD(pedidosDBContextAD, pedidoEN);
                    // Verificar el resultado y establecer la respuesta
                    try
                    {
                        var nuevaOrden = new Orden {
                            IdCliente        = pedidoEN.IdCliente,
                            IdProducto       =pedidoEN.IdProducto,
                            IdAlmacenamiento =pedidoEN.IdAlmacenamiento,
                            IdCanal          =pedidoEN.IdCanal,
                            Cantidad         =pedidoEN.Cantidad,
                            FechaCreacion    =DateTime.Now,
                            UsuarioCreacion  =pedidoEN.UsuarioCreacion,
                            Activo           =true,
                       };
                        pedidosDBContextAD.Orden.Add(nuevaOrden);
                        pedidosDBContextAD.SaveChanges();
                        respuestas.Creado("Pedido creado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        respuestas.Fallido($"Error Al Crear el Pedido en DB.{ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                respuestas.Error500($"Error al crear el pedido CrearPedidoLN:{ex.Message}");
            }

            return Task.CompletedTask;
        }

        public Task ObtenerProductosLN()
        {
            // Lógica para crear un pedido
            try
            {
                using (PedidosDBContextAD pedidosDBContextAD = accesoDatos.ObtenerCadenaPedidos(configuration, environment))
                {
                    try
                    {
                        respuestas.Respuesta.Add("Productos",
                            pedidosDBContextAD.Producto
                            .AsNoTracking()
                            .OrderBy(p => p.IdProducto)
                            .Include(u => u.IdUnidadMedidaNavigation)
                            .Select(p => new
                            {
                                p.IdProducto,
                                p.NombreProducto,
                                p.DescripcionProducto,
                                NombreUnidad = p.IdUnidadMedidaNavigation != null ? p.IdUnidadMedidaNavigation.NombreUnidad : "Unidad desconocida",
                                NomenclarutaUnidad = p.IdUnidadMedidaNavigation != null ? p.IdUnidadMedidaNavigation.NomenclarutaUnidad : "Nomenclatura desconocida",
                                p.CantidadMedidaUnitaria,
                                p.ValorUnitario,
                                p.FechaCreacion,
                                p.UsuarioCreacion,
                                p.FechaActualizacion,
                                p.Activo
                            })
                            .ToList());
                    }
                    catch (Exception ex)
                    {
                        respuestas.Fallido($"Error Al Consultar Productos En DB.{ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                respuestas.Error500($"Error al consultar Productos ObtenerProductosLN:{ex.Message}");
            }
            return Task.CompletedTask;
        }

    }
}
