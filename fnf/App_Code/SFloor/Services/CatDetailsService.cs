using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MFO.Common;
using MFO.Loggers;

/// <summary>
/// Summary description for CatDetailsService
/// </summary>
/// 
namespace SFloor.Services
{
    public static class CatDetailsService
    {
        public static DataTable getSizeDT(string style,bool isStyle) {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query = null;
                query =
                     from dr in dt.AsEnumerable()
                     where dr.Field<String>("StyleCode") == style
                     orderby dr.Field<String>("Size")
                     select dr;
               
            
            try
            {
                query = query.Distinct(new DistictComparer("Size"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                query = from dr in GenericService.getVewImageNewMasterDT().AsEnumerable()
                       where dr.Field<String>("SKUCode") == style
                       orderby dr.Field<String>("Size")
                       select dr;
                try
                {
                    query = query.Distinct(new DistictComparer("Size"));
                    dt = query.CopyToDataTable<DataRow>();
                    query = from dr in GenericService.getVewImageNewMasterDT().AsEnumerable()
                             where dr.Field<String>("StyleCode") == dt.Rows[0]["StyleCode"]+""
                              orderby dr.Field<String>("Size")
                              select dr;
                    query = query.Distinct(new DistictComparer("Size"));
                    dt = query.CopyToDataTable<DataRow>();
                }
                catch {
                    Logger.Error("Exception ocuur CatDetailsService.getSizeDT()", e);
                    dt = new DataTable();
                
                }
                
                return dt;

            }
            return dt;
        }
        public static DataTable getColorDT(string style, bool isStyle)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query = null;
            if (isStyle)
            {
                query =
                     from dr in dt.AsEnumerable()
                     where dr.Field<String>("StyleCode") == style
                     select dr;
            }
            else
            {
                query =
                     from dr in dt.AsEnumerable()
                     where dr.Field<String>("SKUCode") == style
                     select dr;
            }
            try
            {
                query = query.Distinct(new DistictComparer("Color"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception ocuur CatDetailsService.getColorDT()", e);
                dt = new DataTable();
                return dt;

            }
            return dt;
        }

        public static DataTable getRelProductDT(string pType)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUProductType") == pType
                    && dr.Field<String>("StyleCode") == String.Empty
                select dr;
            try
            {
                dt =query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception occur CatService.getRelProductDT()", e);
                dt = new DataTable();
            }
            return dt;
        }
        public static string[] getRelProductDT(string sku,int index)
            {
                DataTable dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUCode") == sku
                        && dr.Field<String>("StyleCode") == String.Empty
                    select dr;
                try
                {
                    dt = query.CopyToDataTable<DataRow>();
                    string type = dt.Rows[0]["SKUProductType"] + "";
                    dt = GenericService.getVewImageNewMasterDT();
                    query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUProductType") == type
                        && dr.Field<String>("StyleCode") == String.Empty
                            orderby dr.Field<String>("SKUName")
                    select dr;
                    dt = query.CopyToDataTable<DataRow>();
                    
                }
                catch (InvalidOperationException e)
                {
                    Logger.Error("Exception occur CatService.getRelProductDT()", e);
                    dt = new DataTable();
                }
                if(index==dt.Rows.Count){
                    string[] str = { dt.Rows[0]["SKUCode"] + "", (1) + "" }; 
                    return  str;
                }
                else{
                    dt = query.Skip(index).CopyToDataTable<DataRow>();
                     string[] str = { dt.Rows[0]["SKUCode"] + "", (index) + "" };
                     return str;

                    }

        }

        public static string[] getRelLastProduct(string sku)
        {

            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCode") == sku
                    && dr.Field<String>("StyleCode") == String.Empty
                select dr;
            try
            {
                dt = query.CopyToDataTable<DataRow>();
                string type = dt.Rows[0]["SKUProductType"] + "";
                dt = GenericService.getVewImageNewMasterDT();
                query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUProductType") == type
                    && dr.Field<String>("StyleCode") == String.Empty
                orderby dr.Field<String>("SKUName")
                select dr;
                dt = query.CopyToDataTable<DataRow>();


            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception occur CatService.getRelProductDT()", e);
                dt = new DataTable();
            }
            string[] str = { dt.Rows[dt.Rows.Count - 1]["SKUCode"] + "", (dt.Rows.Count - 1)+"" }; 
            return str;
        }
    }
}