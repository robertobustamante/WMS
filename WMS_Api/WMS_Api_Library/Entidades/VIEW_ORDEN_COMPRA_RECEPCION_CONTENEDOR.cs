using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VIEW_ORDEN_COMPRA_RECEPCION_CONTENEDOR
{
    public decimal OPERACION { get; set; }
    public string LADO_CANAL	{get; set;}
    public string LADO_TARIMA	{get; set;}
    public string UBICACION_RECEPCION_ID	{get; set;}
    public string CONTENEDOR_ID	{get; set;}
    public string TARIMA_ID	{get; set;}
    public string LOTE_PROVEEDOR	{get; set;}
    public string PLANTA_ID	{get; set;}
    public string CODIGO_BARRAS { get; set; }
    public string MACADDRESS { get; set; }
    public DateTime? FECHA_CADUCIDAD { get; set; }
    public DateTime? FECHA_SACRIFICIO { get; set; }
    public DateTime? FECHA_RECEPCION { get; set; }
    public DateTime? FECHA_ALTA { get; set; }
    public decimal? USUARIO_RECEPCION_ID { get; set; }
    public decimal? USUARIO_ALTA_ID { get; set; }
    public decimal? CANTIDAD_MAY_ETIQUETA { get; set; }
    public decimal? CANTIDAD_MEN_NETO_ETIQUETA { get; set; }
    public decimal? CANTIDAD_MEN_BRUTO_ETIQUETA { get; set; }
    public decimal? CANTIDAD_MAY { get; set; }
    public decimal? CANTIDAD_MEN_BRUTO { get; set; }
    public decimal? CANTIDAD_MEN_NETO { get; set; }
    public decimal? CANTIDAD { get; set; }
    public decimal? COSTO_UNITARIO { get; set; }
    public decimal? TIPO_CONTENEDOR_ID { get; set; }
    public decimal? SECUENCIA_TARIMA { get; set; }
    public decimal? TARA_ETIQUETA { get; set; }
    public decimal? TARA { get; set; }
    public decimal? ORDEN_COMPRA_RECEPCION_ID { get; set; }
    public decimal? MATERIAL_ID { get; set; }
    public decimal? ES_ORDEN_COMPRA { get; set; }

}

