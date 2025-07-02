public class BaseResponse
{
    public int CodigoRespuesta { get; set; }
    public string DescripcionRespuesta { get; set; }


    public BaseResponse()
    {


    }


    public BaseResponse(int codigoRespuesta, string descripcionRespuesta)
    {
        CodigoRespuesta = codigoRespuesta;
        DescripcionRespuesta = descripcionRespuesta;
    }
}

