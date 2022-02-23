using System;
using System.Collections.Generic;

public class ResultadoProceso
{

    bool _HayError = false;
    String _MensajeError = "";
    Object _Respuesta = null;
    String _MensajeRespuesta = "";
    List<Object> _RespuestaLista = null;
    IEnumerable<object> _RespuestaEntidad = null;
    int _TipoRespuesta = 0;
    object _ControlTag = 0;
    object _ValorSalida = 0;
    object _TipoMensaje = 0;

    public ResultadoProceso()
    {
        //Nada
    }

    public bool HayError
    {
        get { return _HayError; }
        set { _HayError = value; }
    }

    public String MensajeError
    {
        get { return _MensajeError; }
        set { _MensajeError = value; }
    }

    public Object Respuesta
    {
        get { return _Respuesta; }
        set { _Respuesta = value; }
    }

    public List<Object> RespuestaLista
    {
        get { return _RespuestaLista; }
        set { _RespuestaLista = value; }
    }

    public IEnumerable<Object> RespuestaEntidad
    {
        get { return _RespuestaEntidad; }
        set { _RespuestaEntidad = value; }
    }
    public String MensajeRespuesta
    {
        get { return _MensajeRespuesta; }
        set { _MensajeRespuesta = value; }
    }

    public int TipoRespuesta
    {
        get { return _TipoRespuesta; }
        set { _TipoRespuesta = value; }
    }
    public object ControlTag
    {
        get { return _ControlTag; }
        set { _ControlTag = value; }
    }
    public object ValorSalida
    {
        get { return _ValorSalida; }
        set { _ValorSalida = value; }
    }
    public object TipoMensaje
    {
        get { return _TipoMensaje; }
        set { _TipoMensaje = value; }
    }
}
