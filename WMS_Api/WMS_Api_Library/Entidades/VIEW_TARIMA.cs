using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VIEW_TARIMA
{
    public string TARIMA_ID { get; set; }

    public string UBICACION_ID { get; set; }

    public string CONTENEDOR_ID { get; set; }

    public decimal? TIPO_CONTENEDOR_ID { get; set; }

    public string TIPO_CONTENEDOR_DESC { get; set; }

    public string PLANTA_ID { get; set; }

    public string PLANTA_DESC { get; set; }    

    public decimal? TARA { get; set; }

    public decimal? ESTADO_MATERIAL_ID { get; set; }

    public string ESTADO_MATERIAL_DESC { get; set; }

    public decimal? USUARIO_ESTADO_MATERIAL_ID { get; set; }

    public string USUARIO_ESTADO_MATERIAL_DESC { get; set; }

    public DateTime? FECHA_ESTADO_MATERIAL { get; set; }

    public decimal? USUARIO_INGRESO_ALMACEN_ID { get; set; }

    public string USUARIO_INGRESO_ALMACEN_DESC { get; set; }

    public DateTime? FECHA_INGRESO_ALMACEN { get; set; }

    public string UBICACION_PREVIA_ID { get; set; }

    public decimal? CANTIDAD_BASCULA { get; set; }

    public DateTime? FECHA_PESAJE_BASCULA { get; set; }

    public string MACADRESSS_GEN { get; set; }

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

