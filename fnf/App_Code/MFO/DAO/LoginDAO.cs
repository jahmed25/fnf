using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;
using MFO.Common;

/// <summary>
/// Summary description for userlogin
/// </summary>
/// 
namespace MFO.DAO
{
    public class LoginDAO
    {
        public DataTable getuserlogin(string emailid, string passwd)
        {
            //Dictionary<string, string> paramDic = new Dictionary<string, string>();
            //paramDic.Add("@EmailID", emailid);
            //paramDic.Add("@Password", passwd);
            return GenericDAO.getDataTable("select * from UserRegistration where EmailId='"+emailid+"' and Password='"+passwd+"'");
        }

        public DataTable Chkpassword(string password, string emialid)
        {
            return GenericDAO.getDataTable("select * from View_UserRegistration where Password='" + password + "' and EmailId='" + emialid + "'");
        }

        public DataTable ChkEmail(string emialid)
        {
            return GenericDAO.getDataTable("select * from View_UserRegistration where EmailId='" + emialid + "'");
        }
    }

}