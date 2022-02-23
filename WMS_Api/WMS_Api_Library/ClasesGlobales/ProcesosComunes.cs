using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProcesosComunes
{

    public static string ObtenerTexto(decimal? Idioma, object Tag)
    {
        string Texto = string.Empty;

        try
        {
            switch (Idioma)
            {
                case 1: //Español
                    Texto = GlobalesLibrary.GTextos.Find(t => t.TEXTO_ID == Convert.ToDecimal(Tag)).DESCRIPCION_1;
                    break;
                case 2: //Ingles
                    Texto = GlobalesLibrary.GTextos.Find(t => t.TEXTO_ID == Convert.ToDecimal(Tag)).DESCRIPCION_2;
                    break;
                case 3: //Idioma 3
                    Texto = GlobalesLibrary.GTextos.Find(t => t.TEXTO_ID == Convert.ToDecimal(Tag)).DESCRIPCION_3;
                    break;
                case 4: //Idioma 4
                    Texto = GlobalesLibrary.GTextos.Find(t => t.TEXTO_ID == Convert.ToDecimal(Tag)).DESCRIPCION_4;
                    break;
                case 5: //Idioma 5
                    Texto = GlobalesLibrary.GTextos.Find(t => t.TEXTO_ID == Convert.ToDecimal(Tag)).DESCRIPCION_5;
                    break;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
            Texto = string.Empty;
        }

        if (Texto.Trim().Length <= 0)
            Texto = "ErrorText";

        return Texto;
    }

    //public static string ObtenerTextoEncabezado(String ColumnName)
    //{

    //    string Texto = string.Empty;

    //    try
    //    {
    //        Texto = GlobalesLibrary.GTextos.Find(t => t.DESC_ID.Trim() == ColumnName.Trim()).TEXTO_IDIOMA;
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.ToString();
    //        Texto = ColumnName;
    //    }

    //    return Texto;
    //}

    public static String VERIFICA_CONEXION()
    {
        String ReturnValue = String.Empty;

        Conectividad Cnn = new Conectividad();

        Cnn.Conectar();

        if (Cnn.BASE_DATOS == "GIIC")
            ReturnValue = String.Empty;

        Cnn.Desconectar();

        return ReturnValue;
    }

    /// <summary>
    /// Proceso para validar existe objecto
    /// </summary>
    /// <param name="TABLA">Nombre de la Tabla</param>
    /// <param name="OPERACION">Proceso Agregar o Eliminar</param>
    /// <param name="ENTIDAD">Arreglo de los filtros</param>
    /// <param name="ID">Valor de retorno del ID buscado, cuando existe el objecto</param>
    /// <param name="DESCRIPCION">Valor de retorno de DESCRIPCION buscado, cuando existe el objecto</param>
    /// <returns></returns>
    public static bool EXISTE_OBJECTO(String TABLA, int OPERACION, object[] ENTIDAD, ref object ID, ref object DESCRIPCION)
    {
        bool HayError = false;

        ID = "";
        DESCRIPCION = "";

        return HayError;
    }
    
}