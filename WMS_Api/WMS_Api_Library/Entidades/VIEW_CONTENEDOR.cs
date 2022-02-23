using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VIEW_CONTENEDOR
{
    public string CONTENEDOR_ID { get; set; }

    public decimal? MATERIAL { get; set; }

    public string MATERIAL_DESC { get; set; }

    public decimal? TIPO_CONTENEDOR_ID { get; set; }

    public string TIPO_CONTENEDOR_DESC { get; set; }

    public decimal? CANTIDAD_MAY { get; set; }

    public string UNIDAD_ID_MAYOR { get; set; }

    public decimal? CANTIDAD_MEN { get; set; }

    public string UNIDAD_ID_MENOR { get; set; }

    public decimal? CANTIDAD { get; set; }

    public decimal? PIEZAS { get; set; }

    public decimal? CANTIDAD_MEN_STD { get; set; }

    public decimal? TARA { get; set; }

    public decimal? PESO_X_UNIMEN { get; set; }

    public decimal? UNIMEN_X_UNIMAY { get; set; }

    public string TARIMA_ID { get; set; }

    public string TARIMA_PROD_ID { get; set; }

    public string UBICACION_ID { get; set; }

    public string UBICACION_PREVIA_ID { get; set; }

    public decimal? EN_EXISTENCIA { get; set; }

    public decimal? PROVEEDOR_ID { get; set; }

    public string PROVEEDOR_DESC { get; set; }

    public decimal? RANCHO_ID { get; set; }

    public string RANCHO_DESC { get; set; }

    public string LOTE_RANCHO_ID { get; set; }

    public string LOTE_RANCHO_DESC { get; set; }

    public string LOTE_PROV { get; set; }

    public decimal? LOTE_ID { get; set; }

    public string LOTE_DESC { get; set; }

    public string PLANTA_GEN_ID { get; set; }

    public DateTime? FECHA_LOTE { get; set; }

    public DateTime? FECHA_PROCESO { get; set; }    

    public decimal? PLANTA_ORIGEN_ID { get; set; }

    public decimal? USUARIO_GEN_ID { get; set; }

    public DateTime? FECHA_GENERACION { get; set; }

    public string MACADRESS_GEN { get; set; }

    public DateTime? FECHA_CAD_ORIG { get; set; }

    public DateTime? FECHA_SAC_ORIG { get; set; }

    public DateTime? FECHA_CAD_ETQ { get; set; }

    public DateTime? FECHA_SAC_ETQ { get; set; }

    public DateTime? FECHA_ACT { get; set; }

    public decimal? USUARIO_ACT_ID { get; set; }

    public decimal? EDO_MAT_ID { get; set; }

    public decimal? USUARIO_EDOMAT_ID { get; set; }

    public DateTime? FECHA_EDOMAT { get; set; }

    public decimal? USUARIO_CANCEL_ID { get; set; }

    public DateTime? FECHA_CANCELACION { get; set; }

    public DateTime? FECHA_IMP_ETIQUETA { get; set; }

    public decimal? USUARIO_IMP_ETQ_ID { get; set; }

    public decimal? COSTO_UNIMEN { get; set; }

    public decimal? COSTO_UNIMEN_CINY { get; set; }

    public string LADO_CANAL { get; set; }

    public decimal? CLIENTE_MAQUILA_ID { get; set; }

    public decimal? PEDIDO_PLAN { get; set; }

    public decimal? CANTIDAD_ORIGEN { get; set; }

    public decimal? CODIGO_BARRA_PROVEEDOR_ID { get; set; }

    public decimal? USUARIO_ALTA_ID { get; set; }

    public string USUARIO_ALTA_DESC { get; set; }

    public DateTime? FECHA_ALTA { get; set; }

    public decimal? USUARIO_MODIFICA_ID { get; set; }

    public string USUARIO_MODIFICA_DESC { get; set; }

    public DateTime? FECHA_MODIFICA { get; set; }

    public decimal? USUARIO_ELIMINA_ID { get; set; }

    public string USUARIO_ELIMINA_DESC { get; set; }

    public DateTime? FECHA_ELIMINA { get; set; }

}