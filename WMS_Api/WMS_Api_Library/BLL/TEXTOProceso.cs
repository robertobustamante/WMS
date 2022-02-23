using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TEXTOProceso
{

    public ResultadoProceso Obtener(VIEW_TEXTO Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatos dll = new AccesoDatos();
        string Error = string.Empty;

        try
        {
            List<VIEW_TEXTO> ResLista = new List<VIEW_TEXTO>();

            Cnn.Conectar();

            ResLista = dll.ObtenerTEXTO(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, Ent);

            if (ResLista.Count > 0)
            {
                Retorno.HayError = false;
                Retorno.Respuesta = ResLista;
            }
            else
            {
                if (Error.Trim().Length > 0)
                {
                    Retorno.MensajeError = Error;
                    Retorno.HayError = true;
                }
                else
                {
                    Retorno.HayError = false;
                }

                Retorno.Respuesta = null;
            }

        }
        catch (Exception ex)
        {
            Retorno.HayError = true;
            Retorno.MensajeError = ex.ToString();
            Retorno.Respuesta = null;
        }
        finally
        {
            Cnn.Desconectar();
        }

        return Retorno;
    }

    public ResultadoProceso ValidarTEXTO(Conectividad Cnn, int PROCESO, VIEW_TEXTO Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        AccesoDatos dll = new AccesoDatos();
        string Error = string.Empty;

        try
        {

        }
        catch (Exception ex)
        {
            Retorno.HayError = true;
            Retorno.MensajeError = ex.ToString();
            Retorno.Respuesta = false;
        }

        return Retorno;

    }

    public ResultadoProceso ProcesoTEXTO(int PROCESO, VIEW_TEXTO Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatos dll = new AccesoDatos();
        string Error = string.Empty;
        string Trans = this.GetType().ToString();

        try
        {
            Cnn.Conectar();

            Cnn.IniciarTransaccion(Trans);

            Retorno = ValidarTEXTO(Cnn, PROCESO, Ent);

            if (!Retorno.HayError)
            {
                if (dll.ProcesoTEXTO(Cnn, ref Error, PROCESO, Ent))
                {
                    Retorno.Respuesta = true;
                    Retorno.HayError = false;
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