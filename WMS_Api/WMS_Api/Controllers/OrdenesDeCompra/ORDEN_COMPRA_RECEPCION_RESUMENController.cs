using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WMS_Api.Controllers.OrdenesDeCompra
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ORDEN_COMPRA_RECEPCION_RESUMENController : ApiController
    {
        ORDEN_COMPRA_RECEPCIONProceso bll = new ORDEN_COMPRA_RECEPCIONProceso();
        /// <summary>
        /// Funcion que devuelve el listado
        /// </summary>
        /// <returns>Devuelve un IEnumerable<VIEW_ORDCOMP_RECEP_RESUMEN></returns>
        [HttpGet]
        public IEnumerable<VIEW_ORDCOMP_RECEP_RESUMEN> Get(decimal pOperacion, string pPlanta_id, string pTarima_id, decimal pOrden_Compra_Recepcion_id)
        {
            var returnValue = (IEnumerable<VIEW_ORDCOMP_RECEP_RESUMEN>)bll.Obtener_ResumenTarimaRecepcion(new VIEW_ORDCOMP_RECEP_RESUMEN() { OPERACION = pOperacion, PLANTA_ID = pPlanta_id, TARIMA_ID = pTarima_id, ORDEN_COMPRA_RECEPCION_ID = pOrden_Compra_Recepcion_id }).Respuesta;
            return returnValue;
        }


    }
}
