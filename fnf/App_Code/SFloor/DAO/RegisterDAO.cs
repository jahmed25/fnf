using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SFloor.DAO.Generic;
using MFO.Commom;

/// <summary>
/// Summary description for RegisterDAO
/// </summary>
/// 
namespace SFloor.DAO
{
    public static class RegisterDAO
    {
        public static int register(IDictionary<String, String> colDic) 
        {
            int i = 0;
            string query = "select * from USER_REGISTER where EMAIL='" + colDic["@EMAIL"] + "'";
            DataTable dt = GenericDAO.getDataTable(query);
            if (!CommonUtil.DT.isEmptyOrNull(dt))
                throw new NotSupportedException("Email already registerd");
            else {
                query = "insert into USER_REGISTER (EMAIL, MOBILE,SESSION_ID,PASSWORD) values(@EMAIL, @MOBILE,@SESSION_ID,@PASSWORD)";
                i = GenericDAO.insertQuery(query, colDic);
            }
            return i;
        }
        public static DataTable getUser(string email) 
        {
            string query = "select * from USER_REGISTER where EMAIL=@EMAIL";
            Dictionary<string,string> param= new Dictionary<string,string>();
            param.Add("@EMAIL",email);
            return GenericDAO.getDataTableByParam(query, param);
        }


        public static void update(string name, string email, string mobile)
        {
            string query = "update USER_REGISTER  set EMAIL=@EMAIL, MOBILE=@MOBILE where EMAIL=@EMAIL_1";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@EMAIL", email);
            param.Add("@MOBILE", mobile);
            param.Add("@EMAIL_1", HttpContext.Current.Session[MFO.Constants.Constant.Session.LOGED_IN_EMAIL]+"");
            GenericDAO.updateQuery(query, param);
            query = "update  SHIPPING_MASTER set NAME=@NAME where EMAIL=@EMAIL_1";
            param = new Dictionary<string, string>();
            param.Add("@NAME", name);
            param.Add("@EMAIL_1", HttpContext.Current.Session[MFO.Constants.Constant.Session.LOGED_IN_EMAIL] + "");
            GenericDAO.updateQuery(query, param);
            HttpContext.Current.Session[MFO.Constants.Constant.Session.LOGED_IN_EMAIL] = email;
        }
    }
}