using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for CMS
/// </summary>
[WebService(Namespace = "http://sujanmaharjan.info.np/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CMS : System.Web.Services.WebService
{
    BL_CMS_WebApi bl = new BL_CMS_WebApi();

    public CMS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    protected string getRequestStreamData()
    {

        StreamReader stream = new StreamReader(this.Context.Request.InputStream);
        string x = stream.ReadToEnd();
        string xml = HttpUtility.UrlDecode(x);

        return xml;
    }

    [WebMethod]
    public string View_Schedule_Information()
    {
        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);
               
        return bl.BL_JSON_View_Schedule();
    }


    [WebMethod]
    public string View_AviableContainer_CounZone()
    {

        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);

        EL_CMS.EL_Schedule ES = new EL_CMS.EL_Schedule();


        ES.CID = obj["s_CUID"];


        return bl.BL_JSON_View_AviableContainer(ES);
    }


    [WebMethod]
    public string Add_Available_BookingContainer()
    {

        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);

        EL_CMS.EL_Schedule ES = new EL_CMS.EL_Schedule();

        ES.UID = obj["uid"];
        ES.Username = obj["username"];
        ES.Countryname = obj["countryname"];
        ES.CountryZone = obj["countryzone"];
        ES.CountainerID = obj["containerID"];
        ES.ArrivalDate = obj["requestDate"];



        return bl.BL_JSON_Add_Available_BookingContainer(ES);
    }



    [WebMethod]
    public string Cancel_Available_BookingContainer()
    {

        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);

        EL_CMS.EL_Schedule ES = new EL_CMS.EL_Schedule();

        ES.CountainerID = obj["containerName"];
       

        return bl.BL_JSON_Cancel_Available_BookingContainer(ES);
    }


    [WebMethod]
    public string View_BookingContainer_By_UID()
    {

        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);

        EL_CMS.EL_Schedule ES = new EL_CMS.EL_Schedule();

        ES.UID = obj["uid"];
       
        return bl.BL_JSON_View_BookingContainer_By_UID(ES);
    }



    [WebMethod]
    public string View_ALL_BookingContainer()
    {

        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);

      

        return bl.BL_JSON_View_ALL_BookingContainer();
    }



    [WebMethod]
    public string Update_Booking_Conatiner_Status_Admin()
    {

        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);

        EL_CMS.EL_Schedule ES = new EL_CMS.EL_Schedule();

        ES.CountainerID = obj["ContainerName"];

        return bl.BL_JSON_Update_Booking_Conatiner_Status_Admin(ES);
    }



    [WebMethod]
    public string Update_Booking_Conatiner_Status_Client()
    {

        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);

        EL_CMS.EL_Schedule ES = new EL_CMS.EL_Schedule();

        ES.CountainerID = obj["containerName"];

        return bl.BL_JSON_Update_Booking_Conatiner_Status_Client(ES);
    }


    [WebMethod]
    public string Register_Client_Details()
    {
     
        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);

        EL_CMS.EL_UserDetails ES = new EL_CMS.EL_UserDetails();

        ES.Username = obj["username"];
        ES.Emailadd = obj["emailAdd"];
        ES.Password = obj["newpass"];
        ES.Address = obj["address"];
        ES.contactno = obj["contacNum"];

        return bl.BL_JSON_Register_Client_Details(ES);
    }



    [WebMethod]
    public string CMSLoginCheck()
    {
        string chkvalidusr = "";

        string G_xml = getRequestStreamData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var obj = js.Deserialize<Dictionary<string, string>>(G_xml);

        EL_CMS.EL_UserDetails EEO = new EL_CMS.EL_UserDetails();


        EEO.Username = obj["uname"];
        EEO.Password = obj["pass"];


        chkvalidusr = bl.BL_JSON_CMSLoginCheck(EEO);

       

        if (chkvalidusr.Trim() == "1")
        {

            chkvalidusr = bl.BL_JSON_GetUsrNmeRole(EEO);
        }

        return chkvalidusr;
    }


}
