using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using Microsoft.VisualBasic;
using GotDotNet.ApplicationBlocks.Data;
using System.Data;


public class DBBase
{
    protected AdoHelper _Fabrica;
    protected string _ConnectionString;

    public DBBase()
    {
        _Fabrica = new SqlServer();
        _ConnectionString = SysMisc.GetOraConnStr();
    }

    protected void AgregarParametro(IDbCommand cmd, string nombreParam, ParameterDirection direccionParam, System.Data.DbType tipoParam, object valorParam)
    {
        IDbDataParameter param = cmd.CreateParameter();
        param.ParameterName = nombreParam;
        param.DbType = tipoParam;
        param.Direction = direccionParam;
        param.Value = valorParam;
        cmd.Parameters.Add(param);
    }
   
    protected void AgregarParametro(IDbCommand cmd, string nombreParam, ParameterDirection direccionParam, System.Data.DbType tipoParam, object valorParam, byte PrecisionParam, byte EscalaParam)
    {
        IDbDataParameter param = cmd.CreateParameter();
        param.ParameterName = nombreParam;
        param.DbType = tipoParam;
        param.Direction = direccionParam;
        param.Value = valorParam;
        param.Precision = PrecisionParam;
        param.Scale = EscalaParam;
        cmd.Parameters.Add(param);
    }
    
    protected void AgregarParametro(IDbCommand cmd, string nombreParam, ParameterDirection direccionParam, System.Data.DbType tipoParam, object valorParam, byte PrecisionParam, byte EscalaParam, int iSize)
    {
        IDbDataParameter param = cmd.CreateParameter();
        param.ParameterName = nombreParam;
        param.DbType = tipoParam;
        param.Direction = direccionParam;
        param.Value = valorParam;
        param.Precision = PrecisionParam;
        param.Scale = EscalaParam;
        param.Size = iSize;
        cmd.Parameters.Add(param);
    }
}


