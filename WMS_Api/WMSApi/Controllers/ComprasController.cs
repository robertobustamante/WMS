using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WMSApi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        ORDEN_COMPRAProceso bllOC = new ORDEN_COMPRAProceso();
        ORDEN_COMPRA_RECEPCIONProceso bllOCR = new ORDEN_COMPRA_RECEPCIONProceso();
        
        [HttpGet("GetTablaOrdenCompra")]
        public async Task<ActionResult<List<VIEW_ORDEN_COMPRA>>> GetTablaOrdenCompra(string idPlanta)
        {
            return  (List<VIEW_ORDEN_COMPRA>)bllOC.Obtener(new VIEW_ORDEN_COMPRA() { OPERACION = 6, PLANTA_ID = idPlanta }).Respuesta;
        }

        [HttpGet("GetTablaReceocion")]
        public async Task<ActionResult<List<VIEW_ORDEN_COMPRA_RECEPCION>>> GetTablaRecepcion(string idPlanta, string folioMicrosip)
        {
            return (List<VIEW_ORDEN_COMPRA_RECEPCION>)bllOCR.Obtener(new VIEW_ORDEN_COMPRA_RECEPCION() { OPERACION = 6, PLANTA_ID = idPlanta, MICROSIP_FOLIO = folioMicrosip }).Respuesta;
        }
    }
}