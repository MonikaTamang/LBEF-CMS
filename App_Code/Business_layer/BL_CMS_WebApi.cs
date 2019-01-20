using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for BL_CMS_WebApi
/// </summary>
public class BL_CMS_WebApi
{
    Gobal_Connection gc = new Gobal_Connection();

    public BL_CMS_WebApi()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    private DataTable BL_View_Schedule()
    {


        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "View_Schedule_SP";
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        if (dr.HasRows)
        {

            dt.Load(dr);
        }

        dr.Close();
        cmd.Connection.Close();

        return dt;
    }

    public string BL_JSON_View_Schedule()
    {
        DataTable PNCL_Dt = this.BL_View_Schedule();
        return ConvertDataTabletoString(PNCL_Dt);

    }

    private DataTable BL_View_AviableContainer(EL_CMS.EL_Schedule ES)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "View_Container_Information_SP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@containerId", ES.CID);
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        if (dr.HasRows)
        {

            dt.Load(dr);
        }

        dr.Close();
        cmd.Connection.Close();

        return dt;
    }

    public string BL_JSON_View_AviableContainer(EL_CMS.EL_Schedule ES)
    {
        DataTable PNCL_Dt = this.BL_View_AviableContainer(ES);
        return ConvertDataTabletoString(PNCL_Dt);

    }


    private string BL_Add_Available_BookingContainer(EL_CMS.EL_Schedule ES)
    {
        string rtnmsg = "";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "Add_Container_SP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@uid", ES.UID);
        cmd.Parameters.AddWithValue("@username", ES.Username);
        cmd.Parameters.AddWithValue("@countryname", ES.Countryname);
        cmd.Parameters.AddWithValue("@countryzone", ES.CountryZone);
        cmd.Parameters.AddWithValue("@containerID", ES.CountainerID);
        cmd.Parameters.AddWithValue("@requestDate", ES.ArrivalDate);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {

            rtnmsg = dr["rtnMsg"].ToString();

        }
        dr.Close();
        cmd.Connection.Close();

        return rtnmsg;
    }

    public string BL_JSON_Add_Available_BookingContainer(EL_CMS.EL_Schedule ES)
    {

        string PNCL_Dt = this.BL_Add_Available_BookingContainer(ES);
        return PNCL_Dt;

    }


    private string Cancel_Available_BookingContainer(EL_CMS.EL_Schedule ES)
    {
        string rtnmsg = "";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "Cancel_Available_BookingContainer_SP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@containerName", ES.CountainerID);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {

            rtnmsg = dr["rtnMsg"].ToString();

        }
        dr.Close();
        cmd.Connection.Close();

        return rtnmsg;
    }

    public string BL_JSON_Cancel_Available_BookingContainer(EL_CMS.EL_Schedule ES)
    {

        string PNCL_Dt = this.Cancel_Available_BookingContainer(ES);
        return PNCL_Dt;

    }



    private DataTable BL_View_BookingContainer_By_UID(EL_CMS.EL_Schedule ES)
    {


        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "View_BookingContainer_By_UID_SP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@uid", ES.UID);
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        if (dr.HasRows)
        {

            dt.Load(dr);
        }

        dr.Close();
        cmd.Connection.Close();

        return dt;
    }

    public string BL_JSON_View_BookingContainer_By_UID(EL_CMS.EL_Schedule ES)
    {
        DataTable PNCL_Dt = this.BL_View_BookingContainer_By_UID(ES);
        return ConvertDataTabletoString(PNCL_Dt);

    }



    private DataTable BL_View_ALL_BookingContainer()
    {


        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "View_ALL_BookingContainer_SP";
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        if (dr.HasRows)
        {

            dt.Load(dr);
        }

        dr.Close();
        cmd.Connection.Close();

        return dt;
    }

    public string BL_JSON_View_ALL_BookingContainer()
    {
        DataTable PNCL_Dt = this.BL_View_ALL_BookingContainer();
        return ConvertDataTabletoString(PNCL_Dt);

    }


    private string BL_Update_Booking_Conatiner_Status_Admin(EL_CMS.EL_Schedule ES)
    {
        string rtnmsg = "";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "Update_Booking_Conatiner_Status_Admin_SP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@containerName", ES.CountainerID);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {

            rtnmsg = dr["rtnMsg"].ToString();

        }
        dr.Close();
        cmd.Connection.Close();

        return rtnmsg;
    }

    public string BL_JSON_Update_Booking_Conatiner_Status_Admin(EL_CMS.EL_Schedule ES)
    {

        string PNCL_Dt = this.BL_Update_Booking_Conatiner_Status_Admin(ES);
        return PNCL_Dt;

    }



    private string BL_Update_Booking_Conatiner_Status_Client(EL_CMS.EL_Schedule ES)
    {
        string rtnmsg = "";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "Update_Booking_Conatiner_Status_Client_SP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@containername",ES.CountainerID);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {

            rtnmsg = dr["rtnMsg"].ToString();

        }
        dr.Close();
        cmd.Connection.Close();

        return rtnmsg;
    }

    public string BL_JSON_Update_Booking_Conatiner_Status_Client(EL_CMS.EL_Schedule ES)
    {

        string PNCL_Dt = this.BL_Update_Booking_Conatiner_Status_Client(ES);
        return PNCL_Dt;

    }


    private string BL_Register_Client_Details(EL_CMS.EL_UserDetails ES)
    {
        string rtnmsg = "";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "Registration_User_Details_SP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@name", ES.Username);
        cmd.Parameters.AddWithValue("@password", ES.Password);
        cmd.Parameters.AddWithValue("@address", ES.Address);
        cmd.Parameters.AddWithValue("@email", ES.Emailadd);
        cmd.Parameters.AddWithValue("@contact", ES.contactno);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {

            rtnmsg = dr["rtnMsg"].ToString();

        }
        dr.Close();
        cmd.Connection.Close();

        return rtnmsg;
    }

    public string BL_JSON_Register_Client_Details(EL_CMS.EL_UserDetails ES)
    {

        string PNCL_Dt = this.BL_Register_Client_Details(ES);
        return PNCL_Dt;

    }



    private string BL_CMSLoginCheck(EL_CMS.EL_UserDetails EEO)
    {

        string rtnString = "0";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "checkUseLoginValid";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@emailId", EEO.Username);
        cmd.Parameters.AddWithValue("@passcode", EEO.Password);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                rtnString = dr.GetString(0);

            }
        }


        dr.Close();
        cmd.Connection.Close();

        return rtnString;

    }

    public string BL_JSON_CMSLoginCheck(EL_CMS.EL_UserDetails EEO)
    {

        string PNCL_Dt = this.BL_CMSLoginCheck(EEO);
        return PNCL_Dt;
    }

    private string BL_GetUsrNmeRole(EL_CMS.EL_UserDetails EEO)
    {

        string rtnString = "0";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.CommandText = "getUsrNmeDesgByEMailPasscode";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@emailId", EEO.Username.Trim());
        cmd.Parameters.AddWithValue("@passcode", EEO.Password.Trim());
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                rtnString = dr["rtnMsg"].ToString();

            }
        }


        dr.Close();
        cmd.Connection.Close();

        return rtnString;

    }

    public string BL_JSON_GetUsrNmeRole(EL_CMS.EL_UserDetails EEO)
    {

        string PNCL_Dt = this.BL_GetUsrNmeRole(EEO);
        return PNCL_Dt;
    }




    private static string ConvertDataTabletoString(DataTable dt)
    {

        JavaScriptSerializer serializer = new JavaScriptSerializer();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

        Dictionary<string, object> row;

        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }

}