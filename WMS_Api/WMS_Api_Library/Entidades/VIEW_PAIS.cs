using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VIEW_PAIS
{
    public decimal? PAIS_ID { get; set; }

    public string DESCRIPCION { get; set; }

    public string DESC_CORTA { get; set; }

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