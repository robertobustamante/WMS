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
    public class OCR_MATERIALController : ApiController
    {
        ORDEN_COMPRA_RECEPCION_MATERIALProceso bll = new ORDEN_COMPRA_RECEPCION_MATERIALProceso();


        [HttpGet]
        public IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION_MATERIAL> Get(decimal pOperacion, string pPlanta_id, decimal pOrden_Compra_Recepcion_id)
        {
            var returnValue = (IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION_MATERIAL>)bll.Obtener(new VIEW_ORDEN_COMPRA_RECEPCION_MATERIAL() { OPERACION = pOperacion, PLANTA_ID = pPlanta_id, ORDEN_COMPRA_RECEPCION_ID = pOrden_Compra_Recepcion_id }).Respuesta;
            return returnValue;
        }
    }
}
