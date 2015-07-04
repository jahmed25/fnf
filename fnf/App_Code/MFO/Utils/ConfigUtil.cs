using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;

/// <summary>
/// Summary description for ConfigUtil
/// </summary>
namespace MFO.Utils
{
	public class ConfigUtil
	{

		private static string hostUrl = null;
		private static string adminUrl = null;
		private static string dbConnectionString;
		private static string sitename;
        private static string staticPath;
        private static string mailServer;
        private static string mailPassword;
        private static string mailUsername;
        private static string mailFrom;
        private static string parchiOrderEmail;
        private static string ccNo;
        private static string ccEmail;
        private static bool? isDebugOn =null;
        private static bool? isWarningOn = null;

		static ConfigUtil()
		{
			dbConnectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            sitename = ConfigurationManager.AppSettings["SiteName"];
            mailServer = ConfigurationManager.AppSettings["MailServer"];
            mailPassword = ConfigurationManager.AppSettings["MailPassword"];
            mailUsername = ConfigurationManager.AppSettings["MailUsername"];
            mailFrom = ConfigurationManager.AppSettings["MailFrom"];
            parchiOrderEmail = ConfigurationManager.AppSettings["PurchiOrderPlacedEmailID"];
            ccNo = ConfigurationManager.AppSettings["CC_NO"];
            ccEmail = ConfigurationManager.AppSettings["CC_Email"];
            isDebugOn = ConfigurationManager.AppSettings["IsDebugOn"] == null || ConfigurationManager.AppSettings["IsDebugOn"].ToLower().Equals("no") ? false : true;
            isWarningOn = ConfigurationManager.AppSettings["IsWarningOn"] == null || ConfigurationManager.AppSettings["IsWarningOn"].ToLower().Equals("no") ? false : true;
		}

		public static string getServerPath()
		{
			if (adminUrl == null)
			{
				adminUrl = ConfigurationManager.AppSettings["adminServerPath"];
			}
			return adminUrl;
		}
        public static bool IsDebugOn
        {
            get
            {
                if (isDebugOn==null)
                    return ConfigurationManager.AppSettings["IsDebugOn"] == null || ConfigurationManager.AppSettings["IsDebugOn"].ToLower().Equals("no") ? false : true;
                return isDebugOn.Value;
            }
        }
        public static bool IsWarningOn
        {
            get
            {
                if (isWarningOn == null)
                    return ConfigurationManager.AppSettings["isWarningOn"] == null || ConfigurationManager.AppSettings["isWarningOn"].ToLower().Equals("no") ? false : true;
                return isWarningOn.Value;
            }
        }
		public static string StaticPath()
		{
			if (staticPath == null)
			{
				staticPath = ConfigurationManager.AppSettings["staticPath"];
			}
			return staticPath;
		}
		public static string hostURL()
		{
			if (hostUrl == null)
			{
				hostUrl = ConfigurationManager.AppSettings["hostUrl"];
			}
			return hostUrl;
		}
		public static string DbConnectionString
		{
			get
			{
				return dbConnectionString;
			}
		}
        public static string ParchiOrderEmail
        {
            get
            {
                return parchiOrderEmail;
            }
        }
		public static string MailServer
		{
			get
			{   if(mailServer==null)
				    return ConfigurationManager.AppSettings["MailServer"];
                return mailServer;
			}
		}

		public static string MailUsername
		{
			get
            {
                if (mailUsername==null)
				    return ConfigurationManager.AppSettings["MailUsername"];
                return mailUsername;
			}
		}
		public static string MailPassword
		{
			get
			{   if(mailPassword==null)
				    return ConfigurationManager.AppSettings["MailPassword"];
            return mailPassword;
			}
		}

		public static string MailFrom
		{
			get
			{
                if (mailFrom==null)
				return ConfigurationManager.AppSettings["MailFrom"];
                return mailFrom;
			}
		}
        public static string CC_NO
        {
            get
            {
                if (ccNo == null)
                    return ConfigurationManager.AppSettings["CC_NO"];
                return ccNo;
            }
        }
        public static string CC_Email
        {
            get
            {
                if (ccEmail == null)
                    return ConfigurationManager.AppSettings["CC_Email"];
                return ccEmail;
            }
        }
		public static bool EnableErrorLogEmail
		{
			get
			{
				return bool.Parse(ConfigurationManager.AppSettings
				["EnableErrorLogEmail"]);
			}
		}
		public static string ErrorLogEmail
		{
			get
			{
				return ConfigurationManager.AppSettings["ErrorLogEmail"];
			}
		}
		public static string getValue(String key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}
}