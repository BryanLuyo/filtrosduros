using Newtonsoft.Json;
using System.Collections.Generic;

public class SaldoSistemaFinancieroResponseBT : BaseResponse
{
    [JsonProperty(PropertyName = "SdtRespuesta")]
    public SaldoSistemaFinancieroBT SaldoSistemaFinancieroBT { get; set; }
    public SaldoSistemaFinancieroResponseBT() { }

    public SaldoSistemaFinancieroResponseBT(SaldoSistemaFinancieroBT saldoSistemaFinancieroBT)
    {
        SaldoSistemaFinancieroBT = saldoSistemaFinancieroBT;
    }
}
public class SaldoSistemaFinancieroBT
{
    [JsonProperty(PropertyName = "DEPESBTSALDOFINANCIERO")]
    public List<SaldoFinancieroBT> ListaSaldoFinancieroBT { get; set; }
}
public class SaldoFinancieroBT
{
    public int NroSaldo { get; set; }
    public int CantidadCuentas { get; set; }
    public decimal SaldoRefinanciado { get; set; }
    public decimal SaldoJudicial { get; set; }
    public decimal SaldoVencido { get; set; }
    public double SaldoCastigado { get; set; }  //MOD EXP(AHRA) 20240207 - Adecuación preevaluacion incidencia canal digital
    public int IndCreditoVehicular { get; set; }
    public int MaximaClasificacion { get; set; }
    public string Periodo { get; set; }
}







