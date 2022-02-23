using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ORDEN_COMPRA_RECEPCION_MATERIALProceso
{
    public ResultadoProceso Obtener(VIEW_ORDEN_COMPRA_RECEPCION_MATERIAL Ent = null)
    {
        ResultadoProceso Retorno = new ResultadoProceso();
        Conectividad Cnn = new Conectividad();
        AccesoDatosCatalogos dll = new AccesoDatosCatalogos();
        string Error = string.Empty;

        try
        {
            List<VIEW_ORDEN_COMPRA_RECEPCION_MATERIAL> ResLista = new List<VIEW_ORDEN_COMPRA_RECEPCION_MATERIAL>();

            Cnn.Conectar();

            ResLista = dll.ObtenerORDEN_COMPRA_RECEPCION_MATERIAL(Cnn, ref Error,Convert.ToInt32(Ent.OPERACION),0, Ent);

            if (ResLista.Count > 0)
            {
                Retorno.HayError = false;
                Retorno.Respuesta = ResLista;
            }
            else
            {
                if (Error.Trim().Length > 0)
                {
                    Retorno.MensajeError = Error;
                    Retorno.HayError = true;
                }
                else
                {
                    Retorno.HayError = false;
                }

                Retorno.Respuesta = null;
            }

        }
        catch (Exception ex)
        {
            Retorno.HayError = true;
            Retorno.MensajeError = ex.ToString();
            Retorno.Respuesta = null;
        }
        finally
        {
            Cnn.Desconectar();
        }

        return Retorno;
    }
}

