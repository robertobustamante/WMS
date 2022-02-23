using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VIEW_USUARIO
{
    public decimal? USUARIO_ID { get; set; }

    public string USUARIO { get; set; }

    public string NOMBRE { get; set; }

    public string CONTRASENIA { get; set; }

    public decimal? ROL_ID { get; set; }

    public string ROL_DESC { get; set; }

    public string PLANTA_ID { get; set; }

    public string PLANTA_DESC { get; set; }

    public string DEPARTAMENTO_ID { get; set; }

    public string DEPARTAMENTO_DESC { get; set; }

    public decimal? ALMACEN_ID { get; set; }

    public string ALMACEN_DESC { get; set; }

    public string SKIN { get; set; }

    public decimal? LINEA_EMPAQUE_ID { get; set; }

    public string LINEA_EMPAQUE_DESC { get; set; }

    public decimal? IDIOMA_ID { get; set; }

    public string IDIOMA_DESC { get; set; }

    public decimal? COMPANIA_ID { get; set; }

    public decimal? USUARIO_ALTA_ID { get; set; }

    public string USUARIO_ALTA_DESC { get; set; }

    public DateTime? FECHA_ALTA { get; set; }

    public decimal? USUARIO_MODIFICA_ID { get; set; }

    public string USUARIO_MODIFICA_DESC { get; set; }

    public DateTime? FECHA_MODIFICA { get; set; }

    public decimal? USUARIO_ELIMINA_ID { get; set; }

    public string USUARIO_ELIMINA_DESC { get; set; }

    public DateTime? FECHA_ELIMINA { get; set; }

    public Boolean OPERACION_OFFLINE { get; set; }

}