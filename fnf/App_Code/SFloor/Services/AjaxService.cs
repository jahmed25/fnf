using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SFloor.DAO;
using System.Data;
using MFO.Common;
using MFO.Commom;
using MFO.Constants;
using MFO.Loggers;
using System.Collections;
using MFO.Utils;

/// <summary>
/// Summary description for AjaxService
/// </summary>
/// 

namespace SFloor.Services
{
    public static class AjaxService
    {
        public static int register(IDictionary<String, String> colDic)
        {
            return RegisterDAO.register(colDic);
        }
        public static DataTable getUser(string email)
        {
            return RegisterDAO.getUser(email);
        }
        public static int toggleFav(string sku, string sessionID, string userID)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Logger.Info("AjaxService ########################  sku :"+sku+" sessionID : "+sessionID+" userID : "+userID);
            int count = FavDAO.toggleFav(sku, sessionID, userID);
			 Logger.Info("AjaxService ########################  count :"+count);
            // DataTable dt = new DataTable(); GenericService.getVewImageNewMasterDT();
                //IEnumerable<DataRow> query =
                //from dr in dt.AsEnumerable() 
                //    where dr.Field<String>("SKUCode") == sku
                //select dr;
                //try{
                // dt = query.CopyToDataTable<DataRow>();
                //}catch(Exception e){Logger.Info("AjaxService ########################  exception :"+e);}
                //Logger.Info("AjaxService ########################  dt :"+dt.Rows.Count);
                //if(!CommonUtil.DT.isEmptyOrNull(dt)){
                //    dic.Add("brand",dt.Rows[0]["SKUBrand"]+"");
                //    dic.Add("sku",dt.Rows[0]["SKUCode"]+"");
                //    dic.Add("name",dt.Rows[0]["SKUName"]+"");
                //    dic.Add("mrp",dt.Rows[0]["MRP"]+"");
                //    dic.Add("price",dt.Rows[0]["SpecialPrice"]+"");
                //    dic.Add("image",dt.Rows[0]["PathInternaldetailsSmallImage"]+"");
                //}
             return count;

        }
        public static void clearCart(string sessionId)
        {
            CartDAO.clearCart(sessionId);
        }
        public static void clearFav(string sessionId)
        {
            FavDAO.clearFav(sessionId);
        }
        public static DataTable getProdBySKU(string sku) 
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
            from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCode") == sku
            select dr;
            try
            {
                dt = query.CopyToDataTable<DataRow>();
            }
            catch { }
            return dt; 
        }
        public static DataTable getVarientProd(string style,string size,string color)
        {
            style = style == null ? "" : style.Trim();
            size = size == null ? "" : size.Trim();
            color = color == null ? "" : color.Trim();
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
            from dr in dt.AsEnumerable()
            where style.Equals(dr["StyleCode"]+"".Trim())
                      && size.Equals(dr["Size"] + "".Trim()) 
            select dr;
            try
            {
                dt = query.CopyToDataTable<DataRow>();
            }
            catch { }
            return dt;
        }

        public static List<string> getPinDT(string like)
        {
            DataTable dt = new DataTable();
            List<string> pinList = new List<string>();
            if (HttpContext.Current.Application[Constant.Application.PIN_DT] != null&&false)
                dt = HttpContext.Current.Application[Constant.Application.PIN_DT] as DataTable;
            else
                dt = PinDAO.getPinDT();
               var v =(from DataRow dr in dt.Rows
                  where dr.Field<String>("PinCodeLocation_PinCode").StartsWith(like)
                  select (string)dr["PinCodeLocation_PinCode"]);
            try
            {

                pinList=v.ToList<string>();
            }
            catch { }
            return pinList;
        }

        public static Dictionary<string,string> getCityState(string pin)
        {
            DataTable dt = new DataTable();
            List<string> pinList = new List<string>();
            if (HttpContext.Current.Application[Constant.Application.PIN_DT] != null)
                dt = HttpContext.Current.Application[Constant.Application.PIN_DT] as DataTable;
            else
                dt = PinDAO.getPinDT();
            IEnumerable<DataRow> query = from DataRow dr in dt.Rows
                where dr.Field<String>("PinCodeLocation_PinCode").Equals(pin)
                select dr;
            dt=query.CopyToDataTable<DataRow>();
            Dictionary<string, string> dic = new Dictionary<string,string>();
            if(!CommonUtil.DT.isEmptyOrNull(dt))
            {
                dic.Add("city",dt.Rows[0]["PinCodeLocation_City"]+"");
                dic.Add("state",dt.Rows[0]["PinCodeLocation_State"]+"");
            }
            return dic;

        }

        public static List<string> getStateDT(string startWith)
        {
            DataTable dt = new DataTable();
            List<string> pinList = new List<string>();
            if (HttpContext.Current.Application[Constant.Application.PIN_DT] != null)
                dt = HttpContext.Current.Application[Constant.Application.PIN_DT] as DataTable;
            else
                dt = PinDAO.getPinDT();
            var v = (from DataRow dr in dt.Rows
                     where dr.Field<String>("PinCodeLocation_State").ToLower().StartsWith(startWith.ToLower())
                     select (string)dr["PinCodeLocation_State"]);
            try
            {

                pinList = v.ToList<string>().Distinct().ToList();
            }
            catch { }
            return pinList;
        }

        public static List<string> getCityDT(string startWith)
        {
            DataTable dt = new DataTable();
            List<string> pinList = new List<string>();
            if (HttpContext.Current.Application[Constant.Application.PIN_DT] != null)
                dt = HttpContext.Current.Application[Constant.Application.PIN_DT] as DataTable;
            else
                dt = PinDAO.getPinDT();
            var v = (from DataRow dr in dt.Rows
                     where dr.Field<String>("PinCodeLocation_City").ToLower().StartsWith(startWith.ToLower())
                     select (string)dr["PinCodeLocation_City"]);
            try
            {
                pinList = v.ToList<string>().Distinct().ToList();
            }
            catch { }
            return pinList;
        }

        public static bool addShipping(string email, string name, string phone, string pin, string city, string state,string  address, string sessionId, string userId)
        {
            return ShippingDAO.addOrUpdate(email, name, phone, pin, city, state, address,sessionId, userId);
        }

        public static string createOrder(string sessionID,string shippingEmail,string payMode,string userID)
        {
            DataTable carDT = HomeService.getCartDT(sessionID);
            string total = HomeService.getTotal();

            string shippingId = "";
            if (StringUtil.isNullOrEmpty(userID))
                shippingId = ShippingDAO.getShippinIDByEmail(shippingEmail);
            else
                shippingId = ShippingDAO.getShippinIDByUserID(userID);

            int orderID= OrderDAO.createOrder(total, payMode, shippingId);
            OrderDAO.createOrderStatus(orderID);
            OrderDAO.createOrderDetails(carDT,orderID.ToString());
            return orderID+"";
        }

      
        public static bool removeProdFromInventory(string p)
        {
            throw new NotImplementedException();
        }
        public static int getInventory(string sku)
        {
            return ProductDAO.getInventory(sku);
        }
        public static Dictionary<string, string> checkInventory(DataTable dt, string sessionId)
        {
            Dictionary<string, string> invDic = new Dictionary<string, string>();
            if (CommonUtil.DT.isEmptyOrNull(dt))
                dt = HomeService.getCartDT(sessionId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                int inventory = AjaxService.getInventory(dt.Rows[i]["SKU"] + "");
                if (inventory == 0)
                {
                    invDic.Add(dt.Rows[i]["SKU"] + "", "SOLD_OUT");
                }
                else if (inventory < Int32.Parse(dt.Rows[i]["QTY"] + ""))
                {
                    string msg = "Only " + inventory + " Item(s) are left in inventory!!";
                    invDic.Add(dt.Rows[i]["SKU"] + "", msg);

                }
            }
            return invDic;
        }

        public static void updateInventroy(string sessionId)
        {
            ProductDAO.updateInventory(HomeService.getCartDT(sessionId));
        }
        public static DataTable searchBrand(string like)
        {
            like = like.ToLower();
            //List<string> list= new List<string>();
            DataTable resultDT = new DataTable();
            DataTable dt = GenericService.getVewImageNewMasterDT(); ;
            var v = (from DataRow dr in dt.Rows
                     where dr.Field<String>("SKUBrand").ToLower().StartsWith(like)
                     select dr);
                     
            try{
                //list=v.ToList<string>();
                resultDT = v.Distinct(new DistictComparer("SKUBrand")).CopyToDataTable<DataRow>();
            }catch{
            }
            return resultDT;
        }
        public static DataTable searchCat(string like)
        {
            like = like.ToLower();
            //List<string> list= new List<string>();
            DataTable resultDT = new DataTable();
            DataTable dt = GenericService.getVewImageNewMasterDT(); ;
            var v = (from DataRow dr in dt.Rows
                     where dr.Field<String>("SKUCategory").ToLower().StartsWith(like)
                     select dr);
            try
            {
                //list=v.ToList<string>();
                resultDT = v.Distinct(new DistictComparer("SKUCategory")).CopyToDataTable<DataRow>();
            }
            catch
            {
            }
            return resultDT;
        }
        public static DataTable searchSubCat(string like)
        {
            like = like.ToLower();
            //List<string> list= new List<string>();
            DataTable resultDT = new DataTable();
            DataTable dt = GenericService.getVewImageNewMasterDT(); ;
            var v = (from DataRow dr in dt.Rows
                     where dr.Field<String>("SKUCategoryType").ToLower().StartsWith(like)
                     select dr);
            try
            {
                //list=v.ToList<string>();
                resultDT = v.Distinct(new DistictComparer("SKUCategoryType")).CopyToDataTable<DataRow>();
            }
            catch
            {
            }
            return resultDT;
        }
        public static DataTable searchName(string like)
        {
            like = like.ToLower();
            //List<string> list= new List<string>();
            DataTable resultDT = new DataTable();
            DataTable dt = GenericService.getVewImageNewMasterDT(); ;
            var v = (from DataRow dr in dt.Rows
                     where dr.Field<String>("SKUName").ToLower().StartsWith(like)
                     select dr);
            try
            {
                //list=v.ToList<string>();
                resultDT = v.Distinct(new DistictComparer("SKUName")).CopyToDataTable<DataRow>();
            }
            catch
            {
            }
            return resultDT;
        }
        public static DataTable searchPType(string like)
        {
            like = like.ToLower();
            //List<string> list= new List<string>();
            DataTable resultDT = new DataTable();
            DataTable dt = GenericService.getVewImageNewMasterDT(); ;
            var v = (from DataRow dr in dt.Rows
                     where dr.Field<String>("SKUProductType").ToLower().StartsWith(like)
                     select dr);
            try
            {
                //list=v.ToList<string>();
                resultDT = v.Distinct(new DistictComparer("SKUProductType")).CopyToDataTable<DataRow>();
            }
            catch
            {
            }
            return resultDT;
        }
    
        public static DataTable searchSKU(string like)
        {
            like = like.ToLower();
            //List<string> list= new List<string>();
            DataTable resultDT = new DataTable();
            DataTable dt = GenericService.getVewImageNewMasterDT(); ;
            var v = (from DataRow dr in dt.Rows
                     where dr.Field<String>("SKUCode").ToLower().StartsWith(like)
                     select dr);
            try
            {
                //list=v.ToList<string>();
                resultDT = v.CopyToDataTable<DataRow>();
            }
            catch
            {
            }
            return resultDT;
        }
    }
   
}