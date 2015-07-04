using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MFO.Loggers;
using MFO.Commom;
using MFO.Constants;
using MFO.DTO;
using System.Data.Linq.SqlClient;
using MFO.Common;
using MFO.Utils;
using System.Data;

namespace MFO.Services
{

    /// <summary>
    /// Summary description for CategoryDetailsDAO
    /// </summary>
    public static class CategoryDetailsService
    {

        public static DataTable getDTBySKU(string skuCode)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCode") == skuCode
                orderby dr.Field<String>("Size") ascending
                select dr;
            try
            {
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception occur CategoryDetailsService.getHoverImage() ", e);
                return null;
            }
            return dt;
        }
        public static DataTable getDTBySKUORStyle(string skuCode,string style)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCode") == skuCode
                    || dr.Field<String>("StyleCode") == style
                select dr;
            try
            {
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception occur CategoryDetailsService.getDTBySKUORStyle() ", e);
                return null;
            }
            return dt;
        }


        public static DataTable getDTByStyleAndColor(string style)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("StyleCode") == style
                    && dr.Field<String>("Color") != ""
                    && dr.Field<String>("Color") != null
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("Color"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception occur CategoryDetailsService.getDTByColorAndSKU() ", e);
                return null;
            }
            return dt;
        }
        public static DataTable getDTByProductType(string SKUProductType)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUProductType") == SKUProductType
                    && dr.Field<String>("Color") != ""
                orderby dr.Field<String>("SKUBrand") ascending
                select dr;
            try
            {
               
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception occur  CategoryDetailsService.getDTByProductType()", e);
                return null;
            }
            return dt;
        }

        public static DataTable getDTBySkuAndStyle(string skuCode, string style)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCode") == skuCode
                    && dr.Field<String>("StyleCode") == style
                select dr;
            try
            {

                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception occur  CategoryDetailsService.getDTBySkuAndStyle()", e);
                return null;
            }
            return dt;
        }

        public static DataTable getDTByStyle(string style)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("StyleCode") == style
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("Size"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception occur  CategoryDetailsService.getDTBySkuAndStyle()", e);
                return null;
            }
            return dt;
        }



        public static string getRelProductDT(string p, string p_2)
        {
            throw new NotImplementedException();
        }
    }
}