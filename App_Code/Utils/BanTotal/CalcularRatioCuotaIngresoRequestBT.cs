//INI HDR(RMC) REQ22205 20220330
public class CalcularRatioCuotaIngresoRequestBT
{
    public decimal TipoCambio { get; set; }
    public int TipoPersona { get; set; }
    public string NroDocumentoTitular { get; set; }
    public int PlanCredito { get; set; }
    public int MonedaFinanciamiento { get; set; }
    public int NroSueldosAnualConyuge { get; set; }
    public string NroDocumentoConyuge { get; set; }
    public decimal MontoIngresoConyugeSoles { get; set; }
    public int NroSueldosAnualTitular { get; set; }
    public decimal MontoIngresoTitularSoles { get; set; }
    public decimal MontoCuotaMafDolar { get; set; }
    public decimal MontoCuotaMafSoles { get; set; }
    public int IndTaxista { get; set; }
    public decimal CuotaReprogramadaDolar { get; set; }
    public decimal CuotaReprogramadaSoles { get; set; }
    public decimal GastosOperativosMoneda { get; set; }
    //INI ADD CSTI(JF) REQ22205 10112022
    public int PaisTitular { get; set; }
    public int TipoDocumentoTitular { get; set; }
    public int PaisConyuge { get; set; }
    public int TipoDocumentoConyuge { get; set; }
    public int Plazo { get; set; }
    //FIN ADD CSTI(JF) REQ22205 10112022
}
//FIN HDR(RMC) REQ22205 20220330