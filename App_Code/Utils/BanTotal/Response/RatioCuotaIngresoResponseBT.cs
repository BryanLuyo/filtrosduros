using Newtonsoft.Json;

public class RatioCuotaIngresoResponseBT:BaseResponse
{
    [JsonProperty(PropertyName = "RCI")]
    public decimal RCI { get; set; }

    [JsonProperty(PropertyName = "RCIReprogramado")]
    public decimal RCIReprogramado { get; set; }
    public RatioCuotaIngresoResponseBT() { }

    public RatioCuotaIngresoResponseBT(decimal rci, decimal rciReprogramado)
    {
        RCI = rci;
        RCIReprogramado = rciReprogramado;
    }
}

