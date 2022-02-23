using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
public class GlobalesLibrary
{
    public static List<VIEW_TEXTO> GTextos = new List<VIEW_TEXTO>();
    public static VIEW_USUARIO GUsuario = new VIEW_USUARIO() { USUARIO_ID = 0, IDIOMA_ID = 1 };

    public static String BD_PRODUCTIVO = "";
    public static bool VALIDA_FOLIOS = false;

    #region VALORES DEFAULT

    public const int DEFAULT_MONEDA_ID = 1;
    public const int DEFAULT_MONEDA_ID_VALOR = 1;
    public const int ANIMAL_INDIVIDUAL = 1;
    public const string DEFAULT_STRING_NUMERO = "0";
    public const int DEFAULT_DECIMAL_NUMERO = 0;

    public const int OPERACION_CONSULTAR = 1;
    public const int OPERACION_AGREGAR = 2;
    public const int OPERACION_MODIFICAR = 3;
    public const int OPERACION_ELIMINAR = 4;
    public const int OPERACION_FILTRAR = 5;
    public const int OPERACION_EXPORTAR = 6;
    public const int OPERACION_IMPRIMIR = 7;

    public const string TIPO_DATO_STRING = "System.String";
    public const string TIPO_DATO_ENTERO = "System.Int64";
    public const string TIPO_DATO_DECIMAL = "System.Decimal";
    public const string TIPO_DATO_FECHA = "System.DateTime";
    public const string TIPO_DATO_BOLEANO = "System.Boolean";

    public const string FORMATO_TEXTO = "";
    public const string FORMATO_NUMERO = "#,###";
    public const string FORMATO_DECIMAL = "#,###.00";
    public const string FORMATO_MONEDA = "$#,###.00";
    public const string FORMATO_FECHA = "dd/MM/yyyy";
    public const string FORMATO_HORA = "mm:HH:ss";

    #endregion

    #region CULTURE INFO

    public class CULTURA
    {
        public int CULTURA_ID { get; set; }
        public String DESC_CULTURA_ID { get; set; }
    }

    public const int CULTURA_ESP_MX = 1;
    public const int CULTURA_EN_US = 2;
    public const int CULTURA_FR_FR = 3;
    public const int CULTURA_ZN_CH = 4;
    public const int CULTURA_PT_BR = 5;
    public const int CULTURA_ESP_ES = 6;

    public const String CULTURE_INFO_ESPAÑOL_MX = "es-MX";
    public const String CULTURE_INFO_ESPAÑOL_ES = "es-ES";
    public const String CULTURE_INFO_INGLES = "en-US";
    public const String CULTURE_INFO_FRANCES = "fr-FR";
    public const String CULTURE_INFO_CHINO = "zn-CH";
    public const String CULTURE_INFO_JAPONES = "ja-JP";
    public const String CULTURE_INFO_PORTUGUES = "pt-BR";
    public const String CULTURE_INFO_ALEMAN = "de";
    public const String CULTURE_INFO_RUSO = "RU";

    #endregion


    public static DateTime FechaActualServidor()
    {
        DateTime Fecha = new DateTime();
        try
        {
            Fecha = Conectividad.ObtenerFechaActual();
        }
        catch (Exception ex)
        {
            return new DateTime(1900, 01, 01);
        }
        finally
        {
        }
        return Fecha;
    }
}