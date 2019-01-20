using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EL_CMS
/// </summary>
public class EL_CMS
{
    public EL_CMS()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public  class EL_Schedule {

        private string _CID = "";

        public string CID
        {
            get { return _CID; }
            set { _CID = value; }
        }


        private string _UID = "";

        public string UID
        {
            get { return _UID; }
            set { _UID = value; }
        }


        private string _Username = "";

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }


        private string _Countryname = "";

        public string Countryname
        {
            get { return _Countryname; }
            set { _Countryname = value; }
        }


        private string _CountryZone = "";

        public string CountryZone
        {
            get { return _CountryZone; }
            set { _CountryZone = value; }
        }


        private string _CountainerID = "";

        public string CountainerID
        {
            get { return _CountainerID; }
            set { _CountainerID = value; }
        }

        private string _ArrivalDate = "";

        public string ArrivalDate
        {
            get { return _ArrivalDate; }
            set { _ArrivalDate = value; }
        }


    }

    public class EL_UserDetails {

        private string _Username = "";

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }



        private string _Emailadd = "";

        public string Emailadd
        {
            get { return _Emailadd; }
            set { _Emailadd = value; }
        }


        private string _Password = "";

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Address = "";

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }


        private string _contactno = "";

        public string contactno
        {
            get { return _contactno; }
            set { _contactno = value; }
        }


    }
}