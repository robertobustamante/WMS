using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WMS_Api.Controllers.Catalogos
{
    [EnableCors(origins: "http://25.87.145.217:85", headers: "*", methods: "*")]
    public class TEXTOController : ApiController
    {
        TEXTOProceso bll = new TEXTOProceso();

        /// <summary>
        /// Funcion que devuelve el listado
        /// </summary>
        /// <returns>Devuelve un IEnumerable<VIEW_PAIS></returns>
        [HttpGet]
        public IEnumerable<VIEW_TEXTO> Get()
        {
            var returnValue = (IEnumerable<VIEW_TEXTO>)bll.Obtener(null).Respuesta;
            return returnValue;
        }

        /// <summary>
        /// Funcion para validar por id si existe el registro
        /// </summary>
        /// <param name="id">Parametro id a consultar</param>
        /// <returns>Devuelve un IEnumerable<VIEW_PAIS></returns>
        [HttpGet]
        public IEnumerable<VIEW_TEXTO> Get(int id)
        {
            var returnValue = (IEnumerable<VIEW_TEXTO>)bll.ValidarTEXTO(null, GlobalesLibrary.OPERACION_CONSULTAR, new VIEW_TEXTO { TEXTO_ID = id }).Respuesta;
            return returnValue;
        }

    }
}
