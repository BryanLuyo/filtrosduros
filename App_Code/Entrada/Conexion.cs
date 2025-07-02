using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Bend.Common.Utils;


public class Conexion : DBBase 
{

    public double obtenerTipoCambio(string tipoCambio, int identFechaProceso)
    {
        DataSet dsResultado = new DataSet();
        IDbConnection cn = _Fabrica.GetConnection(this._ConnectionString);
        IDbCommand cmd = cn.CreateCommand();
        cmd.CommandText = "MCV_Tipo_Cambio_Dolares_FechaProceso";
        cmd.CommandType = CommandType.StoredProcedure;
        AgregarParametro(cmd, "@TIPO", ParameterDirection.Input, System.Data.DbType.String, tipoCambio);
        AgregarParametro(cmd, "@INDET_FECH_PROCESO", ParameterDirection.Input, System.Data.DbType.String, identFechaProceso);
        try
        {
            cn.Open();
            dsResultado = _Fabrica.ExecuteDataset(cmd);
            if ((dsResultado.Tables[0].Rows.Count > 0))
            {
              
                return Convert.ToDouble(dsResultado.Tables[0].Rows[0]["TIPO_CAMBIO_VENTA"]);
            }
            else
                return 0;
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    public int obtenerIdentFecha(string tipoCambio, int identFechaProceso)
    {
        DataSet dsResultado = new DataSet();
        IDbConnection cn = _Fabrica.GetConnection(this._ConnectionString);
        IDbCommand cmd = cn.CreateCommand();
        cmd.CommandText = "PRC_PROCESO_ObtenerFechaProceso";
     
        try
        {
            cn.Open();
            dsResultado = _Fabrica.ExecuteDataset(cmd);
            if ((dsResultado.Tables[0].Rows.Count > 0))
            {

                return Convert.ToInt32(dsResultado.Tables[0].Rows[0][0]);
            }
            else
                return 0;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

	
}