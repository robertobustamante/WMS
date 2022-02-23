using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AccesoDatosCatalogos
{

    #region PAIS

    public List<VIEW_PAIS> ObtenerPAIS(Conectividad Cnn, ref string Error, int Operacion, int LlamadoReferencia, VIEW_PAIS Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (LlamadoReferencia > 0)
                Param.Add("LLAMADO_REFERENCIA", LlamadoReferencia, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent != null)
            {
                if (Ent.PAIS_ID != null)
                    Param.Add("PAIS_ID", Ent.PAIS_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.DESCRIPCION != null)
                    Param.Add("DESCRIPCION", Ent.DESCRIPCION, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.DESC_CORTA != null)
                    Param.Add("DESC_CORTA", Ent.DESC_CORTA, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.USUARIO_ALTA_ID != null)
                    Param.Add("USUARIO_ALTA_ID", Ent.USUARIO_ALTA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.FECHA_ALTA != null)
                    Param.Add("FECHA_ALTA", Ent.FECHA_ALTA, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.USUARIO_MODIFICA_ID != null)
                    Param.Add("USUARIO_MODIFICA_ID", Ent.USUARIO_MODIFICA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.FECHA_MODIFICA != null)
                    Param.Add("FECHA_MODIFICA", Ent.FECHA_MODIFICA, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.USUARIO_ELIMINA_ID != null)
                    Param.Add("USUARIO_ELIMINA_ID", Ent.USUARIO_ELIMINA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.FECHA_ELIMINA != null)
                    Param.Add("FECHA_ELIMINA", Ent.FECHA_ELIMINA, ClaseParametros.TIPO_PARAMETRO.FECHA);
            }

            return Datos.ListaDesdeDataTable<VIEW_PAIS>(Cnn.LeerSP("SPGIIC_PAIS", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    public String ProcesoPAIS_VALIDA(Conectividad Cnn, ref string Error, int Operacion, ref object TipoMensaje, ref object ControlTag, VIEW_PAIS Ent, ref object ParametroSalida)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PAIS_ID != null)
                Param.Add("PAIS_ID", Ent.PAIS_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);            

            if (Ent.DESCRIPCION != null)
                Param.Add("DESCRIPCION", Ent.DESCRIPCION, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.DESC_CORTA != null)
                Param.Add("DESC_CORTA", Ent.DESC_CORTA, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            return Cnn.ValidaProcesoSP("spGIIC_PAIS_VALIDA", Param, ref TipoMensaje, ref ControlTag, ref ParametroSalida);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return Error;
        }
    }

    public bool ProcesoPAIS(Conectividad Cnn, ref string Error, int Operacion, VIEW_PAIS Ent)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PAIS_ID != null)
                Param.Add("PAIS_ID", Ent.PAIS_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.DESCRIPCION != null)
                Param.Add("DESCRIPCION", Ent.DESCRIPCION, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.DESC_CORTA != null)
                Param.Add("DESC_CORTA", Ent.DESC_CORTA, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.USUARIO_ALTA_ID != null)
                Param.Add("USUARIO_ALTA_ID", Ent.USUARIO_ALTA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_ALTA != null)
                Param.Add("FECHA_ALTA", Ent.FECHA_ALTA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_MODIFICA_ID != null)
                Param.Add("USUARIO_MODIFICA_ID", Ent.USUARIO_MODIFICA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_MODIFICA != null)
                Param.Add("FECHA_MODIFICA", Ent.FECHA_MODIFICA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_ELIMINA_ID != null)
                Param.Add("USUARIO_ELIMINA_ID", Ent.USUARIO_ELIMINA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_ELIMINA != null)
                Param.Add("FECHA_ELIMINA", Ent.FECHA_ELIMINA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            return Cnn.EjecutarSP("spGIIC_PAIS", Param);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return false;
        }
    }

    #endregion

    #region ORDEN_COMPRA

    public List<VIEW_ORDEN_COMPRA> ObtenerORDEN_COMPRA(Conectividad Cnn, ref string Error, VIEW_ORDEN_COMPRA Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Ent.OPERACION, ClaseParametros.TIPO_PARAMETRO.NUMERO);            

            if (Ent != null)
            {
                if (Ent.PLANTA_ID != null)
                    Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.ORDEN_COMPRA_ID != null)
                    Param.Add("ORDEN_COMPRA_ID", Ent.ORDEN_COMPRA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);                                

                if (Ent.MICROSIP_DOCTO_CM_ID != null)
                    Param.Add("MICROSIP_DOCTO_CM_ID", Ent.MICROSIP_DOCTO_CM_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);
                                
            }

            return Datos.ListaDesdeDataTable<VIEW_ORDEN_COMPRA>(Cnn.LeerSP("SPGIIC_ORDEN_COMPRA", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    //public String ProcesoORDEN_COMPRA_VALIDA(Conectividad Cnn, ref string Error, int Operacion, ref object TipoMensaje, ref object ControlTag, VIEW_ORDEN_COMPRA Ent, ref object ParametroSalida)
    //{
    //    try
    //    {
    //        ClaseParametros Param = new ClaseParametros();

    //        Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

    //        if (Ent.ORDEN_COMPRA_ID != null)
    //            Param.Add("ORDEN_COMPRA_ID", Ent.ORDEN_COMPRA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);
            

    //        return Cnn.ValidaProcesoSP("spGIIC_ORDEN_COMPRA_VALIDA", Param, ref TipoMensaje, ref ControlTag, ref ParametroSalida);
    //    }
    //    catch (Exception ex)
    //    {
    //        Error = ex.ToString();
    //        return Error;
    //    }
    //}

    public bool ProcesoORDEN_COMPRA(Conectividad Cnn, ref string Error, int Operacion, VIEW_ORDEN_COMPRA Ent)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PLANTA_ID != null)
                Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.ORDEN_COMPRA_ID != null)
                Param.Add("ORDEN_COMPRA_ID", Ent.ORDEN_COMPRA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TIPO_COMPRA_ID != null)
                Param.Add("TIPO_COMPRA_ID", Ent.TIPO_COMPRA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.ESTATUS_ID != null)
                Param.Add("ESTATUS_ID", Ent.ESTATUS_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_ORDEN_COMPRA != null)
                Param.Add("FECHA_ORDEN_COMPRA", Ent.FECHA_ORDEN_COMPRA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.FECHA_ENTREGA != null)
                Param.Add("FECHA_ENTREGA", Ent.FECHA_ENTREGA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.ALMACEN_ID != null)
                Param.Add("ALMACEN_ID", Ent.ALMACEN_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PROVEEDOR_ID != null)
                Param.Add("PROVEEDOR_ID", Ent.PROVEEDOR_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.MONEDA_ID != null)
                Param.Add("MONEDA_ID", Ent.MONEDA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TIPO_CAMBIO != null)
                Param.Add("TIPO_CAMBIO", Ent.TIPO_CAMBIO, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.IMPORTE_NETO != null)
                Param.Add("IMPORTE_NETO", Ent.IMPORTE_NETO, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TOTAL_IMPUESTOS != null)
                Param.Add("TOTAL_IMPUESTOS", Ent.TOTAL_IMPUESTOS, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TOTAL_RETENCIONES != null)
                Param.Add("TOTAL_RETENCIONES", Ent.TOTAL_RETENCIONES, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.OTROS_CARGOS != null)
                Param.Add("OTROS_CARGOS", Ent.OTROS_CARGOS, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            //if (Ent.OTROS_GASTOS != null)
            //    Param.Add("OTROS_GASTOS", Ent.OTROS_GASTOS, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.GASTOS_ADUANALES != null)
                Param.Add("GASTOS_ADUANALES", Ent.GASTOS_ADUANALES, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TIPO_DESCUENTO_ID != null)
                Param.Add("TIPO_DESCUENTO_ID", Ent.TIPO_DESCUENTO_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.CONDICION_PAGO_ID != null)
                Param.Add("CONDICION_PAGO_ID", Ent.CONDICION_PAGO_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.VIA_EMBARQUE_ID != null)
                Param.Add("VIA_EMBARQUE_ID", Ent.VIA_EMBARQUE_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.MICROSIP_DOCTO_CM_ID != null)
                Param.Add("MICROSIP_DOCTO_CM_ID", Ent.MICROSIP_DOCTO_CM_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.MICROSIP_FOLIO != null)
                Param.Add("MICROSIP_FOLIO", Ent.MICROSIP_FOLIO, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.MICROSIP_FECHA != null)
                Param.Add("MICROSIP_FECHA", Ent.MICROSIP_FECHA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.MICROSIP_FECHA_ENTREGA != null)
                Param.Add("MICROSIP_FECHA_ENTREGA", Ent.MICROSIP_FECHA_ENTREGA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.MICROSIP_FECHA_SINCRONIZACION != null)
                Param.Add("MICROSIP_FECHA_SINCRONIZACION", Ent.MICROSIP_FECHA_SINCRONIZACION, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.OBSERVACIONES != null)
                Param.Add("OBSERVACIONES", Ent.OBSERVACIONES, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.IMPRIMIR_ETIQUETAS_IND != null)
              Param.Add("IMPRIMIR_ETIQUETAS_IND", Ent.IMPRIMIR_ETIQUETAS_IND, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            //if (Ent.FOLIO_MOV_ENTRADA != null)
            //    Param.Add("FOLIO_MOV_ENTRADA", Ent.FOLIO_MOV_ENTRADA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            //if (Ent.FOLIO_MOV_AJUSTE != null)
            //    Param.Add("FOLIO_MOV_AJUSTE", Ent.FOLIO_MOV_AJUSTE, ClaseParametros.TIPO_PARAMETRO.NUMERO);            

            if (Ent.USUARIO_RECEPCION_ID != null)
                Param.Add("USUARIO_RECEPCION_ID", Ent.USUARIO_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_RECEPCION != null)
                Param.Add("FECHA_RECEPCION", Ent.FECHA_RECEPCION, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_ALTA_ID != null)
                Param.Add("USUARIO_ALTA_ID", Ent.USUARIO_ALTA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_ALTA != null)
                Param.Add("FECHA_ALTA", Ent.FECHA_ALTA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_MODIFICA_ID != null)
                Param.Add("USUARIO_MODIFICA_ID", Ent.USUARIO_MODIFICA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_MODIFICA != null)
                Param.Add("FECHA_MODIFICA", Ent.FECHA_MODIFICA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_ELIMINA_ID != null)
                Param.Add("USUARIO_ELIMINA_ID", Ent.USUARIO_ELIMINA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_ELIMINA != null)
                Param.Add("FECHA_ELIMINA", Ent.FECHA_ELIMINA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            return Cnn.EjecutarSP("spGIIC_ORDEN_COMPRA", Param);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return false;
        }
    }

    #endregion

    #region ORDEN_COMPRA_RECEPCION

    public List<VIEW_ORDEN_COMPRA_RECEPCION> ObtenerORDEN_COMPRA_RECEPCION(Conectividad Cnn, ref string Error, VIEW_ORDEN_COMPRA_RECEPCION Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Ent.OPERACION, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent != null)
            {
                if (Ent.PLANTA_ID != null)
                    Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                    Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.ORDEN_COMPRA_ID != null)
                    Param.Add("ORDEN_COMPRA_ID", Ent.ORDEN_COMPRA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.MICROSIP_FOLIO != null)
                    Param.Add("MICROSIP_FOLIO", Ent.MICROSIP_FOLIO, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.TARIMA_ID != null)
                    Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);


            }

            return Datos.ListaDesdeDataTable<VIEW_ORDEN_COMPRA_RECEPCION>(Cnn.LeerSP("SPGIIC_ORDEN_COMPRA_RECEPCION", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    public List<VIEW_ORDCOMP_RECEP_DETALLE_TARIMA> ObtenerORDEN_COMPRA_RECEPCION_DETALLE_TARIMA(Conectividad Cnn, ref string Error, VIEW_ORDCOMP_RECEP_DETALLE_TARIMA Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Ent.OPERACION, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent != null)
            {
                if (Ent.PLANTA_ID != null)
                    Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                    Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.TARIMA_ID != null)
                    Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.LADO_A != null)
                    Param.Add("LADO_TARIMA", Ent.LADO_A, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.CONTENEDOR_A != null)
                    Param.Add("CONTENEDOR_ID", Ent.CONTENEDOR_A, ClaseParametros.TIPO_PARAMETRO.TEXTO);


            }

            return Datos.ListaDesdeDataTable<VIEW_ORDCOMP_RECEP_DETALLE_TARIMA>(Cnn.LeerSP("SPGIIC_ORDEN_COMPRA_RECEPCION", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    public List<VIEW_ORDCOMP_RECEP_LADO_TARIMA> ObtenerORDEN_COMPRA_RECEPCION_LADO_TARIMA(Conectividad Cnn, ref string Error, VIEW_ORDCOMP_RECEP_LADO_TARIMA Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Ent.OPERACION, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent != null)
            {
                if (Ent.PLANTA_ID != null)
                    Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                    Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.TARIMA_ID != null)
                    Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.LADO != null)
                    Param.Add("LADO_TARIMA", Ent.LADO, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.CONTENEDOR != null)
                    Param.Add("CONTENEDOR_ID", Ent.CONTENEDOR, ClaseParametros.TIPO_PARAMETRO.TEXTO);


            }

            return Datos.ListaDesdeDataTable<VIEW_ORDCOMP_RECEP_LADO_TARIMA>(Cnn.LeerSP("SPGIIC_ORDEN_COMPRA_RECEPCION", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    public List<VIEW_ORDCOMP_RECEP_RESUMEN> ObtenerORDEN_COMPRA_RECEPCION_RESUMEN_TARIMA(Conectividad Cnn, ref string Error, VIEW_ORDCOMP_RECEP_RESUMEN Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Ent.OPERACION, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent != null)
            {
                if (Ent.PLANTA_ID != null)
                    Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                    Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.TARIMA_ID != null)
                    Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);


            }

            return Datos.ListaDesdeDataTable<VIEW_ORDCOMP_RECEP_RESUMEN>(Cnn.LeerSP("SPGIIC_ORDEN_COMPRA_RECEPCION", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    //public String ProcesoORDEN_COMPRA_RECEPCION_VALIDA(Conectividad Cnn, ref string Error, int Operacion, ref object TipoMensaje, ref object ControlTag, VIEW_ORDEN_COMPRA_RECEPCION Ent, ref object ParametroSalida)
    //{
    //    try
    //    {
    //        ClaseParametros Param = new ClaseParametros();

    //        Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

    //        if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
    //            Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);


    //        return Cnn.ValidaProcesoSP("spGIIC_ORDEN_COMPRA_RECEPCION_VALIDA", Param, ref TipoMensaje, ref ControlTag, ref ParametroSalida);
    //    }
    //    catch (Exception ex)
    //    {
    //        Error = ex.ToString();
    //        return Error;
    //    }
    //}

    public bool ProcesoORDEN_COMPRA_RECEPCION(Conectividad Cnn, ref string Error, int Operacion, VIEW_ORDEN_COMPRA_RECEPCION Ent)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PLANTA_ID != null)
                Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.ORDEN_COMPRA_ID != null)
                Param.Add("ORDEN_COMPRA_ID", Ent.ORDEN_COMPRA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.ESTATUS_ID != null)
                Param.Add("ESTATUS_ID", Ent.ESTATUS_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);            

            if (Ent.ALMACEN_ID != null)
                Param.Add("ALMACEN_ID", Ent.ALMACEN_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PROVEEDOR_ID != null)
                Param.Add("PROVEEDOR_ID", Ent.PROVEEDOR_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.MONEDA_ID != null)
                Param.Add("MONEDA_ID", Ent.MONEDA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TIPO_CAMBIO != null)
                Param.Add("TIPO_CAMBIO", Ent.TIPO_CAMBIO, ClaseParametros.TIPO_PARAMETRO.NUMERO);
            
            if (Ent.MICROSIP_FOLIO != null)
                Param.Add("MICROSIP_FOLIO", Ent.MICROSIP_FOLIO, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.OBSERVACIONES != null)
                Param.Add("OBSERVACIONES", Ent.OBSERVACIONES, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.IMPRIMIR_ETIQUETAS_IND != null)
                Param.Add("IMPRIMIR_ETIQUETAS_IND", Ent.IMPRIMIR_ETIQUETAS_IND, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.USUARIO_RECEPCION_ID != null)
                Param.Add("USUARIO_RECEPCION_ID", Ent.USUARIO_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_RECEPCION != null)
                Param.Add("FECHA_RECEPCION", Ent.FECHA_RECEPCION, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_ALTA_ID != null)
                Param.Add("USUARIO_ALTA_ID", Ent.USUARIO_ALTA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_ALTA != null)
                Param.Add("FECHA_ALTA", Ent.FECHA_ALTA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_MODIFICA_ID != null)
                Param.Add("USUARIO_MODIFICA_ID", Ent.USUARIO_MODIFICA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_MODIFICA != null)
                Param.Add("FECHA_MODIFICA", Ent.FECHA_MODIFICA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_ELIMINA_ID != null)
                Param.Add("USUARIO_ELIMINA_ID", Ent.USUARIO_ELIMINA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_ELIMINA != null)
                Param.Add("FECHA_ELIMINA", Ent.FECHA_ELIMINA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            return Cnn.EjecutarSP("spGIIC_ORDEN_COMPRA_RECEPCION", Param);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return false;
        }
    }

    public string ProcesoORDEN_COMPRA_RECEPCION_CONTENEDOR(Conectividad Cnn, ref string Error, int Operacion, VIEW_ORDEN_COMPRA_RECEPCION_CONTENEDOR Ent, ref object TipoMensaje, ref object ControlTag, ref object ParametroSalida)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PLANTA_ID != null)
                Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TARIMA_ID != null)
                Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.LADO_TARIMA != null)
                Param.Add("LADO_TARIMA", Ent.LADO_TARIMA, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.CODIGO_BARRAS != null)
                Param.Add("CODIGO_BARRA_PROVEEDOR", Ent.CODIGO_BARRAS, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.MACADDRESS != null)
                Param.Add("MACADDRESS_GEN", Ent.MACADDRESS, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.USUARIO_ALTA_ID != null)
                Param.Add("USUARIO_ALTA_ID", Ent.USUARIO_ALTA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.MATERIAL_ID != null)
                Param.Add("MATERIAL_ID", Ent.MATERIAL_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.CANTIDAD_MEN_NETO != null)
                Param.Add("CANTIDAD_MEN_NETO", Ent.CANTIDAD_MEN_NETO, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.ES_ORDEN_COMPRA != null)
                Param.Add("ES_ORDEN_COMPRA", Ent.ES_ORDEN_COMPRA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            return Cnn.ValidaProcesoSP("spGIIC_PROCESO_GENERAL_COMPRA_CONTENEDOR", Param, ref TipoMensaje, ref ControlTag, ref ParametroSalida);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return Error;
        }
    }


    #endregion

    #region ORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA

    public List<VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA> ObtenerORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA(Conectividad Cnn, ref string Error, VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Ent.OPERACION, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent != null)
            {
                if (Ent.PLANTA_ID != null)
                    Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                    Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.TARIMA_ID != null)
                    Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.USUARIO_ASIGNACION_ID != null)
                    Param.Add("USUARIO_ID", Ent.USUARIO_ASIGNACION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);



            }

            return Datos.ListaDesdeDataTable<VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA>(Cnn.LeerSP("spGIIC_ORDEN_COMPRA_RECEPCION_ASIGNACION", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    public String ProcesoORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA_VALIDA(Conectividad Cnn, ref string Error, int Operacion, ref object TipoMensaje, ref object ControlTag, VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA Ent, ref object ParametroSalida)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PLANTA_ID != null)
                Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TARIMA_ID != null)
                Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

           

            if (Ent.USUARIO_ASIGNACION_ID != null)
                Param.Add("USUARIO_ASIGNACION_ID", Ent.USUARIO_ASIGNACION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);



            return Cnn.ValidaProcesoSP("spGIIC_ORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA_VALIDA", Param, ref TipoMensaje, ref ControlTag, ref ParametroSalida);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return Error;
        }
    }
    public bool ProcesoORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA(Conectividad Cnn, ref string Error, int Operacion, VIEW_ORDCOMP_RECEP_ASIGNACION_TARIMA Ent)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PLANTA_ID != null)
                Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TARIMA_ID != null)
                Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.ESTATUS != null)
                Param.Add("CERRADA", Ent.ESTATUS, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.USUARIO_ASIGNACION_ID != null)
                Param.Add("USUARIO_ASIGNACION_ID", Ent.USUARIO_ASIGNACION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.USUARIO_MODIFICA_ID != null)
                Param.Add("USUARIO_MODIFICA_ID", Ent.USUARIO_MODIFICA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            return Cnn.EjecutarSP("spGIIC_ORDEN_COMPRA_RECEPCION_ASIGNACION_TARIMA", Param);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return false;
        }
    }

    #endregion

    #region ORDEN_COMPRA_RECEPCION_MATERIAL
    public List<VIEW_ORDEN_COMPRA_RECEPCION_MATERIAL> ObtenerORDEN_COMPRA_RECEPCION_MATERIAL(Conectividad Cnn, ref string Error, int Operacion, int LlamadoReferencia, VIEW_ORDEN_COMPRA_RECEPCION_MATERIAL Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (LlamadoReferencia > 0)
                Param.Add("LLAMADO_REFERENCIA", LlamadoReferencia, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent != null)
            {
                if (Ent.PLANTA_ID != null)
                    Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.ORDEN_COMPRA_RECEPCION_ID != null)
                    Param.Add("ORDEN_COMPRA_RECEPCION_ID", Ent.ORDEN_COMPRA_RECEPCION_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                
            }

            return Datos.ListaDesdeDataTable<VIEW_ORDEN_COMPRA_RECEPCION_MATERIAL>(Cnn.LeerSP("spGIIC_ORDEN_COMPRA_RECEPCION_MATERIAL", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    #endregion
}
