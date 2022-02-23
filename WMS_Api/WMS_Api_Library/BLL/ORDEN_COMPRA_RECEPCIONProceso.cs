using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ORDEN_COMPRA_RECEPCIONProceso
{

    public ResultadoProceso Obtener(VIEW_ORDEN_COMPRA_RECEPCION Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_ORDEN_COMPRA_RECEPCION> ResLista = new List<VIEW_ORDEN_COMPRA_RECEPCION>();

            Cnn.Conectar();

            ResLista = dll.ObtenerORDEN_COMPRA_RECEPCION(Cnn, ref Error, Ent);

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

    public ResultadoProceso Obtener_LadosTarima(VIEW_ORDCOMP_RECEP_DETALLE_TARIMA Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_ORDCOMP_RECEP_DETALLE_TARIMA> ResLista = new List<VIEW_ORDCOMP_RECEP_DETALLE_TARIMA>();

            Cnn.Conectar();

            ResLista = dll.ObtenerORDEN_COMPRA_RECEPCION_DETALLE_TARIMA(Cnn, ref Error, Ent);

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

    public ResultadoProceso Obtener_LadoTarima(VIEW_ORDCOMP_RECEP_LADO_TARIMA Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_ORDCOMP_RECEP_LADO_TARIMA> ResLista = new List<VIEW_ORDCOMP_RECEP_LADO_TARIMA>();

            Cnn.Conectar();

            ResLista = dll.ObtenerORDEN_COMPRA_RECEPCION_LADO_TARIMA(Cnn, ref Error, Ent);

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

    public ResultadoProceso Obtener_ResumenTarimaRecepcion(VIEW_ORDCOMP_RECEP_RESUMEN Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_ORDCOMP_RECEP_RESUMEN> ResLista = new List<VIEW_ORDCOMP_RECEP_RESUMEN>();

            Cnn.Conectar();

            ResLista = dll.ObtenerORDEN_COMPRA_RECEPCION_RESUMEN_TARIMA(Cnn, ref Error, Ent);

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

    public ResultadoProceso ObtenerResumen(VIEW_ORDEN_COMPRA_RECEPCION Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_ORDEN_COMPRA_RECEPCION> ResLista = new List<VIEW_ORDEN_COMPRA_RECEPCION>();

            Cnn.Conectar();

            ResLista = dll.ObtenerORDEN_COMPRA_RECEPCION(Cnn, ref Error, Ent); //OPERACION 6 - OBTENER RESUMEN

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

    public ResultadoProceso Obtener_UsuarioAsignacionTarima(VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA> ResLista = new List<VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA>();

            Cnn.Conectar();

            ResLista = dll.ObtenerORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA(Cnn, ref Error, Ent);

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

    public ResultadoProceso ValidarORDEN_COMPRA_RECEPCION(Conectividad Cnn, int PROCESO, VIEW_ORDEN_COMPRA_RECEPCION Ent)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;
        VIEW_ORDEN_COMPRA_RECEPCION vEnt = new VIEW_ORDEN_COMPRA_RECEPCION();
        bool ConexionIniciada = false;

        try
        {
            List<VIEW_ORDEN_COMPRA_RECEPCION> ResLista = new List<VIEW_ORDEN_COMPRA_RECEPCION>();

            if (Cnn == null)
            {
                ConexionIniciada = true;
                Cnn = new Conectividad();
                Cnn.Conectar();
            }

            vEnt.ORDEN_COMPRA_RECEPCION_ID = Ent.ORDEN_COMPRA_RECEPCION_ID;

            ResLista = dll.ObtenerORDEN_COMPRA_RECEPCION(Cnn, ref Error, vEnt);

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

    //public ResultadoProceso ValidarORDEN_COMPRA_RECEPCIONProceso(Conectividad Cnn, int PROCESO, int LLAMADO_REFERENCIA, VIEW_ORDEN_COMPRA_RECEPCION Ent)
    //{
    //    ResultadoProceso Retorno = new ResultadoProceso();
    //    AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
    //    string Error = string.Empty;
    //    VIEW_ORDEN_COMPRA_RECEPCION vEnt = new VIEW_ORDEN_COMPRA_RECEPCION();
    //    bool ConexionIniciada = false;
    //    string Mensaje = string.Empty;
    //    object TipoRespuesta = 0;
    //    object ControlTag = 0;
    //    object ParametroSalida = 0;

    //    try
    //    {
    //        List<VIEW_ORDEN_COMPRA_RECEPCION> ResLista = new List<VIEW_ORDEN_COMPRA_RECEPCION>();

    //        if (Cnn == null)
    //        {
    //            ConexionIniciada = true;
    //            Cnn = new Conectividad();
    //            Cnn.Conectar();
    //        }

    //        vEnt.ORDEN_COMPRA_RECEPCION_ID = Ent.ORDEN_COMPRA_RECEPCION_ID;

    //        ResLista = dll.ObtenerORDEN_COMPRA_RECEPCION(Cnn, ref Error, GlobalesLibrary.OPERACION_CONSULTAR, vEnt);

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
    //            Mensaje = dll.ProcesoORDEN_COMPRA_RECEPCION_VALIDA(Cnn, ref Error, PROCESO, ref TipoRespuesta, ref ControlTag, Ent, ref ParametroSalida);
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

    public ResultadoProceso ProcesoORDEN_COMPRA_RECEPCION(int PROCESO, VIEW_ORDEN_COMPRA_RECEPCION Ent)
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

            Retorno = ValidarORDEN_COMPRA_RECEPCION(Cnn, PROCESO, Ent);

            if (!Retorno.HayError)
            {
                if (dll.ProcesoORDEN_COMPRA_RECEPCION(Cnn, ref Error, PROCESO, Ent))
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
