using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SFloor.DAO.Generic;
using MFO.Commom;
using System.Collections;

/// <summary>
/// Summary description for CartDAO
/// </summary>
/// 
namespace SFloor.DAO
{
    public static class CartDAO
    {
        public static int addToCart(string sessionId, string qty, string price, string total, string sku, string userID)
        {
            IDictionary<string, string> colDic = new Dictionary<string, string>();
            int i = 0;
            colDic.Add("@SKU", sku);
            colDic.Add("@QTY", qty);
            colDic.Add("@UNIT_PRICE", price);
            colDic.Add("@SESSION_ID", sessionId);
            colDic.Add("@TOTAL", total);
            colDic.Add("@USER_ID", userID);
            string query = "insert into CART (SKU, QTY,UNIT_PRICE,SESSION_ID,TOTAL,USER_ID) values(@SKU, @QTY,@UNIT_PRICE,@SESSION_ID,@TOTAL,@USER_ID)";
                i = GenericDAO.insertQuery(query, colDic);
            return i;
        }

        
        public static void updateCart(string userId, string sessionId)
        {
            IDictionary<string, string> colDic = new Dictionary<string, string>();
            colDic.Add("@SESSION_ID", sessionId);
            colDic.Add("@USER_ID", userId);
            string query = "update CART set SESSION_ID=@SESSION_ID where USER_ID=@USER_ID";
            GenericDAO.updateQuery(query, colDic);
        }
        public static void updateQuantity(string qty, string sessionId,string sku,string total)
        {
            IDictionary<string, string> colDic = new Dictionary<string, string>();
            colDic.Add("@SESSION_ID", sessionId);
            colDic.Add("@QTY", qty);
            colDic.Add("@TOTAL", total);
            colDic.Add("@SKU", sku);
            string query = "update CART set QTY=@QTY,TOTAL=@TOTAL where SESSION_ID=@SESSION_ID and SKU=@SKU";
            GenericDAO.updateQuery(query, colDic);
        }
        public static DataTable getCartDT(string sessionId)
        {
            DataTable dt = null;
            string query = "SELECT v.ShippingReturns,v.Color,v.Size,v.SizeDataType, v.Inventory, v.PathInternaldetailsSmallImage,v.SKUName,v.SKUBrand,ID,SKU,SESSION_ID,QTY,TOTAL,UNIT_PRICE,USER_ID,DATE";
            query += " FROM CART c join PRODUCTS v on  c.SKU=v.SKUCode  where c.SESSION_ID='"+sessionId+"' order by c.DATE DESC";
            dt = GenericDAO.getDataTable(query);
            return dt;
        }


        internal static void clearCart(string sessionId)
        {
            GenericDAO.updateQuery("delete CART where SESSION_ID='"+sessionId+"'");
        }

        public static DataTable getCartDT(string sessionId, string sku)
        {
            DataTable dt = null;
            string query = "SELECT v.ShippingReturns,v.Color,v.Size, v.Inventory, v.PathInternaldetailsSmallImage,v.SKUName,v.SKUBrand,ID,SKU,SESSION_ID,QTY,TOTAL,UNIT_PRICE,USER_ID,DATE";
            query += " FROM CART c join PRODUCTS v on  c.SKU=v.SKUCode  where c.SESSION_ID='" + sessionId + "' and sku ='"+sku+"' order by c.DATE DESC";
            dt = GenericDAO.getDataTable(query);
            return dt;
        }

        public static void removeFromCart(string  sessionId, string sku)
        {
            GenericDAO.deleteQuery("delete CART where SESSION_ID='" + sessionId + "' and sku='" + sku + "'");
        }
    }
}