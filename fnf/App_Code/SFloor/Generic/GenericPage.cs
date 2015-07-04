using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.IO;

namespace SFloor.Pages
{
    public class GenericPage : Page
    {
        string header;
        string footer;
        string head;
        public bool isEnalbleCache = true;
        public String Header
        {
            get { return header; }
        }
        public String Footer
        {
            get { return footer; }
        }
        public String Head
        {
            get { return head; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //load Header
            GZipEncodePage();
            Control c = LoadControl("~/sfloor/pages/Header.ascx");
            header = RenderControl(c);

            c = LoadControl("~/sfloor/pages/Footer.ascx");
            footer = RenderControl(c);

            c = LoadControl("~/sfloor/pages/Head.ascx");
            head = RenderControl(c);
            load(sender, e);
            doCache();
        }

        private string RenderControl(Control control)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            control.RenderControl(writer);
            return sb.ToString();
        }
        public virtual void load(object sender, EventArgs e)
        {
        }
        
        public static void GZipEncodePage()
        {
            HttpResponse Response = HttpContext.Current.Response;

            if (IsGZipSupported())
            {
                string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
                if (AcceptEncoding.ToLower().Contains("gzip"))
                {
                   
                    Response.Filter = new System.IO.Compression.GZipStream(Response.Filter,
                                              System.IO.Compression.CompressionMode.Compress);
                    Response.AppendHeader("Content-Encoding", "gzip");
                }
                else
                {
                    Response.Filter = new System.IO.Compression.DeflateStream(Response.Filter,
                                              System.IO.Compression.CompressionMode.Compress);
                    Response.AppendHeader("Content-Encoding", "deflate");
                    
                }
            }

            // Allow proxy servers to cache encoded and unencoded versions separately
            
        }
        public static bool IsGZipSupported()
        {
            string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
            if (!string.IsNullOrEmpty(AcceptEncoding) &&
                 AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate"))
                return true;
            return false;
        }
        public void doCache() {
            if (isEnalbleCache)
            {
                Response.AppendHeader("Vary", "Content-Encoding");
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(60 * 60));
                Response.Cache.SetCacheability(HttpCacheability.Public);
                Response.Cache.SetValidUntilExpires(true);
            }
        }
    }
}