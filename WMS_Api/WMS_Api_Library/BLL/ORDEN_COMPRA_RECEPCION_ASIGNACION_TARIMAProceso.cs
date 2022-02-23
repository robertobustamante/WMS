using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMAProceso
{

    public ResultadoProceso ValidarORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA(Conectividad Cnn, int PROCESO, VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;
        string Mensaje = string.Empty;
        object TipoRespuesta = 0;
        object ControlTag = 0;
        object ParametroSalida = 0;
        bool ConexionIniciada = false;
        VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA vEnt = new VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA();

        try
        {
            List<VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA> ResLista = new List<VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA>();

            if (Cnn == null)
            {
                ConexionIniciada = true;
                Cnn = new Conectividad();
                Cnn.Conectar();
            }
            vEnt.PLANTA_ID = Ent.PLANTA_ID;
            vEnt.ORDEN_COMPRA_RECEPCION_ID = Ent.ORDEN_COMPRA_RECEPCION_ID;
            vEnt.USUARIO_ASIGNACION_ID = Ent.USUARIO_ASIGNACION_ID;
            vEnt.TARIMA_ID = Ent.TARIMA_ID;

            // ResLista = dll.(Cnn, ref Error, vEnt);


            if (PROCESO == GlobalesLibrary.OPERACION_MODIFICAR)
            {
                Mensaje = dll.ProcesoORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA_VALIDA(Cnn, ref Error, PROCESO, ref TipoRespuesta, ref ControlTag, Ent,ref ParametroSalida);
                if (Mensaje.Trim().Length > 0)
                {
                    Retorno.MensajeRespuesta = Mensaje;
                    Retorno.TipoRespuesta = Convert.ToInt32(TipoRespuesta);
                    Retorno.ControlTag = ControlTag;
                    Retorno.ValorSalida = ParametroSalida;
                }
            }        
        }
        catch (Exception ex)
        {
            Retorno.HayError = true;
            Retorno.MensajeError = ex.ToString();
            Retorno.Respuesta = false;
        }

        if (ConexionIniciada)
            Cnn.Desconectar();

        return Retorno;

    }
    public ResultadoProceso ProcesoORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA(int PROCESO, VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;
        string Trans = this.GetType().ToString();

        try
        {
            Cnn.Conectar();

            Cnn.IniciarTransaccion(Trans);

            Retorno = ValidarORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA(Cnn, PROCESO, Ent);

            if (!Retorno.HayError)
            {
                if (dll.ProcesoORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA(Cnn, ref Error, PROCESO, Ent))
                {
                    Retorno.Respuesta = true;
                    Retorno.HayError = false;
                    Retorno.ValorSalida = "200";
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
                Cnn.CancelarTransaccion(Trans);
                Retorno.Respuesta = false;
            }
            else
            {
                Cnn.ConfirmarTransaccion(Trans);
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

