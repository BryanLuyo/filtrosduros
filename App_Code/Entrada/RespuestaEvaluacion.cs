using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RespuestaEvaluacion
/// </summary>
public class RespuestaEvaluacion
{
    public RespuestaEvaluacion()
    {
        RespuestaPowerCurve = string.Empty;
        MensajeRespuestaPowerCurve=string.Empty;
        Rci = 0;
        PuntajeExperian = 0;
        SumaSaldoCastigado= 0;
        SumaSaldoRefinanciado= 0;
        SumaSaldoVencidoJudicial= 0;
        SumaSaldoVencido   =0;
        ClasificacionSBS=string.Empty;
    }
    public string RespuestaPowerCurve { get; set; }
    public string MensajeRespuestaPowerCurve { get; set; }
    public decimal Rci { get; set; }
    public decimal PuntajeExperian { get; set; }
    public decimal SumaSaldoCastigado { get; set; }
    public decimal SumaSaldoRefinanciado { get; set; }
    public decimal SumaSaldoVencidoJudicial { get; set; }
    public decimal SumaSaldoVencido { get; set; } /*ADD ITM(MJTS) 100122 REQ21317*/
    public string ClasificacionSBS { get; set; }
}