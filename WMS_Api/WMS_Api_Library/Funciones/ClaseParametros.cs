using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class ClaseParametros 
{

    public enum TIPO_PARAMETRO
    {
        NINGUNO = -1,
        TEXTO = 1,
        NUMERO = 2,
        FECHA = 3,
        FECHA_HORA = 4,
        BOLEANO = 5,
        DECIMAL = 6,
        IMAGEN = 7,
        HORA = 8
    }

    public String _NombreParam = "";
    public Object _ValorParam = null;
    public TIPO_PARAMETRO _TipoParam = TIPO_PARAMETRO.NINGUNO;
    public List<ClaseParametros> _ListaParametros = new List<ClaseParametros>();
    public Boolean _ParametroSalida= false;

    public ClaseParametros()
    {

    }

    public void Add(String NombreParametro, Object ValorParmetro, TIPO_PARAMETRO TipoParametro = TIPO_PARAMETRO.NINGUNO)
    {
        try
        {
            //Se llena el listado de la coleccion de parametros.
            ClaseParametros ParQuery = new ClaseParametros
            {
                NombreParam = NombreParametro
            };

            switch (TipoParametro)
            {
                case TIPO_PARAMETRO.TEXTO:
                    //ParQuery.ValorParam = "'" + Convert.ToString(ValorParmetro) + "'";
                    ParQuery.ValorParam = Convert.ToString(ValorParmetro).Trim();
                    break;

                case TIPO_PARAMETRO.NUMERO:
                    ParQuery.ValorParam = Convert.ToDecimal(ValorParmetro);
                    break;

                case TIPO_PARAMETRO.FECHA:
                    //ParQuery.ValorParam = "'" + Convert.ToDateTime(ValorParmetro).ToString("yyyy-MM-dd") + "'";
                    //ParQuery.ValorParam = Convert.ToDateTime(ValorParmetro).ToString("yyyy-MM-dd");
                    ParQuery.ValorParam = Convert.ToDateTime(ValorParmetro);
                    break;

                case TIPO_PARAMETRO.FECHA_HORA:
                    //ParQuery.ValorParam = "'" + Convert.ToDateTime(ValorParmetro).ToString("yyyy-MM-dd hh:mm:ss") + "'";
                    //ParQuery.ValorParam = Convert.ToDateTime(ValorParmetro).ToString("yyyy-MM-dd hh:mm:ss");
                    ParQuery.ValorParam = Convert.ToDateTime(ValorParmetro);
                    break;

                case TIPO_PARAMETRO.BOLEANO:
                    ParQuery.ValorParam = Convert.ToBoolean(ValorParmetro);
                    break;

                case TIPO_PARAMETRO.DECIMAL:
                    ParQuery.ValorParam = Convert.ToDecimal(ValorParmetro);
                    break;

                case TIPO_PARAMETRO.IMAGEN:
                    ParQuery.ValorParam = ValorParmetro;
                    //ParQuery.ValorParam = Convert.TO(ValorParmetro);
                    break;

                case TIPO_PARAMETRO.HORA:
                    ParQuery.ValorParam = ValorParmetro;
                    break;

                default:
                    ParQuery.ValorParam = ValorParmetro;
                    break;
            }

            ParQuery.TipoParam = TipoParametro;

            ListaParametros.Add(ParQuery);

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    public void Add(String NombreParametro, Object ValorParmetro, Type Tipo)
    {

        TIPO_PARAMETRO tipoPar = TIPO_PARAMETRO.NINGUNO;

        if (Tipo == typeof(string))
        {
            tipoPar = TIPO_PARAMETRO.TEXTO;
        }
        else if (Tipo == typeof(decimal))
        {
            tipoPar = TIPO_PARAMETRO.NUMERO;
        }
        else if (Tipo == typeof(DateTime))
        {
            tipoPar = TIPO_PARAMETRO.FECHA_HORA;
        }
        else
        {
            tipoPar = TIPO_PARAMETRO.TEXTO;
        }

        Add(NombreParametro, ValorParmetro, tipoPar);

    }

    public void Add(String NombreParametro, Object ValorParmetro, TIPO_PARAMETRO TipoParametro = TIPO_PARAMETRO.NINGUNO, Boolean Salida = false)
    {
        try
        {
            //Se llena el listado de la coleccion de parametros.
            ClaseParametros ParQuery = new ClaseParametros
            {
                NombreParam = NombreParametro
            };

            switch (TipoParametro)
            {
                case TIPO_PARAMETRO.TEXTO:
                    //ParQuery.ValorParam = "'" + Convert.ToString(ValorParmetro) + "'";
                    ParQuery.ValorParam = Convert.ToString(ValorParmetro).Trim();
                    ParQuery.ParametroSalida = Salida;
                    break;

                case TIPO_PARAMETRO.NUMERO:
                    ParQuery.ValorParam = Convert.ToDecimal(ValorParmetro);
                    ParQuery.ParametroSalida = Salida;
                    break;

                case TIPO_PARAMETRO.FECHA:
                    //ParQuery.ValorParam = "'" + Convert.ToDateTime(ValorParmetro).ToString("yyyy-MM-dd") + "'";
                    //ParQuery.ValorParam = Convert.ToDateTime(ValorParmetro).ToString("yyyy-MM-dd");
                    ParQuery.ValorParam = Convert.ToDateTime(ValorParmetro);
                    ParQuery.ParametroSalida = Salida;
                    break;

                case TIPO_PARAMETRO.FECHA_HORA:
                    //ParQuery.ValorParam = "'" + Convert.ToDateTime(ValorParmetro).ToString("yyyy-MM-dd hh:mm:ss") + "'";
                    //ParQuery.ValorParam = Convert.ToDateTime(ValorParmetro).ToString("yyyy-MM-dd hh:mm:ss");
                    ParQuery.ValorParam = Convert.ToDateTime(ValorParmetro);
                    ParQuery.ParametroSalida = Salida;
                    break;

                case TIPO_PARAMETRO.BOLEANO:
                    ParQuery.ValorParam = Convert.ToBoolean(ValorParmetro);
                    ParQuery.ParametroSalida = Salida;
                    ParQuery.ParametroSalida = Salida;
                    break;

                case TIPO_PARAMETRO.DECIMAL:
                    ParQuery.ValorParam = Convert.ToDecimal(ValorParmetro);
                    ParQuery.ParametroSalida = Salida;
                    break;

                case TIPO_PARAMETRO.IMAGEN:
                    ParQuery.ValorParam = ValorParmetro;
                    ParQuery.ParametroSalida = Salida;
                    //ParQuery.ValorParam = Convert.TO(ValorParmetro);
                    break;

                case TIPO_PARAMETRO.HORA:
                    ParQuery.ValorParam = ValorParmetro;
                    ParQuery.ParametroSalida = Salida;
                    break;

                default:
                    ParQuery.ValorParam = ValorParmetro;
                    ParQuery.ParametroSalida = Salida;
                    break;
            }

            ParQuery.TipoParam = TipoParametro;

            ListaParametros.Add(ParQuery);

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    public String NombreParam
    {
        get { return _NombreParam; }
        set { _NombreParam = value; }
    }

    public Object ValorParam
    {
        get { return _ValorParam; }
        set { _ValorParam = value; }
    }

    public TIPO_PARAMETRO TipoParam
    {
        get { return _TipoParam; }
        set { _TipoParam = value; }
    }

    public List<ClaseParametros> ListaParametros
    {
        get { return _ListaParametros; }
        set { _ListaParametros = value; }
    }

    public Boolean ParametroSalida
    {
        get { return _ParametroSalida; }
        set { _ParametroSalida = value; }
    }
}
