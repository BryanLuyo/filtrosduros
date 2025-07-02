using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConstantesBT
/// </summary>
public class ConstantesBT
{
    public struct PlanCredito
    {
        public struct CodigoBT
        {
            public const int ToyotaLife = 38;
            public const int Tradicional = 1;
            public const int Tradicional_M = 9;
            public const int Taxis_M = 13;
            public const int Lexus_Life = 40;
            public const int SemiNuevos = 43;
            public const int PlanAgricola = 300;
            public const int RapiCredit = 39;
            //INI EXP(AHRA) SOLXXXX 20240509 - Pricing
            public const int Plan50_50 = 18;
            public const int Grandes_Iniciales = 208;
            public const int Hino_life_Negocios = 107;
            //FIN EXP(AHRA) SOLXXXX 20240509 - Pricing
        }
        public struct CodigoMAF
        {
            public const int ToyotaLife = 25617;
            public const int Tradicional = 20003;
            public const int Tradicional_M = 21377;
            public const int Taxis_M = 21385;
            public const int Lexus_Life = 25837;
            public const int SemiNuevos = 26120;
            public const int PlanAgricola = 28052;
            public const int RapiCredit = 25722;
            //INI EXP(AHRA) SOLXXXX 20240509 - Pricing
            public const int Plan50_50 = 22204;
            public const int Grandes_Iniciales = 28105;
            public const int Hino_life_Negocios = 28053;
            //FIN EXP(AHRA) SOLXXXX 20240509 - Pricing
        }
    }
    public struct Moneda
    {
        public struct CodigoBT
        {
            public const int Soles = 1;
            public const int Dolares = 2;
        }
        public struct CodigoMAF
        {
            public const int Soles = 122;
            public const int Dolares = 121;
        }
    }
    public struct CategoriaLaboral
    {
        public struct CodigoBT
        {
            public const int PrimeraCategoria = 9;
            public const int TerceraCategoria = 4; //Taxista BT
            public const int CuartaCategoria = 3;
            public const int QuintaCategoria = 1;
        }
        public struct CodigoMAF
        {
            public const int PrimeraCategoria = 20112;
            public const int TerceraCategoria = 20075;
            public const int CuartaCategoria = 20076;
            public const int QuintaCategoria = 20077;
            public const int SinCategoria = 20130;
        }
    }
    public struct EstadoVehiculo
    {
        public struct CodigoBT
        {
            public const int Nuevo = 1;
            public const int Usado = 2;
        }
        public struct CodigoMAF
        {
            public const int Nuevo = 20006;
            public const int Usado = 20007;
        }
    }
    public struct Uso
    {
        public struct CodigoBT
        {
            public const int Particular = 1;
            public const int Comercial = 2;
            public const int TPU = 3;
            public const int Alquiler = 5;
            public const int Taxi = 6;
        }
        public struct CodigoMAF
        {
            public const int Particular = 20269;
            public const int Comercial = 20270;
            public const int TPU = 20319;
            public const int Alquiler = 20271;
            public const int Taxi = 20344;
            public const int InterProvincial = 21166;
        }
    }
    public struct TipoPersona
    {
        public struct CodigoBT
        {
            public const int Natural = 1;
            public const int Juridica = 2;
        }
        public struct CodigoMAF
        {
            public const int Natural = 194;
            public const int Juridica = 195;
        }
        public struct Descripcion
        {
            public const string Natural = "F";
            public const string Juridica = "J";
        }
    }
    public struct Sucursal
    {
        public struct CodigoBT
        {
            public const int SanIsidro = 1;
            public const int Huanuco = 116;
            public const int Cuzco = 117;
        }
        public struct CodigoMAF
        {
            public const int Natural = 194;
        }
    }
    public struct Producto
    {
        public struct CodigoBT
        {
            public const int CreditoVehicular = 101;
        }
        public struct CodigoMAF
        {
            public const int CreditoVehicular = 20066;
        }
    }
    public struct Cobertura
    {
        public struct CodigoBT
        {
            public const int PerdidaTotal = 1;
            public const int TodoRiesgo = 2;
        }
        public struct CodigoMAF
        {
            public const int PerdidaTotal = 25103;
            public const int TodoRiesgo = 25102;
        }
    }
    public struct ZonaCirculacion
    {
        public struct CodigoBT
        {
            public const int Lima = 1;
            public const int ProvinciaNorte = 2;
            public const int ProvinciaSur = 3;
        }
        public struct CodigoMAF
        {
            public const int Lima = 21155;
            public const int ProvinciaNorte = 21157;
            public const int ProvinciaSur = 21156;
        }
    }
    public struct TipoDocumento
    {
        public struct CodigoBT
        {
            public const int DNI = 1;
            public const int CE = 172;
            public const int PAS = 173;
            public const int RUC = 174;
        }
        public struct CodigoMAF
        {
            public const int DNI = 171;
            public const int CE = 172;
            public const int PAS = 173;
            public const int RUC = 174;
        }
    }
    public struct IndSeguro
    {
        public struct CodigoBT
        {
            public const string Verdadero = "S";
            public const string Falso = "N";
        }
        public struct CodigoMAF
        {
            public const string Verdadero = "True";
            public const string Falso = "False";
        }
    }
    public struct RangoVentas
    {
        public struct CodigoBT
        {
            public const int MenorA660MilSoles = 1;
            public const int MayorA660MilYMenorA3Punto3MillonesSoles = 2;

        }
        public struct CodigoMAF
        {
            public const int MenorA660MilSoles = 26313;
            public const int MayorA660MilYMenorA3Punto3MillonesSoles = 26314;
        }
    }
    public struct EstadoCivil
    {
        public struct CodigoBT
        {
            public const int Soltero = 1;
            public const int CasadoConSeparacionBien = 2;
            public const int CasadoSinSeparacionBien = 6;
            public const int Viudo = 3;
            public const int Divorciado = 4;
            public const int Conviviente = 5;

        }
        public struct CodigoMAF
        {
            public const int Soltero = 949;
            public const int Casado = 950;
            public const int Viudo = 968;
            public const int Divorciado = 969;
            public const int Conviviente = 20078;
        }
    }
    public struct Sexo
    {
        public struct CodigoBT
        {
            public const int Masculino = 0;
            public const int Femenino = 0;

        }
        public struct CodigoMAF
        {
            public const int Masculino = 947;
            public const int Femenino = 948;
        }
        public struct Descripcion
        {
            public const string Masculino = "M";
            public const string Femenino = "F";
        }
    }
    public struct FinanciamientoSeguro
    {
        public struct Descripcion
        {
            public const string Si = "S";
            public const string No = "N";

        }
        public struct CodigoMAF
        {
            public const bool Si = true;
            public const bool No = false;
        }
    }
    public struct FinanciamientoGastos
    {
        public struct Descripcion
        {
            public const string Si = "S";
            public const string No = "N";

        }
        public struct CodigoMAF
        {
            public const bool Si = true;
            public const bool No = false;
        }
    }
    public struct TieneCuotasDobles
    {
        public struct Descripcion
        {
            public const string Si = "S";
            public const string No = "N";

        }
        public struct CodigoMAF
        {
            public const bool Si = true;
            public const bool No = false;
        }
    }
    public struct TipoDireccion
    {
        public struct CodigoBT
        {
            public const int Domicilio = 1; //Vivienda
            public const int Legal = 3;
            public const int Correspondencia = 2;
            public const int Laboral = 4;
            public const int Cobranzas = 5;

        }
        public struct CodigoMAF
        {
            public const int Domicilio = 925;
            public const int Legal = 926;
            public const int Correspondencia = 927;
            public const int Laboral = 2256;
        }
    }
    public struct TipoClienteDesgravamen
    {
        public struct CodigoBT
        {
            public const int Titular = 2;
            public const int Mancomunado = 1;
            public const int SinSeguroDesgravamen = 3;

        }
        public struct CodigoMAF
        {
            public const int Titular = 20242;
            public const int Mancomunado = 20243;
            public const int SinSeguroDesgravamen = 20244;
        }
    }
    //INI HDR(RMC) 20230102 - REQConsejeros
    public struct Aseguradora
    {
        public struct CodigoBT
        {
            public const int RimacSeguros = 3;
            public const int PacificoSeguros = 4;
            public const int MafreSeguros = 1;
            public const int LaPositivaSeguros = 2;
        }
        public struct CodigoMAF
        {
            public const int RimacSeguros = 5;
            public const int PacificoSeguros = 4;
            public const int MafreSeguros = 2670;
            public const int LaPositivaSeguros = 2671;
        }
    }
}