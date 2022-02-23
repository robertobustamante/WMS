using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PAISProceso
{

    public ResultadoProceso Obtener(VIEW_PAIS Ent = null, int LLAMADO_REFERENCIA = 0)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_PAIS> ResLista = new List<VIEW_PAIS>();

            Cnn.Conectar();

            ResLista = dll.ObtenerPAIS(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, LLAMADO_REFERENCIA, Ent);

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

    public ResultadoProceso ValidarPAIS(Conectividad Cnn, int PROCESO, int LLAMADO_REFERENCIA, VIEW_PAIS Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;
        VIEW_PAIS vEnt = new VIEW_PAIS();
        bool ConexionIniciada = false;

        try
        {
            List<VIEW_PAIS> ResLista = new List<VIEW_PAIS>();

            if (Cnn == null)
            {
                ConexionIniciada = true;
                Cnn = new Conectividad();
                Cnn.Conectar();
            }

            vEnt.PAIS_ID = Ent.PAIS_ID;

            ResLista = dll.ObtenerPAIS(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, LLAMADO_REFERENCIA, vEnt);

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

    public ResultadoProceso ValidarPAISProceso(Conectividad Cnn, int PROCESO, int LLAMADO_REFERENCIA, VIEW_PAIS Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;
        VIEW_PAIS vEnt = new VIEW_PAIS();
        bool ConexionIniciada = false;
        string Mensaje = string.Empty;
        object TipoRespuesta = 0;
        object ControlTag = 0;
        object ParametroSalida = 0;

        try
        {
            List<VIEW_PAIS> ResLista = new List<VIEW_PAIS>();

            if (Cnn == null)
            {
                ConexionIniciada = true;
                Cnn = new Conectividad();
                Cnn.Conectar();
            }

            vEnt.PAIS_ID = Ent.PAIS_ID;

            ResLista = dll.ObtenerPAIS(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, LLAMADO_REFERENCIA, vEnt);

            if (PROCESO == GlobalesLibrary.OPERACION_CONSULTAR)
            {
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
            }
            else
            {
                if (ResLista.Count > 0 && PROCESO != GlobalesLibrary.OPERACION_ELIMINAR && PROCESO != GlobalesLibrary.OPERACION_MODIFICAR)
                {
                    Retorno.HayError = true;
                    Retorno.MensajeError = ProcesosComunes.ObtenerTexto(GlobalesLibrary.GUsuario.IDIOMA_ID, 101);
                }
                Mensaje = dll.ProcesoPAIS_VALIDA(Cnn, ref Error, PROCESO, ref TipoRespuesta, ref ControlTag, Ent, ref ParametroSalida);
                if (Mensaje.Trim().Length > 0)
                {
                    Retorno.MensajeRespuesta = Mensaje;
                    Retorno.MensajeError = Mensaje;
                    Retorno.TipoRespuesta = Convert.ToInt32(TipoRespuesta);
                    Retorno.ControlTag = ControlTag;
                    Retorno.HayError = true;
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

    public ResultadoProceso ProcesoPAIS(int PROCESO, VIEW_PAIS Ent)
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

            Retorno = ValidarPAIS(Cnn, PROCESO, 0, Ent);

            if (!Retorno.HayError)
            {
                if (dll.ProcesoPAIS(Cnn, ref Error, PROCESO, Ent))
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
