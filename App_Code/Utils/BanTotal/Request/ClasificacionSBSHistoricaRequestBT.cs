using Newtonsoft.Json;

public class ClasificacionSBSHistoricaRequestBT:BaseRequest
{
    [JsonProperty("IdTipoPersona")]
    public int IdTipoPersona { get; set; }

    [JsonProperty("IdTipoDocumento")]
    public int IdTipoDocumento { get; set; }

    [JsonProperty("NroDocumentoCliente")]
    public string NroDocumentoCliente { get; set; }

    [JsonProperty("NroUltimosMeses")] 
    public int NroUltimosMeses { get; set; } 

    public ClasificacionSBSHistoricaRequestBT()
    {

    }

    public ClasificacionSBSHistoricaRequestBT(BtInreq btInReq, int idTipoPersona, int idTipoDocumento,
        string nroDocumentoCliente, int nroUltimosMeses) : base(btInReq) //MOD CSTI(JF) REQ22205 09112022
    {
        IdTipoPersona = idTipoPersona;
        IdTipoDocumento = idTipoDocumento;
        NroDocumentoCliente = nroDocumentoCliente;
        NroUltimosMeses = nroUltimosMeses;  //MOD CSTI(JF) REQ22205 09112022
    }
}

