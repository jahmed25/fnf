using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SFloor.DAO.Generic;
using System.Data;
using MFO.Commom;
using MFO.Utils;

/// <summary>
/// Summary description for ShippingDAO
/// </summary>
/// 
namespace SFloor.DAO
{
    public static class ShippingDAO
    {

        public static bool addOrUpdate(string email, string name, string phone, string pin, string city, string state,string address,string sessionId, string userId)
        {
            DataTable dt;
            if(!StringUtil.isNullOrEmpty(userId))
                dt=GenericDAO.getDataTable("Select ID from SHIPPING_MASTER where USER_ID='" + userId + "'");
            else
                dt=GenericDAO.getDataTable("Select ID from SHIPPING_MASTER where EMAIL_ID='" + email + "'");
            string query="";
            IDictionary<string, string> colDic = new Dictionary<string, string>();
            colDic.Add("@SESSION_ID", sessionId);
            colDic.Add("@USER_ID", userId);
            colDic.Add("@MOBILE", phone);
            colDic.Add("@PIN", pin);
            colDic.Add("@CITY", city);
            colDic.Add("@STATE", state);
            colDic.Add("@EMAIL", email);
            colDic.Add("@NAME", name);
            colDic.Add("@ADDRESS", address);
            if (CommonUtil.DT.isEmptyOrNull(dt))
            {
                query = "insert into SHIPPING_MASTER (SESSION_ID, USER_ID,MOBILE,PIN,CITY,STATE,EMAIL,NAME,ADDRESS) values(@SESSION_ID, @USER_ID,@MOBILE,@PIN,@CITY,@STATE,@EMAIL,@NAME,@ADDRESS)";
                return GenericDAO.insertQuery(query, colDic) > 0 ? true : false;
            }
            else
            {
                query = "Update SHIPPING_MASTER set SESSION_ID= @SESSION_ID, USER_ID=@USER_ID,MOBILE=@MOBILE,PIN=@PIN,CITY=@CITY,STATE=@STATE,EMAIL=@EMAIL,NAME=@NAME,ADDRESS=@ADDRESS where user_id='" + userId + "'";
                return GenericDAO.updateQuery(query, colDic) > 0 ? true : false;
            }
        }
        public static string  getShippinIDByEmail(string email)
        {
            DataTable dt = GenericDAO.getDataTable("Select ID from SHIPPING_MASTER where EMAIL='" + email + "'");
            return dt.Rows[0]["ID"] + "";
        }

        public static string getShippinIDByUserID(string userID)
        {
            DataTable dt = GenericDAO.getDataTable("Select ID from SHIPPING_MASTER where USER_ID='" + userID + "'");
            return dt.Rows[0]["ID"] +"";
        }

        public static DataTable getShippinByUserID(string userID)
        {
            return GenericDAO.getDataTable("Select * from SHIPPING_MASTER where USER_ID='" + userID + "'");
            
        }
        public static DataTable getShippinByEmailID(string userID)
        {
            return GenericDAO.getDataTable("Select * from SHIPPING_MASTER where EMAIL='" + userID + "'");

        }
        public static DataTable getShipping(string id)
        {
           return
               GenericDAO.getDataTable("Select * from SHIPPING_MASTER where ID='" + id + "'");
        }
    }
}