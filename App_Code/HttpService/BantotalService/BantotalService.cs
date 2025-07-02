using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Caching;
using infraestructura.servicio;
using Newtonsoft.Json;
using Utils.Bantotal;
using Utils.Bantotal.Request;


/// <summary>
/// Summary description for BantotalService
/// </summary>
public static class BantotalService
{
    private static string UriBantotal = ConfigurationManager.AppSettings["UrlBanTotal"];
    private static string UriToken = ConfigurationManager.AppSettings["ServiceToken"];
    private static string UriRCI = ConfigurationManager.AppSettings["ServiceRci"];
    private static string UriSaldoFinanciero = ConfigurationManager.AppSettings["ServiceSaldoFinanciero"];
    private static string UriClasificacion = ConfigurationManager.AppSettings["ServiceClasificacion"];
    private static string UriEvolucionCH = ConfigurationManager.AppSettings["ServiceEvolucionCH"];


    private static int ObtenerIdentTipoPersonaBT(int identTipoPersonaMaf)
    {
        switch (identTipoPersonaMaf)
        {
            case ConstantesBT.TipoPersona.CodigoMAF.Natural: return ConstantesBT.TipoPersona.CodigoBT.Natural;
            case ConstantesBT.TipoPersona.CodigoMAF.Juridica: return ConstantesBT.TipoPersona.CodigoBT.Juridica;
            default: return 0;
        }
    }
    private static int ObtenerTipoDocumentoBT(int tipoDocumentoMaf)
    {
        switch (tipoDocumentoMaf)
        {
            case ConstantesBT.TipoDocumento.CodigoMAF.DNI: return ConstantesBT.TipoDocumento.CodigoBT.DNI;
            case ConstantesBT.TipoDocumento.CodigoMAF.CE: return ConstantesBT.TipoDocumento.CodigoBT.CE;
            case ConstantesBT.TipoDocumento.CodigoMAF.PAS: return ConstantesBT.TipoDocumento.CodigoBT.PAS;
            case ConstantesBT.TipoDocumento.CodigoMAF.RUC: return ConstantesBT.TipoDocumento.CodigoBT.RUC;
            default: return 0;
        }
    }
    private static int ObtenerIdentMonedaBT(int identMonedaMaf)
    {
        switch (identMonedaMaf)
        {
            case ConstantesBT.Moneda.CodigoMAF.Soles: return ConstantesBT.Moneda.CodigoBT.Soles;
            case ConstantesBT.Moneda.CodigoMAF.Dolares: return ConstantesBT.Moneda.CodigoBT.Dolares;
            default: return 0;
        }
    }
    public static int ObtenerIdentPlanCreditoBT(int planCreditoMaf)
    {
        switch (planCreditoMaf)
        {
            case ConstantesBT.PlanCredito.CodigoMAF.ToyotaLife: return ConstantesBT.PlanCredito.CodigoBT.ToyotaLife;
            case ConstantesBT.PlanCredito.CodigoMAF.Tradicional: return ConstantesBT.PlanCredito.CodigoBT.Tradicional;
            case ConstantesBT.PlanCredito.CodigoMAF.Tradicional_M: return ConstantesBT.PlanCredito.CodigoBT.Tradicional_M;
            case ConstantesBT.PlanCredito.CodigoMAF.Taxis_M: return ConstantesBT.PlanCredito.CodigoBT.Taxis_M;
            case ConstantesBT.PlanCredito.CodigoMAF.Lexus_Life: return ConstantesBT.PlanCredito.CodigoBT.Lexus_Life;
            case ConstantesBT.PlanCredito.CodigoMAF.SemiNuevos: return ConstantesBT.PlanCredito.CodigoBT.SemiNuevos;    //Constantes.PlanCredito.CodigoBT.SemiNuevos
            case ConstantesBT.PlanCredito.CodigoMAF.PlanAgricola: return ConstantesBT.PlanCredito.CodigoBT.PlanAgricola;
            case ConstantesBT.PlanCredito.CodigoMAF.RapiCredit: return ConstantesBT.PlanCredito.CodigoBT.RapiCredit;
            //INI EXP(AHRA) SOLXXXX 20240524 - Pricing
            case ConstantesBT.PlanCredito.CodigoMAF.Plan50_50: return ConstantesBT.PlanCredito.CodigoBT.Plan50_50;
            case ConstantesBT.PlanCredito.CodigoMAF.Grandes_Iniciales: return ConstantesBT.PlanCredito.CodigoBT.Grandes_Iniciales;
            case ConstantesBT.PlanCredito.CodigoMAF.Hino_life_Negocios: return ConstantesBT.PlanCredito.CodigoBT.Hino_life_Negocios;
            //FIN EXP(AHRA) SOLXXXX 20240524 - Pricing


            default: return planCreditoMaf;
        }
    }
    public static SaldoSistemaFinancieroResponseBT obtenerSaldoFinanciero(Cotizacion request, string Token)
    {
        SaldoSistemaFinancieroRequestBT requestSaldoFinanciero = new SaldoSistemaFinancieroRequestBT()
        {

            IdTipoPersona = ObtenerIdentTipoPersonaBT(request.I067TipoPersona),
            IdTipoDocumento = ObtenerTipoDocumentoBT(request.I062TipoDocumento),
            NroDocumentoCliente = request.NumeroDocumento,
            NroUltimosPeriodos = 12
        };
        /*INI - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        IDictionary<string, SaldoSistemaFinancieroResponseBT> ConsultaSF = new Dictionary<string, SaldoSistemaFinancieroResponseBT>();
        var cachevar = HttpRuntime.Cache.Get("ConsultarSaldoSistemaFinancieroBTCache");
        var cadena = requestSaldoFinanciero.IdTipoPersona + "-" + requestSaldoFinanciero.IdTipoDocumento + "-" + requestSaldoFinanciero.NroDocumentoCliente + "-" + requestSaldoFinanciero.NroUltimosPeriodos;
        if (cachevar != null)
        {
            ConsultaSF = (IDictionary<string, SaldoSistemaFinancieroResponseBT>)cachevar;
            var rpta = ConsultaSF.FirstOrDefault(i => i.Key.Equals(cadena));

            if (rpta.Value != null)
                return rpta.Value;
        }
        /*FIN - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */

        requestSaldoFinanciero.BtInreq = new BtInreq()
        {
            Device = ConfigurationManager.AppSettings["DeviceBT"],
            Canal = ConfigurationManager.AppSettings["ChannelBT"],
            Requerimiento = ConfigurationManager.AppSettings["RequirementBT"],
            Usuario = ConfigurationManager.AppSettings["ExternalUserBT"],
            Token = Token
        };

        var uriserviceSaldoFinanciero = new Uri(UriBantotal + UriSaldoFinanciero);
        LoggerBT.LoggerSaveTramas(requestSaldoFinanciero, "obtenerSaldoFinanciero.log", "[Request  serviceBT - SaldoFinanciero =>]", "");
        var responseSaldoFinanciero = HttpService.SendRequestAsync<SaldoSistemaFinancieroResponseBT>(uriserviceSaldoFinanciero, HttpMethod.Post, null, requestSaldoFinanciero).Result;
        LoggerBT.LoggerSaveTramas(responseSaldoFinanciero, "obtenerSaldoFinanciero.log", "[Response  serviceBT - SaldoFinanciero =>]", "");
        /*INI - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        if (responseSaldoFinanciero.CodigoRespuesta == 0)
        {
            ConsultaSF.Add(cadena, responseSaldoFinanciero);
            HttpRuntime.Cache.Insert("ConsultarSaldoSistemaFinancieroBTCache", ConsultaSF, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);
        }
        /*FIN - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */

        return responseSaldoFinanciero;
    }

    public static ClasificacionSBSHistoricaResponseBT obtenerClasificacionSBS(Cotizacion request, string Token)
    {
        ClasificacionSBSHistoricaRequestBT requestSbs = new ClasificacionSBSHistoricaRequestBT()
        {
            IdTipoPersona = ObtenerIdentTipoPersonaBT(request.I067TipoPersona),
            IdTipoDocumento = ObtenerTipoDocumentoBT(request.I062TipoDocumento),
            NroDocumentoCliente = request.NumeroDocumento,
            NroUltimosMeses = 12
        };
        /*INI - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        IDictionary<string, ClasificacionSBSHistoricaResponseBT> ClasificacionSBS = new Dictionary<string, ClasificacionSBSHistoricaResponseBT>();
        var cachevar = HttpRuntime.Cache.Get("ListarClasificacionSBSHistoricaBTCache");
        var cadena = requestSbs.IdTipoDocumento + "-" + requestSbs.IdTipoPersona + "-" + requestSbs.NroDocumentoCliente + "-" + requestSbs.NroUltimosMeses;
        if (cachevar != null)
        {
            ClasificacionSBS = (IDictionary<string, ClasificacionSBSHistoricaResponseBT>)cachevar;
            var rpta = ClasificacionSBS.FirstOrDefault(i => i.Key == cadena);
            if (rpta.Value != null)
                return rpta.Value;
        }
        /*FIN - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */

        requestSbs.BtInreq = new BtInreq()
        {
            Device = ConfigurationManager.AppSettings["DeviceBT"],
            Canal = ConfigurationManager.AppSettings["ChannelBT"],
            Requerimiento = ConfigurationManager.AppSettings["RequirementBT"],
            Usuario = ConfigurationManager.AppSettings["ExternalUserBT"],
            Token = Token
        };

        var uriserviceSbs = new Uri(UriBantotal + UriClasificacion);
        LoggerBT.LoggerSaveTramas(requestSbs, "obtenerClasificacionSBS.log", "[Request  serviceBT - ClasificacionSBS =>]", "");
        var responseSbs = HttpService.SendRequestAsync<ClasificacionSBSHistoricaResponseBT>(uriserviceSbs, HttpMethod.Post, null, requestSbs).Result;
        LoggerBT.LoggerSaveTramas(responseSbs, "obtenerClasificacionSBS.log", "[Response  serviceBT - ClasificacionSBS =>]", "");
        /*INI - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        if (responseSbs.CodigoRespuesta == 0)
        {
            ClasificacionSBS.Add(cadena, responseSbs);
            HttpRuntime.Cache.Insert("ListarClasificacionSBSHistoricaBTCache", ClasificacionSBS, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);
        }
        /*FIN - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        return responseSbs;
    }

    public static RatioCuotaIngresoResponseBT obtenerCalculoRCI(Cotizacion request, string Token)
    {
        RatioCuotaIngresoRequestBT requestRCI = new RatioCuotaIngresoRequestBT()
        {
            PepaisTit =604,
            PetdocTit = ObtenerTipoDocumentoBT(request.I062TipoDocumento),
            NroDocumentoTitular = request.NumeroDocumento,
            PepaisCon =604,
            TipoCambio = request.TipoCambioCalculo,
            PlanCredito = ""+ObtenerIdentPlanCreditoBT(request.PlanCredito),
            MonedaFinanciamiento = ObtenerIdentMonedaBT(request.MonedaCredito),
            MontoIngresoTitularSoles =request.TotalIngresoMensualSoles,
            MontoCuotaMafSoles =request.MontoCuotaMoneda,
            IndTaxista = 0,
            CuotaReprogramadaSoles =0,
            GastosOperativosMoneda = ObtenerIdentMonedaBT(request.MonedaCredito),
            Plazo = Convert.ToInt32(request.Plazo)
        };
        /*INI - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        //IDictionary<string, RatioCuotaIngresoResponseBT> RCIBT = new Dictionary<string, RatioCuotaIngresoResponseBT>();
        //var cachevar = HttpRuntime.Cache.Get("CalcularRCIBTCache");
        //var cadena = requestRCI.PaisTitular + "-" + requestRCI.TipoDocumentoTitular + "-" + requestRCI.NroDocumentoTitular + "-" + requestRCI.PaisConyuge
        //        + "-" + requestRCI.TipoDocumentoConyuge + "-" + requestRCI.NroDocumentoConyuge + "-" + requestRCI.TipoCambio
        //        + "-" + requestRCI.PlanCredito + "-" + requestRCI.MonedaFinanciamiento + "-" + requestRCI.MontoIngresoConyugeSoles + "-" + requestRCI.MontoIngresoTitularSoles
        //        + "-" + requestRCI.MontoCuotaMafSoles + "-" + requestRCI.IndTaxista + "-" + requestRCI.CuotaReprogramadaSoles + "-" + requestRCI.GastosOperativosMoneda + "-" + requestRCI.Plazo;
        //if (cachevar != null)
        //{
        //    RCIBT = (IDictionary<string, RatioCuotaIngresoResponseBT>)cachevar;
        //    var rpta = RCIBT.FirstOrDefault(i => i.Key == cadena);
        //    if (rpta.Value != null)
        //        return rpta.Value;
        //}
        /*FIN - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */

        requestRCI.BtInreq = new BtInreq()
        {
            Device = ConfigurationManager.AppSettings["DeviceBT"],
            Canal = ConfigurationManager.AppSettings["ChannelBT"],
            Requerimiento = ConfigurationManager.AppSettings["RequirementBT"],
            Usuario = ConfigurationManager.AppSettings["ExternalUserBT"],
            Token = Token
        };

        var uriserviceRCI = new Uri(UriBantotal + UriRCI);
        LoggerBT.LoggerSaveTramas(requestRCI, "obtenerCalculoRCI.log", "[Request  serviceBT - CalculoRCI =>]", "");
        var responseRci = HttpService.SendRequestAsync<RatioCuotaIngresoResponseBT>(uriserviceRCI, HttpMethod.Post, null, requestRCI).Result;
        LoggerBT.LoggerSaveTramas(responseRci, "obtenerCalculoRCI.log", "[Response  serviceBT - CalculoRCI =>]", "");
        /*INI - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        //if (responseRci.CodigoRespuesta == 0)
        //{
        //    RCIBT.Add(cadena, responseRci);
        //    HttpRuntime.Cache.Insert("CalcularRCIBTCache", RCIBT, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);
        //}
        /*FIN - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        return responseRci;
    }

    public static string ObtenerTokenBT()
    {
        var cachevar = HttpRuntime.Cache.Get("TokenCache");
        if (cachevar != null)
            return (string)cachevar;
        var requestToken = new AutenticacionRequestBT()
        {
            BtInreq = new BtInreq()
            {
                Device = ConfigurationManager.AppSettings["DeviceBT"],
                Canal = ConfigurationManager.AppSettings["ChannelBT"],
                Requerimiento = ConfigurationManager.AppSettings["RequirementBT"],
                Usuario = ConfigurationManager.AppSettings["ExternalUserBT"],
                Token = ""
            },
            UserId = ConfigurationManager.AppSettings["UserId"],
            UserPassword = ConfigurationManager.AppSettings["UserPassword"]
        };
        var uriserviceToken = new Uri(UriBantotal + UriToken);
        LoggerBT.LoggerSaveTramas(requestToken, "ObtenerTokenBT.log", "[Request  serviceBT - ObtenerSessionTokenBanTotal =>]","");
        var responseToken = HttpService.SendRequestAsync<AutenticacionResponseBT>(uriserviceToken, HttpMethod.Post, null, requestToken).Result;
        LoggerBT.LoggerSaveTramas(responseToken, "ObtenerTokenBT.log", "[Response  serviceBT - ObtenerSessionTokenBanTotal =>]", "");
        if (!string.IsNullOrEmpty(responseToken.SessionToken))
        {
            HttpRuntime.Cache.Insert("TokenCache", responseToken.SessionToken, null, DateTime.Now.AddHours(Convert.ToDouble(0.5)), Cache.NoSlidingExpiration);
        }

        return responseToken.SessionToken;
    }
    public static EvolucionClasificacionHistoricaResponseBT obtenerEvolucionClasificacionHistorica(Cotizacion request, string Token)
    {
        EvolucionClasificacionHistoricaRequestBT requestSbs = new EvolucionClasificacionHistoricaRequestBT()
        {
            IdTipoPersona = ObtenerIdentTipoPersonaBT(request.I067TipoPersona),
            IdTipoDocumento = ObtenerTipoDocumentoBT(request.I062TipoDocumento),
            NroDocumentoCliente = request.NumeroDocumento,
            NroUltimosMeses = 12
        };
        /*INI - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        IDictionary<string, EvolucionClasificacionHistoricaResponseBT> ClasificacionSBS = new Dictionary<string, EvolucionClasificacionHistoricaResponseBT>();
        var cachevar = HttpRuntime.Cache.Get("EvoluacionClasificacionHistoricaBTCache");
        var cadena = requestSbs.IdTipoDocumento + "-" + requestSbs.IdTipoPersona + "-" + requestSbs.NroDocumentoCliente + "-" + requestSbs.NroUltimosMeses;
        if (cachevar != null)
        {
            ClasificacionSBS = (IDictionary<string, EvolucionClasificacionHistoricaResponseBT>)cachevar;
            var rpta = ClasificacionSBS.FirstOrDefault(i => i.Key == cadena);
            if (rpta.Value != null)
                return rpta.Value;
        }
        /*FIN - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */

        requestSbs.BtInreq = new BtInreq()
        {
            Device = ConfigurationManager.AppSettings["DeviceBT"],
            Canal = ConfigurationManager.AppSettings["ChannelBT"],
            Requerimiento = ConfigurationManager.AppSettings["RequirementBT"],
            Usuario = ConfigurationManager.AppSettings["ExternalUserBT"],
            Token = Token
        };

        var uriserviceSbs = new Uri(UriBantotal + UriEvolucionCH);
        LoggerBT.LoggerSaveTramas(requestSbs, "EvoluacionClasificacionHistorica.log", "[Request  serviceBT - EvoluacionClasificacionHistorica =>]", "");
        var responseSbs = HttpService.SendRequestAsync<EvolucionClasificacionHistoricaResponseBT>(uriserviceSbs, HttpMethod.Post, null, requestSbs).Result;
        LoggerBT.LoggerSaveTramas(responseSbs.CalificacionHistorica, "EvoluacionClasificacionHistorica.log", "[Response  serviceBT - EvoluacionClasificacionHistorica =>]", "");
        /*INI - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        if (responseSbs.CodigoRespuesta == 0)
        {
            ClasificacionSBS.Add(cadena, responseSbs);
            HttpRuntime.Cache.Insert("EvoluacionClasificacionHistoricaBTCache", ClasificacionSBS, null, DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoCache"].ToString())), Cache.NoSlidingExpiration);
        }
        /*FIN - ADECUACION POR PROBLEMAS DE INGRESO AMICAR */
        return responseSbs;
    }


}