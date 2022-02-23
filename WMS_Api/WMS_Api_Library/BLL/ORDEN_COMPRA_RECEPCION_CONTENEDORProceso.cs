using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ORDEN_COMPRA_RECEPCION_CONTENEDORProceso
{
    public ResultadoProceso ProcesoORDEN_COMPRA_RECEPCION_CONTENEDOR(int PROCESO, VIEW_ORDEN_COMPRA_RECEPCION_CONTENEDOR Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        ORDEN_COMPRA_RECEPCIONProceso bll = new ORDEN_COMPRA_RECEPCIONProceso();
        string Error = string.Empty;
        string Trans = this.GetType().ToString();
         object TipoMensaje=null;  object ControlTag=null;  object ParametroSalida=null;

        try
        {
            Cnn.Conectar();

           // Cnn.IniciarTransaccion(Trans);

           // Retorno = ValidarORDEN_COMPRA_RECEPCION(Cnn, PROCESO, Ent);

            if (!Retorno.HayError)
            {
                Retorno.MensajeRespuesta = dll.ProcesoORDEN_COMPRA_RECEPCION_CONTENEDOR(Cnn, ref Error, PROCESO, Ent, ref TipoMensaje, ref ControlTag, ref ParametroSalida);

                if (Retorno.MensajeRespuesta != null)
                {
                    Retorno.Respuesta = true;
                    Retorno.HayError = false;
                    Retorno.TipoMensaje = TipoMensaje;
                    Retorno.ValorSalida = ParametroSalida.ToString();
                    if (Convert.ToDecimal(ParametroSalida).ToString().Length >=12)
                    {
                        var returnValue = (IEnumerable<VIEW_ORDCOMP_RECEP_LADO_TARIMA>)dll.ObtenerORDEN_COMPRA_RECEPCION_LADO_TARIMA(Cnn, ref Error, new VIEW_ORDCOMP_RECEP_LADO_TARIMA() { OPERACION = 7, PLANTA_ID = Ent.PLANTA_ID, TARIMA_ID = Ent.TARIMA_ID, LADO = Ent.LADO_TARIMA, ORDEN_COMPRA_RECEPCION_ID = Ent.ORDEN_COMPRA_RECEPCION_ID, CONTENEDOR = ParametroSalida.ToString().Trim() });
                        Retorno.RespuestaEntidad = returnValue;
                    }

                }
                else
                {
                    if (Error.Trim().Length > 0)
                        Retorno.MensajeError = Error;
                    else
                        Retorno.MensajeError = string.Empty;

                    Retorno.Respuesta = false;
                    Retorno.HayError = true;
                }
            }
            else
            {
                Retorno.HayError = true;
                Retorno.MensajeError = Error;
            }

            if (Retorno.HayError)
            {
                //Cnn.CancelarTransaccion(Trans);
                Retorno.Respuesta = false;
            }
            else
            {
                //Cnn.ConfirmarTransaccion(Trans);
                Retorno.Respuesta = true;
            }

        }
        catch (Exception ex)
        {
            Retorno.HayError = true;
            Retorno.MensajeError = ex.ToString();
            Retorno.Respuesta = false;
        }
        finally
        {
            Cnn.Desconectar();
        }

        return Retorno;

    }
}

