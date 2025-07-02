public class AutenticacionResponseBT:BaseResponse
{
    private string _sessionToken;

    public string SessionToken
    {
        get
        {
            return _sessionToken;
        }
        set
        {
            _sessionToken = value;
        }
    }

    public AutenticacionResponseBT(int codigoRespuesta, string descripcionRespuesta, string sessionToken = null)
        : base(codigoRespuesta, descripcionRespuesta)
    {
        _sessionToken = sessionToken;
    }
}

