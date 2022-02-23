using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AccesoDatos
{

    #region TEXTO

    public List<VIEW_TEXTO> ObtenerTEXTO(Conectividad Cnn, ref string Error, int Operacion, VIEW_TEXTO Ent)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            return Datos.ListaDesdeDataTable<VIEW_TEXTO>(Cnn.LeerSP("spGIIC_TEXTO", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    public bool ProcesoTEXTO(Conectividad Cnn, ref string Error, int Operacion, VIEW_TEXTO Ent)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TEXTO_ID != null)
                Param.Add("TEXTO_ID", Ent.TEXTO_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.DESCRIPCION_1 != null)
                Param.Add("DESCRIPCION_1", Ent.DESCRIPCION_1, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.DESCRIPCION_2 != null)
                Param.Add("DESCRIPCION_2", Ent.DESCRIPCION_2, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.DESCRIPCION_3 != null)
                Param.Add("DESCRIPCION_3", Ent.DESCRIPCION_3, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.DESCRIPCION_4 != null)
                Param.Add("DESCRIPCION_4", Ent.DESCRIPCION_4, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.DESCRIPCION_5 != null)
                Param.Add("DESCRIPCION_5", Ent.DESCRIPCION_5, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            return Cnn.EjecutarSP("spGIIC_TEXTO", Param);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return false;
        }
    }

    #endregion

    #region CONTENEDOR
    public List<VIEW_CONTENEDOR> ObtenerCONTENEDOR(Conectividad Cnn, ref string Error, int Operacion, VIEW_CONTENEDOR Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent != null)
            {

                if (Ent.CONTENEDOR_ID != null)
                    Param.Add("CONTENEDOR_ID", Ent.CONTENEDOR_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.TIPO_CONTENEDOR_ID != null)
                    Param.Add("TIPO_CONTENEDOR_ID", Ent.TIPO_CONTENEDOR_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.CANTIDAD_MAY != null)
                    Param.Add("CANTIDAD_MAY", Ent.CANTIDAD_MAY, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.CANTIDAD_MEN != null)
                    Param.Add("CANTIDAD_MEN", Ent.CANTIDAD_MEN, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.CANTIDAD != null)
                    Param.Add("CANTIDAD", Ent.CANTIDAD, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.PIEZAS != null)
                    Param.Add("PIEZAS", Ent.PIEZAS, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.CANTIDAD_MEN_STD != null)
                    Param.Add("CANTIDAD_MEN_STD", Ent.CANTIDAD_MEN_STD, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.TARA != null)
                    Param.Add("TARA", Ent.TARA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.TARIMA_ID != null)
                    Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.TARIMA_PROD_ID != null)
                    Param.Add("TARIMA_PROD_ID", Ent.TARIMA_PROD_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.UBICACION_ID != null)
                    Param.Add("UBICACION_ID", Ent.UBICACION_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.EN_EXISTENCIA != null)
                    Param.Add("EN_EXISTENCIA", Ent.EN_EXISTENCIA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.PROVEEDOR_ID != null)
                    Param.Add("PROVEEDOR_ID", Ent.PROVEEDOR_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.LOTE_PROV != null)
                    Param.Add("LOTE_PROV", Ent.LOTE_PROV, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.LOTE_ID != null)
                    Param.Add("LOTE_ID", Ent.LOTE_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.PLANTA_GEN_ID != null)
                    Param.Add("PLANTA_GEN_ID", Ent.PLANTA_GEN_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.FECHA_LOTE != null)
                    Param.Add("FECHA_LOTE", Ent.FECHA_LOTE, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.FECHA_PROCESO != null)
                    Param.Add("FECHA_PROCESO", Ent.FECHA_PROCESO, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.USUARIO_GEN_ID != null)
                    Param.Add("USUARIO_GEN_ID", Ent.USUARIO_GEN_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.FECHA_GENERACION != null)
                    Param.Add("FECHA_GENERACION", Ent.FECHA_GENERACION, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.MACADRESS_GEN != null)
                    Param.Add("MACADRESS_GEN", Ent.MACADRESS_GEN, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.FECHA_CAD_ORIG != null)
                    Param.Add("FECHA_CAD_ORIG", Ent.FECHA_CAD_ORIG, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.FECHA_SAC_ORIG != null)
                    Param.Add("FECHA_SAC_ORIG", Ent.FECHA_SAC_ORIG, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.FECHA_CAD_ETQ != null)
                    Param.Add("FECHA_CAD_ETQ", Ent.FECHA_CAD_ETQ, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.FECHA_SAC_ETQ != null)
                    Param.Add("FECHA_SAC_ETQ", Ent.FECHA_SAC_ETQ, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.FECHA_ACT != null)
                    Param.Add("FECHA_ACT", Ent.FECHA_ACT, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.USUARIO_ACT_ID != null)
                    Param.Add("USUARIO_ACT_ID", Ent.USUARIO_ACT_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.EDO_MAT_ID != null)
                    Param.Add("EDO_MAT_ID", Ent.EDO_MAT_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.USUARIO_EDOMAT_ID != null)
                    Param.Add("USUARIO_EDOMAT_ID", Ent.USUARIO_EDOMAT_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.FECHA_EDOMAT != null)
                    Param.Add("FECHA_EDOMAT", Ent.FECHA_EDOMAT, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.USUARIO_CANCEL_ID != null)
                    Param.Add("USUARIO_CANCEL_ID", Ent.USUARIO_CANCEL_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.FECHA_CANCELACION != null)
                    Param.Add("FECHA_CANCELACION", Ent.FECHA_CANCELACION, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.UBICACION_PREVIA_ID != null)
                    Param.Add("UBICACION_PREVIA_ID", Ent.UBICACION_PREVIA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.FECHA_IMP_ETIQUETA != null)
                    Param.Add("FECHA_IMP_ETIQUETA", Ent.FECHA_IMP_ETIQUETA, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.USUARIO_IMP_ETQ_ID != null)
                    Param.Add("USUARIO_IMP_ETQ_ID", Ent.USUARIO_IMP_ETQ_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.COSTO_UNIMEN != null)
                    Param.Add("COSTO_UNIMEN", Ent.COSTO_UNIMEN, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.COSTO_UNIMEN_CINY != null)
                    Param.Add("COSTO_UNIMEN_CINY", Ent.COSTO_UNIMEN_CINY, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.LADO_CANAL != null)
                    Param.Add("LADO_CANAL", Ent.LADO_CANAL, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.CLIENTE_MAQUILA_ID != null)
                    Param.Add("CLIENTE_MAQUILA_ID", Ent.CLIENTE_MAQUILA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.PEDIDO_PLAN != null)
                    Param.Add("PEDIDO_PLAN", Ent.PEDIDO_PLAN, ClaseParametros.TIPO_PARAMETRO.NUMERO);

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

            return Datos.ListaDesdeDataTable<VIEW_CONTENEDOR>(Cnn.LeerSP("spGIIC_CONTENEDOR", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }

    public bool ProcesoCONTENEDOR(Conectividad Cnn, ref string Error, int Operacion, VIEW_CONTENEDOR Ent)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.CONTENEDOR_ID != null)
                Param.Add("CONTENEDOR_ID", Ent.CONTENEDOR_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.TIPO_CONTENEDOR_ID != null)
                Param.Add("TIPO_CONTENEDOR_ID", Ent.TIPO_CONTENEDOR_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.CANTIDAD_MAY != null)
                Param.Add("CANTIDAD_MAY", Ent.CANTIDAD_MAY, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.CANTIDAD_MEN != null)
                Param.Add("CANTIDAD_MEN", Ent.CANTIDAD_MEN, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.CANTIDAD != null)
                Param.Add("CANTIDAD", Ent.CANTIDAD, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PIEZAS != null)
                Param.Add("PIEZAS", Ent.PIEZAS, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.CANTIDAD_MEN_STD != null)
                Param.Add("CANTIDAD_MEN_STD", Ent.CANTIDAD_MEN_STD, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TARA != null)
                Param.Add("TARA", Ent.TARA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TARIMA_ID != null)
                Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.TARIMA_PROD_ID != null)
                Param.Add("TARIMA_PROD_ID", Ent.TARIMA_PROD_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.UBICACION_ID != null)
                Param.Add("UBICACION_ID", Ent.UBICACION_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.EN_EXISTENCIA != null)
                Param.Add("EN_EXISTENCIA", Ent.EN_EXISTENCIA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PROVEEDOR_ID != null)
                Param.Add("PROVEEDOR_ID", Ent.PROVEEDOR_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.LOTE_PROV != null)
                Param.Add("LOTE_PROV", Ent.LOTE_PROV, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.LOTE_ID != null)
                Param.Add("LOTE_ID", Ent.LOTE_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PLANTA_GEN_ID != null)
                Param.Add("PLANTA_GEN_ID", Ent.PLANTA_GEN_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.FECHA_LOTE != null)
                Param.Add("FECHA_LOTE", Ent.FECHA_LOTE, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.FECHA_PROCESO != null)
                Param.Add("FECHA_PROCESO", Ent.FECHA_PROCESO, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_GEN_ID != null)
                Param.Add("USUARIO_GEN_ID", Ent.USUARIO_GEN_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_GENERACION != null)
                Param.Add("FECHA_GENERACION", Ent.FECHA_GENERACION, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.MACADRESS_GEN != null)
                Param.Add("MACADRESS_GEN", Ent.MACADRESS_GEN, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.FECHA_CAD_ORIG != null)
                Param.Add("FECHA_CAD_ORIG", Ent.FECHA_CAD_ORIG, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.FECHA_SAC_ORIG != null)
                Param.Add("FECHA_SAC_ORIG", Ent.FECHA_SAC_ORIG, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.FECHA_CAD_ETQ != null)
                Param.Add("FECHA_CAD_ETQ", Ent.FECHA_CAD_ETQ, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.FECHA_SAC_ETQ != null)
                Param.Add("FECHA_SAC_ETQ", Ent.FECHA_SAC_ETQ, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.FECHA_ACT != null)
                Param.Add("FECHA_ACT", Ent.FECHA_ACT, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_ACT_ID != null)
                Param.Add("USUARIO_ACT_ID", Ent.USUARIO_ACT_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.EDO_MAT_ID != null)
                Param.Add("EDO_MAT_ID", Ent.EDO_MAT_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.USUARIO_EDOMAT_ID != null)
                Param.Add("USUARIO_EDOMAT_ID", Ent.USUARIO_EDOMAT_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_EDOMAT != null)
                Param.Add("FECHA_EDOMAT", Ent.FECHA_EDOMAT, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_CANCEL_ID != null)
                Param.Add("USUARIO_CANCEL_ID", Ent.USUARIO_CANCEL_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_CANCELACION != null)
                Param.Add("FECHA_CANCELACION", Ent.FECHA_CANCELACION, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.UBICACION_PREVIA_ID != null)
                Param.Add("UBICACION_PREVIA_ID", Ent.UBICACION_PREVIA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.FECHA_IMP_ETIQUETA != null)
                Param.Add("FECHA_IMP_ETIQUETA", Ent.FECHA_IMP_ETIQUETA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.USUARIO_IMP_ETQ_ID != null)
                Param.Add("USUARIO_IMP_ETQ_ID", Ent.USUARIO_IMP_ETQ_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.COSTO_UNIMEN != null)
                Param.Add("COSTO_UNIMEN", Ent.COSTO_UNIMEN, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.COSTO_UNIMEN_CINY != null)
                Param.Add("COSTO_UNIMEN_CINY", Ent.COSTO_UNIMEN_CINY, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.LADO_CANAL != null)
                Param.Add("LADO_CANAL", Ent.LADO_CANAL, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.CLIENTE_MAQUILA_ID != null)
                Param.Add("CLIENTE_MAQUILA_ID", Ent.CLIENTE_MAQUILA_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PEDIDO_PLAN != null)
                Param.Add("PEDIDO_PLAN", Ent.PEDIDO_PLAN, ClaseParametros.TIPO_PARAMETRO.NUMERO);

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

            return Cnn.EjecutarSP("spGIIC_CONTENEDOR", Param);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return false;
        }
    }

    #endregion

    #region AL_TARIMA

    public List<VIEW_TARIMA> ObtenerTARIMA(Conectividad Cnn, ref string Error, int Operacion, VIEW_TARIMA Ent = null)
    {
        try
        {
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent != null)
            {

                if (Ent.TARIMA_ID != null)
                    Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.UBICACION_ID != null)
                    Param.Add("UBICACION_ID", Ent.UBICACION_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.TIPO_CONTENEDOR_ID != null)
                    Param.Add("TIPO_CONTENEDOR_ID", Ent.TIPO_CONTENEDOR_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.PLANTA_ID != null)
                    Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.TARA != null)
                    Param.Add("TARA", Ent.TARA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.ESTADO_MATERIAL_ID != null)
                    Param.Add("ESTADO_MATERIAL_ID", Ent.ESTADO_MATERIAL_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.USUARIO_ESTADO_MATERIAL_ID != null)
                    Param.Add("USUARIO_ESTADO_MATERIAL_ID", Ent.USUARIO_ESTADO_MATERIAL_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.FECHA_ESTADO_MATERIAL != null)
                    Param.Add("FECHA_ESTADO_MATERIAL", Ent.FECHA_ESTADO_MATERIAL, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.FECHA_INGRESO_ALMACEN != null)
                    Param.Add("FECHA_INGRESO_ALMACEN", Ent.FECHA_INGRESO_ALMACEN, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.UBICACION_PREVIA_ID != null)
                    Param.Add("UBICACION_PREVIA_ID", Ent.UBICACION_PREVIA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

                if (Ent.CANTIDAD_BASCULA != null)
                    Param.Add("CANTIDAD_BASCULA", Ent.CANTIDAD_BASCULA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

                if (Ent.FECHA_PESAJE_BASCULA != null)
                    Param.Add("FECHA_PESAJE_BASCULA", Ent.FECHA_PESAJE_BASCULA, ClaseParametros.TIPO_PARAMETRO.FECHA);

                if (Ent.MACADRESSS_GEN != null)
                    Param.Add("MACADRESSS_GEN", Ent.MACADRESSS_GEN, ClaseParametros.TIPO_PARAMETRO.FECHA);

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

            return Datos.ListaDesdeDataTable<VIEW_TARIMA>(Cnn.LeerSP("spGIIC_AL_TARIMA", Param));
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return null;
        }
    }    

    public bool ProcesoTARIMA(Conectividad Cnn, ref string Error, int Operacion, VIEW_TARIMA Ent)
    {
        try
        {
            object parametroSalida = 0;
            ClaseParametros Param = new ClaseParametros();

            Param.Add("OPERACION", Operacion, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.TARIMA_ID != null && Ent.TARIMA_ID.Length > 0)
                Param.Add("TARIMA_ID", Ent.TARIMA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.UBICACION_ID != null)
                Param.Add("UBICACION_ID", Ent.UBICACION_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.TIPO_CONTENEDOR_ID != null)
                Param.Add("TIPO_CONTENEDOR_ID", Ent.TIPO_CONTENEDOR_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.PLANTA_ID != null)
                Param.Add("PLANTA_ID", Ent.PLANTA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);            

            if (Ent.CONTENEDOR_ID != null)
                Param.Add("CONTENEDOR_ID", Ent.CONTENEDOR_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.TARA != null)
                Param.Add("TARA", Ent.TARA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.ESTADO_MATERIAL_ID != null)
                Param.Add("ESTADO_MATERIAL_ID", Ent.ESTADO_MATERIAL_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.USUARIO_ESTADO_MATERIAL_ID != null)
                Param.Add("USUARIO_ESTADO_MATERIAL_ID", Ent.USUARIO_ESTADO_MATERIAL_ID, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_ESTADO_MATERIAL != null)
                Param.Add("FECHA_ESTADO_MATERIAL", Ent.FECHA_ESTADO_MATERIAL, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.FECHA_INGRESO_ALMACEN != null)
                Param.Add("FECHA_INGRESO_ALMACEN", Ent.FECHA_INGRESO_ALMACEN, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.UBICACION_PREVIA_ID != null)
                Param.Add("UBICACION_PREVIA_ID", Ent.UBICACION_PREVIA_ID, ClaseParametros.TIPO_PARAMETRO.TEXTO);

            if (Ent.CANTIDAD_BASCULA != null)
                Param.Add("CANTIDAD_BASCULA", Ent.CANTIDAD_BASCULA, ClaseParametros.TIPO_PARAMETRO.NUMERO);

            if (Ent.FECHA_PESAJE_BASCULA != null)
                Param.Add("FECHA_PESAJE_BASCULA", Ent.FECHA_PESAJE_BASCULA, ClaseParametros.TIPO_PARAMETRO.FECHA);

            if (Ent.MACADRESSS_GEN != null)
                Param.Add("MACADRESSS_GEN", Ent.MACADRESSS_GEN, ClaseParametros.TIPO_PARAMETRO.TEXTO);

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

            return Cnn.EjecutarSP("spGIIC_AL_TARIMA", Param);
        }
        catch (Exception ex)
        {
            Error = ex.ToString();
            return false;
        }
    }
    
    #endregion

}