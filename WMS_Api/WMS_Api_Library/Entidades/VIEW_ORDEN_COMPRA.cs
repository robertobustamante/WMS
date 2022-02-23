using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VIEW_ORDEN_COMPRA
{
    public decimal OPERACION { get; set; }
    public string PLANTA_ID { get; set; }
    public string PLANTA_DESC { get; set; }
    public decimal? ORDEN_COMPRA_ID { get; set; }
    public decimal? TIPO_COMPRA_ID { get; set; }
    public string TIPO_COMPRA_DESC { get; set; }
    public decimal? ESTATUS_ID { get; set; }
    public string ESTATUS_DESC { get; set; }
    public DateTime? FECHA_ORDEN_COMPRA { get; set; }
    public decimal? ALMACEN_ID { get; set; }
    public string ALMACEN_DESC { get; set; }
    public decimal? PROVEEDOR_ID { get; set; }
    public string PROVEEDOR_NOMBRE { get; set; }
    public decimal? MONEDA_ID { get; set; }
    public string MONEDA_DESC { get; set; }
    public decimal? TIPO_CAMBIO { get; set; }
    public decimal? IMPORTE_NETO { get; set; }
    public decimal? TOTAL_IMPUESTOS { get; set; }
    public decimal? TOTAL_RETENCIONES { get; set; }
    public decimal? OTROS_CARGOS { get; set; }
    public decimal? GASTOS_ADUANALES { get; set; }
    public decimal? TIPO_DESCUENTO_ID { get; set; }
    public decimal? CONDICION_PAGO_ID { get; set; }
    public decimal? VIA_EMBARQUE_ID { get; set; }
    public int? MICROSIP_DOCTO_CM_ID { get; set; }
    public string MICROSIP_FOLIO { get; set; }
    public DateTime? MICROSIP_FECHA { get; set; }
    public DateTime? MICROSIP_FECHA_ENTREGA { get; set; }
    public DateTime? MICROSIP_FECHA_SINCRONIZACION { get; set; }
    public DateTime? FECHA_ENTREGA { get; set; }
    public string OBSERVACIONES { get; set; }
    public bool IMPRIMIR_ETIQUETAS_IND { get; set; }
    public decimal? USUARIO_RECEPCION_ID { get; set; }
    public string USUARIO_RECEPCION_DESC { get; set; }
    public DateTime? FECHA_RECEPCION { get; set; }
    public decimal? USUARIO_ALTA_ID { get; set; }
    public string USUARIO_ALTA_DESC { get; set; }
    public DateTime? FECHA_ALTA { get; set; }
    public decimal? USUARIO_MODIFICA_ID { get; set; }
    public string USUARIO_MODIFICA_DESC { get; set; }
    public DateTime? FECHA_MODIFICA { get; set; }
    public decimal? USUARIO_ELIMINA_ID { get; set; }
    public string USUARIO_ELIMINA_DESC { get; set; }
    public DateTime? FECHA_ELIMINA { get; set; }
    public decimal? USUARIO_ACTUAL_ID { get; set; }

    public string FOLIO { get; set; }
    public decimal? CANTIDAD_MAY_SOLICTADO { get; set; }
    public decimal? CANTIDAD_MEN_SOLICTADO { get; set; }
    public decimal? CANTIDAD_MEN_RECEPCION { get; set; }
    public decimal? CANT_MAY_PENDIENTE { get; set; }
    public decimal? CANT_MEN_PENDIENTE { get; set; }

    public decimal? CANTIDAD_MAY_FAC { get; set; }
    public decimal? CANTIDAD_MEN_FAC { get; set; }
    public decimal? CANTIDAD_MAY_REC { get; set; }
    public decimal? CANTIDAD_MEN_REC { get; set; }
}


