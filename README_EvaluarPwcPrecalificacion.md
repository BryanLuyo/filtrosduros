# Funcion `EvaluarPwcPrecalificacion`

Este documento describe de forma resumida los pasos principales ejecutados por la funcion `EvaluarPwcPrecalificacion` ubicada en `App_Code/Service.cs`.

1. **Registro de la solicitud**
   - Se registra la trama de entrada mediante el `LoggerService` para fines de auditoria.
2. **Configuracion de servicios externos**
   - Se asigna el id de cotizacion y se guarda el request en `ServiciosExternos`.
3. **Mapeo de datos de cotizacion**
   - Se copian los datos recibidos en el objeto `oDatoPrecalificadorpwc` que sera enviado a PowerCurve.
4. **Inicializacion de la respuesta**
   - Se crea un objeto `RespuestaEvaluacion` y se asignan campos calculados o por defecto.
5. **Obtencion de token Bantotal**
   - Se solicita un token mediante `BantotalService.ObtenerTokenBT()` para consumir los servicios necesarios.
6. **Asignacion de informacion auxiliar**
   - Se consultan los saldos financieros, la informacion de Experian, el RCI y la clasificacion SBS a traves de metodos auxiliares.
7. **Evaluacion en PowerCurve**
   - Se invoca `ObtenerPrecalificacionPowercurve` pasando los datos recopilados para obtener la respuesta de precalificacion.
8. **Registro y retorno**
   - Se registran las tramas de respuesta y se devuelve el objeto `RespuestaEvaluacion` con la informacion final.

Esta funcion actua como orquestador de las llamadas necesarias para obtener la precalificacion de un cliente segun la informacion ingresada.
