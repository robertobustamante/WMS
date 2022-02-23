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
    public class OCR_ASIGNA_TARIMAController : ApiController
    {
        ORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMAProceso bllRT = new ORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMAProceso();
        [HttpPut]
        public ResultadoProceso Put(string pPlanta_id, decimal pOrden_Compra_Recepcion_id, string pTarima_id, decimal Estatus, int pusuario_id)
        {
            ResultadoProceso resultado = new ResultadoProceso();
            VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA pEnt = new VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA();
            pEnt.PLANTA_ID = pPlanta_id;
            pEnt.ORDEN_COMPRA_RECEPCION_ID = pOrden_Compra_Recepcion_id;
            pEnt.TARIMA_ID = pTarima_id;
            pEnt.USUARIO_ASIGNACION_ID = Convert.ToDecimal(pusuario_id);
            pEnt.USUARIO_MODIFICA_ID = Convert.ToDecimal(pusuario_id);
            pEnt.ESTATUS = Estatus;
            resultado = bllRT.ProcesoORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA(GlobalesLibrary.OPERACION_MODIFICAR, pEnt);

            return resultado;
        }
    }
}
