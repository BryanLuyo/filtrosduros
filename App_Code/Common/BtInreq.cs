using Newtonsoft.Json;

public class BtInreq
{
    [JsonIgnore]
    private string _device;

    [JsonIgnore]
    private string _usuario;

    [JsonIgnore]
    private string _requerimiento;

    [JsonIgnore]
    private string _canal;

    [JsonIgnore]
    private string _token;

    [JsonProperty(PropertyName = "Device")]
    public string Device
    {
        get
        {
            return _device;
        }
        set
        {
            _device = value;
        }
    }

    [JsonProperty(PropertyName = "Usuario")]
    public string Usuario
    {
        get
        {
            return _usuario;
        }
        set
        {
            _usuario = value;
        }
    }

    [JsonProperty(PropertyName = "Requerimiento")]
    public string Requerimiento
    {
        get
        {
            return _requerimiento;
        }
        set
        {
            _requerimiento = value;
        }
    }

    [JsonProperty(PropertyName = "Canal")]
    public string Canal
    {
        get
        {
            return _canal;
        }
        set
        {
            _canal = value;
        }
    }

    [JsonProperty(PropertyName = "Token")]
    public string Token
    {
        get
        {
            return _token;
        }
        set
        {
            _token = value;
        }
    }
}

