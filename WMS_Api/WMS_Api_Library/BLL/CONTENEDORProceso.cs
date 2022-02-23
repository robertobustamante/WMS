using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CONTENEDORProceso
{

    public ResultadoProceso Obtener(VIEW_CONTENEDOR Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatos dll = new AccesoDatos();
        string Error = string.Empty;

        try
        {
            List<VIEW_CONTENEDOR> ResLista = new List<VIEW_CONTENEDOR>();

            Cnn.Conectar();

            ResLista = dll.ObtenerCONTENEDOR(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, Ent);

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

    public ResultadoProceso ValidarCONTENEDOR(Conectividad Cnn, int PROCESO, VIEW_CONTENEDOR Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        AccesoDatos dll = new AccesoDatos();
        string Error = string.Empty;
        VIEW_CONTENEDOR vEnt = new VIEW_CONTENEDOR();
        bool ConexionIniciada = false;

        try
        {
            List<VIEW_CONTENEDOR> ResLista = new List<VIEW_CONTENEDOR>();

            if (Cnn == null)
            {
                ConexionIniciada = true;
                Cnn = new Conectividad();
                Cnn.Conectar();
            }

            vEnt.CONTENEDOR_ID = Ent.CONTENEDOR_ID;

            ResLista = dll.ObtenerCONTENEDOR(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, vEnt);

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

    public ResultadoProceso ProcesoCONTENEDOR(int PROCESO, VIEW_CONTENEDOR Ent)
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

            Retorno = ValidarCONTENEDOR(Cnn, PROCESO, Ent);

            if (!Retorno.HayError)
            {
                if (dll.ProcesoCONTENEDOR(Cnn, ref Error, PROCESO, Ent))
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