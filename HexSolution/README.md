# HexSolution

Esta carpeta alberga una nueva solucion que sigue la arquitectura hexagonal creada en este proyecto. El archivo `.env` reemplaza al `web.config` original, trasladando sus valores de configuracion a variables de entorno.

La solucion se representa por `HexSolution.sln`, que se deja como marcador para integrar la estructura con Visual Studio u otras herramientas.

Dentro de esta carpeta se encuentran las carpetas `Application`, `Domain` y `Controllers`, junto con la documentacion asociada.

## Ejecución de la solución

1. Instalar las dependencias definidas en `packages.config`, incluyendo `DotNetEnv`, que permite cargar variables desde `.env`.
2. Al iniciar la aplicación se invoca `Env.Load()` (ver constructor de `PrecalificacionService`).
3. Copiar el archivo `.env` junto con la solución o ajustar la ruta en el constructor si se mueve a otro lugar.
4. Compilar la solución en Visual Studio o usando `msbuild` y ejecutar normalmente.

El archivo `.env` contiene las claves que antes estaban en `web.config`. Una vez cargado, estas variables de entorno pueden obtenerse con `Environment.GetEnvironmentVariable` o mediante configuraciones existentes.
