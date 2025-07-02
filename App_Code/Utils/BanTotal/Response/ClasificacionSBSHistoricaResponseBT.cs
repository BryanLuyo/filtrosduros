using Newtonsoft.Json;
using System.Collections.Generic;

public class ClasificacionSBSHistoricaResponseBT:BaseResponse
{
    [JsonProperty(PropertyName = "SdtRespuesta")]
    public ClasificacionSBSHistoricaBT ClasificacionSBSHistoricaBT { get; set; }
    public ClasificacionSBSHistoricaResponseBT() { }

    public ClasificacionSBSHistoricaResponseBT(ClasificacionSBSHistoricaBT clasificacionSBSHistoricaBT)
    {
        ClasificacionSBSHistoricaBT = clasificacionSBSHistoricaBT;
    }
}
public class ClasificacionSBSHistoricaBT
{
    [JsonProperty(PropertyName = "DEPESBTListaSBSHis")]
    public List<ClasificacionSbsBT> ListaClasificacionSbsBT { get; set; }
}
public class ClasificacionSbsBT
{
    public string Clasificacion { get; set; }
    public int NroItem { get; set; }
    public string Periodo { get; set; }
}


