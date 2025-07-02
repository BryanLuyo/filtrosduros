using Newtonsoft.Json;

public class SaldoSistemaFinancieroRequestBT: BaseRequest
{
    [JsonProperty("IdTipoPersona")]
    public int IdTipoPersona { get; set; }

    [JsonProperty("IdTipoDocumento")]
    public int IdTipoDocumento { get; set; }

    [JsonProperty("NroDocumentoCliente")]
    public string NroDocumentoCliente { get; set; }

    [JsonProperty("NroUltimosPeriodos")]
    public int NroUltimosPeriodos { get; set; }

    public SaldoSistemaFinancieroRequestBT()
    {

    }

    public SaldoSistemaFinancieroRequestBT(BtInreq btInReq, int idTipoPersona, int idTipoDocumento,
        string nroDocumentoCliente, int nroUltimosPeriodos) : base(btInReq)
    {
        IdTipoPersona = idTipoPersona;
        IdTipoDocumento = idTipoDocumento;
        NroDocumentoCliente = nroDocumentoCliente;
        NroUltimosPeriodos = nroUltimosPeriodos;
    }
}







