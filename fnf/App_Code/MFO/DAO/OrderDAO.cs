using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SFloor.DAO.Generic;
using MFO.Utils;

/// <summary>
/// Summary description for OrderDAO
/// </summary>
/// 

namespace SFloor.DAO
{
    public static class OrderDAO
    {
        public static int createOrder(string total,string payType,string shippingId)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            float shipinCharge= float.Parse(ConfigUtil.getValue("ShippigCharge"));
            float vat= float.Parse(ConfigUtil.getValue("VAT"));
            float amount = float.Parse(total);
            vat=(amount*vat/100);
            string orderNo = DateTime.Now.GetHashCode()+"";
            float totalAmount= amount+vat+shipinCharge;
            string query = "insert into ORDER_MASTER (ORDER_NO,CREATED_DATE,PAYMINT_METHOD,AMOUNT,SHIPPING_CHARGE,VAT,TOTAL_AMOUNT,SHIPPING_ID,DOCKET_NO) ";
            query += "values(@ORDER_NO,GETDATE(),@PAYMINT_METHOD,@AMOUNT,@SHIPPING_CHARGE,@VAT,@TOTAL_AMOUNT,@SHIPPING_ID,@DOCKET_NO)";
            dic.Add("@ORDER_NO", orderNo);
            dic.Add("@PAYMINT_METHOD", payType);
             dic.Add("@AMOUNT", total);
             dic.Add("@VAT", vat.ToString());
             dic.Add("@SHIPPING_CHARGE",shipinCharge.ToString());
             dic.Add("@TOTAL_AMOUNT", totalAmount.ToString());
             dic.Add("@SHIPPING_ID", shippingId);
             dic.Add("@DOCKET_NO", "");
             return GenericDAO.insertQuery(query, dic); 
        }
        public static int createOrderStatus(int orderId)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string query = "insert into ORDER_STATUS (ORDER_ID,STATUS,LAST_MODIFIED_DATE,MODIFIED_BY,DESCRIPTION) ";
            query += "values(@ORDER_ID,@STATUS,GETDATE(),@MODIFIED_BY,@DESCRIPTION)";
            dic.Add("@ORDER_ID", orderId+"");
            dic.Add("@STATUS", "SUBMITED_BY_CUSTOMER");
            dic.Add("@MODIFIED_BY", "CUSTOMER");
            dic.Add("@DESCRIPTION","Customer placed the order");
            return GenericDAO.insertQuery(query, dic);
        }

        public static void createOrderDetails(DataTable carDT,string orderID)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow row in carDT.Rows)
            {
                string query = "insert into ORDER_DETAILS (SKU,PRODUCT_NAME,UNIT_PRICE,QTY,TOTAL,ORDER_ID) ";
                query += "values(@SKU,@PRODUCT_NAME,@UNIT_PRICE,@QTY,@TOTAL,@ORDER_ID)";
                dic.Add("@SKU", row["SKU"] + "");
                dic.Add("@PRODUCT_NAME", row["SKUName"] + "");
                dic.Add("@UNIT_PRICE", row["UNIT_PRICE"] + "");
                dic.Add("@QTY", row["QTY"] + "");
                dic.Add("@TOTAL", row["TOTAL"] + "");
                dic.Add("@ORDER_ID", orderID);
                GenericDAO.insertQuery(query, dic);
                dic.Clear();                                   
            }
        }

        public static DataTable getOrder(string orderId)
        {
            DataTable dt = null;
            string query = "SELECT * FROM ORDER_MASTER where ID="+orderId;
            dt = GenericDAO.getDataTable(query);
            return dt;
        }
        public static DataTable getOrderByEmail(string email)
        {
            DataTable dt = null;
            string query = @"SELECT     ORDER_MASTER.*, SHIPPING_MASTER.*
                                FROM         ORDER_MASTER  INNER JOIN
                                SHIPPING_MASTER  ON SHIPPING_MASTER.ID = ORDER_MASTER.SHIPPING_ID
                                where SHIPPING_MASTER.email='" + email+"'";
            dt = GenericDAO.getDataTable(query);
            return dt;
        }

        public static DataTable getOrderDetails(string orderId)
        {
            DataTable dt = null;
            string query = "SELECT v.Color,v.Size,v.SizeDataType, v.SKUBrand, v.PathInternaldetailsSmallImage,v.SKUName,v.SKUBrand,QTY,TOTAL,UNIT_PRICE,SKU";
            query += " FROM ORDER_DETAILS c join PRODUCTS v on  c.SKU=v.SKUCode  where c.ORDER_ID='" + orderId + "'";
            dt = GenericDAO.getDataTable(query);
            return dt;
        }
        public static DataTable getOrderStatus(string orderId)
        {
            DataTable dt = null;
            string query = "SELECT *  ";
            query += " FROM ORDER_STATUS where ORDER_ID='" + orderId + "'";
            dt = GenericDAO.getDataTable(query);
            return dt;
        }


        public static void updateStatus(string orderid)
        {
            string query = "update ";
            query += " ORDER_STATUS set status='CENCELED_BY_CUSTOMER' where ORDER_ID='" + orderid + "'";
            GenericDAO.updateQuery(query);
            
        }
    }
}