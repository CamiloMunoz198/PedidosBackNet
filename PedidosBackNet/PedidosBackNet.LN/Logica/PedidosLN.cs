using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PedidosBackNet.AD.Contextos;
using PedidosBackNet.AD.Entidades;
using PedidosBackNet.EN.Modelos;
using PedidosBackNet.LN.Base;
using System;
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
                        var nuevaOrden = new Orden
                        {
                            IdCliente = pedidoEN.IdCliente,
                            IdProducto = pedidoEN.IdProducto,
                            IdAlmacenamiento = pedidoEN.IdAlmacenamiento,
                            IdCanal = pedidoEN.IdCanal,
                            Cantidad = pedidoEN.Cantidad,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = pedidoEN.UsuarioCreacion,
                            Activo = true,
                        };
                        pedidosDBContextAD.Orden.Add(nuevaOrden);
                        pedidosDBContextAD.SaveChanges();

                        var ran = new Random().Next(0, 100);
                        //Datos de integracion con el proveedor No Implementado aun
                        EntregaEN entregaEN = new EntregaEN()
                        {
                            CodigoEntrega = "ENT-" + Convert.ToString(ran),
                            IdEstatusEntrega=1
                        };


                        var nuevaEntrega = new Entrega
                        {
                            CodigoEntrega = entregaEN.CodigoEntrega,
                            IdOrden = nuevaOrden.IdOrden,
                            IdEstatusEntrega = entregaEN.IdEstatusEntrega,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = pedidoEN.UsuarioCreacion,
                            Activo = true,
                        };

                        pedidosDBContextAD.Entrega.Add(nuevaEntrega);
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
                                p.IdUnidadMedida,
                                NombreUnidad = p.IdUnidadMedidaNavigation != null ? p.IdUnidadMedidaNavigation.NombreUnidad : "Unidad desconocida",
                                NomenclarutaUnidad = p.IdUnidadMedidaNavigation != null ? p.IdUnidadMedidaNavigation.NomenclarutaUnidad : "Nomenclatura desconocida",
                                p.CantidadMedidaUnitaria,
                                p.ValorUnitario,
                                p.FechaCreacion,
                                p.UsuarioCreacion,
                                p.FechaActualizacion,
                                p.UsuarioActualizacion,
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

        public Task ObtenerInventarioLN()
        {
            // Lógica para obtener inventario
            try
            {
                using (PedidosDBContextAD pedidosDBContextAD = accesoDatos.ObtenerCadenaPedidos(configuration, environment))
                {
                    try
                    {
                        respuestas.Respuesta.Add("Inventario",
                            pedidosDBContextAD.Inventario
                            .AsNoTracking()
                            .OrderBy(p => p.IdProducto)
                            .Include(p => p.IdProductoNavigation)
                            .Include(u => u.IdProductoNavigation.IdUnidadMedidaNavigation)
                            .Include(a => a.IdAlmacenamientoNavigation)
                            .Include(t=> t.IdAlmacenamientoNavigation.IdTipoAlmacenamientoNavigation)
                            .Select(p => new
                            {
                                p.IdProducto,
                                NombreProducto = p.IdProductoNavigation != null ? p.IdProductoNavigation.NombreProducto : "Producto desconocido",
                                DescripcionProducto = p.IdProductoNavigation != null ? p.IdProductoNavigation.DescripcionProducto : "Descripción desconocida",
                                NombreUnidad = p.IdProductoNavigation != null && p.IdProductoNavigation.IdUnidadMedidaNavigation != null ? p.IdProductoNavigation.IdUnidadMedidaNavigation.NombreUnidad : "Unidad desconocida",
                                NomenclarutaUnidad = p.IdProductoNavigation != null && p.IdProductoNavigation.IdUnidadMedidaNavigation != null ? p.IdProductoNavigation.IdUnidadMedidaNavigation.NomenclarutaUnidad : "Nomenclatura desconocida",
                                CantidadMedidaUnitaria = p.IdProductoNavigation != null ? p.IdProductoNavigation.CantidadMedidaUnitaria ?? 0 : 0,
                                ValorUnitario = p.IdProductoNavigation != null ? p.IdProductoNavigation.ValorUnitario ?? 0 : 0,
                                p.Cantidad,
                                p.IdAlmacenamiento,
                                p.IdAlmacenamientoNavigation.IdTipoAlmacenamiento,
                                NombreTipoAlmacenamiento = p.IdAlmacenamientoNavigation != null && p.IdAlmacenamientoNavigation.IdTipoAlmacenamientoNavigation != null ?
                                p.IdAlmacenamientoNavigation.IdTipoAlmacenamientoNavigation.NombreTipoAlmacenamiento : "Nombre Tipo Almacenamiento Desconocido",
                                NombreAlmacenamiento = p.IdAlmacenamientoNavigation != null ? p.IdAlmacenamientoNavigation.NombreAlmacenamiento : "Nombre Almacenamiento Desconocido",
                                CodigoCiudad = p.IdAlmacenamientoNavigation != null ? p.IdAlmacenamientoNavigation.CodigoCiudad : "Codigo Ciudad Desconocido",
                                NombreCiudad = p.IdAlmacenamientoNavigation != null && p.IdAlmacenamientoNavigation.Ciudad!=null ? 
                                p.IdAlmacenamientoNavigation.Ciudad.NombreCiudad : "Nombre Ciudad Desconocida",
                                CodigoDepartamento = p.IdAlmacenamientoNavigation != null ? p.IdAlmacenamientoNavigation.CodigoDepartamento : "Codigo Departamento Desconocido",
                                NombreDepartamento = p.IdAlmacenamientoNavigation != null  && p.IdAlmacenamientoNavigation.Ciudad!= null && p.IdAlmacenamientoNavigation.Ciudad.CodigoDepartamentoNavigation != null ?
                                p.IdAlmacenamientoNavigation.Ciudad.CodigoDepartamentoNavigation.NombreDepartamento : "Nombre Departamento Desconocido",
                                DireccionAlmacenamiento= p.IdAlmacenamientoNavigation !=null?p.IdAlmacenamientoNavigation.DireccionAlmacenamiento: "Direccion Desconocida",
                                NumeroAlmacenamiento=p.IdAlmacenamientoNavigation!= null? p.IdAlmacenamientoNavigation.NumeroContactoAlmacenamiento:0,
                                p.FechaCreacion,
                                p.UsuarioCreacion,
                                p.FechaActualizacion,
                                p.UsuarioActualizacion,
                                p.Activo
                            })
                            .ToList());
                    }
                    catch (Exception ex)
                    {
                        respuestas.Fallido($"Error Al Consultar Inventario En DB. {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                respuestas.Error500($"Error al consultar Inventario ObtenerInventarioLN: {ex.Message}");
            }
            return Task.CompletedTask;
        }

        public Task ObtenerClientesLN()
        {
            // Lógica para crear un pedido
            try
            {
                using (PedidosDBContextAD pedidosDBContextAD = accesoDatos.ObtenerCadenaPedidos(configuration, environment))
                {
                    try
                    {
                        respuestas.Respuesta.Add("Clientes",
                            pedidosDBContextAD.Cliente
                            .AsNoTracking()
                            .OrderBy(p => p.IdCliente)
                            .Include(u => u.IdTipoClienteNavigation)
                            .Include(c => c.Ciudad)
                            .ThenInclude(d => d.CodigoDepartamentoNavigation)
                            .Select(p => new
                            {
                                p.IdCliente,
                                TipoCliente = p.IdTipoClienteNavigation != null ? p.IdTipoClienteNavigation.NombreTipoCliente : "Tipo Cliente Desconocido",
                                p.NombresCliente,
                                p.DireccionCliente,
                                p.CelularCliente,
                                p.BarrioCliente,
                                p.CodigoDepartamento,
                                Departamento = p.Ciudad != null && p.Ciudad.CodigoDepartamentoNavigation != null? 
                                p.Ciudad.CodigoDepartamentoNavigation.NombreDepartamento: "Departamento Desconocido",
                                p.CodigoCiudad,
                                Ciudad = p.Ciudad != null ? p.Ciudad.NombreCiudad : "Ciudad Desconocida",
                                p.FechaCreacion,
                                p.UsuarioCreacion,
                                p.FechaActualizacion,
                                p.UsuarioActualizacion,
                                p.Activo
                            })
                            .ToList());
                    }
                    catch (Exception ex)
                    {
                        respuestas.Fallido($"Error Al Consultar Clientes En DB.{ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                respuestas.Error500($"Error al consultar Clientes ObtenerClientesLN:{ex.Message}");
            }
            return Task.CompletedTask;
        }

    }
}
