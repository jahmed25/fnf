using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MFO.Common;
using MFO.Loggers;

namespace MFO.DAO
{
    public class RecentViewDAO
    {
        public static int addRecentViewItems(int? pId, string userId, string ip, DateTime dateTime)
        {
            Logger.Info("adding Recent View Items");
            DataTable dt = GenericDAO.getDataTable("select *  from VISIT_RECENT_ITEMS where PRODUCT_ID ='" + pId + "' and (USER_ID='" + userId + "'or IP='" + ip + "')");

            if (null == dt || dt.Rows.Count == 0)
            {
                if (null == userId || "".Equals(userId.Trim()))
                    return GenericDAO.insertQuery("insert into VISIT_RECENT_ITEMS(IP,PRODUCT_ID,DATE) values('" + ip + "','" + pId + "',getDate())");
                else
                    return GenericDAO.insertQuery("insert into VISIT_RECENT_ITEMS(USER_ID,IP,PRODUCT_ID,DATE) values('" + userId + "','" + ip + "','" + pId + "',getDate())");
            }
            return 0;
        }

        public static System.Data.DataTable getRecentItemsByUserId(string userId, String ip)
        {
            DataTable dt = GenericDAO.getDataTable("select top(10) PRODUCT_ID , RECENT_ITEMS_ID, DATE from VISIT_RECENT_ITEMS where USER_ID ='" + userId + "' or IP ='" + ip + "' ORDER BY DATE DESC");
            return getProducts(dt);
        }


        private static DataTable getProducts(DataTable dt)
        {
            String pIds = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pIds += "" + dt.Rows[i]["PRODUCT_ID"] + ",";

                }

            }
            if (!"".Equals(pIds.Trim()))
            {
                pIds = pIds.Substring(0, pIds.Length - 1);
                return GenericDAO.getDataTable("select * from PRODUCTS where ProductNewID in(" + pIds + ") ");
            }
            return null;
        }
    }
}