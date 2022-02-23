using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VIEW_ORDEN_COMPRA_RECEPCION
{
    public decimal OPERACION { get; set; }
    public string PLANTA_ID { get; set; }
    public string PLANTA_DESC { get; set; }
    public decimal? ORDEN_COMPRA_RECEPCION_ID { get; set; }
    public decimal? ORDEN_COMPRA_ID { get; set; }
    public decimal? ESTATUS_ID { get; set; }
    public string ESTATUS_DESC { get; set; }
    public decimal? ALMACEN_ID { get; set; }
    public string ALMACEN_DESC { get; set; }
    public decimal? PROVEEDOR_ID { get; set; }
    public string PROVEEDOR_NOMBRE { get; set; }
    public decimal? MONEDA_ID { get; set; }
    public string MONEDA_DESC { get; set; }
    public decimal? TIPO_CAMBIO { get; set; }
    public string REMISION_ID { get; set; }
    public string FACTURA { get; set; }
    public string OBSERVACIONES { get; set; }
    public string TARIMA_ID { get; set; }
    public bool IMPRIMIR_ETIQUETAS_IND { get; set; }
    public decimal? FOLIO_MOV_ENTRADA { get; set; }
    public decimal? FOLIO_MOV_AJUSTE { get; set; }
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

    public string MICROSIP_FOLIO { get; set; }
    public string REMISION { get; set; }

    public decimal? RECEPCION { get; set; }
    public decimal? CANTIDAD_TARIMAS { get; set; }
    public decimal? CANTIDAD_MAY_REMFACT { get; set; }
    public decimal? CANTIDAD_MEN_REMFACT { get; set; }
    public decimal? CANTIDAD_MAY_RECEPCION { get; set; }
    public decimal? CANTIDAD_MEN_RECEPCION { get; set; }
    public decimal? CANTIDAD_RECEPCION { get; set; }

}


