using Newtonsoft.Json;
using System.Collections.Generic;

public class EvolucionClasificacionHistoricaResponseBT : BaseResponse
{
    [JsonProperty(PropertyName = "CalificacionHistorica")]
    public string CalificacionHistorica { get; set; }
    public EvolucionClasificacionHistoricaResponseBT() { }

    public EvolucionClasificacionHistoricaResponseBT(string clasificacionSBSHistoricaBT)
    {
        CalificacionHistorica = clasificacionSBSHistoricaBT;
    }
}

