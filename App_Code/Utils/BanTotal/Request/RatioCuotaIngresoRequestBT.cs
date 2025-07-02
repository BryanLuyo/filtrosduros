using Newtonsoft.Json;

public class RatioCuotaIngresoRequestBT:BaseRequest
{
    [JsonProperty("PepaisTit")]
    public int PepaisTit { get; set; }

    [JsonProperty("PetdocTit")]
    public int PetdocTit { get; set; }

    [JsonProperty("NroDocumentoTitular")]
    public string NroDocumentoTitular { get; set; }

    [JsonProperty("PepaisCon")]
    public int PepaisCon { get; set; }

    [JsonProperty("PetdocCon")]
    public int PetdocCon { get; set; }

    [JsonProperty("NroDocumentoConyuge")]
    public string NroDocumentoConyuge { get; set; }

    [JsonProperty("TipoCambio")]
    public decimal TipoCambio { get; set; }

    [JsonProperty("PlanCredito")]
    public string PlanCredito { get; set; }

    [JsonProperty("MonedaFinanciamiento")]
    public int MonedaFinanciamiento { get; set; }

    [JsonProperty("MontoIngresoConyugeSoles")]
    public decimal MontoIngresoConyugeSoles { get; set; }

    [JsonProperty("MontoIngresoTitularSoles")]
    public decimal MontoIngresoTitularSoles { get; set; }

    [JsonProperty("MontoCuotaMafSoles")]
    public decimal MontoCuotaMafSoles { get; set; }

    [JsonProperty("IndTaxista")]
    public int IndTaxista { get; set; }

    [JsonProperty("CuotaReprogramadaSoles")]
    public decimal CuotaReprogramadaSoles { get; set; }

    [JsonProperty("GastosOperativosMoneda")]
    public decimal GastosOperativosMoneda { get; set; }
    [JsonProperty("Plazo")]
    public int Plazo { get; set; }
    [JsonProperty("PaisTitular")]
    public int PaisTitular { get; set; }
    //falto agregar
    [JsonProperty("TipoDocumentoTitular")]
    public int TipoDocumentoTitular { get; set; }
    [JsonProperty("PaisConyuge")]
    public int PaisConyuge { get; set; }
    [JsonProperty("TipoDocumentoConyuge")]
    public int TipoDocumentoConyuge { get; set; }

    public RatioCuotaIngresoRequestBT()
    {

    }

    public RatioCuotaIngresoRequestBT(BtInreq btInReq, int pepaisTit, int petdocTit, string nroDocumentoTitular,
        int pepaisCon, int petdocCon, string nroDocumentoConyuge, decimal tipoCambio, string planCredito, int monedaFinanciamiento,
        decimal montoIngresoConyugeSoles, decimal montoIngresoTitularSoles, decimal montoCuotaMafSoles, int indTaxista,
        decimal cuotaReprogramadaSoles, decimal gastosOperativosMoneda, int plazo, int paisTitular, 
        int tipoDocumentoTitular, int paisConyuge, int tipoDocumentoConyuge) : base(btInReq)
    {
        TipoCambio = tipoCambio;
        PepaisTit = pepaisTit;
        PetdocTit = petdocTit;
        NroDocumentoTitular = nroDocumentoTitular;
        PepaisCon = pepaisCon;
        PetdocCon = petdocCon;
        NroDocumentoConyuge = nroDocumentoConyuge;
        TipoCambio = tipoCambio;
        PlanCredito = planCredito;
        MonedaFinanciamiento = monedaFinanciamiento;
        MontoIngresoConyugeSoles = montoIngresoConyugeSoles;
        MontoIngresoTitularSoles = montoIngresoTitularSoles;
        MontoCuotaMafSoles = montoCuotaMafSoles;
        IndTaxista = indTaxista;
        CuotaReprogramadaSoles = cuotaReprogramadaSoles;
        GastosOperativosMoneda = gastosOperativosMoneda;
        Plazo = plazo;
        PaisTitular = paisTitular;
        TipoDocumentoTitular = tipoDocumentoTitular;
        PaisConyuge = paisConyuge;
        TipoDocumentoConyuge = tipoDocumentoConyuge;
    }
}


