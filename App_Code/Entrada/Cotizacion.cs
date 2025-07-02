using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public class Cotizacion
{

    private string NumeroDocumentoField;
    private int I062TipoDocumentoField;

    private DateTime? FechaNacimientoField;
    private DateTime? FechaInicioLaboresField;
    private DateTime? FechaFinLaboresField;

    private int NacionalidadField;
    private decimal TotalIngresoMensualSolesField;
    private decimal TotalIngresoMensualConyugalSolesField;
    private decimal PlazoField;
    private decimal MontoCuotaField;
    private decimal PorcentajeCuotaInicialField;

    private decimal MontoCuotaInicialField;
    private int I067TipoPersonaField;
    private int I309EstadoCivilField;
    private int I815CategoriaLaboralField;

    //Falta considerar aun estos parametros
    private string NumeroCotizacionField;
    private string ApellidoPaternoField;
    private decimal MontoVehiculoField;
    private decimal MontoSeguroField;

    private decimal CuotaReprogramadaDolarField;
    private int PlanCreditoField;
    private int MonedaCreditoField;
    private decimal TipoCambioCalculoField;
    private int PuntajeScoreField;                  //ADD EXP(AHRA) REQ25868 20240522 - Pricing
    private string NivelScoreField;                 //ADD EXP(AHRA) REQ25868 20240522 - Pricing

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string NumeroCotizacion
    {
        get
        {
            return this.NumeroCotizacionField;
        }
        set
        {
            this.NumeroCotizacionField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string NumeroDocumento
    {
        get
        {
            return this.NumeroDocumentoField;
        }
        set
        {
            this.NumeroDocumentoField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int I062TipoDocumento
    {
        get
        {
            return this.I062TipoDocumentoField;
        }
        set
        {
            this.I062TipoDocumentoField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ApellidoPaterno
    {
        get
        {
            return this.ApellidoPaternoField;
        }
        set
        {
            this.ApellidoPaternoField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
    public DateTime? FechaNacimiento
    {
        get
        {
            return this.FechaNacimientoField;
        }
        set
        {
            this.FechaNacimientoField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int Nacionalidad
    {
        get
        {
            return this.NacionalidadField;
        }
        set
        {
            this.NacionalidadField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int I309EstadoCivil
    {
        get
        {
            return this.I309EstadoCivilField;
        }
        set
        {
            this.I309EstadoCivilField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int I067TipoPersona
    {
        get
        {
            return this.I067TipoPersonaField;
        }
        set
        {
            this.I067TipoPersonaField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
    public DateTime? FechaInicioLabores
    {
        get
        {
            return this.FechaInicioLaboresField;
        }
        set
        {
            this.FechaInicioLaboresField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
    public DateTime? FechaFinLabores
    {
        get
        {
            return this.FechaFinLaboresField;
        }
        set
        {
            this.FechaFinLaboresField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal TotalIngresoMensualSoles
    {
        get
        {
            return this.TotalIngresoMensualSolesField;
        }
        set
        {
            this.TotalIngresoMensualSolesField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal TotalIngresoMensualConyugalSoles
    {
        get
        {
            return this.TotalIngresoMensualConyugalSolesField;
        }
        set
        {
            this.TotalIngresoMensualConyugalSolesField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int I815CategoriaLaboral
    {
        get
        {
            return this.I815CategoriaLaboralField;
        }
        set
        {
            this.I815CategoriaLaboralField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int PlanCredito
    {
        get
        {
            return this.PlanCreditoField;
        }
        set
        {
            this.PlanCreditoField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int MonedaCredito
    {
        get
        {
            return this.MonedaCreditoField;
        }
        set
        {
            this.MonedaCreditoField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal Plazo
    {
        get
        {
            return this.PlazoField;
        }
        set
        {
            this.PlazoField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal MontoVehiculoDolar
    {
        get
        {
            return this.MontoVehiculoField;
        }
        set
        {
            this.MontoVehiculoField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal PorcentajeCuotaInicial
    {
        get
        {
            return this.PorcentajeCuotaInicialField;
        }
        set
        {
            this.PorcentajeCuotaInicialField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal MontoCuotaInicialMoneda
    {
        get
        {
            return this.MontoCuotaInicialField;
        }
        set
        {
            this.MontoCuotaInicialField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal MontoSeguroMoneda
    {
        get
        {
            return this.MontoSeguroField;
        }
        set
        {
            this.MontoSeguroField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal MontoCuotaMoneda
    {
        get
        {
            return this.MontoCuotaField;
        }
        set
        {
            this.MontoCuotaField = value;
        }
    }

    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal CuotaReprogramadaDolar
    {
        get
        {
            return this.CuotaReprogramadaDolarField;
        }
        set
        {
            this.CuotaReprogramadaDolarField = value;
        }
    }

    public decimal TipoCambioCalculo
    {
        get
        {
            return this.TipoCambioCalculoField;
        }
        set
        {
            this.TipoCambioCalculoField = value;
        }
    }
    //INI EXP(AHRA) SOLXXXX 20240522 - Pricing
    public int PuntajeScore
    {
        get
        {
            return this.PuntajeScoreField;
        }
        set
        {
            this.PuntajeScoreField = value;
        }
    }
    public string NivelScore
    {
        get
        {
            return this.NivelScoreField;
        }
        set
        {
            this.NivelScoreField = value;
        }
    }
    //FIN EXP(AHRA) SOLXXXX 20240522 - Pricing
}



