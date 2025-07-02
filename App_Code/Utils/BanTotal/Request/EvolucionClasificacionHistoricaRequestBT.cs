using Newtonsoft.Json;

public class EvolucionClasificacionHistoricaRequestBT : BaseRequest
{
    [JsonProperty("IdTipoPersona")]
    public int IdTipoPersona { get; set; }

    [JsonProperty("IdTipoDocumento")]
    public int IdTipoDocumento { get; set; }

    [JsonProperty("NroDocumentoCliente")]
    public string NroDocumentoCliente { get; set; }

    [JsonProperty("NroUltimosMeses")] 
    public int NroUltimosMeses { get; set; } 

    public EvolucionClasificacionHistoricaRequestBT()
    {

    }

    public EvolucionClasificacionHistoricaRequestBT(BtInreq btInReq, int idTipoPersona, int idTipoDocumento,
        string nroDocumentoCliente, int nroUltimosMeses) : base(btInReq)
    {
        IdTipoPersona = idTipoPersona;
        IdTipoDocumento = idTipoDocumento;
        NroDocumentoCliente = nroDocumentoCliente;
        NroUltimosMeses = nroUltimosMeses; 
    }
}

