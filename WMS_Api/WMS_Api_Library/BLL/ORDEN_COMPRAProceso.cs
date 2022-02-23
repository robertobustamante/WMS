using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ORDEN_COMPRAProceso
{

    public ResultadoProceso Obtener(VIEW_ORDEN_COMPRA Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_ORDEN_COMPRA> ResLista = new List<VIEW_ORDEN_COMPRA>();

            Cnn.Conectar();

            ResLista = dll.ObtenerORDEN_COMPRA(Cnn, ref Error, Ent);

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

    public ResultadoProceso ObtenerResumen(VIEW_ORDEN_COMPRA Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_ORDEN_COMPRA> ResLista = new List<VIEW_ORDEN_COMPRA>();

            Cnn.Conectar();

            ResLista = dll.ObtenerORDEN_COMPRA(Cnn, ref Error, Ent); //OPERACION 6 - OBTENER RESUMEN

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

    public ResultadoProceso ValidarORDEN_COMPRA(Conectividad Cnn, int PROCESO, VIEW_ORDEN_COMPRA Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;
        VIEW_ORDEN_COMPRA vEnt = new VIEW_ORDEN_COMPRA();
        bool ConexionIniciada = false;

        try
        {
            List<VIEW_ORDEN_COMPRA> ResLista = new List<VIEW_ORDEN_COMPRA>();

            if (Cnn == null)
            {
                ConexionIniciada = true;
                Cnn = new Conectividad();
                Cnn.Conectar();
            }

            vEnt.ORDEN_COMPRA_ID = Ent.ORDEN_COMPRA_ID;

            ResLista = dll.ObtenerORDEN_COMPRA(Cnn, ref Error, vEnt);

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

    //public ResultadoProceso ValidarORDEN_COMPRAProceso(Conectividad Cnn, int PROCESO, int LLAMADO_REFERENCIA, VIEW_ORDEN_COMPRA Ent)
    //{
    //    ResultadoProceso Retorno = new ResultadoProceso();
    //    AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
    //    string Error = string.Empty;
    //    VIEW_ORDEN_COMPRA vEnt = new VIEW_ORDEN_COMPRA();
    //    bool ConexionIniciada = false;
    //    string Mensaje = string.Empty;
    //    object TipoRespuesta = 0;
    //    object ControlTag = 0;
    //    object ParametroSalida = 0;

    //    try
    //    {
    //        List<VIEW_ORDEN_COMPRA> ResLista = new List<VIEW_ORDEN_COMPRA>();

    //        if (Cnn == null)
    //        {
    //            ConexionIniciada = true;
    //            Cnn = new Conectividad();
    //            Cnn.Conectar();
    //        }

    //        vEnt.ORDEN_COMPRA_ID = Ent.ORDEN_COMPRA_ID;

    //        ResLista = dll.ObtenerORDEN_COMPRA(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, vEnt);

    //        if (PROCESO == GlobalesLibrary.OPERACION_CONSULTAR)
    //        {
    //            if (ResLista.Count > 0)
    //            {
    //                Retorno.HayError = false;
    //                Retorno.Respuesta = ResLista;
    //            }
    //            else
    //            {
    //                Retorno.HayError = true;
    //                Retorno.Respuesta = null;
    //            }
    //        }
    //        else
    //        {
    //            if (ResLista.Count > 0 && PROCESO != GlobalesLibrary.OPERACION_ELIMINAR && PROCESO != GlobalesLibrary.OPERACION_MODIFICAR)
    //            {
    //                Retorno.HayError = true;
    //                Retorno.MensajeError = ProcesosComunes.ObtenerTexto(GlobalesLibrary.GUsuario.IDIOMA_ID, 101);
    //            }
    //            Mensaje = dll.ProcesoORDEN_COMPRA_VALIDA(Cnn, ref Error, PROCESO, ref TipoRespuesta, ref ControlTag, Ent, ref ParametroSalida);
    //            if (Mensaje.Trim().Length > 0)
    //            {
    //                Retorno.MensajeRespuesta = Mensaje;
    //                Retorno.MensajeError = Mensaje;
    //                Retorno.TipoRespuesta = Convert.ToInt32(TipoRespuesta);
    //                Retorno.ControlTag = ControlTag;
    //                Retorno.HayError = true;
    //            }
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        Retorno.HayError = true;
    //        Retorno.MensajeError = ex.ToString();
    //        Retorno.Respuesta = false;
    //    }

    //    if (ConexionIniciada)
    //        Cnn.Desconectar();

    //    return Retorno;

    //}

    public ResultadoProceso ProcesoORDEN_COMPRA(int PROCESO, VIEW_ORDEN_COMPRA Ent)
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

            Retorno = ValidarORDEN_COMPRA(Cnn, PROCESO, Ent);

            if (!Retorno.HayError)
            {
                if (dll.ProcesoORDEN_COMPRA(Cnn, ref Error, PROCESO, Ent))
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
