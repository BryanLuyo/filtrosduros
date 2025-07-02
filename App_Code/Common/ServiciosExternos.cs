
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using Bend.Common.Logging.Interface;
using MAF.BanTotal.NetFramework.Common.Transports.Services.Responses.Buro;
using Newtonsoft.Json;

public class ServiciosExternos
{

    private const int coberturaID = 25102;//TotalRiesgo
    private const int productoID = 20066; //CreditoVehicular
    private const bool motorshow = false;
    public string IdCotizacion = string.Empty;
    public readonly LoggerInstance logger = new LoggerInstance();


    public decimal Obte(int idClienteScore)
    {
        decimal scorePuntaje = 0;
        using (WSExperian.ServiceSoapClient client = new WSExperian.ServiceSoapClient())
        {
            scorePuntaje = client.ObtenerPuntajeScoreExperian(idClienteScore);
        }
        return scorePuntaje;
    }


    /// <summary>
    /// calculo RCI
    /// </summary>
    /// <param name="cotizacion"></param>
    /// <returns></returns>
    public RatioCuotaIngresoResponseBT CalculoRCI(CotizacionDataAdicional cotizacion, double cuotaMonedaMaf) //MOD HDR(RMC) 20220329 - REQ22205 Se cambio ws_rcc.MatrizParametros por CalcularRatioCuotaIngresoResponse
    {
        string lRespuestaCalculoRCI;
        //ws_rcc.MatrizParametros oRequest = new ws_rcc.MatrizParametros();

        try
        {
            ////INI HDR(RMC) 20220329 - REQ22205 Se agrego seccion de codigo
            //OperacionesServiceBT serviceBT = new OperacionesServiceBT();

            //CalcularRatioCuotaIngresoRequestBT calcularRatioCuotaIngresoRequestBT = new CalcularRatioCuotaIngresoRequestBT();

            //calcularRatioCuotaIngresoRequestBT.TipoCambio = cotizacion.TipoCambio;
            //calcularRatioCuotaIngresoRequestBT.TipoPersona = cotizacion.TipoPersona;
            //calcularRatioCuotaIngresoRequestBT.NroDocumentoTitular = cotizacion.NumeroDocumento;
            //calcularRatioCuotaIngresoRequestBT.PlanCredito = cotizacion.PlanCredito;
            //calcularRatioCuotaIngresoRequestBT.MonedaFinanciamiento = cotizacion.MonedaCredito; //Preguntar

            //if (cotizacion.IngresoMensualConyugeSoles > 0)
            //{
            //    calcularRatioCuotaIngresoRequestBT.NroSueldosAnualConyuge = 12;
            //    calcularRatioCuotaIngresoRequestBT.NroDocumentoConyuge = cotizacion.NumeroDocumentoConyuge;
            //    calcularRatioCuotaIngresoRequestBT.MontoIngresoConyugeSoles = cotizacion.IngresoMensualConyugeSoles;
            //}

            //calcularRatioCuotaIngresoRequestBT.NroSueldosAnualTitular = ObtenerNumeroSueldos(cotizacion.CodigoCategoriaLaboral, 0, false);
            //decimal montoIngresoSoles5ta = (cotizacion.IngresoMensualTitularSoles * (14M / 12M));
            //calcularRatioCuotaIngresoRequestBT.MontoIngresoTitularSoles = Math.Round(montoIngresoSoles5ta, 2);
            //calcularRatioCuotaIngresoRequestBT.MontoCuotaMafDolar = (cotizacion.MonedaCredito == MonedaMaf.DOLARES ? (decimal)cuotaMonedaMaf : ((decimal)cuotaMonedaMaf / (decimal)cotizacion.TipoCambio));
            //calcularRatioCuotaIngresoRequestBT.MontoCuotaMafSoles = (cotizacion.MonedaCredito == MonedaMaf.SOLES ? (decimal)cuotaMonedaMaf : ((decimal)cuotaMonedaMaf * (decimal)cotizacion.TipoCambio));
            //calcularRatioCuotaIngresoRequestBT.IndTaxista = 0;
            //calcularRatioCuotaIngresoRequestBT.CuotaReprogramadaDolar = cotizacion.CuotaReprogramadaDolar;
            //calcularRatioCuotaIngresoRequestBT.CuotaReprogramadaSoles = (cotizacion.CuotaReprogramadaDolar * (decimal)cotizacion.TipoCambio);
            //calcularRatioCuotaIngresoRequestBT.GastosOperativosMoneda = 0; //Preguntar

            ////INI ADD CSTI(JF) REQ22205 10112022       
            //calcularRatioCuotaIngresoRequestBT.PaisTitular = cotizacion.PaisTitular;
            //calcularRatioCuotaIngresoRequestBT.TipoDocumentoTitular = cotizacion.TipoDocumentoTitular;
            //calcularRatioCuotaIngresoRequestBT.PaisConyuge = cotizacion.PaisConyuge;
            //calcularRatioCuotaIngresoRequestBT.TipoDocumentoConyuge = cotizacion.TipoDocumentoConyuge;
            //calcularRatioCuotaIngresoRequestBT.Plazo = cotizacion.Plazo;
            ////FIN ADD CSTI(JF) REQ22205 10112022

            //lRespuestaCalculoRCI = Newtonsoft.Json.JsonConvert.SerializeObject(calcularRatioCuotaIngresoRequestBT);

            ////logger.SaveLogAsync(LogHandler.CreateLogEvent(oRequest, "ObtenerCotizacion " + lRespuestaCalculoRCI));
            //WriteLogBT(lRespuestaCalculoRCI, "WI 66 - Api Bantotal - CalcularRCI", true);

            //var resultado = serviceBT.CalcularRCIBT(calcularRatioCuotaIngresoRequestBT); //MOD CSTI(JF) REQ22205 09112022

            //string res = Newtonsoft.Json.JsonConvert.SerializeObject(resultado);
            //WriteLogBT(res, "WI 66 - Api Bantotal - CalcularRCI", false);

            //return resultado;
            //FIN HDR(RMC) 20220330 - REQ22205

            //using (ws_rcc.Service oService = new ws_rcc.Service())
            //{
            //    oRequest.IDMATRIZ = 0;
            //    oRequest.TIPOCAMBIO = (double)cotizacion.TipoCambio;
            //    oRequest.I067TIPOPERSONA = cotizacion.TipoPersona;
            //    oRequest.NRODOCUMENTOTITULAR = cotizacion.NumeroDocumento;
            //    oRequest.I801PLANCREDITO = cotizacion.PlanCredito;
            //    oRequest.IDCONYUGE = 0;
            //    oRequest.NROSUELDOANUALCONYUGE = "";
            //    oRequest.NRODOCUMENTOCONYUGE = "";
            //    oRequest.MONTOINGRESOCONYUGESOLES = 0;
            //    oRequest.MONTOCARGAFAMILIARDOLAR = 0;
            //    oRequest.PORCENTAJEMARGENUTILIDAD = 0;
            //    oRequest.I834REGIMENSUNAT = 0;
            //    oRequest.MONEDAFINANCIAMIENTO = cotizacion.MonedaCredito;
            //    if (cotizacion.IngresoMensualConyugeSoles > 0)
            //    {
            //        oRequest.NRODOCUMENTOCONYUGE = cotizacion.NumeroDocumentoConyuge;
            //        oRequest.IDCONYUGE = 0;
            //        oRequest.NROSUELDOANUALCONYUGE = "12";
            //        oRequest.MONTOINGRESOCONYUGESOLES = cotizacion.IngresoMensualConyugeSoles;
            //    }
            //    oRequest.NROSUELDOSANUALTITULAR = Convert.ToString(ObtenerNumeroSueldos(cotizacion.CodigoCategoriaLaboral, 0, false));
            //    decimal montoIngresoSoles5ta = (cotizacion.IngresoMensualTitularSoles * (14M / 12M));
            //    oRequest.MONTOINGRESOTITULARSOLES = Math.Round(montoIngresoSoles5ta, 2);
            //    oRequest.MONTONIVELENDEUDAMIENTODOLAR = (double)oService.ObtenerNivelEndeudamientoDolar(oRequest);
            //    oRequest.MONTOCUOTAMAFDOLAR = (cotizacion.MonedaCredito == MonedaMaf.DOLARES ? cuotaMonedaMaf : (cuotaMonedaMaf / (double)cotizacion.TipoCambio));
            //    oRequest.MONTOCUOTAMAFSOLES = (cotizacion.MonedaCredito == MonedaMaf.SOLES ? cuotaMonedaMaf : (cuotaMonedaMaf * (double)cotizacion.TipoCambio));
            //    oRequest.INGRESOPROMEDIODOLAR = Convert.ToDouble(Math.Round((cotizacion.IngresoMensualTitularSoles) / cotizacion.TipoCambio, 2));
            //    oRequest.COSTOMENSUALDOLAR = 0;//ObtenerCostoMensualDolar(oSolicitud.Cliente.i067TipoPersona.IDENT_CAMPO.Value, oSolicitud.Cliente.Id.Value, CInt(solicitud.Item("CONYUGE").ToString.Trim), matrizrcc.PORCENTAJEMARGENUTILIDAD)
            //    oRequest.INDTAXISTA = 0;// oSolicitud.INDTAXISTA.Value
            //    oRequest.CUOTAREPROGRAMADADOLAR = cotizacion.CuotaReprogramadaDolar; //ADD-CSP(MCL)-REQ12763-20190424

            //    lRespuestaCalculoRCI = Newtonsoft.Json.JsonConvert.SerializeObject(oRequest);

            //    //logger.SaveLogAsync(LogHandler.CreateLogEvent(oRequest, "ObtenerCotizacion " + lRespuestaCalculoRCI));
            //    WriteLog(lRespuestaCalculoRCI, "ws_rcc.CalcularRCI", true);
            //    bool dato = oService.CalcularRCI(ref oRequest);

            //    lRespuestaCalculoRCI = Newtonsoft.Json.JsonConvert.SerializeObject(oRequest);
            //    WriteLog(lRespuestaCalculoRCI, "ws_rcc.CalcularRCI", false);
            //}
            //return oRequest;
            return new RatioCuotaIngresoResponseBT();
        }
        catch (Exception ex)
        {
            logger.SaveLogAsync(LogHandler.CreateLogErrorAndWarning("Errores", ex));
            throw new Exception("Error en Obtener Calculo en WI 66 - Api Bantotal - CalcularRCI", ex); //MOD HDR(RMC) 20220329 - REQ22205 Se cambio RCI por WI 66 - Api Bantotal - CalcularRCI

        }
    }

    internal void LogRequest(Cotizacion toDatosPrecalificador, int idOpcion)
    {
        string res = JsonConvert.SerializeObject(toDatosPrecalificador);
        WriteLog(res, "EvaluarPwcPrecalificacion Request-" + IdCotizacion + "-Opcion:" + idOpcion, true);
    }

    public SaldoSistemaFinancieroResponseBT ObtenerSaldosistemaSaldos(int i067tipopersona, int i062tipodocumento, string identificador, int meses) //INI HDR(RMC) 20220329 - REQ22205 Se cambio DataSet por ConsultarSaldoSistemaFinancieroResponse 
    {
        string lRespuestaConsultaSaldoRCI;
        //DataSet Resultado = new DataSet();
        try
        {
            ////INI HDR(RMC) 20220329 - REQ22205 Se agrego seccion de codigo
            //OperacionesServiceBT serviceBT = new OperacionesServiceBT();

            //lRespuestaConsultaSaldoRCI = "Tipo persona:" + i067tipopersona + ", tipodocumento:" + i062tipodocumento + ", identificador:" + identificador + ", meses:" + meses;
            //WriteLogBT(lRespuestaConsultaSaldoRCI, "WI 66 - Api Bantotal - ConsultarSaldos -" + IdCotizacion, true);

            //var resultado = serviceBT.ConsultarSaldoSistemaFinancieroDetalleBT(i067tipopersona, i062tipodocumento, identificador, meses);

            //string res = JsonConvert.SerializeObject(resultado);
            //WriteLogBT(res, "WI 66 - Api Bantotal - ConsultarSaldos -" + IdCotizacion, false);

            //return resultado;
            //INI HDR(RMC) 20220329 - REQ22205 

            //using (ws_rcc.Service rcc = new ws_rcc.Service())
            //{
            //    lRespuestaConsultaSaldoRCI = "Tipo persona:" + i067tipopersona + ", tipodocumento:" + i062tipodocumento + ", identificador:" + identificador + ", meses:" + meses;
            //    WriteLog(lRespuestaConsultaSaldoRCI, "ws_rcc.ConsultarSaldos Request-" + IdCotizacion, true);

            //    Resultado = rcc.ConsultarSaldoSistemaFinancieroDetalle(i067tipopersona, i062tipodocumento, identificador, meses);

            //    string res = JsonConvert.SerializeObject(Resultado);
            //    WriteLog(res, "ws_rcc.ConsultarSaldos Response-" + IdCotizacion, true);

            //}

            //return Resultado;
            return new SaldoSistemaFinancieroResponseBT();
        }
        catch (Exception ex)
        {
            logger.SaveLogAsync(LogHandler.CreateLogErrorAndWarning("Errores", ex));
            throw new Exception("Error en obtener Saldos en WI 66 - Api Bantotal - ConsultarSaldos", ex); //INI HDR(RMC) 20220329 - REQ22205 RCI por WI 66 - Api Bantotal - ConsultarSaldos
        }
    }


    public ClasificacionSBSHistoricaResponseBT ObtenerClasificacionSBSHistorica(int i067tipopersona, int i062tipodocumento, string identificador, int meses) //MOD HDR(RMC) 20220329 - REQ22205 Se cambio DataSet por ConsultarSaldoSistemaFinancieroResponse 
    {
        string lRespuestaClasificacionSBSHistorica;
        //DataSet Resultado = new DataSet();
        try
        {
            //INI HDR(RMC) 20220329 - REQ22205 Se agrego seccion de codigo
            //OperacionesServiceBT serviceBT = new OperacionesServiceBT();

            //lRespuestaClasificacionSBSHistorica = "Tipo persona:" + i067tipopersona + ", tipodocumento:" + i062tipodocumento + ", identificador:" + identificador + ", meses:" + meses;
            //WriteLogBT(lRespuestaClasificacionSBSHistorica, "WI 66 - Api Bantotal - Clasificacion SBS Historica Request-" + IdCotizacion, true);
            //var resultado = serviceBT.ListarClasificacionSBSHistoricaBT(i067tipopersona, i062tipodocumento, identificador, meses); //MOD CSTI(JF) REQ22205 09112022 
            //string res = JsonConvert.SerializeObject(resultado);
            //WriteLogBT(res, "WI 66 - Api Bantotal - Clasificacion SBS Historica Response-" + IdCotizacion, true);

            //return resultado;
            //FIN HDR(RMC) 20220329 - REQ22205 

            //using (ws_rcc.Service rcc = new ws_rcc.Service())
            //{
            //    lRespuestaClasificacionSBSHistorica = "Tipo persona:" + i067tipopersona + ", tipodocumento:" + i062tipodocumento + ", identificador:" + identificador + ", meses:" + meses;
            //    WriteLog(lRespuestaClasificacionSBSHistorica, "ws_rcc.Clasificacion Request-" + IdCotizacion, true);
            //    Resultado = rcc.ListarClasificacionSBSHistorica(i067tipopersona, i062tipodocumento, identificador, meses);
            //    string res = JsonConvert.SerializeObject(Resultado);
            //    WriteLog(res, "ws_rcc.Clasificacion Response-" + IdCotizacion, true);
            //}
            //return Resultado;
            return new ClasificacionSBSHistoricaResponseBT();
        }
        catch (Exception ex)
        {
            logger.SaveLogAsync(LogHandler.CreateLogErrorAndWarning("Errores", ex));
            throw new Exception("Error en obtener Clasificiacion en RCC", ex);
        }
    }



    private int ObtenerNumeroSueldos(int categoriaLaboral, int tipoEmpresa, bool nroSueldosQC)
    {
        int nroSueldo = 12;
        if (categoriaLaboral == 20077) // quinta categoria
        {
            //if (tipoEmpresa == 22062) // privada
            // {
            nroSueldo = 14;
            nroSueldosQC = true;
            // }
            // else
            //  {
            //     nroSueldosQC = false;
            // }
        }
        return nroSueldo;

    }

    public int ObtenerExperian(Cotizacion toDatosPrecalificador, WSExperian.parametro parametromaf, ref WSExperian.xmlexperian lxmlrespuesta)
    {
        int IdExperianCliente = 0;
        string lRespuestaExperian;
        try
        {
            using (WSExperian.ServiceSoapClient experian = new WSExperian.ServiceSoapClient())
            {
                
                //El usuario por defecto es 0 
                lRespuestaExperian = Newtonsoft.Json.JsonConvert.SerializeObject(toDatosPrecalificador);
                WriteLog(lRespuestaExperian, "wsexperian.experian.RegistrarServicioExperianParamDesacoplado", true);
                IDictionary<string, int> ObExperian = new Dictionary<string, int>();
                var cachevar = HttpRuntime.Cache.Get("wsObtenerExperianCache");
                var cadena = toDatosPrecalificador.NumeroCotizacion + "-" + Convert.ToInt32(toDatosPrecalificador.I062TipoDocumento)+ "-" + toDatosPrecalificador.NumeroDocumento + "-" + toDatosPrecalificador.ApellidoPaterno + "-" + 0;
                if (cachevar != null)
                {
                    ObExperian = (IDictionary<string, int>)cachevar;
                    var rpta = ObExperian.FirstOrDefault(i => i.Key.Equals(cadena));
                    //if (rpta.Value != 0)
                        return rpta.Value;
                }
                IdExperianCliente = experian.RegistrarServicioExperianParamDesacoplado(toDatosPrecalificador.NumeroCotizacion,
                Convert.ToInt32(toDatosPrecalificador.I062TipoDocumento), toDatosPrecalificador.NumeroDocumento, toDatosPrecalificador.ApellidoPaterno, 0,
                parametromaf, ref lxmlrespuesta);
                ObExperian.Add(cadena, IdExperianCliente);
                HttpRuntime.Cache.Insert("wsObtenerExperianCache", ObExperian, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);

                lRespuestaExperian = Convert.ToString(IdExperianCliente);
                WriteLog(lRespuestaExperian, "wsexperian.experian.RegistrarServicioExperianParamDesacoplado", false);

            }
            return IdExperianCliente;
        }
        catch (Exception ex)
        {
            logger.SaveLogAsync(LogHandler.CreateLogErrorAndWarning("Errores", ex));
            throw new Exception("Error en obtener IdExperian", ex);
        }

    }

    public decimal ObtenerPuntajeScoreExperian(int idExperianCliente)
    {
        decimal puntajeExperian = 0;

        try
        {
            using (WSExperian.ServiceSoapClient experian = new WSExperian.ServiceSoapClient())
            {
                IDictionary<string, decimal> ObPuntajeScoreExperian = new Dictionary<string, decimal>();
                var cachevar = HttpRuntime.Cache.Get("wsObtenerPuntajeScoreExperianCache");
                var cadena = ""+idExperianCliente;
                if (cachevar != null)
                {
                    ObPuntajeScoreExperian = (IDictionary<string, decimal>)cachevar;
                    var rpta = ObPuntajeScoreExperian.FirstOrDefault(i => i.Key.Equals(cadena));
                    //if (rpta.Value != 0)
                    return rpta.Value;
                }
                WriteLog(Convert.ToString(idExperianCliente), "wsexperian.experian.ObtenerIdExperian", true);
                puntajeExperian = experian.ObtenerPuntajeScoreExperian(idExperianCliente);
                ObPuntajeScoreExperian.Add(cadena, puntajeExperian);
                HttpRuntime.Cache.Insert("wsObtenerPuntajeScoreExperianCache", ObPuntajeScoreExperian, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);
                WriteLog(Convert.ToString(puntajeExperian), "wsexperian.experian.ObtenerPuntajeScoreExperian", false);
            }
            return puntajeExperian;
        }
        catch (Exception ex)
        {
            logger.SaveLogAsync(LogHandler.CreateLogErrorAndWarning("Errores", ex));
            throw new Exception("Error en llamada Puntaje Experian", ex);
        }

    }

    public string ObtenerPrecalificacionPowercurve(ws_powercurve.EvaluarPwcPrecalificacionCotizacion cotizacion, int idopcion, ref int idSolPwc, ref string mensaje)
    {

        string lRespuestaPowerCurve = "";
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (ws_powercurve.Service1SoapClient wsPowerCurve = new ws_powercurve.Service1SoapClient())
            {
                lRespuestaPowerCurve = Newtonsoft.Json.JsonConvert.SerializeObject(cotizacion);
                WriteLog(lRespuestaPowerCurve, "wsPowerCurve.EvaluarPwcPrecalificacion-Request" + IdCotizacion, true);
                lRespuestaPowerCurve = wsPowerCurve.EvaluarPwcPrecalificacion(cotizacion, idopcion, ref idSolPwc, ref mensaje);
                WriteLog(lRespuestaPowerCurve, "wsPowerCurve.ObtenerPrecalificacionPowercurve-Response" + IdCotizacion, false);
            }
            return lRespuestaPowerCurve;
        }
        catch (Exception ex)
        {
            logger.SaveLogAsync(LogHandler.CreateLogErrorAndWarning("Errores", ex));
            throw new Exception("Error en llamada Power Curve", ex);
        }

    }

    public static void WriteLog(string strLog, string servicio, Boolean flagInput)
    {

        RequestLog request = new RequestLog(RequestType.Trace, "");

        request.Application = System.Configuration.ConfigurationManager.AppSettings["ApplicationName"];
        request.LocalTime = DateTime.Now;
        request.Type = RequestType.Log;

        if (flagInput)
        {
            request.Message = String.Format("{0} --, servicio: {1}, RequestXML SOAP XmlInput: {2} ", DateTime.Now, servicio, strLog);
        }
        else
        {
            request.Message = String.Format("{0} --, servicio: {1}, Response Rpta: {2} ", DateTime.Now, servicio, strLog);
        }
        LoggerInstance logger = new LoggerInstance();
        logger.SaveLogAsync(request);

    }

    public static void WriteLogBT(string strLog, string servicio, Boolean flagInput)
    {

        RequestLog request = new RequestLog(RequestType.Trace, "");

        request.Application = System.Configuration.ConfigurationManager.AppSettings["ApplicationName"];
        request.LocalTime = DateTime.Now;
        request.Type = RequestType.Log;

        if (flagInput)
        {
            request.Message = String.Format("{0} --, servicio: {1}, Request: {2} ", DateTime.Now, servicio, strLog);
        }
        else
        {
            request.Message = String.Format("{0} --, servicio: {1}, Response: {2} ", DateTime.Now, servicio, strLog);
        }
        LoggerInstance logger = new LoggerInstance();
        logger.SaveLogAsync(request);

    }

}





