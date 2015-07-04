using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MFO.DTO;
using MFO.Utils;
using MFO.Loggers;
using System.Text.RegularExpressions;
using System.IO;
using NVelocityTemplateEngine;
using NVelocityTemplateEngine.Interfaces;
using System.Collections;

/// <summary>
/// Summary description for Util
/// </summary>
/// 
namespace MFO.Commom
{
    public class CommonUtil
    {
        public static string GetUser_IP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
        public static void DtNullCheck(DataTable dt)
        {
            if (null == dt)
                System.Web.HttpContext.Current.Response.Redirect(ConfigUtil.hostURL() + "Opps-Sorry");
        }
        public static bool isCached(String name)
        {
            if (!"true".Equals(ConfigUtil.getValue("cacheEnable").ToString().ToLower()))
            {
                Logger.Warning("Caching is disabled");
                return false;
            }
            else
            {
                int cacheExpireHour = Int32.Parse(ConfigUtil.getValue("cacheExpireHour").ToString());
                DataCacheDTO cache = (DataCacheDTO)HttpContext.Current.Application[name];
                if (cache != null && cache.CacheTime.AddHours(cacheExpireHour).CompareTo(DateTime.Now) > 0)
                {
                    return true;
                }
                else
                {
                    Logger.Warning("DT " + name + " is not cached or date is expired");
                    return false;
                }
            }
        }
        public static String readTemlate(String templateName,IDictionary context)
        {
            string templateDir = System.Web.HttpContext.Current.Request.PhysicalApplicationPath+"/templete/";
			INVelocityEngine fileEngine = 
				NVelocityEngineFactory.CreateNVelocityFileEngine(templateDir, true);
			
			return fileEngine.Process(context, templateName);
                

        }
        public static bool isValidEmail(string email)
        {
            Regex regExEmail = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return regExEmail.IsMatch(email);
        }
        public static class DT
        { 
            public static bool isEmptyOrNull(DataTable dt){
                return dt == null || dt.Rows.Count == 0;
            }
        }
    }
}