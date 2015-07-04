using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MFO.DAO;
using System.Data;
using MFO.Loggers;
using MFO.Commom;
using MFO.Constants;
using MFO.DTO;
using System.Data.Linq.SqlClient;
using MFO.Common;
using MFO.Utils;
using System.Collections;


/// <summary>
/// Summary description for CategoriesService
/// </summary>
/// 
namespace MFO.Services
{
    public static class CategoriesService 
    {
        public static DataTable addColm(DataTable dt)
        {
            if (dt != null)
            {
                Logger.Info("Start addColm()");
                dt.Columns.Add("link", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String hRef = ConfigUtil.hostURL();
                    String brand = dt.Rows[i]["SKUBrand"] as String;

                    hRef += "" + brand.Replace(".", "");
                    hRef += "-" + dt.Rows[i]["SKUName"] as String;
                    hRef = hRef.Replace(" ", "-").Replace("&", "").Replace("--", "-");
                    hRef += "?htm=" + dt.Rows[i]["SKUCode"] as String;
                    dt.Rows[i]["link"] = hRef;

                }
            }

            Logger.Info("End addColm()");

            return dt;
        }
        public static DataTable getProductByBrand(string SKUCategory, string SKUCategoryType, string SKUBrand,int pageNo)
        {
            SKUBrand = SKUBrand.Replace("'", "\''");
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable() 
                    where dr.Field<String>("SKUCategory") == SKUCategory
                         && dr.Field<String>("SKUCategoryType") == SKUCategoryType
                         && SKUBrand.Contains(dr.Field<String>("SKUBrand").ToLower())
                         && dr.Field<String>("StyleCode") == String.Empty
                select dr;
                    query = query.OrderBy(row => row.Field<string>("SKUName"));
                return applyPagination(pageNo, ref dt, ref query);
            
        }
        public static DataTable getProductByBrand( string SKUBrand, int pageNo)
        {
            SKUBrand = SKUBrand.Replace("'", "\''");
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUBrand")==SKUBrand
                     && dr.Field<String>("StyleCode") == String.Empty
                select dr;
            query = query.OrderBy(row => row.Field<string>("SKUName"));
            return applyPagination(pageNo, ref dt, ref query);
        }
        private static DataTable applyPagination(int pageNo, ref DataTable dt, ref IEnumerable<DataRow> query)
        {
            try
            {
               
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (Exception)
            {
                dt = new DataTable();
            }


            if (pageNo==1 && dt.Rows.Count >= 16)
            {
                query = query.Take(16);
                return query.CopyToDataTable<DataRow>();
            }
            else if (pageNo == 1 && dt.Rows.Count >= 1 && dt.Rows.Count<16)
            {
                return query.CopyToDataTable<DataRow>();
            }

            else if (pageNo > 1 && dt.Rows.Count >=(pageNo * 16))
            {
                query = query.Skip((pageNo-1)  * 16).Take(16);
                return query.CopyToDataTable<DataRow>();
            }
            else if (pageNo > 1 && dt.Rows.Count < (pageNo * 16) && dt.Rows.Count >= ((pageNo - 1) * 16))
            {
                query = query.Skip((pageNo - 1) * 16);
                return query.CopyToDataTable<DataRow>();
            }
            else
                return null;
        }
        public static DataTable getProductByCatSub(string SKUCategory, string SKUCategoryType, int pageNo)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCategory") == SKUCategory
                     && dr.Field<String>("SKUCategoryType") == SKUCategoryType
                     && dr.Field<String>("StyleCode") == String.Empty
                select dr;
                query = query.OrderBy(row => row.Field<string>("SKUName"));
                return applyPagination(pageNo, ref dt, ref query);
        }
        public static DataTable getDistictProductByBrand(string CategoryTypeID)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("CategoryTypeID") == CategoryTypeID
                orderby dr.Field<String>("SKUBrand") 
                select dr;
            try
            {
               query= query.Distinct(new DistictComparer("SKUBrand"));
               query = query.OrderBy(row => row.Field<string>("SKUName"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception ocuur CategoriesService.getVewImageNewMasterDT()", e);
                dt = new DataTable();
                return dt;
                
            }
           
            return dt;
        }
        public static DataTable getDistictBrand(DataTable dt)
        {
            try
            {
               var query = dt.AsEnumerable().Distinct(new DistictComparer("SKUBrand"));
               query = query.OrderBy(row => row.Field<string>("SKUName"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception ocuur CategoriesService.getVewImageNewMasterDT()", e);
                dt = new DataTable();
                return dt;
            }
            return dt;
        }
        public static DataTable getProductByPTypeId(string productTypeId,int pageNo)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("ProductTypeID") == productTypeId
                      && dr.Field<String>("StyleCode") == String.Empty
                select dr;
                query = query.OrderBy(row => row.Field<string>("SKUName"));
                return applyPagination(pageNo, ref dt, ref query);
        }
        public static DataTable getProductByCatType(string CategoryTypeID,int pageNo)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where
                     dr.Field<String>("CategoryTypeID") == CategoryTypeID
                     && dr.Field<String>("StyleCode") == String.Empty
                select dr;
                 query = query.OrderBy(row => row.Field<string>("SKUName"));
                return   applyPagination(pageNo, ref dt, ref query);
        }
        public static DataTable sort(string SKUCategory, string SKUCategoryType, string min, string max, string productType,string skuBrand,int pageNo)
        {
            
            DataTable dt = GenericService.getVewImageNewMasterDT();

            IEnumerable<DataRow> query=null;
            if (!StringUtil.isNullOrEmpty(productType))
            {
                productType = productType.Trim().Replace("'", "\''");
                query =
                          from dr in dt.AsEnumerable()
                          where dr.Field<String>(Constant.Columns.PRODUCT_TYPE_ID) == productType
                              && dr.Field<String>("StyleCode") == String.Empty
                              && dr.Field<Int32>("SpecialPrice") >= Int32.Parse(min)
                              && dr.Field<Int32>("SpecialPrice") <= Int32.Parse(max)
                          orderby dr.Field<Int32>("SpecialPrice")
                          select dr;
            }
            else
            {
                query =
                          from dr in dt.AsEnumerable()
                          where dr.Field<String>("SKUCategory") == SKUCategory
                              && dr.Field<String>("SKUCategoryType") == SKUCategoryType
                              && dr.Field<String>("StyleCode") == String.Empty
                              && dr.Field<Int32>("SpecialPrice") >= Int32.Parse(min)
                              && dr.Field<Int32>("SpecialPrice") <= Int32.Parse(max)
                          orderby dr.Field<Int32>("SpecialPrice")
                          select dr;
            }
            return applyPagination(pageNo, ref dt, ref query);
        }
        public static DataTable sortToggle(string SKUCategory, string SKUCategoryType, Int32 toggleVal, string productType, string skuBrand,int pageNo)
        {
            productType = productType.Replace("'", "\''");
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query = null;
            if (Constant.Sorting.LOW_TO_HIGH.Equals(toggleVal) && !StringUtil.isNullOrEmpty(productType))
            {
                query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUCategory") == SKUCategory
                            && dr.Field<String>("SKUCategoryType") == SKUCategoryType
                            && dr.Field<String>("StyleCode") == String.Empty
                            && dr.Field<String>(Constant.Columns.PRODUCT_TYPE_ID) == productType
                    orderby dr.Field<Int32>("SpecialPrice") 
                    select dr;
             }
            else if (Constant.Sorting.HIGH_TO_LOW.Equals(toggleVal) && !StringUtil.isNullOrEmpty(productType))
            {
                query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCategory") == SKUCategory
                    && dr.Field<String>("SKUCategoryType") == SKUCategoryType
                    && dr.Field<String>("StyleCode") == String.Empty
                    && dr.Field<String>(Constant.Columns.PRODUCT_TYPE_ID) == productType
                orderby dr.Field<Int32>("SpecialPrice") descending
                select dr;
            }
            else if (Constant.Sorting.HIGH_TO_LOW.Equals(toggleVal) && !StringUtil.isNullOrEmpty(skuBrand))
            {
                query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCategory") == SKUCategory
                    && dr.Field<String>("SKUCategoryType") == SKUCategoryType
                    && dr.Field<String>("StyleCode") == String.Empty
                    && skuBrand.Contains(dr.Field<String>(Constant.Columns.SKU_BRAND).ToLower()) 
                orderby dr.Field<Int32>("SpecialPrice") descending
                select dr;
            }
            else if (Constant.Sorting.LOW_TO_HIGH.Equals(toggleVal) && !StringUtil.isNullOrEmpty(skuBrand))
            {
                query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCategory") == SKUCategory
                    && dr.Field<String>("SKUCategoryType") == SKUCategoryType
                    && dr.Field<String>("StyleCode") == String.Empty
                    && skuBrand.Contains(dr.Field<String>(Constant.Columns.SKU_BRAND).ToLower())
                orderby dr.Field<Int32>("SpecialPrice")
                select dr;
            }
            else if (Constant.Sorting.LOW_TO_HIGH.Equals(toggleVal))
            {
                query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCategory") == SKUCategory
                        && dr.Field<String>("StyleCode") == String.Empty
                        && dr.Field<String>("SKUCategoryType") == SKUCategoryType
                orderby dr.Field<Int32>("SpecialPrice")
                select dr;
            }
            else {
                query =
              from dr in dt.AsEnumerable()
              where dr.Field<String>("SKUCategory") == SKUCategory
                  && dr.Field<String>("SKUCategoryType") == SKUCategoryType
                        && dr.Field<String>("StyleCode") == String.Empty
              orderby dr.Field<Int32>("SpecialPrice") descending
              select dr;
            }
            return applyPagination(pageNo, ref dt, ref query);

        }
        public static DataTable getDistictProductByCatType(string categoryTypeId)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("CategoryTypeID") == categoryTypeId
                orderby dr.Field<String>("SKUProductType")
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("SKUProductType"));
                query = query.OrderBy(row => row.Field<string>("SKUName"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception ocuur CategoriesService.getVewImageNewMasterDT()", e);
                dt = new DataTable();
                return dt;

            }

            return dt;
        }
        public static DataTable getDistictCatType(DataTable dt)
        {
            try
            {
               var query = dt.AsEnumerable().Distinct(new DistictComparer("SKUProductType"));
               query = query.OrderBy(row => row.Field<string>("SKUName"));
                dt = query.CopyToDataTable<DataRow>();
            }   
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception ocuur CategoriesService.getVewImageNewMasterDT()", e);
                dt = new DataTable();
                return dt;

            }

            return dt;
        }
        public static DataTable getDistictProductByCat(string categoryTypeId)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCategory") == categoryTypeId
                orderby dr.Field<String>("SKUBrand")
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("SKUCategory"));
                query = query.OrderBy(row => row.Field<string>("SKUName"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception ocuur CategoriesService.getVewImageNewMasterDT()", e);
                dt = new DataTable();
                return dt;

            }

            return dt;
        }

        public static DataTable getProductByFREE_SEARCH(string searchId, int p)
        {
            searchId = searchId.ToLower();
			
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUName").ToLower().Contains(searchId)
                      || dr.Field<String>("SKUCode").ToLower().Contains(searchId)
                      || dr.Field<String>("SKUProductType").ToLower().Contains(searchId)
                      || dr.Field<String>("SKUCategory").ToLower().Contains(searchId)
                      || dr.Field<String>("SKUCategoryType").ToLower().Contains(searchId)
					  || dr.Field<String>("SKUBrand").ToLower().Contains(searchId)
               
                select dr;
            try
            {
                //query = query.Distinct(new DistictComparer("SKUBrand"));
                query = query.OrderBy(row => row.Field<string>("SKUName"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception ocuur CategoriesService.getVewImageNewMasterDT()", e);
                dt = new DataTable();
                return dt;

            }
            return dt;
        }
        public static DataTable getProductBySKU(string searchId, int p)
        {
            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCode")==searchId
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("SKUBrand"));
                query = query.OrderBy(row => row.Field<string>("SKUName"));
                dt = query.CopyToDataTable<DataRow>();
            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception ocuur CategoriesService.getVewImageNewMasterDT()", e);
                dt = new DataTable();
                return dt;

            }
            return dt;
        }
    }
      
}
