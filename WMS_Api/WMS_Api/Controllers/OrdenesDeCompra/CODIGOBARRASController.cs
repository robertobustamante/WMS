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
    public class CODIGOBARRASController : ApiController
    {
        ORDEN_COMPRA_RECEPCION_CONTENEDORProceso bll = new ORDEN_COMPRA_RECEPCION_CONTENEDORProceso();

        [HttpPost]
        public ResultadoProceso Post(string pPlanta_id, decimal pOrden_Compra_Recepcion_id, string pTarima_id, string pLado_Tarima, string pCodigo_Barras, string pMacAddress, int pusuario_modifica_id, decimal pMaterial, decimal pCantidad_Menor)
        {
            ResultadoProceso resultado = new ResultadoProceso();
            VIEW_ORDEN_COMPRA_RECEPCION_CONTENEDOR pEnt = new VIEW_ORDEN_COMPRA_RECEPCION_CONTENEDOR();
            pEnt.PLANTA_ID = pPlanta_id;
            pEnt.ORDEN_COMPRA_RECEPCION_ID = pOrden_Compra_Recepcion_id;
            pEnt.TARIMA_ID = pTarima_id;
            pEnt.LADO_TARIMA = pLado_Tarima;
            pEnt.CODIGO_BARRAS = pCodigo_Barras;
            pEnt.MACADDRESS = pMacAddress;
            pEnt.USUARIO_ALTA_ID = Convert.ToDecimal(pusuario_modifica_id);
            pEnt.ES_ORDEN_COMPRA = 1;
            if (pMaterial > 0) { pEnt.MATERIAL_ID = pMaterial; };
            if (pCantidad_Menor > 0) { pEnt.CANTIDAD_MEN_NETO = pCantidad_Menor; };
            resultado = bll.ProcesoORDEN_COMPRA_RECEPCION_CONTENEDOR(GlobalesLibrary.OPERACION_AGREGAR, pEnt);

            return resultado;
        }
    }
}
