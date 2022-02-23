using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VIEW_ORDCOMP_RECEP_RESUMEN
{
    public decimal OPERACION { get; set; }
    public string PLANTA_ID { get; set; }
    public decimal? ORDEN_COMPRA_RECEPCION_ID { get; set; }
    public string TARIMA_ID { get; set; }
    public decimal SECUENCIA_ID { get; set; }
    public decimal MATERIAL_ID { get; set; }
    public string MATERIAL_DESC { get; set; }
    public decimal? CANTIDAD_MAY_REMFACT { get; set; }
    public decimal? CANTIDAD_MEN_REMFACT { get; set; }
    public string UNIDAD_MAYOR_DESC { get; set; }
    public decimal? CANTIDAD_MAY_RECEPCION { get; set; }
    public string UNIDAD_MENOR_DESC { get; set; }
    public decimal? CANTIDAD_MEN_RECEPCION { get; set; }
    public string UNIDAD_SISTEMA_DESC { get; set; }
    public decimal? CANTIDAD_RECEPCION { get; set; }
    public string ASIGNADO_A { get; set; }
}
