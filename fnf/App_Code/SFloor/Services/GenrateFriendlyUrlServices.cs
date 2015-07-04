using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MFO.Common;
using System.Data;
using System.Text;
using MFO.Utils;
using System.IO;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace SFloor.Services{
    public static class GenrateFriendlyUrlServices
    {
        public static string Genrate()
        {
            StringBuilder xml = new StringBuilder();
            xml.AppendLine("<rewriter>");


            xml.AppendLine("<!-- ======================== START Category Details Page ======================================= -->");
            xml.AppendLine("<if url='~/(.+)?htm'>");
            xml.AppendLine("  <rewrite to='~/sfloor/pages/CatDetails.aspx' processing='stop'/>");
            xml.AppendLine("</if>");
            xml.AppendLine("<!-- ======================== END Category Details Page ======================================= -->");

            DataTable dt = getProductTypeDT();

            xml.AppendLine("<!-- ========================START Product Type ======================================= -->");
            foreach (DataRow row in dt.Rows) { 
                String ifCondition="~/"+StringUtil.urlEncode(row["CategoryTypeUrlName"]+"");
                ifCondition += "/"+StringUtil.urlEncode(row["SKUProductType"] + "");
                xml.AppendLine("<if url='" + ifCondition + "'>");
                xml.AppendLine("  <rewrite to='~/sfloor/pages/Categories.aspx?Pid=" + row["ProductTypeID"] + "' processing='stop'/>");
                xml.AppendLine("</if>");
            }
            xml.AppendLine("<!-- ========================END Product Type ======================================= -->");
            
            dt = getCategoryTypeDT();
            xml.AppendLine("<!-- ========================START Category Type ======================================= -->");
            foreach (DataRow row in dt.Rows) { 
                String ifCondition="~/"+StringUtil.urlEncode(row["CategoryTypeUrlName"]+"");
                xml.AppendLine("<if url='" + ifCondition + "'>");
                xml.AppendLine("   <rewrite to='~/sfloor/pages/Categories.aspx?CategoryType=" + row["CategoryTypeID"] + "' processing='stop'/>");
                xml.AppendLine("</if>");
            }
            xml.AppendLine("<!-- ========================END Category Type ======================================= -->");
            xml.AppendLine("</rewriter>");
            //writeFile(xml.ToString());
            return xml.ToString();
        }

        private static void writeFile(string content)
        {
            String path = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "autoGenrated\\friendlyURL-"+DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss")+".xml";
            File.WriteAllText(path, content);
            
        }
        public static DataTable getProductTypeDT()
        {

            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("ProductTypeID"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch { }
            return dt;
        }
        public static DataTable getCategoryTypeDT()
        {

            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("CategoryTypeID"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch { }
            return dt;
        }
    }
}