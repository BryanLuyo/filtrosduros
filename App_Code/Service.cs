
#region "Comentarios de WS_PREVALUACION"
//************************************************************************************** 
// * Autor: Pablo Uribe
// * Fecha de Creacion: 18-11-2019
// * Descripcion: Servicio que permite conectarse con el servicio proxy power curve pasandole los parametros que solicita
//***************************************************************************************
#endregion


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Threading.Tasks;//ADD HDR(EHC) 20220330 - REQ22205 Paralelo
using Bend.Common.Utils.Utils;
using Domain.Interfaces;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.Scrip    tService]

public class Service : System.Web.Services.WebService, IPrecalificacionService
{

    #region Servicios - Campos

    //ws_rcc.MatrizParametros matrizrcc = new ws_rcc.MatrizParametros(); //MOD HDR(RMC) 20220513 - REQ22205 Se comento linea de codigo

    ServiciosExternos ServiciosExternos = new ServiciosExternos();
    ws_powercurve.EvaluarPwcPrecalificacionCotizacion oDatoPrecalificadorpwc = new ws_powercurve.EvaluarPwcPrecalificacionCotizacion();
    WSExperian.parametro parametromaf = new WSExperian.parametro();
    WSExperian.xmlexperian lxmlrespuesta = new WSExperian.xmlexperian();
    Constantes constante = new Constantes();
    CotizacionDataAdicional parametros = new CotizacionDataAdicional();
    private static LoggerService loggerService;
    private readonly IPrecalificacionService _precalificacionService = new PrecalificacionService();
    string lsRespuesta = "";
    int idSolPwc = 0;
    string StrMensaje = "";
    decimal rci = 0;
    int idExperianCliente;
    decimal puntajeExperian = 0;
    //DataSet dsSaldoFinDet = new DataSet(); //MOD HDR(RMC) 20220329 - REQ22205 Se comento linea de codigo
    DataSet dsClasi = new DataSet();
    #endregion
    public Service()
    {
        loggerService = LoggerService.Instance;
    }
    #region "WebMetodos"
    [WebMethod]
    public RespuestaEvaluacion EvaluarPwcPrecalificacion(Cotizacion toDatosPrecalificador, int idOpcion)
    {
        return _precalificacionService.EvaluarPwcPrecalificacion(toDatosPrecalificador, idOpcion);
    }

    [WebMethod]
    public string PingService(string nombre)
    {
        return nombre + " The ping to services is success";
    }
    #endregion
}
