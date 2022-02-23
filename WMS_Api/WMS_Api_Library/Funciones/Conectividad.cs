using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class Conectividad
{

    public static string Connectionstring = @"Data Source=localhost;Initial Catalog=GIIC_QA;Persist Security Info=True;User ID=SA;Password=Imperial258";

    public static SqlConnection Conexion;
    protected static SqlConnection Conexion1;
    protected static SqlTransaction Trans;
    protected static Conectividad.TransactionCollection Transaccion = new TransactionCollection();
    protected static SqlCommand Comando;
    protected static string Prefijo = "@";
    protected static SqlParameter ValorRetorno;
    protected static SqlParameter ValorMensaje;
    protected static SqlParameter ValorTag;
    protected static SqlParameter ParametroRetorno;
    protected static SqlDataAdapter TablaRetorno;
    protected static SqlDataReader Retorno;
    String _BASE_DATOS = string.Empty;
    Dictionary<string, string> ParametroOutPut = new Dictionary<string, string>();

    public static bool MantenerConexion { get; set; } = false;

    public Conectividad()
    {

    }

    public bool Conectar()
    {
        if (MantenerConexion && Conexion != null && Conexion.State == ConnectionState.Open)
        {
            return true;
        }
        bool returnValue = true;

        Conexion = new SqlConnection();

        Conexion.ConnectionString = Connectionstring;

        Conexion.Open();

        BASE_DATOS = Conexion.Database;

        return returnValue;
    }

    public bool Desconectar()
    {

        if (MantenerConexion)
        {
            return true;
        }
        bool returnValue = true;

        if (Conexion.State == ConnectionState.Open)
            Conexion.Close();

        return returnValue;
    }

    public bool IniciarTransaccion(String NombreTransaccion)
    {
        bool returnValue = false;

        //if (MantenerConexion)
        //{
        //    return true;
        //}

        NombreTransaccion = NombreTransaccion.PadRight(32, '0').Substring(0, 31);

        SqlTransaction sqlTransaction;

        if (Transaccion.Count > 0)
        {
            Conexion1 = new SqlConnection
            {
                ConnectionString = Connectionstring
            };

            Conexion1.Open();
            sqlTransaction = Conexion1.BeginTransaction(NombreTransaccion);
        }
        else
            sqlTransaction = Conexion.BeginTransaction(NombreTransaccion);

        if (sqlTransaction != null)
        {
            Transaccion.Add(NombreTransaccion, sqlTransaction);
            returnValue = true;
        }

        return returnValue;
    }

    public bool CancelarTransaccion(String NombreTransaccion)
    {
        bool returnValue = true;

        //if (MantenerConexion)
        //{
        //    return true;
        //}

        NombreTransaccion = NombreTransaccion.PadRight(32, '0').Substring(0, 31);

        if (Transaccion[NombreTransaccion] != null)
        {
            if (Transaccion.Count == 1)
                Transaccion[NombreTransaccion].Rollback();
            else
            {
                Transaccion[NombreTransaccion].Rollback();
                Conexion1.Close();
            }
        }

        Transaccion.Remove(NombreTransaccion);

        return returnValue;
    }

    public bool ConfirmarTransaccion(String NombreTransaccion)
    {
        bool returnValue = true;

        //if (MantenerConexion)
        //{
        //    return true;
        //}

        NombreTransaccion = NombreTransaccion.PadRight(32, '0').Substring(0, 31);

        if (Transaccion[NombreTransaccion] != null)
        {
            if (Transaccion.Count == 1)
                Transaccion[NombreTransaccion].Commit();
            else
            {
                Transaccion[NombreTransaccion].Commit();
                Conexion1.Close();
            }
        }

        Transaccion.Remove(NombreTransaccion);

        return returnValue;
    }

    public static DataSet ObtenerConsulta(String Query)
    {
        SqlConnection Cnn = new SqlConnection();
        Cnn.ConnectionString = Connectionstring;

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = new SqlCommand(Query, Cnn);

        Cnn.Open();
        da.Fill(ds);
        Cnn.Close();

        return ds;
    }

    public DataTable LeerSP(string StoredProcedure, ClaseParametros Param)
    {
        DataTable returnValue = new DataTable();

        ClearParams();

        if (Transaccion.Count > 0)
            Comando = new SqlCommand(StoredProcedure, Conexion, (SqlTransaction)Transaccion[checked(Transaccion.Count - 1)].Value);
        else
            Comando = new SqlCommand(StoredProcedure, Conexion);

        Comando.CommandTimeout = 60;

        Comando.CommandType = CommandType.StoredProcedure;

        foreach (ClaseParametros item in Param.ListaParametros)
        {
            Comando.Parameters.AddWithValue(Prefijo + item.NombreParam, item.ValorParam);
        }

        ValorRetorno = new SqlParameter("@RETORNO", SqlDbType.Int);

        ValorRetorno.Direction = ParameterDirection.Output;

        Comando.Parameters.Add(ValorRetorno);

        TablaRetorno = new SqlDataAdapter(Comando);

        TablaRetorno.Fill(returnValue);

        return returnValue;
    }

    public int LeerID(string StoredProcedure, ClaseParametros Param)
    {
        int returnValue = 0;

        ClearParams();

        if (Transaccion.Count > 0)
        {
            if (Transaccion.Count > 1)
                Comando = new SqlCommand(StoredProcedure, Conexion1, (SqlTransaction)Transaccion[checked(Transaccion.Count - 1)].Value);
            else
                Comando = new SqlCommand(StoredProcedure, Conexion, (SqlTransaction)Transaccion[checked(Transaccion.Count - 1)].Value);
        }
        else
            Comando = new SqlCommand(StoredProcedure, Conexion);

        Comando.CommandTimeout = 60;

        Comando.CommandType = CommandType.StoredProcedure;

        foreach (ClaseParametros item in Param.ListaParametros)
        {
            Comando.Parameters.AddWithValue(Prefijo + item.NombreParam, item.ValorParam);
        }

        ValorRetorno = new SqlParameter("@RETORNO", SqlDbType.Int);

        ValorRetorno.Direction = ParameterDirection.Output;

        Comando.Parameters.Add(ValorRetorno);

        Comando.ExecuteNonQuery();

        if (Convert.ToInt32(ValorRetorno.Value) > 0)
            returnValue = Convert.ToInt32(ValorRetorno.Value);
        else
            returnValue = Convert.ToInt32(ValorRetorno.Value);

        return returnValue;
    }

    public bool EjecutarSP(string StoredProcedure, ClaseParametros Param)
    {
        bool returnValue = false;

        ClearParams();

        if (Transaccion.Count > 0)
        {
            if (Transaccion.Count > 1)
                Comando = new SqlCommand(StoredProcedure, Conexion1, (SqlTransaction)Transaccion[checked(Transaccion.Count - 1)].Value);
            else
                Comando = new SqlCommand(StoredProcedure, Conexion, (SqlTransaction)Transaccion[checked(Transaccion.Count - 1)].Value);
        }
        else
            Comando = new SqlCommand(StoredProcedure, Conexion);

        Comando.CommandTimeout = 60;

        Comando.CommandType = CommandType.StoredProcedure;

        foreach (ClaseParametros item in Param.ListaParametros)
        {
            Comando.Parameters.AddWithValue(Prefijo + item.NombreParam, item.ValorParam);
        }

        ValorRetorno = new SqlParameter("@RETORNO", SqlDbType.Int);

        ValorRetorno.Direction = ParameterDirection.Output;

        Comando.Parameters.Add(ValorRetorno);

        Comando.ExecuteNonQuery();

        if (Convert.ToInt64(ValorRetorno.Value) > 0)
            returnValue = true;
        else
            returnValue = false;

        return returnValue;
    }

    public string ValidarSP(string StoredProcedure, ClaseParametros Param)
    {
        string returnValue = string.Empty;

        ClearParams();

        if (Transaccion.Count > 0)
        {
            if (Transaccion.Count > 1)
                Comando = new SqlCommand(StoredProcedure, Conexion1, (SqlTransaction)Transaccion[checked(Transaccion.Count - 1)].Value);
            else
                Comando = new SqlCommand(StoredProcedure, Conexion, (SqlTransaction)Transaccion[checked(Transaccion.Count - 1)].Value);
        }
        else
            Comando = new SqlCommand(StoredProcedure, Conexion);

        Comando.CommandTimeout = 60;

        Comando.CommandType = CommandType.StoredProcedure;

        foreach (ClaseParametros item in Param.ListaParametros)
        {
            Comando.Parameters.AddWithValue(Prefijo + item.NombreParam, item.ValorParam);
        }

        ValorRetorno = new SqlParameter("@RETORNO", SqlDbType.VarChar, 500);

        ValorRetorno.Direction = ParameterDirection.Output;

        Comando.Parameters.Add(ValorRetorno);

        Comando.ExecuteNonQuery();

        if (Convert.ToString(ValorRetorno.Value).Trim().Length > 0)
            returnValue = Convert.ToString(ValorRetorno.Value).Trim();
        else
            returnValue = Convert.ToString(ValorRetorno.Value).Trim();

        return returnValue;
    }

    public string ValidaProcesoSP(string StoredProcedure, ClaseParametros Param, ref object TipoMensaje, ref object ControlTag, ref object ParametroSalida)
    {
        string returnValue = string.Empty;
        //ParametroSalida = new Dictionary<string, string>();
        ClearParams();

        if (Transaccion.Count > 0)
        {
            if (Transaccion.Count > 1)
                Comando = new SqlCommand(StoredProcedure, Conexion1, (SqlTransaction)Transaccion[checked(Transaccion.Count - 1)].Value);
            else
                Comando = new SqlCommand(StoredProcedure, Conexion, (SqlTransaction)Transaccion[checked(Transaccion.Count - 1)].Value);
        }
        else
            Comando = new SqlCommand(StoredProcedure, Conexion);

        Comando.CommandTimeout = 60;

        Comando.CommandType = CommandType.StoredProcedure;

        Comando.Parameters.AddWithValue("@IDIOMA",GlobalesLibrary.GUsuario.IDIOMA_ID);

        foreach (ClaseParametros item in Param.ListaParametros)
        {

            Comando.Parameters.AddWithValue(Prefijo + item.NombreParam, item.ValorParam);

            //if (item.ParametroSalida)
            //{
            //    //ParametroRetorno = new SqlParameter(Prefijo + item.NombreParam,item.TipoParam);
            //    //ParametroRetorno.Direction = ParameterDirection.Output;
            //    //Comando.Parameters.Add(ParametroRetorno);
            //    //ParametroSalida.Add(item.NombreParam, "");
            //}
            //else
            //{
            //    Comando.Parameters.AddWithValue(Prefijo + item.NombreParam, item.ValorParam);
            //}


        }

        ValorRetorno = new SqlParameter("@TIPO_MENSAJE", SqlDbType.Int);
        ValorMensaje = new SqlParameter("@MENSAJE", SqlDbType.VarChar,250);
        ValorTag = new SqlParameter("@TAG", SqlDbType.Int);
        ParametroRetorno = new SqlParameter("@RETORNO_VALOR", SqlDbType.VarChar, 500);

        ValorRetorno.Direction = ParameterDirection.Output;
        ValorMensaje.Direction = ParameterDirection.Output;
        ValorTag.Direction = ParameterDirection.Output;
        ParametroRetorno.Direction = ParameterDirection.Output;

        Comando.Parameters.Add(ValorRetorno);
        Comando.Parameters.Add(ValorMensaje);
        Comando.Parameters.Add(ValorTag);
        Comando.Parameters.Add(ParametroRetorno);

        Comando.ExecuteNonQuery();
        
        //foreach (KeyValuePair<string,string>  item in ParametroSalida)
        //{
        //   if(Comando.ExecuteReader().GetSchemaTable().Columns.Equals(item.Key))
        //    {
        //       // item.Value = Comando.ExecuteReader().GetSchemaTable().Select()
        //    }
        //}

        if (Convert.ToString(ValorMensaje.Value).Trim().Length > 0)
            returnValue = Convert.ToString(ValorMensaje.Value).Trim();

        TipoMensaje = ValorRetorno.Value;
        ControlTag = ValorTag.Value;
        ParametroSalida = ParametroRetorno.Value;

        return returnValue;
    }


    public void ClearParams()
    {
        if (Comando != null)
            Comando.Parameters.Clear();
    }

    public static DateTime ObtenerFechaActual()
    {
        DateTime FechaActual = new DateTime();
        
        Conexion = new SqlConnection();
        Conexion.ConnectionString = Connectionstring;

        Comando = new SqlCommand("SELECT GETDATE() AS FECHA_ACTUAL", Conexion);

        Conexion.Open();

        Retorno = Comando.ExecuteReader();

        if (Retorno.Read())
        {
            FechaActual = Retorno.GetDateTime(0);
        }

        Conexion.Close();

        return FechaActual;
    }

    public class TransactionCollection : NameObjectCollectionBase
    {
        public DictionaryEntry this[int index]
        {
            get
            {
                return new DictionaryEntry((object)this.BaseGetKey(index), RuntimeHelpers.GetObjectValue(this.BaseGet(index)));
            }
        }

        public SqlTransaction this[string key]
        {
            get
            {
                return (SqlTransaction)this.BaseGet(key);
            }
            set
            {
                this.BaseSet(key, (object)value);
            }
        }

        public string[] AllKeys
        {
            get
            {
                return this.BaseGetAllKeys();
            }
        }

        public bool HasKeys
        {
            get
            {
                return this.BaseHasKeys();
            }
        }

        public TransactionCollection()
        {
        }

        public TransactionCollection(IDictionary d, bool bReadOnly)
        {
            foreach (object obj in d)
            {
                DictionaryEntry dictionaryEntry1;
                DictionaryEntry dictionaryEntry2 = obj != null ? (DictionaryEntry)obj : dictionaryEntry1;
                this.BaseAdd(Convert.ToString(dictionaryEntry2.Key), RuntimeHelpers.GetObjectValue(dictionaryEntry2.Value));
            }
            this.IsReadOnly = bReadOnly;
        }

        public void Add(string key, SqlTransaction value)
        {
            this.BaseAdd(key, (object)value);
        }

        public void Remove(string key)
        {
            this.BaseRemove(key);
        }

        public void Remove(int index)
        {
            this.BaseRemoveAt(index);
        }

        public void Clear()
        {
            this.BaseClear();
        }
    }
    
    public String BASE_DATOS
    {
        get { return _BASE_DATOS; }
        set { _BASE_DATOS = value; }
    }
}
