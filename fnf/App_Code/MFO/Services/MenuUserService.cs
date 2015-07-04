using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MFO.DAO;
using MFO.Constants;
using MFO.Utils;
using MFO.Common;
using MFO.Loggers;

/// <summary>
/// Summary description for MenuUserControlService
/// </summary>
/// 

namespace MFO.Services{
    
    public static class MenuUserService
    {
        private static MenuUserDAO menuDAO = new MenuUserDAO();
        public static DataTable getWomenCategoryDT()
        {
            DataTable dt = null;
            if (HttpContext.Current.Application[Constant.Application.WOMEN_CAT_DT] == null)
            {
                dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUCategory") == Constant.ColumnValue.WOMEN
                        && dr.Field<String>("CategoryTypeID") != null
                        && dr.Field<String>("CategoryTypeID") != String.Empty
                        orderby dr.Field<String>("SKUCategory")
                    select dr;
                try
                {
                    query = query.Distinct(new DistictComparer("CategoryTypeID"));
                    dt = query.CopyToDataTable<DataRow>();
                    HttpContext.Current.Application[Constant.Application.WOMEN_CAT_DT] = dt;
                }
                catch (InvalidOperationException e)
                {
                    Logger.Error("Exception occur CategoriesService.getCategoryDT()", e);
                    dt = new DataTable();
                }
            }
            else if (HttpContext.Current.Application[Constant.Application.WOMEN_CAT_DT] !=null)
            {
                dt= (DataTable)HttpContext.Current.Application[Constant.Application.WOMEN_CAT_DT];
            }
            return dt;

        }
        public static DataTable getMenCategoryDT()
        {
            DataTable dt = null;
            if (HttpContext.Current.Application[Constant.Application.MEN_CAT_DT] == null)
            {
                dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUCategory") == Constant.ColumnValue.MEN
                        && dr.Field<String>("CategoryTypeID") != null
                        && dr.Field<String>("CategoryTypeID") != String.Empty
                        orderby dr.Field<String>("SKUCategory")
                    select dr;
                try
                {
                    query = query.Distinct(new DistictComparer("CategoryTypeID"));
                    dt = query.CopyToDataTable<DataRow>();
                    HttpContext.Current.Application[Constant.Application.MEN_CAT_DT] = dt;
                }
                catch (InvalidOperationException e)
                {
                    Logger.Error("Exception occur CategoriesService.getCategoryDT()", e);
                    dt = new DataTable();
                }
            }
            else if (HttpContext.Current.Application[Constant.Application.MEN_CAT_DT] != null)
            {
                dt= (DataTable)HttpContext.Current.Application[Constant.Application.MEN_CAT_DT];
            }
            return dt;

        }
        public static DataTable getHomeDecorCategoryDT()
        {
            DataTable dt = null;
            if (HttpContext.Current.Application[Constant.Application.HOME_DECOR_CAT_DT] == null)
            {
                dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUCategory") == Constant.ColumnValue.HOME_DECOR
                        && dr.Field<String>("CategoryTypeID") != null
                        && dr.Field<String>("CategoryTypeID") != String.Empty
                    orderby dr.Field<String>("SKUCategory")
                    select dr;
                try
                {
                    query = query.Distinct(new DistictComparer("CategoryTypeID"));
                    dt = query.CopyToDataTable<DataRow>();
                    HttpContext.Current.Application[Constant.Application.HOME_DECOR_CAT_DT] = dt;
                }
                catch (InvalidOperationException e)
                {
                    Logger.Error("Exception occur CategoriesService.getCategoryDT()", e);
                    dt = new DataTable();
                }
            }
            else if (HttpContext.Current.Application[Constant.Application.HOME_DECOR_CAT_DT] != null)
            {
                dt = (DataTable)HttpContext.Current.Application[Constant.Application.HOME_DECOR_CAT_DT];
            }
            return dt ;

        }

        public static DataTable getBrandByBegsDT()
        {
            DataTable dt = null;
            if (HttpContext.Current.Application[Constant.Application.SHOP_BY_BAGS] == null)
            {
                dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUCategoryType") == Constant.ColumnValue.BAGS
                    orderby dr.Field<String>("SKUBrand")
                    select dr;
                try
                {
                    query = query.Distinct(new DistictComparer("SKUBrand"));
                    dt = query.CopyToDataTable<DataRow>();
                    HttpContext.Current.Application[Constant.Application.SHOP_BY_BAGS] = dt;
                }
                catch (InvalidOperationException e)
                {
                    Logger.Error("Exception occur CategoriesService.getBrandByBegsDT()", e);
                    dt = new DataTable();
                    }
            }
            else if (HttpContext.Current.Application[Constant.Application.SHOP_BY_BAGS] != null)
            {
                dt = (DataTable)HttpContext.Current.Application[Constant.Application.SHOP_BY_BAGS];
            }
            return dt;
        }
        public static DataTable getBrandByClothingDT()
        {
            DataTable dt = null;
            if (HttpContext.Current.Application[Constant.Application.SHOP_BY_CLOTHING] == null)
            {
                dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUCategoryType") == Constant.ColumnValue.CLOTHING
                    orderby dr.Field<String>("SKUBrand")
                    select dr;
                try
                {
                    query = query.Distinct(new DistictComparer("SKUBrand"));
                    dt = query.CopyToDataTable<DataRow>();
                    HttpContext.Current.Application[Constant.Application.SHOP_BY_CLOTHING] = dt;
                }
                catch (InvalidOperationException e)
                {
                    Logger.Error("Exception occur CategoriesService.getBrandByClothingDT()", e);
                    dt = new DataTable();
                 }
            }
            else if (HttpContext.Current.Application[Constant.Application.SHOP_BY_CLOTHING] != null)
            {
                dt = (DataTable)HttpContext.Current.Application[Constant.Application.SHOP_BY_CLOTHING];
            }
            return dt;
        }
        public static DataTable getBrandByAccessoriesgDT()
        {
            DataTable dt = null;
            if (HttpContext.Current.Application[Constant.Application.SHOP_BY_ACCESSORIES] == null)
            {
                dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUCategoryType") == Constant.ColumnValue.ACCESSORIES
                    orderby dr.Field<String>("SKUBrand")
                    select dr;
                try
                {
                    query = query.Distinct(new DistictComparer("SKUBrand"));
                    dt = query.CopyToDataTable<DataRow>();
                    HttpContext.Current.Application[Constant.Application.SHOP_BY_ACCESSORIES] = dt;
                }
                catch (InvalidOperationException e)
                {
                    Logger.Error("Exception occur CategoriesService.getBrandByAccessoriesgDT()", e);
                    dt = new DataTable();
                }
            }
            else if (HttpContext.Current.Application[Constant.Application.SHOP_BY_ACCESSORIES] != null)
            {
                dt = (DataTable)HttpContext.Current.Application[Constant.Application.SHOP_BY_ACCESSORIES];
            }
            return dt;
        }
        public static DataTable getBrandByFootweargDT()
        {
            DataTable dt = null;
            if (HttpContext.Current.Application[Constant.Application.SHOP_BY_FOOTWEAR] == null)
            {
                dt = GenericService.getVewImageNewMasterDT();
                IEnumerable<DataRow> query =
                    from dr in dt.AsEnumerable()
                    where dr.Field<String>("SKUCategoryType") == Constant.ColumnValue.FOOTWEAR
                    orderby dr.Field<String>("SKUBrand")
                    select dr;
                try
                {
                    query = query.Distinct(new DistictComparer("SKUBrand"));
                    dt = query.CopyToDataTable<DataRow>();
                    HttpContext.Current.Application[Constant.Application.SHOP_BY_FOOTWEAR] = dt;
                }
                catch (InvalidOperationException e)
                {
                    Logger.Error("Exception occur CategoriesService.getBrandByFootweargDT()", e);
                    dt = new DataTable();
                 }
            }
            else if (HttpContext.Current.Application[Constant.Application.SHOP_BY_FOOTWEAR] != null)
            {
                dt = (DataTable)HttpContext.Current.Application[Constant.Application.SHOP_BY_FOOTWEAR];
            }
            return dt;
        }

    }
}