using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Enumerados
/// </summary>
public class Enumerados
{
	
   public enum EstadoCivil : int
    {
        Soltero = 949,
        Casado = 950,
        Viudo = 968,
        Divorciado = 969,
        Conviviente = 20078
    }

   public enum TipoDocumentoIdentificacion : int
   {
       DNI = 171,
       CarnetIdentidad = 176,
       CarnetExtranjeria = 172,
       Pasaporte = 173,
       RUC = 174,
       SinDocumento = 175,
       CarnedelasFFPP =966,
       CarnedelasFFAA =967,
       Todos = 0
   }

   public enum TipoPersona
   {
       Natural = 194,
       Jurídica = 195
   }

   public enum CategoriaLaboral
   {
       QuintaCategoria = 20077,
       CuartaCategoria = 20076,
       TerceraCategoria = 20075,
       PrimeraCategoria = 20112,
       SinCategoria = 20130
   }
    //INI ADD CSTI(JF) REQ22205 10112022
    public enum PaisesBT
    {
        Peru = 604
    }
    //FIN ADD CSTI(JF) REQ22205 10112022
}