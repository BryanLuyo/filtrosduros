using System;

public interface IPrecalificacionService
{
    RespuestaEvaluacion EvaluarPwcPrecalificacion(Cotizacion datos, int idOpcion);
}
