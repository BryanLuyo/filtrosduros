using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class ConstantesMAF
    {

        public static class EstadoFiltroDuro
        {
            public const int Rechazado = 0;
            public const int Aprobado = 1;
            public const int CuotaMafIngreso = 2;
        }
        public static class EvaluacionAprobacion
        {
            public const string Rechazado = "RECHAZADO";
            public const string AprobadoCondicionado = "APROBADO CONDICIONADO";
            public const string AprobadoPorContactar = "APROBADO POR CONTACTAR";
            public const string AprobadoAutomatico = "APROBADO";
            public const string PorRevisar = "POR REVISAR";
            public struct Codigo
            {
                public const int Rechazado = 1;
                public const int AprobadoCondicionado = 2;
                public const int AprobadoPorContactar = 3;
                public const int AprobadoAutomatico = 4;
                public const int PorRevisar = 5;
            }

            public static int ObtenerCodigoResultado(string Resultado)
            {
                var resultado = 0;
                switch (Resultado)
                {
                    case Rechazado:
                        resultado = Codigo.Rechazado;
                        break;
                    case AprobadoCondicionado:
                        resultado = Codigo.AprobadoCondicionado;
                        break;
                    case AprobadoPorContactar:
                        resultado = Codigo.AprobadoPorContactar;
                        break;
                    case AprobadoAutomatico:
                        resultado = Codigo.AprobadoAutomatico;
                        break;
                    case PorRevisar:
                        resultado = Codigo.PorRevisar;
                        break;
                    default: break;
                }


                return resultado;
            }
        }

    
        public  double ObtenerTipoCambio(string tipoCambio, int ident_Fecha)
        {
            Conexion conexion = new Conexion();
            int ident = conexion.obtenerIdentFecha(tipoCambio,ident_Fecha); //ADD-EXP(BVC)-REQ12815 - 20190120
            return conexion.obtenerTipoCambio(tipoCambio, ident);
        }



        //public decimal CalcularCuotaReprogramadaDolar(DtoPrecalificadorRQT toDatosPrecalificador, decimal montoCuotaBalonReprog)
        //{
        //    decimal montoCuotaReprogramada = 0;
        //     bool enSoles = true;
        //    //decimal montoSeguroVehicular = decimal.Round((tasaSeguroVehicular / 1200) * montoVehiculoMoneda, 2); // MOD MAF(EHC) REQ14144 - 20191010 
        //    decimal montoSeguroVehicular = decimal.Round((toDatosPrecalificador.MontoSeguro / 1200) * toDatosPrecalificador.MontoVehiculo , 2); // MOD MAF(EHC) REQ14144 - 20191010 
        //    WS_Calculo_MAF.WS_Calculo_MAF oService = new WS_Calculo_MAF.WS_Calculo_MAF();
        //    WS_Calculo_MAF.CuotaGenerica oCuotaGenerica = new WS_Calculo_MAF.CuotaGenerica();

        //    oCuotaGenerica.MesesGracia = 0;
        //    oCuotaGenerica.FechaInicio = DateTime.Now;

        //    int diaDeVencimiento = 4;//por defecto para cotizacion
        //    DateTime fechaFinanciamiento = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //    DateTime fechaPrimerVencimiento = CalculoMaf.GetFechaPrimerVencimiento(diaDeVencimiento, fechaFinanciamiento);

        //    oCuotaGenerica.FechaPrimerVencimiento = fechaPrimerVencimiento;
        //    oCuotaGenerica.DiasDefase = 0;
        //    oCuotaGenerica.Comisiones = 0;
        //    oCuotaGenerica.HasCuotaDoble = false;// oSolicitud.CuotasDobles.Value            
        //    oCuotaGenerica.CodigoProducto = "21377"; //Enumerados.Plan.Plan_Tradicional_M
        //    oCuotaGenerica.TipoSeguro = 0; //tipoSeguroParam
        //    oCuotaGenerica.MontoSeguroVehicular = (double)montoSeguroVehicular;// GetMontoSeguroMensualVehicular(idSolicitud)
        //    oCuotaGenerica.Gastos = 0;
        //    oCuotaGenerica.PrecioOtrosBienesFinanciados = 0;

        //    int anioInicial = Convert.ToInt32(toDatosPrecalificador.plazo) / 12;
        //    int anioReprog = (60 - Convert.ToInt32(toDatosPrecalificador.plazo)) / 12;
        //    decimal montoGpsReprog = decimal.Round((nuevoValorGps / anioInicial) * anioReprog, 2);

        //    oCuotaGenerica.PrecioVehiculo = (double)(montoCuotaBalonReprog + montoGpsReprog);
        //    oCuotaGenerica.TEA = 19.99; //'TEA maxima para reprogramación                        
        //    oCuotaGenerica.Plazo = 72 - Convert.ToInt32(toDatosPrecalificador.plazo);
        //    oCuotaGenerica.CuotaInicial = 0;
        //    oCuotaGenerica.MontoDesfaseSeguroVehicular = 0;
        //    oCuotaGenerica.MesesDesfaseSeguroVehicular = 0;
        //    oCuotaGenerica.MontoDesfaseGPS = 0;
        //    oCuotaGenerica.MesesDesfaseSeguroDesgravamen = 0;
        //    oCuotaGenerica.MontoDesfaseSeguroDesgravamen = 0;
        //    oCuotaGenerica.PorcentajeValorFuturoGarantizado = 0;
        //    oCuotaGenerica.MontoDescuento = 0;
        //    oCuotaGenerica.MontoPorte = 0;
        //    oCuotaGenerica.InteresGracia = 0;
        //    oCuotaGenerica.TasaSeguroDesgravamenMensual = 0;
        //    oCuotaGenerica = oService.CalcularCuota(oCuotaGenerica);
        //    montoCuotaReprogramada = Convert.ToDecimal(oCuotaGenerica.CuotaFinanciera) + Convert.ToDecimal(oCuotaGenerica.MontoSeguroVehicular);
        //    // INI MAF(EHC) REQ14144 - 20191010 
        //    if (enSoles)
        //        montoCuotaReprogramada = Math.Round(montoCuotaReprogramada / toDatosPrecalificador.ti, 2);
        //    return decimal.Round(montoCuotaReprogramada, 2);
        //    // FIN MAF(EHC) REQ14144 - 20191010 
        //}



        public enum EstadoCivil
        {
            Soltero = 949,
            Casado = 950,
            Viudo = 968,
            Divorciado = 969,
            Conviviente = 20078
        };
        // INI MAF(EHC) REQ14144- 20181010 
        public static class I1185ResultadoNodo
        {
            public const int ParaAnalisis = 26070;
            public const int Denegacion = 26071;
            public const int AprobacionAutomatica = 26072;

        };
        // FIN MAF(EHC) REQ14144- 20181010 
    }
    //public class CalculoMaf
    //{
    //    public static DateTime GetFechaPrimerVencimiento(int diaDeVencimiento, DateTime fechaInicio)
    //    {
    //        DateTime fechaInicioPrimeraCuota = ObtenerFechaInicioPrimeraCuota(fechaInicio, diaDeVencimiento);
    //        DateTime nuevaFechaInicio = fechaInicioPrimeraCuota;
    //        if (diaDeVencimiento != 0 && nuevaFechaInicio.Day > diaDeVencimiento)
    //            nuevaFechaInicio = DateTime.Today.AddMonths(1);
    //        return nuevaFechaInicio.AddMonths(1);
    //    }
    //    public static DateTime ObtenerFechaInicioPrimeraCuota(DateTime fechaInicio, int diaDeVencimiento)
    //    {

    //        int diaVencimiento = diaDeVencimiento;
    //        DateTime fechaVencimiento = new DateTime();
    //        bool encontrado = false;
    //        // Para el caso que sea menor que el ultimo dia de Fecha de Vencimiento (4,11,18,24 <=)

    //        if ((fechaInicio.Day <= diaVencimiento) && !encontrado)
    //        {
    //            fechaVencimiento = new DateTime(fechaInicio.Year, fechaInicio.Month, diaVencimiento);
    //            encontrado = true;
    //        }
    //        // Si es mayor que el ultimo dia de vencimiento (>24)
    //        if (!encontrado)
    //            fechaVencimiento = new DateTime(fechaInicio.AddMonths(1).Year, fechaInicio.AddMonths(1).Month, diaDeVencimiento);

    //        return fechaVencimiento;
    //    }
    //}


    //public class ParametroScore
    //{
    //    public const int scorePoliticas = 22169;
    //    public const int scoreTaxi = 23143;
    //    public const int scorePuntaje = 22175;
    //    public const int scorePoliticasSimulacion = 22216;
    //    public const int scorePuntajeTaxi = 23141;
    //    public const int nivelesScore = 22199;
    //    public const int nivelesScoreTaxi = 23142;
    //    public const int rangoScore = 931;
    //    public const int rangoScoreTaxi = 1059;
    //    public const int evaluacionautomatica = 25349; // ADD REQ10752 - MAF(JJZA) 20170803
    //    public const int evaluacionautomaticaTerceraTaxista = 25834; // ADD REQ11414 - CSP(NCTS) 20180208
    //    public const int evaluacionautomaticaTerceraNoTaxista = 25835; // ADD REQ11414 - CSP(NCTS) 20180208
    //    public const int evaluacionautomaticaTerceraJuridica = 25848; // EXP(MJMF) REQ11414 - 20180430
    //    public const int scorePuntajeCotizador = 25836; // REQ11088: HDR(EAAR) 20180209  
    //    public const int rangoScoreCotizador = 1177; // REQ11088: HDR(EAAR) 20180209 -- HDR(EATB) 20180824 CAMBIO DE CODIGO ANTIGUO 10073
    //    public const int scoreExperian = 25882; // EXP(MJMF) REQ11724 - 20180524
    //    public const int scoreExperianTaxi = 25883; // EXP(MJMF) REQ11724 - 20180524
    //    public const int scoreExperian3eraNaturalNotaxi = 25884; // EXP(MJMF) REQ11724 - 20180524

    //}
    //public struct validacionesRechazo
    //{
    //    public const int TEA = 1;
    //    public const int FiltroDuro = 2;
    //    public const int ScoreExperian = 3;
    //    public const int ArbolDecisiones = 4;
    //}
    //public struct MonedaMaf
    //{
    //    public const int DOLARES = 121;
    //    public const int SOLES = 122;
    //    public const string DescDolares = "DOLARES";
    //    public const string DescSoles = "SOLES";
    //}
    //public struct Lugar
    //{
    //    public const int LimaCallao = 21155;
    //    public const int ProvinciaNorte = 21157;
    //}
    //public struct CategoriaLaboral
    //{
    //    public const int Categoria4ta = 20076;
    //    public const int Categoria5ta = 20077;
    //    public const string Categoria4taDescripcion = "4ta Categoría";
    //    public const string Categoria5taDescripcion = "5ta Categoría";
    //}
    //public struct TipoDocumento
    //{
    //    public struct CodigoTdp
    //    {
    //        public const int DNI = 1;
    //        public const int CE = 2;
    //        public const int PAS = 3;
    //        public const int RUC = 4;
    //    }
    //    public struct CodigoMaf
    //    {
    //        public const int DNI = 171;
    //        public const int CE = 172;
    //        public const int PAS = 173;
    //        public const int RUC = 174;
    //    }

    //    public struct DefinicionParametroTipoDocumentoBN
    //    {
    //        public const int DNI = 13;
    //        public const int RUC = 16;
    //        public const int CARNETEXTRANJERIA = 14;
    //        public const int PASAPORTE = 15;
    //    }
    //}
    ////INI REQ12706 EHC 20190208
    //public struct FormatDate
    //{
    //    public const string ShortDate = "dd/MM/yyyy";
    //    public const string LongDate = "dd/MM/yyyy hh:mm:ss";
    //}
    //FIN REQ12706 EHC 20190208

