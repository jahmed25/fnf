using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SFloor.DAO.Generic;
using MFO.Commom;
using MFO.Loggers;

/// <summary>
/// Summary description for FavDAO
/// </summary>
/// 
namespace SFloor.DAO
{
    public static class FavDAO
    {
        public static int toggleFav(string sku, string sessionID, string userId)
        {
            int count = 0;
            Logger.Info("FavDAO  ########################  sku :" + sku + " sessionID : " + sessionID + " userID : " + userId);
            DataTable dt = GenericDAO.getDataTable("select * from FAV_LIST where SESSION_ID='" + sessionID + "' and sku='" + sku + "'");
            Logger.Info("FavDAO  ########################  dt :" + dt.Rows.Count);
            if (CommonUtil.DT.isEmptyOrNull(dt))
            {
                Logger.Info("FavDAO  ########################  inserting :");
                string query = "Insert into FAV_LIST (SKU,SESSION_ID,DATE,USER_ID) values('" + sku + "','" + sessionID + "',GETDATE(),'" + userId + "')";
                count = GenericDAO.insertQuery(query);
                Logger.Info("FavDAO  ########################  query :" + query);
                Logger.Info("FavDAO  ########################  count :" + count);
            }
            else
            {
                Logger.Info("FavDAO  ########################  removing :"+sku);
                int? count1 = removeFromWL(sessionID, sku);
                if (count1 != null)
                {
                    count = int.Parse(count1.ToString());
                }
                Logger.Info("FavDAO  ########################  removing :" + count1);
            }
            return count;
        }
        public static DataTable getFavDT(string sessionID)
        {
            DataTable dt = new DataTable();
            string query = "Select * from FAV_LIST where SESSION_ID='" + sessionID + "' order by DATE desc";
            dt = GenericDAO.getDataTable(query);
            return dt;
        }
        public static bool isItemExist(string sessionID, string sku)
        {
            DataTable dt = new DataTable();
            string query = "Select * from FAV_LIST where SESSION_ID='" + sessionID + "' and SKU='" + sku + "' order by DATE desc";
            dt = GenericDAO.getDataTable(query);
            if (dt == null || dt.Rows.Count == 0)
                return false;
            else
                return true;
        }


        public static void updateFavList(string userId, string sessionId)
        {
            IDictionary<string, string> colDic = new Dictionary<string, string>();
            colDic.Add("@SESSION_ID", sessionId);
            colDic.Add("@USER_ID", userId);
            string query = "update FAV_LIST set SESSION_ID=@SESSION_ID where USER_ID=@USER_ID";
            GenericDAO.updateQuery(query, colDic);
        }

        internal static void clearFav(string sessionId)
        {
            GenericDAO.updateQuery("delete FAV_LIST where SESSION_ID='" + sessionId + "'");

        }

        public static int? removeFromWL(string sessionId, string sku)
        {
            return GenericDAO.deleteQuery("delete FAV_LIST where SESSION_ID='" + sessionId + "' and sku='" + sku + "'");
        }
    }
}