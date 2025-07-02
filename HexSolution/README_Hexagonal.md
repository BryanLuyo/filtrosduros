# Hexagonal Architecture Migration

Este proyecto fue reestructurado siguiendo un enfoque de arquitectura hexagonal.

## Capas principales
- **Domain**: Contiene las interfaces que definen los contratos del dominio.
- **Application**: Implementa la lógica de negocio en `PrecalificacionService`.
- **Infrastructure**: Aquí se ubican las dependencias externas, como servicios de Bantotal.
- **API**: Incluye el `Service.asmx` y el `PrecalificacionController` que actúan como adaptadores de entrada.

La funcionalidad original de `EvaluarPwcPrecalificacion` se movió al servicio de aplicación y el web service ahora delega la ejecución a través de la interfaz `IPrecalificacionService`.
