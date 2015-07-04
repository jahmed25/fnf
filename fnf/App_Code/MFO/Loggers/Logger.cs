using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using MFO.Commom;
using MFO.services;
using MFO.Utils;

/// <summary>
/// Summary description for Logger
/// </summary>
/// 
namespace MFO.Loggers
{
    public class Logger
    {
        public enum LogType
        {
            INFO, WARNING, ERROR, DEBUG
        };


        public static void Log(string message, LogType type, string callInfo)
        {
            try
            {

                string path = "log/" + DateTime.Today.ToString("dd-mm-yy") + ".txt";
                if (!File.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + path))
                {
                    File.Create(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + path).Close();
                }
                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + path))
                {


                    string err = String.Empty;
                    string datetime = DateTime.Now.ToLongDateString() + ", at "
                        + DateTime.Now.ToShortTimeString();
                    string ip_address = CommonUtil.GetUser_IP();
                    if (LogType.ERROR.Equals(type))
                    {
                        err = type + ": \n\n Exception generated on " + datetime + "\n Page: " + callInfo + " " + "\n Error URl :" + System.Web.HttpContext.Current.Request.Url.ToString() + "\n IP Address :" + ip_address +
                                        "\n  Referrer URL is " + System.Web.HttpContext.Current.Request.UrlReferrer +
                                 "      \n\n DETAILS :" + message;
                    }
                    else
                    {
                        err = type + ": " + DateTime.Now + ": " + callInfo + " " + " DETAILS :" + message;
                    }
                    w.WriteLine(err);
                    w.Flush();
                    w.Close();
                    if (LogType.ERROR.Equals(type))
                    {
                        EmailService.MailErroInfo(err);
                    }
                }
            }
            catch { }

        }

        public static String callingInfo()
        {
            String calledBy = "";
            StackTrace st = new StackTrace();
            StackFrame f = st.GetFrame(2);
            calledBy = f.GetMethod().DeclaringType.ToString();
            calledBy += "." + f.GetMethod().Name;
            return calledBy;
        }
        public static void Error(string Message, Exception e)
        {
            String callInfo = callingInfo();
            Log(Message + " ERROR DETAILS :" + e.StackTrace, LogType.ERROR, callInfo);
        }
        public static void Error(string Message)
        {

            String callInfo = callingInfo();
            Log(Message, LogType.ERROR, callInfo);
        }
        public static void Info(string Message)
        {
            String callInfo = callingInfo();
            Log(Message, LogType.INFO, callInfo);
        }
        public static void Warning(string Message)
        {
            if (ConfigUtil.IsWarningOn)
            {
                String callInfo = callingInfo();
                Log(Message, LogType.WARNING, callInfo);
            }
        }
        public static void Debug(string Message)
        {
            if (ConfigUtil.IsDebugOn)
            {
                String callInfo = callingInfo();
                Log(Message, LogType.DEBUG, callInfo);
            }
        }

        public static void Error(Exception e)
        {
            String callInfo = callingInfo();
            Log(" ERROR DETAILS :" + e.StackTrace, LogType.ERROR, callInfo);
        }
    }
}