using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;


/// <summary>
/// Summary description for Gobal_Connection
/// </summary>
public class Gobal_Connection
{
	public Gobal_Connection()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public SqlConnection cn = GlobalConnectionForWebApi();

    private static SqlConnection GlobalConnectionForWebApi()
    {

        try
        {
            // if (CErealCMSBk.State.ToString() == "Closed")
            // {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CMSDBConnectionString"].ConnectionString;
            return new SqlConnection(strcon);
            // }
            // return CErealCMSBk;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }

    }



}