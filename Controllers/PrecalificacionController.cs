using System.Web.Mvc;
using Domain.Interfaces;

public class PrecalificacionController : Controller
{
    private readonly IPrecalificacionService _service;

    public PrecalificacionController()
    {
        _service = new PrecalificacionService();
    }

    [HttpPost]
    public ActionResult EvaluarPwcPrecalificacionMvc(Cotizacion datos, int idOpcion)
    {
        var respuesta = _service.EvaluarPwcPrecalificacion(datos, idOpcion);
        return Json(respuesta, JsonRequestBehavior.AllowGet);
    }
}
