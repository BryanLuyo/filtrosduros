
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

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.Scrip    tService]

public class Service : System.Web.Services.WebService
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

        loggerService.LoggerSaveTramas(toDatosPrecalificador, "[INI request  service EvaluarPwcPrecalificacion =>]", "CanalPreevaluacionPC");
        ServiciosExternos.IdCotizacion = toDatosPrecalificador.NumeroCotizacion;
        ServiciosExternos.LogRequest(toDatosPrecalificador, idOpcion);
        oDatoPrecalificadorpwc.fechafinlabores = toDatosPrecalificador.FechaFinLabores;
        oDatoPrecalificadorpwc.fechainiciolabores = toDatosPrecalificador.FechaInicioLabores;
        oDatoPrecalificadorpwc.fechanacimiento = toDatosPrecalificador.FechaNacimiento;
        oDatoPrecalificadorpwc.i062tipodocumento = toDatosPrecalificador.I062TipoDocumento;
        oDatoPrecalificadorpwc.i067tipopersona = toDatosPrecalificador.I067TipoPersona;
        oDatoPrecalificadorpwc.i309estadocivil = toDatosPrecalificador.I309EstadoCivil;
        oDatoPrecalificadorpwc.i815categorialaboral = toDatosPrecalificador.I815CategoriaLaboral;
        oDatoPrecalificadorpwc.identificador = toDatosPrecalificador.NumeroDocumento;
        oDatoPrecalificadorpwc.montocuota = toDatosPrecalificador.MontoCuotaMoneda;
        oDatoPrecalificadorpwc.montcuotainicial = toDatosPrecalificador.MontoCuotaInicialMoneda;
        oDatoPrecalificadorpwc.nacionalidad = toDatosPrecalificador.Nacionalidad;
        oDatoPrecalificadorpwc.plazo = toDatosPrecalificador.Plazo;
        oDatoPrecalificadorpwc.totalingresomensualconyugalsoles = toDatosPrecalificador.TotalIngresoMensualConyugalSoles;
        oDatoPrecalificadorpwc.totalingresomensualsoles = toDatosPrecalificador.TotalIngresoMensualSoles;
        oDatoPrecalificadorpwc.Porccuotainicial = toDatosPrecalificador.PorcentajeCuotaInicial;
        oDatoPrecalificadorpwc.scoreexperian = toDatosPrecalificador.PuntajeScore;      //ADD EXP(AHRA) REQ25868 20240522 - Pricing

        RespuestaEvaluacion respuesta = new RespuestaEvaluacion();
        AsignacionCamposCalculadosoDefault();

        //INI HDR(EHC) 20220330 - REQ22205 Paralelo
        //ParallelOptions parallelOptions = new ParallelOptions
        //{
        //    MaxDegreeOfParallelism = 2
        //};
        //Parallel.Invoke(
        //        parallelOptions,
        //        () => AsignarSaldos(respuesta),//WI66
        //        () => AsignarExperian(toDatosPrecalificador, respuesta),
        //        () => AsignarRCI(toDatosPrecalificador, respuesta),//WI66
        //        () => AsignarClasificacion(respuesta)//WI66
        //    );
        var token = BantotalService.ObtenerTokenBT();
        AsignarSaldos(toDatosPrecalificador, respuesta,token);//WI66
        AsignarExperian(toDatosPrecalificador, respuesta);
        AsignarRCI(toDatosPrecalificador, respuesta, token);//WI66
        AsignarClasificacion(toDatosPrecalificador,respuesta, token);//WI66

        //FIN HDR(EHC) 20220330 - REQ22205 Se agrego seccion de codigo
        respuesta.RespuestaPowerCurve = ServiciosExternos.ObtenerPrecalificacionPowercurve(oDatoPrecalificadorpwc, idOpcion, ref idSolPwc, ref StrMensaje);
        respuesta.MensajeRespuestaPowerCurve = StrMensaje;
        loggerService.LoggerSaveTramas(respuesta, "[FIN response  service EvaluarPwcPrecalificacion =>]", "CanalPreevaluacionPC");
        return respuesta;
    }

    [WebMethod]
    public string PingService(string nombre)
    {
        return nombre + " The ping to services is success";
    }
    #endregion

    private void AsignacionCamposCalculadosoDefault()
    {

        //Campos calculados o por default
        //Asignartipodocumento
        if (oDatoPrecalificadorpwc.i062tipodocumento == Convert.ToDecimal(Enumerados.TipoDocumentoIdentificacion.DNI))
        {
            oDatoPrecalificadorpwc.i062tipodocumentodesc = Enumerados.TipoDocumentoIdentificacion.DNI.ToString();
        }
        else if (oDatoPrecalificadorpwc.i062tipodocumento == Convert.ToDecimal(Enumerados.TipoDocumentoIdentificacion.CarnetIdentidad))
        {
            oDatoPrecalificadorpwc.i062tipodocumentodesc = Enumerados.TipoDocumentoIdentificacion.CarnetIdentidad.ToString();
        }
        else if (oDatoPrecalificadorpwc.i062tipodocumento == Convert.ToDecimal(Enumerados.TipoDocumentoIdentificacion.CarnetExtranjeria))
        {
            oDatoPrecalificadorpwc.i062tipodocumentodesc = Enumerados.TipoDocumentoIdentificacion.CarnetExtranjeria.ToString();
        }
        else if (oDatoPrecalificadorpwc.i062tipodocumento == Convert.ToDecimal(Enumerados.TipoDocumentoIdentificacion.Pasaporte))
        {
            oDatoPrecalificadorpwc.i062tipodocumentodesc = Enumerados.TipoDocumentoIdentificacion.Pasaporte.ToString();
        }
        else if (oDatoPrecalificadorpwc.i062tipodocumento == Convert.ToDecimal(Enumerados.TipoDocumentoIdentificacion.RUC))
        {
            oDatoPrecalificadorpwc.i062tipodocumentodesc = Enumerados.TipoDocumentoIdentificacion.RUC.ToString();
        }
        else if (oDatoPrecalificadorpwc.i062tipodocumento == Convert.ToDecimal(Enumerados.TipoDocumentoIdentificacion.SinDocumento))
        {
            oDatoPrecalificadorpwc.i062tipodocumentodesc = Enumerados.TipoDocumentoIdentificacion.SinDocumento.ToString();
        }
        else if (oDatoPrecalificadorpwc.i062tipodocumento == Convert.ToDecimal(Enumerados.TipoDocumentoIdentificacion.CarnedelasFFAA))
        {
            oDatoPrecalificadorpwc.i062tipodocumentodesc = Enumerados.TipoDocumentoIdentificacion.CarnedelasFFAA.ToString();
        }
        else if (oDatoPrecalificadorpwc.i062tipodocumento == Convert.ToDecimal(Enumerados.TipoDocumentoIdentificacion.CarnedelasFFPP))
        {
            oDatoPrecalificadorpwc.i062tipodocumentodesc = Enumerados.TipoDocumentoIdentificacion.CarnedelasFFPP.ToString();
        }
        // Asignar tipopersona
        if (oDatoPrecalificadorpwc.i067tipopersona == Convert.ToDecimal(Enumerados.TipoPersona.Natural))
        {
            oDatoPrecalificadorpwc.i067tipopersonadesc = Enumerados.TipoPersona.Natural.ToString();
        }
        else if (oDatoPrecalificadorpwc.i067tipopersona == Convert.ToDecimal(Enumerados.TipoPersona.Jurídica))
        {
            oDatoPrecalificadorpwc.i067tipopersonadesc = Enumerados.TipoPersona.Jurídica.ToString();
        }

        // Asignar Estadocivil
        if (oDatoPrecalificadorpwc.i309estadocivil == Convert.ToDecimal(Enumerados.EstadoCivil.Soltero))
        {
            oDatoPrecalificadorpwc.i309estadocivildesc = Enumerados.EstadoCivil.Soltero.ToString();
        }
        else if (oDatoPrecalificadorpwc.i309estadocivil == Convert.ToDecimal(Enumerados.EstadoCivil.Casado))
        {
            oDatoPrecalificadorpwc.i309estadocivildesc = Enumerados.EstadoCivil.Casado.ToString();
        }
        else if (oDatoPrecalificadorpwc.i309estadocivil == Convert.ToDecimal(Enumerados.EstadoCivil.Conviviente))
        {
            oDatoPrecalificadorpwc.i309estadocivildesc = Enumerados.EstadoCivil.Conviviente.ToString();
        }
        else if (oDatoPrecalificadorpwc.i309estadocivil == Convert.ToDecimal(Enumerados.EstadoCivil.Divorciado))
        {
            oDatoPrecalificadorpwc.i309estadocivildesc = Enumerados.EstadoCivil.Divorciado.ToString();
        }
        else if (oDatoPrecalificadorpwc.i309estadocivil == Convert.ToDecimal(Enumerados.EstadoCivil.Viudo))
        {
            oDatoPrecalificadorpwc.i309estadocivildesc = Enumerados.EstadoCivil.Viudo.ToString();
        }

        // Asignar Categoria
        if (oDatoPrecalificadorpwc.i815categorialaboral == Convert.ToDecimal(Enumerados.CategoriaLaboral.PrimeraCategoria))
        {
            oDatoPrecalificadorpwc.i815categorialaboraldesc = Enumerados.CategoriaLaboral.PrimeraCategoria.ToString();
        }
        else if (oDatoPrecalificadorpwc.i815categorialaboral == Convert.ToDecimal(Enumerados.CategoriaLaboral.TerceraCategoria))
        {
            oDatoPrecalificadorpwc.i815categorialaboraldesc = Enumerados.CategoriaLaboral.TerceraCategoria.ToString();
        }
        else if (oDatoPrecalificadorpwc.i815categorialaboral == Convert.ToDecimal(Enumerados.CategoriaLaboral.CuartaCategoria))
        {
            oDatoPrecalificadorpwc.i815categorialaboraldesc = Enumerados.CategoriaLaboral.CuartaCategoria.ToString();
        }
        else if (oDatoPrecalificadorpwc.i815categorialaboral == Convert.ToDecimal(Enumerados.CategoriaLaboral.QuintaCategoria))
        {
            oDatoPrecalificadorpwc.i815categorialaboraldesc = Enumerados.CategoriaLaboral.QuintaCategoria.ToString();
        }


        oDatoPrecalificadorpwc.indclientepep = "NO PEP";
        oDatoPrecalificadorpwc.indexcepcion = new string[] { "NO" };
        oDatoPrecalificadorpwc.requieregrupo = "NO";


    }
    private void AsignarSaldos(Cotizacion toDatosPrecalificador,RespuestaEvaluacion respuesta,string token)
    {
        decimal sumaSaldoCastigado = 0;
        decimal sumaSaldoRefinanciado = 0;
        decimal sumaSaldoVencidoJudicial = 0;
		decimal sumaSaldoVencido = 0; /*ADD ITM(MJTS) 100122 REQ21317*/
        //dsSaldoFinDet = ServiciosExternos.ObtenerSaldosistemaSaldos(Convert.ToInt32(oDatoPrecalificadorpwc.i067tipopersona), Convert.ToInt32(oDatoPrecalificadorpwc.i062tipodocumento), oDatoPrecalificadorpwc.identificador, 12);
        loggerService.LoggerSaveTramas(respuesta, "[INI request AsignarSaldos =>]", "CanalPreevaluacionPC");
        //INI EXP(AHRA) 20230809 - ADECUACION
        var listaSaldos = BantotalService.obtenerSaldoFinanciero(toDatosPrecalificador, token);
        //var listaSaldos = ServiciosExternos.ObtenerSaldosistemaSaldos(Convert.ToInt32(oDatoPrecalificadorpwc.i067tipopersona), Convert.ToInt32(oDatoPrecalificadorpwc.i062tipodocumento), oDatoPrecalificadorpwc.identificador, 12); //ADD HDR(RMC) 20220329 - REQ22205 Se agrego linea de codigo
        //FIN EXP(AHRA) 20230809 - ADECUACION

        oDatoPrecalificadorpwc.saldocastigado = new decimal[12];
        oDatoPrecalificadorpwc.saldorefinanciado = new decimal[12];
        oDatoPrecalificadorpwc.saldovencidojudicial = new decimal[12];
        oDatoPrecalificadorpwc.saldovencido = new decimal[12];/*ADD ITM(MJTS) 100122 REQ21317*/

        //if (dsSaldoFinDet.Tables[0].Rows.Count >= 1)
        //{
        //    for (int i = 0; i <= dsSaldoFinDet.Tables[0].Rows.Count - 1; i++)
        //    {
        //        oDatoPrecalificadorpwc.saldocastigado[i] = dsSaldoFinDet.Tables[0].Rows[i]["saldo_castigado"].ToString() == null ? 0 : Convert.ToDecimal(dsSaldoFinDet.Tables[0].Rows[i]["saldo_castigado"]);
        //        oDatoPrecalificadorpwc.saldorefinanciado[i] = dsSaldoFinDet.Tables[0].Rows[i]["Saldo_Refinanciado"] == null ? 0 : Convert.ToDecimal(dsSaldoFinDet.Tables[0].Rows[i]["Saldo_Refinanciado"]);
        //        oDatoPrecalificadorpwc.saldovencidojudicial[i] = dsSaldoFinDet.Tables[0].Rows[i]["Saldo_VencidoJudicial"] == null ? 0 : Convert.ToDecimal(dsSaldoFinDet.Tables[0].Rows[i]["Saldo_VencidoJudicial"]);
        //        sumaSaldoCastigado += oDatoPrecalificadorpwc.saldocastigado[i];
        //        sumaSaldoRefinanciado += oDatoPrecalificadorpwc.saldorefinanciado[i];
        //        sumaSaldoVencidoJudicial += oDatoPrecalificadorpwc.saldovencidojudicial[i];
        //    }
        //}

        //INI HDR(RMC) 20220329 - REQ22205 Se agrego seccion de codigo
        var listaSaldoSistemaFinanciero = listaSaldos.SaldoSistemaFinancieroBT.ListaSaldoFinancieroBT; //MOD CSTI(JF) REQ22205 08112022

        if (listaSaldoSistemaFinanciero.Count >= 1)
        {
            for (int i = 0; i <= listaSaldoSistemaFinanciero.Count - 1; i++)
            {
                var saldoSistemaFinanciero = listaSaldoSistemaFinanciero[i];
				//INI EXP(AHRA) 20240207  - Adecuación preevaluacion pwc
                oDatoPrecalificadorpwc.saldocastigado[i] = string.IsNullOrEmpty(saldoSistemaFinanciero.SaldoCastigado.ToString()) ? 0M : Convert.ToDecimal(saldoSistemaFinanciero.SaldoCastigado);
                oDatoPrecalificadorpwc.saldorefinanciado[i] = string.IsNullOrEmpty(saldoSistemaFinanciero.SaldoRefinanciado.ToString()) ? 0M : Convert.ToDecimal(saldoSistemaFinanciero.SaldoRefinanciado);
                oDatoPrecalificadorpwc.saldovencidojudicial[i] = string.IsNullOrEmpty(saldoSistemaFinanciero.SaldoJudicial.ToString()) ? 0M : Convert.ToDecimal(saldoSistemaFinanciero.SaldoJudicial);
				oDatoPrecalificadorpwc.saldovencido[i]= string.IsNullOrEmpty(saldoSistemaFinanciero.SaldoVencido.ToString()) ? 0M : Convert.ToDecimal(saldoSistemaFinanciero.SaldoVencido); /*ADD ITM(MJTS) 100122 REQ21317*/
                //FIN EXP(AHRA) 20240207  - Adecuación preevaluacion incidencia canal digital
                sumaSaldoCastigado += oDatoPrecalificadorpwc.saldocastigado[i];
                sumaSaldoRefinanciado += oDatoPrecalificadorpwc.saldorefinanciado[i];
                sumaSaldoVencidoJudicial += oDatoPrecalificadorpwc.saldovencidojudicial[i];
				sumaSaldoVencido += oDatoPrecalificadorpwc.saldovencido[i];/*ADD ITM(MJTS) 100122 REQ21317*/
            }
        }//FIN HDR(RMC) 20220329 - REQ22205 
        else
        {
            for (int i = 0; i <= 11; i++)
            {
                oDatoPrecalificadorpwc.saldocastigado[i] = -1;
                oDatoPrecalificadorpwc.saldorefinanciado[i] = -1;
                oDatoPrecalificadorpwc.saldovencidojudicial[i] = -1;
                sumaSaldoCastigado += oDatoPrecalificadorpwc.saldocastigado[i];
                sumaSaldoRefinanciado += oDatoPrecalificadorpwc.saldorefinanciado[i];
                sumaSaldoVencidoJudicial += oDatoPrecalificadorpwc.saldovencidojudicial[i];
                sumaSaldoVencido = -1; /*ADD ITM(MJTS) 100122 REQ21317*/
            }

        }
        respuesta.SumaSaldoCastigado = sumaSaldoCastigado;
        respuesta.SumaSaldoRefinanciado = sumaSaldoRefinanciado;
        respuesta.SumaSaldoVencidoJudicial = sumaSaldoVencidoJudicial;
        respuesta.SumaSaldoVencido = sumaSaldoVencido; /*ADD ITM(MJTS) 100122 REQ21317*/
        loggerService.LoggerSaveTramas(respuesta, "[FIN response AsignarSaldos =>]", "CanalPreevaluacionPC");
    }

    private void AsignarClasificacion(Cotizacion toDatosPrecalificador, RespuestaEvaluacion respuesta,string token)
    {
        loggerService.LoggerSaveTramas(respuesta, "[INI request AsignarClasificacion =>]", "CanalPreevaluacionPC");
        oDatoPrecalificadorpwc.clasificacion = new string[12];
        oDatoPrecalificadorpwc.clasificacionconyugue = new string[12];

        //dsClasi = ServiciosExternos.ObtenerClasificacionSBSHistorica(Convert.ToInt32(oDatoPrecalificadorpwc.i067tipopersona), Convert.ToInt32(oDatoPrecalificadorpwc.i062tipodocumento), oDatoPrecalificadorpwc.identificador, 12);

        //INI EXP(AHRA) 20230809 - ADECUACION
        var listaClasificacion = BantotalService.obtenerClasificacionSBS(toDatosPrecalificador,token);
        //var listaClasificacion = ServiciosExternos.ObtenerClasificacionSBSHistorica(Convert.ToInt32(oDatoPrecalificadorpwc.i067tipopersona), Convert.ToInt32(oDatoPrecalificadorpwc.i062tipodocumento), oDatoPrecalificadorpwc.identificador, 12); //ADD HDR(RMC) 20220329 - REQ22205 Se agrego linea de codigo
        //FIN EXP(AHRA) 20230809 - ADECUACION

        //if (dsClasi.Tables[0].Rows.Count >= 1)
        //{

        //    for (int i = 0; i <= dsClasi.Tables[0].Rows.Count - 1; i++)
        //    {
        //        oDatoPrecalificadorpwc.clasificacion[i] = dsClasi.Tables[0].Rows[i]["clasi"].ToString() == null ? "" : dsClasi.Tables[0].Rows[i]["clasi"].ToString();
        //        oDatoPrecalificadorpwc.clasificacionconyugue[i] = "-1";
        //    }
        //}

        //INI HDR(RMC) 20220329 - REQ22205 Se agrego seccion de codigo
        var listaClasificacionSBSHistorica = listaClasificacion.ClasificacionSBSHistoricaBT.ListaClasificacionSbsBT; //MOD CSTI(JF) REQ22205 08112022

        //valor minimo del servicio EvolucionClasificacionHistorica BT
        string EvolucionCH = "";
        var responseECH = BantotalService.obtenerEvolucionClasificacionHistorica(toDatosPrecalificador, token);//agregar un servicio
        EvolucionCH = responseECH.CalificacionHistorica;

        if (listaClasificacionSBSHistorica.Count >= 1)
        {
            for (int i = 0; i <= listaClasificacionSBSHistorica.Count - 1; i++)
            {
                var clasificacionSBSHistorica = listaClasificacionSBSHistorica[i];                
                oDatoPrecalificadorpwc.clasificacion[i] = clasificacionSBSHistorica.Clasificacion.ToString() == null || clasificacionSBSHistorica.Clasificacion.ToString() == "" ? "-1" : clasificacionSBSHistorica.Clasificacion.ToString(); //MOD HDR(RMC) 20221223 - REQ22205
                oDatoPrecalificadorpwc.clasificacion[i] = (oDatoPrecalificadorpwc.clasificacion[i].Equals("-1")) ? EvolucionCH : oDatoPrecalificadorpwc.clasificacion[i];
                oDatoPrecalificadorpwc.clasificacionconyugue[i] = "-1";
            }
        }//FIN HDR(RMC) 20220329 - REQ22205
        else
        {
            for (int i = 0; i <= 11; i++)
            {
                if (string.IsNullOrEmpty(EvolucionCH))
                {
                    oDatoPrecalificadorpwc.clasificacion[i] = "-1";
                    oDatoPrecalificadorpwc.clasificacionconyugue[i] = "-1";
                }
                else
                {
                    oDatoPrecalificadorpwc.clasificacion[i] = EvolucionCH;
                    oDatoPrecalificadorpwc.clasificacionconyugue[i] = "-1";
                }
            }
        }

        loggerService.LoggerSaveTramas(respuesta, "[FIN response AsignarClasificacion =>]", "CanalPreevaluacionPC");
        //INI EXP(AHRA) 20240207  - Adecuación preevaluacion pwc
        respuesta.ClasificacionSBS = Array.Find(oDatoPrecalificadorpwc.clasificacion, valor => valor != "-1");
        //respuesta.ClasificacionSBS = oDatoPrecalificadorpwc.clasificacion[0];
        //FIN EXP(AHRA) 20240207  - Adecuación preevaluacion pwc

    }


    private void AsignarExperian(Cotizacion toDatosPrecalificador, RespuestaEvaluacion respuesta)
    {
        //se mutea todo esto y se le pasa el valor de puntaje experian que viene por el nuevo
        //parametro de entrada pero el nivel para que se utilizaria, preguntar a Peter

        loggerService.LoggerSaveTramas(toDatosPrecalificador, "[INI request AsignarExperian =>]", "CanalPreevaluacionPC");
        //manda codigo o descripcion?

        //INI EXP(AHRA) REQ25868 20240522 - Pricing -- COMENTADO
        if (toDatosPrecalificador.I067TipoPersona == 194)
        {
            puntajeExperian = toDatosPrecalificador.PuntajeScore;
        }
        else
        {
            bool esSoles = toDatosPrecalificador.MonedaCredito == 122;
            parametromaf.Categoria_Laboral = Convert.ToString(toDatosPrecalificador.I815CategoriaLaboral);

            parametromaf.Bono = 0;
            parametromaf.Cuota_Inicial = Math.Round(toDatosPrecalificador.MontoVehiculoDolar * (toDatosPrecalificador.PorcentajeCuotaInicial / 100), 2);//dolarizado
            parametromaf.Monto_Vehiculo = Math.Round(toDatosPrecalificador.MontoVehiculoDolar * toDatosPrecalificador.TipoCambioCalculo);//En Soles
            parametromaf.Porcentaje_Cuota_Inicial = toDatosPrecalificador.PorcentajeCuotaInicial;
            parametromaf.Seguro = esSoles ? toDatosPrecalificador.MontoSeguroMoneda :
                                            Math.Round(toDatosPrecalificador.MontoSeguroMoneda * toDatosPrecalificador.TipoCambioCalculo, 2);//En Soles

            if (Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Experian"]) == 0)
            {
                idExperianCliente = ServiciosExternos.ObtenerExperian(toDatosPrecalificador, parametromaf, ref lxmlrespuesta);
                puntajeExperian = ServiciosExternos.ObtenerPuntajeScoreExperian(idExperianCliente);
                oDatoPrecalificadorpwc.scoreexperian = puntajeExperian;
            }
            else
            {
                oDatoPrecalificadorpwc.scoreexperian = Convert.ToDecimal(System.Configuration.ConfigurationManager.AppSettings["Experian"]);
            }
        }
        //FIN EXP(AHRA) REQ25868 20240522 - Pricing -- COMENTADO
        respuesta.PuntajeExperian = puntajeExperian;
        loggerService.LoggerSaveTramas(respuesta.PuntajeExperian, "[FIN response AsignarExperian =>]", "CanalPreevaluacionPC");
    }
    private void AsignarRCI(Cotizacion cotizacion, RespuestaEvaluacion respuesta,string token)
    {
        //obtener RCI
        loggerService.LoggerSaveTramas(cotizacion, "[INI request AsignarRCI =>]", "CanalPreevaluacionPC");
        parametros.TipoCambio = cotizacion.TipoCambioCalculo;
        parametros.TipoPersona = Convert.ToInt32(oDatoPrecalificadorpwc.i067tipopersona);
        parametros.NumeroDocumento = oDatoPrecalificadorpwc.identificador;
        parametros.PlanCredito = cotizacion.PlanCredito;
        parametros.MonedaCredito = cotizacion.MonedaCredito;
        parametros.EstadoCivil = Convert.ToInt32(oDatoPrecalificadorpwc.i309estadocivil);      
        parametros.IngresoMensualTitularSoles = cotizacion.TotalIngresoMensualSoles;
        parametros.IngresoMensualConyugeSoles = cotizacion.TotalIngresoMensualConyugalSoles - cotizacion.TotalIngresoMensualSoles;

        //  parametros.CuotaReprogramadaDolar = constante.CalcularCuotaReprogramadaDolar(toDatosPrecalificador , montoCuotaBalon);
        parametros.CuotaReprogramadaDolar = cotizacion.CuotaReprogramadaDolar;

        //INI ADD CSTI(JF) REQ22205 10112022
        parametros.PaisTitular = (int)Enumerados.PaisesBT.Peru; //Peru
        parametros.TipoDocumentoTitular = cotizacion.I062TipoDocumento;
        parametros.PaisConyuge = 0;
        parametros.TipoDocumentoConyuge = 0;
        parametros.NumeroDocumentoConyuge = string.Empty;
        parametros.Plazo = (int)cotizacion.Plazo;
        //FIN ADD CSTI(JF) REQ22205 10112022


        //matrizrcc = ServiciosExternos.CalculoRCI(parametros, Convert.ToDouble(oDatoPrecalificadorpwc.montocuota));

        //INI HDR(RMC) 20220330 - REQ22205 Se agrego seccion de codigo
        loggerService.LoggerSaveTramas(parametros, "[INI request CalculoRCI =>]", "CanalPreevaluacionPC");
        //INI EXP(AHRA) 20230809 - ADECUACION
        var response = BantotalService.obtenerCalculoRCI(cotizacion,token);
        //var response = ServiciosExternos.CalculoRCI(parametros, Convert.ToDouble(oDatoPrecalificadorpwc.montocuota));
        //FIN EXP(AHRA) 20230809 - ADECUACION

        loggerService.LoggerSaveTramas(response, "[FIN response CalculoRCI =>]", "CanalPreevaluacionPC");
        rci = response.RCI;
        //FIN HDR(RMC) 20220330 - REQ22205

        //if (matrizrcc.RCIREPROGRAMADO > Convert.ToDecimal(matrizrcc.RCCVALOR))
        //{
        //    rci = matrizrcc.RCIREPROGRAMADO;
        //}
        //else
        //{
        //    rci = Convert.ToDecimal(matrizrcc.RCCVALOR);
        //}

        oDatoPrecalificadorpwc.rci = rci;
        loggerService.LoggerSaveTramas(respuesta, "[FIN response AsignarRCI =>]", "CanalPreevaluacionPC");
        respuesta.Rci = rci;
    }
}