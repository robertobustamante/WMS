using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WMS_Api.Controllers.Comunes
{
    public class IMPRESORAController : ApiController
    {
        [HttpPost]
        public void Post(int TipoImpresion, string id, int Impresora)
        {
            string vPath = @"C:\ETIQUETAS\";
            string vArchivoLocal = vPath + "ETP" + id + ".txt";
           

            try
            {
                switch (Impresora)
                {
                    case 1:
                       
                        Process.Start(vPath + "ImprimirEtiqueta.bat", vArchivoLocal);
                       // Process.Start(psi);
                        //
                        break;
                    case 2:
                        //
                        break;
                    default:
                        //
                        break;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
