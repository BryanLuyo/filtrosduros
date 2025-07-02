using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CotizacionDataAdicional
{
    public decimal TipoCambio { get; set; }
    public int TipoPersona { get; set; }
    public string NumeroDocumento { get; set; }
    public int PlanCredito { get; set; }
    public int MonedaCredito { get; set; }
    public int EstadoCivil { get; set; }
    public string NumeroDocumentoConyuge { get; set; }
    public decimal CuotaReprogramadaDolar { get; set; }
    public int CodigoCategoriaLaboral { get; set; }


    public decimal IngresoMensualTitularSoles { get; set; }
    public decimal IngresoMensualConyugeSoles { get; set; }
    //INI ADD CSTI(JF) REQ22205 10112022   
    public int PaisTitular { get; set; }
    public int TipoDocumentoTitular { get; set; }
    public int PaisConyuge { get; set; }
    public int TipoDocumentoConyuge { get; set; }
    public int Plazo { get; set; }
    //FIN ADD CSTI(JF) REQ22205 10112022
}