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
    public class ORDEN_COMPRA_RECEPCIONController : ApiController
    {
        ORDEN_COMPRA_RECEPCIONProceso bll = new ORDEN_COMPRA_RECEPCIONProceso();
      
        /// <summary>
        /// Funcion que devuelve el listado
        /// </summary>
        /// <returns>Devuelve un IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION></returns>
        [HttpGet]
        public IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION> Get(decimal pOperacion, string pPlanta_id, string pMicrosip_folio)
        {
            var returnValue = (IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION>)bll.Obtener(new VIEW_ORDEN_COMPRA_RECEPCION() { OPERACION = pOperacion, PLANTA_ID = pPlanta_id, MICROSIP_FOLIO = pMicrosip_folio }).Respuesta;
            return returnValue;
        }

        /// <summary>
        /// Funcion que devuelve el detalle de la tarima por lados
        /// </summary>
        /// <returns>Devuelve un IEnumerable<VIEW_ORDCOMP_RECEP_DETALLE_TARIMA></returns>
        [HttpGet]
        public IEnumerable<VIEW_ORDCOMP_RECEP_DETALLE_TARIMA> Get(decimal pOperacion, string pPlanta_id, string pTarima_id, decimal pOrden_Compra_Recepcion_id)
        {
            var returnValue = (IEnumerable<VIEW_ORDCOMP_RECEP_DETALLE_TARIMA>)bll.Obtener_LadosTarima(new VIEW_ORDCOMP_RECEP_DETALLE_TARIMA() { OPERACION = pOperacion, PLANTA_ID = pPlanta_id, TARIMA_ID = pTarima_id, ORDEN_COMPRA_RECEPCION_ID = pOrden_Compra_Recepcion_id }).Respuesta;
            return returnValue;
        }

        /// <summary>
        /// Funcion que devuelve el detalle de la tarima por lados
        /// </summary>
        /// <returns>Devuelve un IEnumerable<VIEW_ORDCOMP_RECEP_DETALLE_TARIMA></returns>
        [HttpGet]
        public IEnumerable<VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA> Get(decimal pOperacion, string pPlanta_id, decimal pOrden_Compra_Recepcion_id, decimal pUsusarioId)
        {
            var returnValue = (IEnumerable<VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA>)bll.Obtener_UsuarioAsignacionTarima(new VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA() { OPERACION = pOperacion, PLANTA_ID = pPlanta_id, USUARIO_ASIGNACION_ID = pUsusarioId, ORDEN_COMPRA_RECEPCION_ID = pOrden_Compra_Recepcion_id }).Respuesta;
            return returnValue;
        }

       


        ///// <summary>
        ///// Funcion que devuelve el listado
        ///// </summary>
        ///// <returns>Devuelve un IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION></returns>
        //[HttpGet]
        //public IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION> Get()
        //{
        //    var returnValue = (IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION>)bll.ObtenerResumen(null).Respuesta;
        //    return returnValue;
        //}

        ///// <summary>
        ///// Funcion para validar por id si existe el registro
        ///// </summary>
        ///// <param name="id">Parametro id a consultar</param>
        ///// <returns>Devuelve un IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION></returns>
        ////[HttpGet]
        ////public IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION> Get(int id)
        ////{
        ////    var returnValue = (IEnumerable<VIEW_ORDEN_COMPRA_RECEPCION>)bll.ValidarORDEN_COMPRA_RECEPCION(null, GlobalesLibrary.OPERACION_CONSULTAR, 0, new VIEW_ORDEN_COMPRA_RECEPCION { ORDEN_COMPRA_RECEPCION_ID = id }).Respuesta;
        ////    return returnValue;
        ////}

        ///// <summary>
        ///// Funcion para agregar un nuevo registro
        ///// </summary>
        ///// <param name="id">PAID_ID</param>
        ///// <param name="descripcion">DESCRIPCION</param>
        ///// <param name="desc_corta">DESC_CORTA</param>
        ///// <param name="usuario_alta_id">USUARIO_ALTA_ID</param>
        ///// <param name="fecha_alta">FECHA_ALTA</param>
        //[HttpPost]
        //public void Post(int id, string descripcion, string desc_corta, int usuario_alta_id, string fecha_alta)
        //{
        //    var returnValue = bll.ProcesoORDEN_COMPRA_RECEPCION(GlobalesLibrary.OPERACION_AGREGAR, new VIEW_ORDEN_COMPRA_RECEPCION { ORDEN_COMPRA_RECEPCION_ID = Convert.ToDecimal(id), USUARIO_ALTA_ID = Convert.ToDecimal(usuario_alta_id), FECHA_ALTA = Convert.ToDateTime(fecha_alta) }).Respuesta;

        //    if (Convert.ToBoolean(returnValue))
        //    {
        //        //Mensaje de retorno si es valio al accion
        //    }
        //    else
        //    {
        //        //Mensaje de retorno si no es valido la accion
        //    }
        //}

        ///// <summary>
        ///// Funcion para modificar un registro ya existente
        ///// </summary>
        ///// <param name="id">ORDEN_COMPRA_RECEPCION_ID</param>
        ///// <param name="descripcion">DESCRIPCION</param>
        ///// <param name="desc_corta">DESC_CORTA</param>
        ///// <param name="usuario_modifica_id">USUARIO_MODIFICA_ID</param>
        ///// <param name="fecha_modifica">FECHA_MODIFICA</param>
        //[HttpPut]
        //public void Put(int id, string descripcion, string desc_corta, int usuario_modifica_id, string fecha_modifica)
        //{
        //    var returnValue = bll.ProcesoORDEN_COMPRA_RECEPCION(GlobalesLibrary.OPERACION_MODIFICAR, new VIEW_ORDEN_COMPRA_RECEPCION { ORDEN_COMPRA_RECEPCION_ID = Convert.ToDecimal(id), USUARIO_MODIFICA_ID = Convert.ToDecimal(usuario_modifica_id), FECHA_MODIFICA = Convert.ToDateTime(fecha_modifica) }).Respuesta;

        //    if (Convert.ToBoolean(returnValue))
        //    {
        //        //Mensaje de retorno si es valio al accion
        //    }
        //    else
        //    {
        //        //Mensaje de retorno si no es valido la accion
        //    }
        //}

        ///// <summary>
        ///// Funcion para eliminar un registro ya existente
        ///// </summary>
        ///// <param name="id">ORDEN_COMPRA_RECEPCION_ID</param>
        ///// <param name="usuario_elimina_id">USUARIO_ELIMINA_ID</param>
        ///// <param name="fecha_elimina">FECHA_ELIMINA</param>
        //[HttpDelete]
        //public void Delete(int id, int usuario_elimina_id, string fecha_elimina)
        //{
        //    var returnValue = bll.ProcesoORDEN_COMPRA_RECEPCION(GlobalesLibrary.OPERACION_ELIMINAR, new VIEW_ORDEN_COMPRA_RECEPCION { ORDEN_COMPRA_RECEPCION_ID = Convert.ToDecimal(id), USUARIO_ELIMINA_ID = Convert.ToDecimal(usuario_elimina_id), FECHA_ELIMINA = Convert.ToDateTime(fecha_elimina) }).Respuesta;

        //    if (Convert.ToBoolean(returnValue))
        //    {
        //        //Mensaje de retorno si es valio al accion
        //    }
        //    else
        //    {
        //        //Mensaje de retorno si no es valido la accion
        //    }
        //}

    }
}
