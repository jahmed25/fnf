using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.IO;
using MFO.Commom;
using System.Collections;
using MFO.Utils;
using MFO.services;
using SFloor.DAO;
using MFO.Constants;
using MFO.Loggers;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace SFloor.Services
{

    public static class EmailTemplateService
    {

        public static void sendOrderPlacedEmail()
        {
            Logger.Info("START EmailTemplateService.sendOrderPlacedEmail()");
            try
            {
                string orderId = HttpContext.Current.Session[Constant.Session.CURRENT_ORDER] + "";
                Logger.Debug("orderId" + orderId);
                DataTable orderDT = OrderDAO.getOrder(orderId);
                DataTable orderDetailsDT = OrderDAO.getOrderDetails(orderId);
                DataTable shippingDT = ShippingDAO.getShipping(orderDT.Rows[0]["SHIPPING_ID"] + "");
                String emailSendTo = shippingDT.Rows[0]["EMAIL"] + "";
                Logger.Debug("emailSendTo" + emailSendTo);
                if (!CommonUtil.DT.isEmptyOrNull(orderDT))
                {
                    IDictionary context = new Hashtable();
                    context.Add("CUSTOMER", shippingDT.Rows[0]["NAME"] + "");
                    context.Add("ORDER_DATE", DateTime.Now + "");
                    context.Add("ORDER_NO", orderDT.Rows[0]["ORDER_NO"] + "");
                    context.Add("PAYMINT_MODE", orderDT.Rows[0]["PAYMINT_METHOD"]);
                    context.Add("EMAIL", emailSendTo);
                    context.Add("MOBILE", shippingDT.Rows[0]["MOBILE"] + "");
                    context.Add("ADDRESS", shippingDT.Rows[0]["ADDRESS"] + "");
                    context.Add("CITY", shippingDT.Rows[0]["CITY"] + "");
                    context.Add("STATE", shippingDT.Rows[0]["STATE"] + "");
                    context.Add("PIN", shippingDT.Rows[0]["PIN"] + "");
                    context.Add("COUNTRY", "India.");
                    context.Add("CC_NO ", ConfigUtil.CC_NO);
                    context.Add("CC_EMAIL ", ConfigUtil.CC_Email);
                    Logger.Debug("CustomerCareNo = " + ConfigUtil.CC_NO);
                    Logger.Debug("CustomerCareEmail = " + ConfigUtil.CC_Email);
                    Logger.Debug("context.CUSTOMER_CARE_NO = " + context["CC_NO"]);
                    Logger.Debug("context.CUSTOMER_CARE_EMAIL = " + context["CC_EMAIL"]);
                    Logger.Debug("context.PIN = " + context["PIN"]);

                    context.Add("SHIPPING_CHARGE", ConfigUtil.getValue("ShippigCharge"));
                    context.Add("SUBTOTAL", Decimal.Parse(orderDT.Rows[0]["AMOUNT"]+"").ToString("#.00") );
                    context.Add("VAT", orderDT.Rows[0]["VAT"]);
                    context.Add("TOTAL",Decimal.Parse(orderDT.Rows[0]["TOTAL_AMOUNT"]+"").ToString("#.00") );
                    List<object> orderList = new List<object>();
                    foreach (DataRow orderRow in orderDetailsDT.Rows)
                    {
                        orderList.Add(new
                        {
                            NAME = orderRow["SKUName"],
                            BRAND = orderRow["SKUBrand"],
                            QTY = orderRow["QTY"],
                            COLOR = orderRow["Color"],
                            SIZE = orderRow["Size"],
                            TOTAL =  Decimal.Parse(orderRow["TOTAL"]+"").ToString("#.00"),
                            SKU = orderRow["SKU"],
                            UNIT_PRICE = Decimal.Parse(orderRow["UNIT_PRICE"]+"").ToString("#.00"),
                            IMG = ConfigUtil.getServerPath() + "" + orderRow["PathInternaldetailsSmallImage"],
                        });
                    }
                    context.Add("ALL_PRODUCT", orderList);
                    Logger.Debug("orderList:- " + orderList.Count);
                    String html = CommonUtil.readTemlate("orderPlaced.vm", context);
                    Logger.Debug("template file:- "+html);
                    EmailService.SendMail(ConfigUtil.MailFrom, emailSendTo, "Order Confirmation - Order ID - " + orderDT.Rows[0]["ORDER_NO"], html);
                    EmailService.SendMail(ConfigUtil.MailFrom, ConfigUtil.getValue("OrderTrakerEmail"), "Order Confirmation - Order ID - " + orderDT.Rows[0]["ORDER_NO"], html);
					sendSMS(shippingDT.Rows[0]["NAME"] + "",orderDT.Rows[0]["ORDER_NO"]+"", Decimal.Parse(orderDT.Rows[0]["TOTAL_AMOUNT"]+"").ToString("#.00") ,shippingDT.Rows[0]["MOBILE"] + "",emailSendTo);
					sendSMSCustCare(shippingDT.Rows[0]["NAME"] + "",orderDT.Rows[0]["ORDER_NO"]+"", Decimal.Parse(orderDT.Rows[0]["TOTAL_AMOUNT"]+"").ToString("#.00") ,shippingDT.Rows[0]["MOBILE"] + "",emailSendTo);
              
			  }

            }
            catch (Exception e) {
                Logger.Info("error occur "+e);
                Logger.Error(e);

            }
            Logger.Info("End EmailTemplateService.sendOrderPlacedEmail()");
        }
		public static void sendSMS(string name, string orderId,string amout,String phone,string email){
			
			string sURL = "http://orangebulksms.in/shn/api/pushsms.php?usr=617650&pwd=XZPSEBGKHC&sndr=FNFCOM&ph="+phone;
			string text="Hi "+name+", We have received your order "+orderId+" amounting to Rs. "+amout+", and its being processed, Our customer care executive get back to you soon.";
			sURL+="&text="+text+"&rpt=1";
			WebRequest wrGETURL=null;
			wrGETURL = WebRequest.Create(sURL);
			wrGETURL.GetResponse().GetResponseStream();
			
			
		}
		public static void sendSMSCustCare(string name, string orderId,string amout,String phone,string email){
			
			string sURL = "http://orangebulksms.in/shn/api/pushsms.php?usr=617650&pwd=XZPSEBGKHC&sndr=FNFCOM&ph=7042121501";
			string text="One order has been dropped by Mr/Ms "+name+", having order "+orderId+" and totoal amount is Rs. "+amout+", customer phone no is: "+phone+" and email Id is"+email;
			sURL+="&text="+text+"&rpt=1";
			WebRequest wrGETURL=null;
			wrGETURL = WebRequest.Create(sURL);
			wrGETURL.GetResponse().GetResponseStream();
							
		}
        public static Dictionary<String, String> sendForgetPasswordEmail(String email)
        { 
            Dictionary<String,String> responseDic= new Dictionary<String,String>();
              
                String emailSendTo = email;
                DataTable dt = AjaxService.getUser(email);
                if (!CommonUtil.DT.isEmptyOrNull(dt))
                {
                    IDictionary context = new Hashtable();
                    context.Add("USER_ID", dt.Rows[0]["EMAIL"] + "");
                    context.Add("PASSWORD", dt.Rows[0]["PASSWORD"] + "");
                    String html = CommonUtil.readTemlate("forgetPassword.vm", context);
                    EmailService.SendMail(ConfigUtil.MailFrom, emailSendTo, "Forget Password Response", html);
                    responseDic.Add("info", "UserId and Password has been sent to Your e-Mail ID. \n Please Check Your e-Mail");

                }
                else
                {
                    responseDic.Add("error", "Oops!! Email is not Registered.");

                }
 
              return responseDic;
        }

        public static Dictionary<string, string> sendPurchiOrderPlacedEmail(dynamic v)
        {
            Dictionary<String, String> responseDic = new Dictionary<String, String>();
            try
            {
                String emailSendTo = ConfigUtil.ParchiOrderEmail;
               // var v = (dynamic)obj;
                IDictionary context = new Hashtable();
                context.Add("NAME", v.name);
                context.Add("TEXT", ((string)v.text).Replace(",", "<br>"));
                context.Add("ADDRESS", v.address);
                context.Add("PHONE", v.phone);
                context.Add("PATH", ConfigUtil.StaticPath());
                String html = CommonUtil.readTemlate("purchiOrderPlaced.vm", context);
                EmailService.SendMail(ConfigUtil.MailFrom, emailSendTo, "Forget Password Response", html);
                responseDic.Add("info", "Order Placed Successfully, Our Team will Get Back To You soon."); 
            }
            catch (Exception e) {
                responseDic.Add("error", "Opps!! something went wrong, Please try again after some time.\n"+e); 
                
            }
            return responseDic;
        }
    }
}