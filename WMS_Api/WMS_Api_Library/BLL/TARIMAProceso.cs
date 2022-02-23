using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TARIMAProceso
{

    public ResultadoProceso Obtener(VIEW_TARIMA Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatos dll = new AccesoDatos();
        string Error = string.Empty;

        try
        {
            List<VIEW_TARIMA> ResLista = new List<VIEW_TARIMA>();

            Cnn.Conectar();

            ResLista = dll.ObtenerTARIMA(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, Ent);

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

    public ResultadoProceso ValidarTARIMA(Conectividad Cnn, int PROCESO, VIEW_TARIMA Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        AccesoDatos dll = new AccesoDatos();
        string Error = string.Empty;
        int TipoMensaje = 0;
        VIEW_TARIMA vEnt = new VIEW_TARIMA();
        bool ConexionIniciada = false;

        try
        {
            List<VIEW_TARIMA> ResLista = new List<VIEW_TARIMA>();

            if (Cnn == null)
            {
                ConexionIniciada = true;
                Cnn = new Conectividad();
                Cnn.Conectar();
            }

            vEnt.TARIMA_ID = Ent.TARIMA_ID;

            ResLista = dll.ObtenerTARIMA(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, vEnt);

            switch (PROCESO)
            {
                case GlobalesLibrary.OPERACION_CONSULTAR:
                    if (ResLista.Count > 0)
                    {
                        Retorno.HayError = false;
                        Retorno.Respuesta = ResLista;
                    }
                    else
                    {
                        Retorno.HayError = true;
                        Retorno.Respuesta = null;
                    }
                    break;
                case GlobalesLibrary.OPERACION_AGREGAR:
                    if (ResLista.Count > 0)
                    {
                        Retorno.HayError = true;
                        Retorno.MensajeError = ProcesosComunes.ObtenerTexto(GlobalesLibrary.GUsuario.IDIOMA_ID, 101);
                    }
                    break;
                case GlobalesLibrary.OPERACION_MODIFICAR:
                    if (ResLista.Count <= 0)
                    {
                        Retorno.HayError = true;
                        Retorno.MensajeError = ProcesosComunes.ObtenerTexto(GlobalesLibrary.GUsuario.IDIOMA_ID, 102);
                    }
                    break;
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

    public ResultadoProceso ProcesoTARIMA(int PROCESO, VIEW_TARIMA Ent)
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

            Retorno = ValidarTARIMA(Cnn, PROCESO, Ent);

            if (!Retorno.HayError)
            {
                if (dll.ProcesoTARIMA(Cnn, ref Error, PROCESO, Ent))
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