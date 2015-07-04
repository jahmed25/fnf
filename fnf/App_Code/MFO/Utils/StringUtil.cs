using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StringUtil
/// </summary>
/// 
namespace MFO.Utils
{
    public class StringUtil
    {
        public static bool isNullOrEmpty(String str)
        {
            return str == null || String.Empty.Equals(str.Trim());            
        }
        public static string urlEncode(string str)
        { 
            return str.Replace(" ", "-").Replace("&", "").Replace("--", "-");
        }
        public static float getDiscount(string mrp,string spacial)
        {
            if(!(isNullOrEmpty(mrp)&&isNullOrEmpty(spacial))){
                float dis=float.Parse(mrp)-float.Parse(spacial);
                return dis;
            }
            return 0;
        }
       
        public static string checkInventrory(string inventory, string qty)
        {
            int invn=0;
            String returnValue = "Sold Out";
            if (!isNullOrEmpty(inventory))
                invn = (int)float.Parse(inventory);
            if (Int32.Parse(qty) > invn)
                returnValue = "Only " + invn + " item(s) are left, Please choose quantity again.";
            else if (Int32.Parse(qty)<= invn)
            {
                returnValue = "available";
            }
            return returnValue;
        }
        public static string dispLI(object src, object name, bool isDisp)
        {
            if (!StringUtil.isNullOrEmpty(src + "") && isDisp)
            {
                return "" + "<li class='disp'><img src='" + ConfigUtil.getServerPath() + src + "' alt='" + name + "' class='right_inner_categorydetailsimagescss'/> </li>";

            }
            else if (!StringUtil.isNullOrEmpty(src + ""))
            {
                return "" + "<li style='display:none'><img src='" + ConfigUtil.getServerPath() + src + "' alt='" + name + "' class='right_inner_categorydetailsimagescss'/> </li>";
            }
            else
            {
                return "";
            }
        }
    }
    
}
 