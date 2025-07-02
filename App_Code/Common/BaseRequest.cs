public class BaseRequest
{
    private BtInreq _btInReq;

    public BtInreq BtInreq
    {
        get
        {
            return _btInReq;
        }
        set
        {
            _btInReq = value;
        }
    }

    public BaseRequest()
    {
    }

    public BaseRequest(BtInreq btInReq)
    {
        _btInReq = btInReq;
    }
}

