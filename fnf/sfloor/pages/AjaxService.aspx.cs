using System;
using MFO.Utils;
using System.Collections;
using System.Collections.Generic;
using MFO.Commom;
using SFloor.Services;
using MFO.Constants;
using System.Data;
using System.Web.Script.Serialization;
using SFloor.DTO;
using MFO.DAO;
using SFloor.DAO.Generic;
using MFO.services;
using SFloor.DAO;
using MFO.Loggers;
using System.Dynamic;

public partial class sfloor_pages_AjaxService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String action = Request.Params["action"];
        switch (action)
        {
            case "login": login(); break;
            case "register": register(); break;
            case "checkEmail": checkMail(); break;
            case "checkRegEmail": checkRegMail(); break;
            case "logout": logout(); break;
            case "toggleFav": toggleFav(); break;
            case "addToCart": addToCart(); break;
            case "clearCart": clearCart(); break;
            case "clearFav": clearFav(); break;
            case "updateQty": updateQty(); break;
            case "removeFromCart": removeFromCart(); break;
            case "removeFromWL": removeFromWL(); break;
            case "checkInventory": checkInventory(); break;
            case "getPin": getPin(); break;
            case "getCityState": getCityState(); break;
            case "getState": getState(); break;
            case "getCity": getCity(); break;
            case "addShipping": addShipping(); break;
            case "doPaymint": doPaymint(); break;
            case "search": search(); break;
            case "forgetPassword": forgetPassword(); break;
            case "purchiSubmit": purchiSubmit(); break;
            case "cancelStatus": cancelStatus(); break;

                
        }
    }

    private void cancelStatus()
    {
        string orderid = Request.Params["order_id"];
        OrderDAO.updateStatus(orderid);
        sendResponse("success");
    }

    private void purchiSubmit()
    {
        dynamic purchiObj = new ExpandoObject();
        purchiObj.name = Request.Params["parchiName"];
        purchiObj.address = Request.Params["parchiAddress"];
        purchiObj.text = Request.Params["parchiText"];
        purchiObj.phone = Request.Params["purchiPhone"];
        Dictionary<String, String> responseDic =EmailTemplateService.sendPurchiOrderPlacedEmail(purchiObj);
        sendResponse(responseDic);

    }
    private void forgetPassword()
    {
        Dictionary<String, String> responseDic = new Dictionary<String, String>();
        try {
           responseDic= EmailTemplateService.sendForgetPasswordEmail(Request.Params["email"]);
        }
        catch (Exception e)
        {
            responseDic.Add("error", "Oops Internal Server Error </br> Please Try After Sometimes." + e);
        }
        sendResponse(responseDic);
    }

    private void search()
    {
        string serchKey = Request.Params["searchKey"];
        List<SearchDTO> searchList = new List<SearchDTO>();
        DataTable dt = AjaxService.searchName(serchKey);
        if (!CommonUtil.DT.isEmptyOrNull(dt))
        {
            for (int i = 0; i <= 10 && i < dt.Rows.Count; i++)
            {
                SearchDTO sDTO = new SearchDTO();
                sDTO.Name = dt.Rows[i]["SKUName"] + "";
                sDTO.SearchVal = dt.Rows[i]["SKUCode"] + "";
                sDTO.Src = dt.Rows[i]["PathInternaldetailsSmallImage"] + "";
                sDTO.Type = "product";
                searchList.Add(sDTO);
            }
        }
         dt = AjaxService.searchBrand(serchKey);
        if (!CommonUtil.DT.isEmptyOrNull(dt))
        {
            for (int i = 0; i <= 20 && i < dt.Rows.Count; i++)
            {
                SearchDTO sDTO = new SearchDTO();
                sDTO.Name = dt.Rows[i]["SKUBrand"] + "";
                sDTO.SearchVal = dt.Rows[i]["SKUBrand"] + "";
             //   sDTO.Src = dt.Rows[i]["PathInternaldetailsSmallImage"] + "";
                sDTO.Type = "brand";
                searchList.Add(sDTO);
            }
        }
        dt = AjaxService.searchSubCat(serchKey);
        if (!CommonUtil.DT.isEmptyOrNull(dt))
        {
            for (int i = 0; i <= 10 && i < dt.Rows.Count; i++)
            {
                SearchDTO sDTO = new SearchDTO();
                sDTO.Name = dt.Rows[i]["CategoryTypeUrlName"] + "";
                sDTO.SearchVal = dt.Rows[i]["CategoryTypeID"] + "";
               // sDTO.Src = dt.Rows[i]["PathInternaldetailsSmallImage"] + "";
                sDTO.Type = "category";
                searchList.Add(sDTO);
            }
        }
        dt = AjaxService.searchSKU(serchKey);
        if (!CommonUtil.DT.isEmptyOrNull(dt))
        {
            for (int i = 0; i <= 10 && i < dt.Rows.Count; i++)
            {
                SearchDTO sDTO = new SearchDTO();
                sDTO.Name = dt.Rows[i]["SKUCode"] + "";
                sDTO.SearchVal = dt.Rows[i]["SKUCode"] + "";
                // sDTO.Src = dt.Rows[i]["PathInternaldetailsSmallImage"] + "";
                sDTO.Type = "sku";
                searchList.Add(sDTO);
            }
        }
        dt = AjaxService.searchPType(serchKey);
        if (!CommonUtil.DT.isEmptyOrNull(dt))
        {
            for (int i = 0; i <= 10 && i < dt.Rows.Count; i++)
            {
                SearchDTO sDTO = new SearchDTO();
                sDTO.Name = dt.Rows[i]["SKUProductType"] + "";
                sDTO.SearchVal = dt.Rows[i]["ProductTypeID"] + "";
                //sDTO.Src = dt.Rows[i]["PathInternaldetailsSmallImage"] + "";
                sDTO.Type = "subcategory";
                searchList.Add(sDTO);
            }
        }
        sendResponse(searchList);
    }

    private void doPaymint()
    {
        Dictionary<string, string> inventDic = AjaxService.checkInventory(null, Session.SessionID);
        if (inventDic.Count == 0)
        {
            String payMode = "COD";// this is hard code need to be change when paymint gatway will intigrate
            string orderId = AjaxService.createOrder(Session.SessionID, Session[Constant.Session.SHIPING_EMAIL] + "", payMode, Session[Constant.Session.LOGED_IN_USER_ID] + "");
            Session[Constant.Session.CURRENT_ORDER] = orderId;
            AjaxService.updateInventroy(Session.SessionID);
            AjaxService.clearCart(Session.SessionID);
            Session.Remove(Constant.Session.CART_ITEMS);
            Session.Remove(Constant.Session.TOTAL);
            EmailTemplateService.sendOrderPlacedEmail();
            Response.Redirect(ConfigUtil.hostURL() + "order-summary");

        }
        else
        {
            Response.Redirect(ConfigUtil.hostURL() + "check-out");
        }
    }

    private void addShipping()
    {
        string email = Request.Params["email"];
        string name = Request.Params["fname"];
        string phone = Request.Params["phone"];
        string pin = Request.Params["pin"];
        string city = Request.Params["city"];
        string state = Request.Params["state"];
        string address = Request.Params["address"];
        string sessionId = Session.SessionID;
        string userId = Session[Constant.Session.LOGED_IN_USER_ID] != null ? Session[Constant.Session.LOGED_IN_USER_ID] + "" : "";
        bool status = AjaxService.addShipping(email, name, phone, pin, city, state, address, sessionId, userId);
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("status", status.ToString());
        Session[Constant.Session.SHIPING_EMAIL] = email;
        sendResponse(dic);

    }

    private void getCity()
    {
        string startWith = Request.Params["startWith"];
        List<string> cityList = AjaxService.getCityDT(startWith);
        if (cityList.Count >= 10)
            cityList = cityList.GetRange(0, 10);
        sendResponse(cityList);
    }

    private void getState()
    {
        string startWith = Request.Params["startWith"];
        List<string> stareList = AjaxService.getStateDT(startWith);
        if (stareList.Count >= 10)
            stareList = stareList.GetRange(0, 10);
        sendResponse(stareList);
    }

    private void getCityState()
    {
        sendResponse(AjaxService.getCityState(Request.Params["pin"]));
    }
    private void getPin()
    {
        string pinStartWith = Request.Params["startWith"];
        List<string> pinList = AjaxService.getPinDT(pinStartWith);
        if (pinList.Count >= 10)
            pinList = pinList.GetRange(0, 10);
        sendResponse(pinList);
    }
    private void removeFromCart()
    {
        CartDAO.removeFromCart(Session.SessionID, Request.Params["sku"]);
        Session.Remove(Constant.Session.CART_ITEMS);
        Session.Remove(Constant.Session.TOTAL);
        Server.Transfer("ReloadCart.aspx");
        //Dictionary<string, string> dic = new Dictionary<string, string>();
        //dic.Add("success", "success");
        //sendResponse(dic);
    }
    private void removeFromWL()
    {
        FavDAO.removeFromWL(Session.SessionID, Request.Params["sku"]);
        Session.Remove(Constant.Session.FAV_LIST);
        Server.Transfer("ReloadWL.aspx");
        //Dictionary<string, string> dic = new Dictionary<string, string>();
        //dic.Add("success", "success");
        //sendResponse(dic);
    }
    private void updateQty()
    {
        string sku = Request.Params["sku"];
        string qty = Request.Params["qty"];
        Dictionary<string, string> dic = new Dictionary<string, string>();
        DataTable dt = CartDAO.getCartDT(Session.SessionID, sku);
        if (!CommonUtil.DT.isEmptyOrNull(dt))
        {
            int inventory = 0;
            if (StringUtil.isNullOrEmpty(dt.Rows[0]["Inventory"] + ""))
                inventory = 0;
            else
                inventory = (int)float.Parse(dt.Rows[0]["Inventory"] as String);
            if (inventory == 0)
            {
                dic.Add("error", "Oops!! Sorry, Items is Sold Out");
            }
            else if (inventory < Int32.Parse(qty))
            {
                string msg = "Only " + inventory + " Item(s) are left in inventory!!";
                dic.Add("error", msg);
            }
            else
            {
                int quantity = Int32.Parse(qty);
                int uPrice = Convert.ToInt32(dt.Rows[0]["UNIT_PRICE"] + "");
                int subTotal = quantity * uPrice;
                CartDAO.updateQuantity(quantity + "", Session.SessionID, sku, subTotal + "");
                Session.Remove(Constant.Session.CART_ITEMS);
                Session.Remove(Constant.Session.TOTAL);
                HomeService.getCartDT(Session.SessionID);
                string total = HomeService.getTotal();
                dic.Add("subTotal", subTotal + "");
                dic.Add("total", total);
            }
        }
        sendResponse(dic);
    }
    private void sendResponse(object response)
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        string errorStr = ser.Serialize(response);
        Response.Write(errorStr);
        Response.AddHeader("Content-Length", errorStr.Length.ToString());
        Response.ContentType = "application/json";
        Response.Flush();
        Response.Close();
    }
    private void clearCart()
    {
        AjaxService.clearCart(Session.SessionID);
        Session.Remove(Constant.Session.CART_ITEMS);
        Session.Remove(Constant.Session.TOTAL);
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("status", "done");
        sendResponse(dic);
    }
    private void clearFav()
    {
        AjaxService.clearFav(Session.SessionID);
        Session.Remove(Constant.Session.FAV_LIST);
    }
    private void toggleFav()
    {
        Session.Remove(Constant.Session.FAV_LIST);
        string sku = Request.Params["sku"];
        Logger.Info("########################  sku " + sku);
        JavaScriptSerializer ser = new JavaScriptSerializer();
        string userId = "";
        if (Session[Constant.Session.LOGED_IN_USER_ID] != null)
            userId = Session[Constant.Session.LOGED_IN_USER_ID] + "";
        int count = AjaxService.toggleFav(sku, Session.SessionID, userId);
        Logger.Info("########################  count " + count);

        Dictionary<string, string> dic = new Dictionary<string, string>();
        if (count > 0)
        {
            dic.Add("status", "done");
        }
        else
        {
            dic.Add("status", "notDone");
        }
        sendResponse(dic);
    }
    private void logout()
    {
        try
        {
            Session.Remove(Constant.Session.LOGED_IN_EMAIL);
            Session.Remove(Constant.Session.LOGED_IN_USER_ID);
        }
        catch { }
        Response.Redirect(ConfigUtil.hostURL());
    }
    private void checkMail()
    {
        Errors errors = new Errors();
        if (StringUtil.isNullOrEmpty(Request.Params["email"]))
        {
            errors.addError("email", "Email is required");
        }
        else if (!CommonUtil.isValidEmail(Request.Params["email"]))
        {
            errors.addError("email", "Email id is not valid");
        }
        if (errors.errors.Count == 0)
        {
            DataTable dt = AjaxService.getUser(Request.Params["email"]);
            if (!CommonUtil.DT.isEmptyOrNull(dt))
            {
                errors.addError("info", "Congrats!! Emaild id is Exist ");
            }
            else
            {
                errors.addError("email", "Oops!! Email is not Registerd");
            }
        }
        if (errors.errors.Count > 0)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string errorStr = ser.Serialize(errors);
            Response.Write(errorStr);
            Response.AddHeader("Content-Length", errorStr.Length.ToString());
        }
        Response.ContentType = "application/json";
        Response.Flush();
        Response.Close();
    }
    private void checkRegMail()
    {
        Errors errors = new Errors();
        if (StringUtil.isNullOrEmpty(Request.Params["email"]))
        {
            errors.addError("email", "Email is required");
        }
        else if (!CommonUtil.isValidEmail(Request.Params["email"]))
        {
            errors.addError("email", "Email id is not valid");
        }
        if (errors.errors.Count == 0)
        {
            DataTable dt = AjaxService.getUser(Request.Params["email"]);
            if (!CommonUtil.DT.isEmptyOrNull(dt))
            {
                errors.addError("email", "Oops!! Email is already registerd");
            }
            else
            {
                errors.addError("info", "Congrats!! Email id is available ");
            }
        }
        if (errors.errors.Count > 0)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string errorStr = ser.Serialize(errors);
            Response.Write(errorStr);
            Response.AddHeader("Content-Length", errorStr.Length.ToString());
        }
        Response.ContentType = "application/json";
        Response.Flush();
        Response.Close();
    }
    private void register()
    {
        Dictionary<String, String> param = new Dictionary<String, String>();
        Errors errors = validateRegister(param);
        if (errors.errors.Count == 0)
        {
            try
            {
                param.Add("@SESSION_ID", Session.SessionID);
                int userId = AjaxService.register(param);
                Session[Constant.Session.LOGED_IN_USER_ID] = userId.ToString();
                Session[Constant.Session.LOGED_IN_EMAIL] = Request.Params["email"];
                JavaScriptSerializer ser = new JavaScriptSerializer();
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("info", "success");
                string errorStr = ser.Serialize(d);
                Response.Write(errorStr);
                Response.AddHeader("Content-Length", errorStr.Length.ToString());
            }
            catch (NotSupportedException e)
            {
                errors.addError("email", "Email id is already Registerd");
            }
            catch
            {
                errors.addError("system", "Oops!! internal server error, Please try again!");
            }
        }
        if (errors.errors.Count > 0)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string errorStr = ser.Serialize(errors);
            Response.Write(errorStr);
            Response.AddHeader("Content-Length", errorStr.Length.ToString());
        }
        Response.ContentType = "application/json";
        Response.Flush();
        Response.Close();
    }
    private Errors validateRegister(Dictionary<String, String> param)
    {
        Errors errors = new Errors();
        if (StringUtil.isNullOrEmpty(Request.Params["email"]))
        {
            errors.addError("email", "Email is required");
        }
        else if (!CommonUtil.isValidEmail(Request.Params["email"]))
        {
            errors.addError("email", "Email id is not valid");
        }
        else
            param.Add("@EMAIL", Request.Params["email"]);

        if (StringUtil.isNullOrEmpty(Request.Params["mobile"]))
        {
            errors.addError("mobile", "Mobile No is required");
        }
        else if (Request.Params["mobile"].Length != 10)
        {
            errors.addError("mobile", "Mobile No must have 10 digit");
        }
        else
            param.Add("@MOBILE", Request.Params["mobile"]);

        if (StringUtil.isNullOrEmpty(Request.Params["pwd"]))
        {
            errors.addError("pwd", "Password is required");
        }
        else if (Request.Params["pwd"].Length < 8 || Request.Params["pwd"].Length > 20)
        {
            errors.addError("pwd", "Password length must be 8 to 20 character");
        }
        else
            param.Add("@PASSWORD", Request.Params["pwd"]);
        return errors;
    }
    private void login()
    {
        Errors errors = validateLogin();
        if (errors.errors.Count == 0)
        {
            try
            {
                DataTable dt = AjaxService.getUser(Request.Params["email"]);
                if (!CommonUtil.DT.isEmptyOrNull(dt))
                {
                    if (Request.Params["pwd"].Equals(dt.Rows[0]["PASSWORD"]))
                    {
                        Session[Constant.Session.LOGED_IN_USER_ID] = dt.Rows[0]["ID"];
                        Session[Constant.Session.LOGED_IN_EMAIL] = dt.Rows[0]["EMAIL"];
                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        Dictionary<string, string> d = new Dictionary<string, string>();
                        d.Add("info", "success");
                        updateSessionIdInTable();
                        string errorStr = ser.Serialize(d);
                        Response.Write(errorStr);
                        Response.AddHeader("Content-Length", errorStr.Length.ToString());

                    }
                    else
                    {
                        errors.addError("pwd", "Opps!! You typed wrong password");
                    }
                }
                else
                {
                    errors.addError("email", "Opps!! Email id is not Registerd");
                }
            }
            catch
            {
                errors.addError("system", "Oops!! internal server error, Please try again!");
            }
        }
        if (errors.errors.Count > 0)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string errorStr = ser.Serialize(errors);
            Response.Write(errorStr);
            Response.AddHeader("Content-Length", errorStr.Length.ToString());
        }
        Response.ContentType = "application/json";
        Response.Flush();
        Response.Close();

    }
    private void updateSessionIdInTable()
    {
        CartDAO.updateCart(Session[Constant.Session.LOGED_IN_USER_ID] + "", Session.SessionID);
        FavDAO.updateFavList(Session[Constant.Session.LOGED_IN_USER_ID] + "", Session.SessionID);
        Session.Remove(Constant.Session.CART_ITEMS);
        Session.Remove(Constant.Session.FAV_LIST);
        Session.Remove(Constant.Session.TOTAL);
    }
    private Errors validateLogin()
    {
        Errors errors = new Errors();
        if (StringUtil.isNullOrEmpty(Request.Params["email"]))
        {
            errors.addError("email", "Email is required");
        }
        else if (!CommonUtil.isValidEmail(Request.Params["email"]))
        {
            errors.addError("email", "Email id is not valid");
        }

        if (StringUtil.isNullOrEmpty(Request.Params["pwd"]))
        {
            errors.addError("pwd", "Password is required");
        }
        else if (Request.Params["pwd"].Length < 8 || Request.Params["pwd"].Length > 20)
        {
            errors.addError("pwd", "Password length must be 8 to 20 character");
        }
        return errors;
    }
    protected void addToCart()
    {
        string qty = Request.Params["qty"];
        string style = Request.Params["sku"];
        string size = Request.Params["size"] == null ? "" : Request.Params["size"].Trim();
        string color = Request.Params["color"] == null ? "" : Request.Params["color"].Trim();
        Dictionary<string, string> dic = new Dictionary<string, string>();
        DataTable dt = AjaxService.getProdBySKU(style);
        if (!"Normal".Equals(dt.Rows[0]["SKUClassification"] + ""))
        {
            if (validateProduct().Count > 0)
            {
                sendResponse(dic);
                return;
            }
            else
            {
                if ("Variant".Equals(dt.Rows[0]["SKUClassification"] + ""))
                    style = dt.Rows[0]["StyleCode"] + "";
                dt = AjaxService.getVarientProd(style, size, color);
            }
        }
        DataTable dt1 = GenericDAO.getDataTable("select * from CART where SESSION_ID='" + Session.SessionID + "' and  SKU ='" + dt.Rows[0]["SKUCode"] + "'");
        if (!CommonUtil.DT.isEmptyOrNull(dt1))
        {
            int cartQuantity = Int32.Parse(dt1.Rows[0]["QTY"] + "");
            int t = Convert.ToInt32(qty) + cartQuantity;
            int u = Convert.ToInt32(dt1.Rows[0]["UNIT_PRICE"] + "");
            int TotalPrice = t * u;
            checkInventroy(t.ToString(), dic, dt1, cartQuantity.ToString());
            if (dic.Count == 0)
            {
                GenericDAO.updateQuery("update CART set QTY ='" + t + "', TOTAL='" + TotalPrice + "' where SESSION_ID='" + Session.SessionID + "' and SKU ='" + dt1.Rows[0]["SKU"] + "'");
                Session.Remove(Constant.Session.CART_ITEMS);
                Session.Remove(Constant.Session.TOTAL);
                dic.Add("success", "done");
            }
        }
        else
        {
            checkInventroy(qty, dic, dt, null);
            if (dic.Count == 0)
            {
                string userID = "";
                int price = Convert.ToInt32("" + dt.Rows[0]["SpecialPrice"]);
                int Total = price * Int32.Parse(qty);
                if (Session[Constant.Session.LOGED_IN_USER_ID] != null)
                    userID = Session[Constant.Session.LOGED_IN_USER_ID].ToString();
                CartDAO.addToCart(Session.SessionID, qty, price.ToString(), Total.ToString(), dt.Rows[0]["SKUCode"] + "", userID);
                Session.Remove(Constant.Session.CART_ITEMS);
                Session.Remove(Constant.Session.TOTAL);
                dic.Add("success", "success");
            }
        }
        sendResponse(dic);
    }

    private static void checkInventroy(string qty, Dictionary<string, string> dic, DataTable dt, string addQTY)
    {
        int inventory = 0;
        if (StringUtil.isNullOrEmpty(addQTY))
            inventory = AjaxService.getInventory(dt.Rows[0]["SKUCode"] + "");
        else
            inventory = AjaxService.getInventory(dt.Rows[0]["SKU"] + "");

        if (inventory == 0)
        {
            dic.Add("error", "Product is Sold Out!!");
        }
        else if (inventory < Int32.Parse(qty))
        {
            string msg = "Only " + inventory + " Product(s) are left in inventory!!";
            if (!StringUtil.isNullOrEmpty(addQTY))
                msg += "You already added " + addQTY + " Items(s) in Your Cart";
            dic.Add("error", msg);
        }
    }
    private Dictionary<string, string> validateProduct()
    {

        Dictionary<string, string> dic = new Dictionary<string, string>();
        string size = Request.QueryString["size"];
        string color = Request.QueryString["color"];
        string isSize = Request.QueryString["isSize"];
        string isColor = Request.QueryString["isColor"];
        string isSku = Request.QueryString["isSku"];
        string style = Request.QueryString["sku"];
        FrontViewProductDetailsDAO fvpd = new FrontViewProductDetailsDAO();
        DataTable dt = null;
        if ("true".Equals(isColor) && "true".Equals(isSize))
        {
            if (StringUtil.isNullOrEmpty(color))
                dic.Add("error", "Please select the color");
            else if (StringUtil.isNullOrEmpty(size))
                dic.Add("error", "Please select the Size");
            else
            {
                if ("true".Equals(isSku))
                    dt = fvpd.getProdBySkuColorSize(style, color, size);
                else
                    dt = fvpd.getProdByStyleColorSize(style, color, size);
            }
        }
        else if ("true".Equals(isColor))
        {
            if (StringUtil.isNullOrEmpty(color))
            {
                dic.Add("error", "Please select the color");
            }
            else
            {
                if ("true".Equals(isSku))
                    dt = fvpd.getProdBySkuColor(style, color);
                else
                    dt = fvpd.getProdByStyleColor(style, color);
            }
        }
        else if ("true".Equals(isSize))
        {
            if (StringUtil.isNullOrEmpty(size))
            {
                dic.Add("error", "Please select the size");
            }
            else
            {
                if ("true".Equals(isSku))
                    dt = fvpd.getProdBySkuSize(style, size);
                else
                    dt = fvpd.getProdByStyleSize(style, size);
            }
        }
        return dic;
    }
    private void checkInventory()
    {
        DataTable dt = CartDAO.getCartDT(Session.SessionID);
        List<Dictionary<string, string>> errorList = new List<Dictionary<string, string>>();
        if (!CommonUtil.DT.isEmptyOrNull(dt))
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                int inventory = AjaxService.getInventory(dt.Rows[i]["SKU"] + "");
                if (inventory == 0)
                {
                    dic.Add("sku", dt.Rows[i]["SKU"] + "");
                    dic.Add("error", "Oops!! Sorry, Items is Sold Out");
                }
                else if (inventory < Int32.Parse(dt.Rows[i]["QTY"] + ""))
                {
                    string msg = "Only " + inventory + " Item(s) are left in inventory!!";
                    dic.Add("sku", dt.Rows[i]["SKU"] + "");
                    dic.Add("error", msg);
                }
                if (dic.Count > 0)
                    errorList.Add(dic);
            }
        }
        sendResponse(errorList);
    }

}