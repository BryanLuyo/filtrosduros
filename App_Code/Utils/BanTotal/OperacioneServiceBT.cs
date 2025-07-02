using MAF.BanTotal.NetFramework.Common.Integrations.Contracts;
using MAF.BanTotal.NetFramework.Common.Integrations.Repositories;
using MAF.BanTotal.NetFramework.Common.Services.Contracts;
using MAF.BanTotal.NetFramework.Common.Services.Repositories;
using MAF.BanTotal.NetFramework.Common.Transports.Integrations;
using ServiceRequest = MAF.BanTotal.NetFramework.Common.Transports.Services.Requests;
using System;
using System.Configuration;

using System.Collections.Generic;

using System.Web;
using System.Web.Caching;
using System.Linq;
using Newtonsoft.Json;

//INI HDR(RMC) 20220323 - REQ22205
public class OperacionesServiceBT
{
    private BtInReq ObtenerAutenticacion(IBasicService basicservice)
    {
        try
        {
            IAutenticacionIntegration autenticacionIntegracion = new AutenticacionIntegration();
            IAutenticacionService autenticacionService = new AutenticacionService(autenticacionIntegracion, basicservice);

            string device = ConfigurationManager.AppSettings["DeviceBT"].ToString();
            var btInReq = basicservice.ObtenerBtInReq(device);
            string userId = ConfigurationManager.AppSettings["UserId"].ToString();
            string userPassword = ConfigurationManager.AppSettings["UserPassword"].ToString();

            var autenticacionRequest = new ServiceRequest.Authentication.AutenticacionRequest(btInReq, userId, userPassword);
            var cachevar = HttpRuntime.Cache.Get("TokenCache");
            if (cachevar != null)
                return (BtInReq)cachevar;
            var autenticacionResponse = autenticacionService.ObtenerSessionTokenBanTotal(autenticacionRequest);
            if (autenticacionResponse.CodigoRespuesta != 0)
                throw new Exception(autenticacionResponse.DescripcionRespuesta);
            btInReq.Token = autenticacionResponse.SessionToken;
            HttpRuntime.Cache.Insert("TokenCache", btInReq, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);
            return btInReq;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public SaldoSistemaFinancieroResponseBT ConsultarSaldoSistemaFinancieroDetalleBT(int idTipoPersona, int idTipoDocumento, string nroDocumentoCliente, int meses)
    {
        try
        {
            //SaldoSistemaFinancieroResponseBT response = new SaldoSistemaFinancieroResponseBT()
            //{
            //    SaldoSistemaFinancieroBT = new SaldoSistemaFinancieroBT(){
            //        ListaSaldoFinancieroBT = new List<SaldoFinancieroBT>()
            //    }
            //}; //MOD CSTI(JF) REQ22205 09112022

            //string baseAddress = ConfigurationManager.AppSettings["UrlBanTotal"];
            //var basicService = new BasicService(baseAddress);//MOD CSTI(JF) REQ22205 09112022
            //var buroIntegration = new BuroIntegration(); //ADD CSTI(JF) REQ22205 09112022
            //var autenticacionResult = ObtenerAutenticacion(basicService); //ADD CSTI(JF) REQ22205 09112022

            ////COMENTADO CSTI(JF) REQ22205 09112022
            ////var autenticacionResult = basicService.ObtenerBtInReq(ConfigurationManager.AppSettings["DeviceBT"], ConfigurationManager.AppSettings["SessionToken"]);

            //IBuroService buroService = new BuroService(buroIntegration, basicService); //MOD CSTI(JF) REQ22205 09112022

            //SaldoSistemaFinancieroRequestBT request = new SaldoSistemaFinancieroRequestBT()
            //{
            //    //BtInReq = autenticacionResult,
            //    //IdTipoDocumento = idTipoDocumento,
            //    //IdTipoPersona = idTipoPersona,
            //    //NroDocumentoCliente = Convert.ToInt32(nroDocumentoCliente),
            //    //NroUltimosPeriodos = meses
            //};

            //IDictionary<string, SaldoSistemaFinancieroResponseBT> ConsultaSF = new Dictionary<string, SaldoSistemaFinancieroResponseBT>();
            ////IDictionary<string, string> ConsultaSF = new Dictionary<string, string>();
            //var cachevar = HttpRuntime.Cache.Get("ConsultarSaldoSistemaFinancieroBTCache");
            //var cadena = request.IdTipoPersona + "-" + request.IdTipoDocumento + "-" + request.NroDocumentoCliente + "-" + request.NroUltimosPeriodos;
            //if (cachevar != null)
            //{
            //    ConsultaSF = (IDictionary<string, SaldoSistemaFinancieroResponseBT>)cachevar;
            //    var rpta = ConsultaSF.FirstOrDefault(i => i.Key.Equals(cadena));

            //    if (rpta.Value != null)
            //        return rpta.Value;
            //}

            ////INI MOD CSTI(JF) REQ22205 09112022          
            //var responseBT = buroService.ConsultarSaldoSistemaFinancieroBT(request);

            //var responseListBT = responseBT.SaldoSistemaFinancieroBT.ListaSaldoFinancieroBT;

            //if (responseListBT != null && responseListBT.Count > 0)
            //{               
            //    foreach (var item in responseListBT)
            //    {
            //        SaldoFinancieroBT saldoSistemaFinanciero = new SaldoFinancieroBT()
            //        {
            //            NroSaldo = item.NroSaldo,
            //            CantidadCuentas = item.CantidadCuentas,
            //            SaldoRefinanciado = item.SaldoRefinanciado,
            //            SaldoJudicial = item.SaldoJudicial,
            //            SaldoVencido = item.SaldoVencido,
            //            SaldoCastigo = item.SaldoCastigo,
            //            IndCreditoVehicular = item.IndCreditoVehicular,
            //            MaximaClasificacion = item.MaximaClasificacion,
            //            Periodo = item.Periodo
            //        };
            //        response.SaldoSistemaFinancieroBT.ListaSaldoFinancieroBT.Add(saldoSistemaFinanciero);
            //    }              
            //}
            //response.CodigoRespuesta = responseBT.CodigoRespuesta;
            //response.DescripcionRespuesta = responseBT.DescripcionRespuesta;
            ////FIN MOD CSTI(JF) REQ22205 09112022
            //if (responseBT.CodigoRespuesta == 0)
            //{
            //    ConsultaSF.Add(cadena, response);
            //    HttpRuntime.Cache.Insert("ConsultarSaldoSistemaFinancieroBTCache", ConsultaSF, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);
            //}
            //return response;
            return new SaldoSistemaFinancieroResponseBT();
        }
        catch (Exception ex) //MOD CSTI(JF) REQ22205 09112022 
        {
            throw ex;
        }
    }

    //INI HDR(RMC) 20220329 - REQ22205
    public ClasificacionSBSHistoricaResponseBT ListarClasificacionSBSHistoricaBT(int idTipoPersona, int idTipoDocumento,
        string nroDocumentoCliente, int meses) //MOD CSTI(JF) REQ22205 09112022 
    {
        try
        {
            //ClasificacionSBSHistoricaResponseBT response = new ClasificacionSBSHistoricaResponseBT()
            //{
            //    ClasificacionSBSHistoricaBT = new ClasificacionSBSHistoricaBT()
            //    {
            //        ListaClasificacionSbsBT = new List<ClasificacionSbsBT>()
            //    }
            //};  //MOD CSTI(JF) REQ22205 09112022

            //string baseAddress = ConfigurationManager.AppSettings["UrlBanTotal"];
            //var basicService = new BasicService(baseAddress);//MOD CSTI(JF) REQ22205 09112022
            //var buroIntegration = new BuroIntegration(); //ADD CSTI(JF) REQ22205 09112022

            //var autenticacionResult = ObtenerAutenticacion(basicService); //ADD CSTI(JF) REQ22205 09112022

            ////COMENTADO CSTI(JF) REQ22205 09112022
            ////var autenticacionResult = basicService.ObtenerBtInReq(ConfigurationManager.AppSettings["DeviceBT"], ConfigurationManager.AppSettings["SessionToken"]);

            //IBuroService buroService = new BuroService(buroIntegration, basicService); //MOD CSTI(JF) REQ22205 09112022

            //ClasificacionSBSHistoricaRequestBT request = new ClasificacionSBSHistoricaRequestBT()
            //{
            //    BtInReq = autenticacionResult,
            //    IdTipoDocumento = idTipoDocumento,
            //    IdTipoPersona = idTipoPersona,
            //    NroDocumentoCliente = Convert.ToInt32(nroDocumentoCliente),
            //    NroUltimosMeses = meses
            //};

            //IDictionary<string, ClasificacionSBSHistoricaResponseBT> ClasificacionSBS = new Dictionary<string, ClasificacionSBSHistoricaResponseBT>();
            //var cachevar = HttpRuntime.Cache.Get("ListarClasificacionSBSHistoricaBTCache");
            //var cadena = request.IdTipoDocumento + "-" + request.IdTipoPersona + "-" + request.NroDocumentoCliente + "-" + request.NroUltimosMeses;
            //if (cachevar != null)
            //{
            //    ClasificacionSBS = (IDictionary<string, ClasificacionSBSHistoricaResponseBT>)cachevar;
            //    var rpta = ClasificacionSBS.FirstOrDefault(i => i.Key == cadena);
            //    if (rpta.Value != null)
            //        return rpta.Value;
            //}

            ////INI MOD CSTI(JF) REQ22205 09112022          
            //var responseBT = buroService.ListarClasificacionSBSHistoricaBT(request);

            //var responseListBT = responseBT.ClasificacionSBSHistoricaBT.ListaClasificacionSbsBT;
            //if (responseListBT != null && responseListBT.Count > 0)
            //{
            //    foreach (var item in responseListBT)
            //    {
            //        ClasificacionSbsBT clasificacionSBSHistorica = new ClasificacionSbsBT()
            //        {
            //            Clasificacion = item.Clasificacion,
            //            NroItem = item.NroItem,
            //            Periodo = item.Periodo                        
            //        };
            //        response.ClasificacionSBSHistoricaBT.ListaClasificacionSbsBT.Add(clasificacionSBSHistorica);
            //    }
            //}
            //response.CodigoRespuesta = responseBT.CodigoRespuesta;
            //response.DescripcionRespuesta = responseBT.DescripcionRespuesta;
            //if (responseBT.CodigoRespuesta == 0)
            //{
            //    ClasificacionSBS.Add(cadena, response);
            //    HttpRuntime.Cache.Insert("ListarClasificacionSBSHistoricaBTCache", ClasificacionSBS, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);
            //}
            ////FIN MOD CSTI(JF) REQ22205 09112022
            //return response;
            return new ClasificacionSBSHistoricaResponseBT();
        }
        catch (Exception ex)  //MOD CSTI(JF) REQ22205 09112022   
        {
            throw ex; //MOD CSTI(JF) REQ22205 09112022   
        }
    }
    //FIN HDR(RMC) 20220329 - REQ22205

    //INI HDR(RMC) 20220330 - REQ22205
    public RatioCuotaIngresoResponseBT CalcularRCIBT(CalcularRatioCuotaIngresoRequestBT request)//MOD CSTI(JF) REQ22205 09112022
    {
        try
        {
            //RatioCuotaIngresoResponseBT response = new RatioCuotaIngresoResponseBT();

            //string baseAddress = ConfigurationManager.AppSettings["UrlBanTotal"];
            //var basicService = new BasicService(baseAddress);//MOD CSTI(JF) REQ22205 09112022
            //var buroIntegration = new BuroIntegration(); //ADD CSTI(JF) REQ22205 09112022
            //var autenticacionResult = ObtenerAutenticacion(basicService); //ADD CSTI(JF) REQ22205 09112022

            ////COMENTADO CSTI(JF) REQ22205 09112022
            ////var autenticacionResult = basicService.ObtenerBtInReq(ConfigurationManager.AppSettings["DeviceBT"], ConfigurationManager.AppSettings["SessionToken"]);

            //IBuroService buroService = new  BuroService(buroIntegration, basicService); //MOD CSTI(JF) REQ22205 09112022
            ////INI MOD CSTI(JF) REQ22205 10112022    
            //RatioCuotaIngresoRequestBT ratioRequest = new RatioCuotaIngresoRequestBT()
            //{
            //    BtInReq = autenticacionResult,
            //    PepaisTit = request.PaisTitular,
            //    PetdocTit = request.TipoDocumentoTitular,
            //    NroDocumentoTitular = request.NroDocumentoTitular,
            //    PepaisCon = request.PaisConyuge,
            //    PetdocCon = request.TipoDocumentoConyuge,
            //    NroDocumentoConyuge = request.NroDocumentoConyuge,
            //    TipoCambio = request.TipoCambio,
            //    PlanCredito = request.PlanCredito,
            //    MonedaFinanciamiento = request.MonedaFinanciamiento,
            //    MontoIngresoConyugeSoles = request.MontoIngresoConyugeSoles,
            //    MontoIngresoTitularSoles = request.MontoIngresoTitularSoles,
            //    MontoCuotaMafSoles = request.MontoCuotaMafSoles,
            //    IndTaxista = request.IndTaxista,
            //    CuotaReprogramadaSoles = request.CuotaReprogramadaSoles,
            //    GastosOperativosMoneda = request.GastosOperativosMoneda,
            //    Plazo = request.Plazo
            //};

            //IDictionary<string, RatioCuotaIngresoResponseBT> RCIBT = new Dictionary<string, RatioCuotaIngresoResponseBT>();
            //var cachevar = HttpRuntime.Cache.Get("CalcularRCIBTCache");
            //var cadena = request.PaisTitular + "-" + request.TipoDocumentoTitular + "-" + request.NroDocumentoTitular + "-" + request.PaisConyuge
            //        + "-" + request.TipoDocumentoConyuge + "-" + request.NroDocumentoConyuge + "-" + request.TipoCambio
            //        + "-" + request.PlanCredito + "-" + request.MonedaFinanciamiento + "-" + request.MontoIngresoConyugeSoles + "-" + request.MontoIngresoTitularSoles
            //        + "-" + request.MontoCuotaMafSoles + "-" + request.IndTaxista + "-" + request.CuotaReprogramadaSoles + "-" + request.GastosOperativosMoneda + "-" + request.Plazo;
            //if (cachevar != null)
            //{
            //    RCIBT = (IDictionary<string, RatioCuotaIngresoResponseBT>)cachevar;
            //    var rpta = RCIBT.FirstOrDefault(i => i.Key == cadena);
            //    if (rpta.Value != null)
            //        return rpta.Value;
            //}

            //var responseBT = buroService.CalcularRatioCuotaIngresoBT(ratioRequest);           
            //response.CodigoRespuesta = responseBT.CodigoRespuesta;
            //response.DescripcionRespuesta = responseBT.DescripcionRespuesta;
            //response.RCI = responseBT.RCI;
            ////FIN MOD CSTI(JF) REQ22205 10112022 
            //if (responseBT.CodigoRespuesta == 0)
            //{
            //    RCIBT.Add(cadena, response);
            //    HttpRuntime.Cache.Insert("CalcularRCIBTCache", RCIBT, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);
            //}
            //return response;
            return new RatioCuotaIngresoResponseBT();
        }
        catch (Exception ex)  //MOD CSTI(JF) REQ22205 09112022    
        {
            throw ex; //MOD CSTI(JF) REQ22205 09112022   
        }
    }
    //FIN HDR(RMC) 20220330 - REQ22205
}
//FIN HDR(RMC) 20220323 - REQ22205







