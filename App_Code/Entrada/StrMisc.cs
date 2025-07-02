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
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for StrMisc
/// </summary>

public class SysMisc
{
    private const string ENCRYPTER = "aa544@<.AAKKL?=y";

    public static string Encrypt(string text)
    {
        return new Encripta.GOEncripta().EncriptarTexto(ENCRYPTER, text);
    }

    public static string Decrypt(string text)
    {
        return new Desencripta.GODesencripta().DesencriptaTexto(ENCRYPTER, text);
    }

    // TODO: mover a clases de base de datos.
    public static string DBConnStr(string text)
    {
        return new Desencripta.GODesencripta().DesencriptaTexto(ENCRYPTER, ConfigurationManager.ConnectionStrings[text].ToString());
    }

    public static string GetSigoConnStr()
    {
        return DBConnStr("SIGO", false);
    }
    public static string GetSeguridadConnStr()
    {
        return DBConnStr("SEGURIDAD", false);
    }
    public static string GetOraConnStr()
    {
        return DBConnStr("GOCRDMAF", false);
    }

    public static string DBConnStr(string text, bool encrypt)
    {
        string connStr;
        if (encrypt)
            connStr = DBConnStr(text);
        else
            connStr = ConfigurationManager.ConnectionStrings[text].ToString();
        return connStr;
    }


    public static void checkSession()
    {
        if (HttpContext.Current.Session["SYS_CURRENTUSERID"] == null)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Redirect("~/default.aspx");
        }
    }
}


	
