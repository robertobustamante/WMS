using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class Parametro
{
    private string _Nombre;
    private object _Valor;
    private Parametro.TIPO_PARAMETRO _Tipo;

    public string Nombre
    {
        get
        {
            return this._Nombre;
        }
        set
        {
            this._Nombre = value;
        }
    }

    public object Valor
    {
        get
        {
            return this._Valor;
        }
        set
        {
            this._Valor = RuntimeHelpers.GetObjectValue(value);
        }
    }

    public Parametro.TIPO_PARAMETRO Tipo
    {
        get
        {
            return this._Tipo;
        }
        set
        {
            this._Tipo = value;
        }
    }

    public Parametro()
    {
        this._Nombre = "";
        this._Valor = (object)null;
        this._Tipo = Parametro.TIPO_PARAMETRO.TEXTO;
    }

    public Parametro(string Nombre, object Valor, Parametro.TIPO_PARAMETRO Tipo)
    {
        this._Nombre = "";
        this._Valor = (object)null;
        this._Tipo = Parametro.TIPO_PARAMETRO.TEXTO;
        this._Nombre = Nombre;
        this._Valor = RuntimeHelpers.GetObjectValue(Valor);
        this._Tipo = Tipo;
    }

    public Parametro(string Nombre, string Valor)
    {
        this._Nombre = "";
        this._Valor = (object)null;
        this._Tipo = Parametro.TIPO_PARAMETRO.TEXTO;
        this._Nombre = Nombre;
        this._Valor = (object)Valor;
        this._Tipo = Parametro.TIPO_PARAMETRO.TEXTO;
    }

    public enum TIPO_PARAMETRO
    {
        TEXTO,
        NUMERO,
        FECHA,
        FECHA_HORA,
        BOLEANO,
        IMAGEN,
        BINARIO,
    }
}