using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WMS_Api.Controllers.Catalogos
{
    public class PAISController : ApiController
    {
        PAISProceso bll = new PAISProceso();

        /// <summary>
        /// Funcion que devuelve el listado
        /// </summary>
        /// <returns>Devuelve un IEnumerable<VIEW_PAIS></returns>
        [HttpGet]
        public IEnumerable<VIEW_PAIS> Get()
        {
            var returnValue = (IEnumerable<VIEW_PAIS>)bll.Obtener(null, 0).Respuesta;
            return returnValue;
        }

        /// <summary>
        /// Funcion para validar por id si existe el registro
        /// </summary>
        /// <param name="id">Parametro id a consultar</param>
        /// <returns>Devuelve un IEnumerable<VIEW_PAIS></returns>
        [HttpGet]
        public IEnumerable<VIEW_PAIS> Get(int id)
        {
            var returnValue = (IEnumerable<VIEW_PAIS>)bll.ValidarPAIS(null, GlobalesLibrary.OPERACION_CONSULTAR, 0, new VIEW_PAIS { PAIS_ID = id }).Respuesta;
            return returnValue;
        }

        /// <summary>
        /// Funcion para agregar un nuevo registro
        /// </summary>
        /// <param name="id">PAID_ID</param>
        /// <param name="descripcion">DESCRIPCION</param>
        /// <param name="desc_corta">DESC_CORTA</param>
        /// <param name="usuario_alta_id">USUARIO_ALTA_ID</param>
        /// <param name="fecha_alta">FECHA_ALTA</param>
        [HttpPost]
        public void Post(int id, string descripcion, string desc_corta, int usuario_alta_id, string fecha_alta)
        {
            var returnValue = bll.ProcesoPAIS(GlobalesLibrary.OPERACION_AGREGAR, new VIEW_PAIS { PAIS_ID = Convert.ToDecimal(id), DESCRIPCION = descripcion, DESC_CORTA = desc_corta, USUARIO_ALTA_ID = Convert.ToDecimal(usuario_alta_id), FECHA_ALTA = Convert.ToDateTime(fecha_alta) }).Respuesta;
            
            if (Convert.ToBoolean(returnValue))
            {
                //Mensaje de retorno si es valio al accion
            }
            else
            {
                //Mensaje de retorno si no es valido la accion
            }
        }

        /// <summary>
        /// Funcion para modificar un registro ya existente
        /// </summary>
        /// <param name="id">PAIS_ID</param>
        /// <param name="descripcion">DESCRIPCION</param>
        /// <param name="desc_corta">DESC_CORTA</param>
        /// <param name="usuario_modifica_id">USUARIO_MODIFICA_ID</param>
        /// <param name="fecha_modifica">FECHA_MODIFICA</param>
        [HttpPut]
        public void Put(int id, string descripcion, string desc_corta, int usuario_modifica_id, string fecha_modifica)
        {
            var returnValue = bll.ProcesoPAIS(GlobalesLibrary.OPERACION_MODIFICAR, new VIEW_PAIS { PAIS_ID = Convert.ToDecimal(id), DESCRIPCION = descripcion, DESC_CORTA = desc_corta, USUARIO_MODIFICA_ID = Convert.ToDecimal(usuario_modifica_id), FECHA_MODIFICA = Convert.ToDateTime(fecha_modifica) }).Respuesta;

            if (Convert.ToBoolean(returnValue))
            {
                //Mensaje de retorno si es valio al accion
            }
            else
            {
                //Mensaje de retorno si no es valido la accion
            }
        }

        /// <summary>
        /// Funcion para eliminar un registro ya existente
        /// </summary>
        /// <param name="id">PAIS_ID</param>
        /// <param name="usuario_elimina_id">USUARIO_ELIMINA_ID</param>
        /// <param name="fecha_elimina">FECHA_ELIMINA</param>
        [HttpDelete]
        public void Delete(int id, int usuario_elimina_id, string fecha_elimina)
        {
            var returnValue = bll.ProcesoPAIS(GlobalesLibrary.OPERACION_ELIMINAR, new VIEW_PAIS { PAIS_ID = Convert.ToDecimal(id), USUARIO_ELIMINA_ID = Convert.ToDecimal(usuario_elimina_id), FECHA_ELIMINA = Convert.ToDateTime(fecha_elimina) }).Respuesta;

            if (Convert.ToBoolean(returnValue))
            {
                //Mensaje de retorno si es valio al accion
            }
            else
            {
                //Mensaje de retorno si no es valido la accion
            }
        }

    }
}
