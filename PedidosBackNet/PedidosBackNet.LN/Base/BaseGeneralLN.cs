using PedidosBackNet.LN.Modelos;
using PedidosBackNet.LN.Utilidades;

namespace PedidosBackNet.LN.Base
{
    public class BaseGeneralLN
    {
        public readonly RespuestasLN respuestas;
        protected readonly ComponentesLN componenetes;
        protected readonly AccesoDatosLN accesoDatos;
        public BaseGeneralLN()
        {
            respuestas = new RespuestasLN();
            componenetes  = new ComponentesLN();
            accesoDatos  = new AccesoDatosLN();
        }
    }
}
