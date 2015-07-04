using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MFO.Common;
using MFO.Constants;
using MFO.Loggers;
using MFO.Services;
using SFloor.DTO;
using MFO.Utils;
using SFloor.DAO;
using MFO.Commom;

/// <summary>
/// Summary description for HomeServices
/// </summary>
/// 
namespace SFloor.Services
{
    public static class HomeService
    {

        public static List<MenuDTO> getMenu()
        { 

            if (HttpContext.Current.Application["MENU"] != null)
                return HttpContext.Current.Application["MENU"] as List<MenuDTO>;

            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("CategoryID") != null
                    && dr.Field<String>("CategoryID") != String.Empty
                orderby dr.Field<String>("SKUCategory")
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("CategoryID"));
                dt = query.CopyToDataTable<DataRow>();

            }
            catch (InvalidOperationException e)
            {
                Logger.Error("Exception occur HomeService.getMenu()", e);
                dt = new DataTable();
            }

            List<MenuDTO> dtos = new List<MenuDTO>();
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                MenuDTO menu = new MenuDTO();
                menu.Heading = dt.Rows[a]["SKUCategory"] + "";
                menu.Url = ConfigUtil.hostURL() + "" + StringUtil.urlEncode(dt.Rows[a]["SKUCategory"] + "").Trim();
                menu.Id = dt.Rows[a]["SKUCategory"] + "-section";
                DataTable dt1 = getSubMenuDT(dt.Rows[a]["CategoryID"] + "");
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    MenuDTO subMenu = new MenuDTO();
                    subMenu.Heading = dt1.Rows[i]["SKUCategoryType"] + "";
                    subMenu.Url = ConfigUtil.hostURL() + "" + StringUtil.urlEncode(dt1.Rows[i]["CategoryTypeUrlName"] + "").Trim();
                    subMenu.Id = dt1.Rows[i]["CategoryTypeID"] + "";
                    DataTable dt2 = getMenuItemDT(dt1.Rows[i]["CategoryTypeID"] + "");
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        MenuDTO menuItem = new MenuDTO();
                        menuItem.Heading = dt2.Rows[j]["SKUProductType"] + "";
                        string str = StringUtil.urlEncode(dt2.Rows[j]["SKUProductType"] + "");
                        menuItem.Url = subMenu.Url.Trim() + "/" + str.Trim();
                        menuItem.Id = dt2.Rows[j]["ProductTypeID"] + "";
                        subMenu.addContent(menuItem);
                    }
                    menu.addContent(subMenu);
                }
                dtos.Add(menu);
                
            }
            HttpContext.Current.Application["MENU"] = dtos;
            return dtos;
        }

        public static DataTable getSubMenuDT(String menuType)
        {

            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("CategoryID") == menuType
                orderby dr.Field<String>("SKUCategoryType")
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("CategoryTypeID"));
                dt = query.CopyToDataTable<DataRow>();

            }
            catch { }
            return dt;
        }
        public static DataTable getMenuItemDT(String menuType)
        {

            DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("CategoryTypeID") == menuType
                orderby dr.Field<String>("SKUProductType")
                select dr;
            try
            {
                query = query.Distinct(new DistictComparer("ProductTypeID"));
                dt = query.CopyToDataTable<DataRow>();

            }
            catch { }
            return dt;
        }
       public static List<MenuDTO> getMenuDT(String menuType) 
       {

           if (HttpContext.Current.Application[menuType] != null)
               return HttpContext.Current.Application[menuType] as List<MenuDTO>;

           DataTable dt = GenericService.getVewImageNewMasterDT();
            IEnumerable<DataRow> query =
                from dr in dt.AsEnumerable()
                where dr.Field<String>("SKUCategory") == menuType
                    && dr.Field<String>("CategoryTypeID") != null
                    && dr.Field<String>("CategoryTypeID") != String.Empty
                orderby dr.Field<String>("SKUCategory")
                select dr;
           try
           {
               query = query.Distinct(new DistictComparer("CategoryTypeID"));
               dt = query.CopyToDataTable<DataRow>();
               
           }
           catch (InvalidOperationException e)
           {
               Logger.Error("Exception occur HomeService.getMenuDT()", e);
               dt = new DataTable();
           }
           List<MenuDTO> dtos = new List<MenuDTO>();
           for (int i=0; i < dt.Rows.Count; i++)
           {
               MenuDTO dto= new MenuDTO();
               dto.Heading = dt.Rows[i]["SKUCategoryType"] + "";
               dto.Url = ConfigUtil.hostURL()+""+ dt.Rows[i]["CategoryTypeUrlName"] + "";
               DataTable dt1 = CategoriesService.getDistictProductByCatType(dt.Rows[i]["CategoryTypeID"] + "");
               for (int j = 0; j <dt1.Rows.Count; j++)
               {
                   MenuDTO subDto = new MenuDTO();
                   subDto.Heading = dt1.Rows[j]["SKUProductType"]+"";
                   string str = StringUtil.urlEncode(dt1.Rows[j]["SKUProductType"] + "");
                   subDto.Url = dto.Url + "/" + str;

                   dto.addContent(subDto);
               }
               dtos.Add(dto);
               HttpContext.Current.Application[menuType] = dtos;
           }
           return dtos;
       }

       public static List<MenuDTO> getBrandMenuDT()
       {

           if (HttpContext.Current.Application[Constant.Application.BRAND_MENU] != null)
               return HttpContext.Current.Application[Constant.Application.BRAND_MENU] as List<MenuDTO>;

           DataTable dt = GenericService.getVewImageNewMasterDT();
           IEnumerable<DataRow> query =
               from dr in dt.AsEnumerable()
               select dr;
           try
           {
               query = query.Distinct(new DistictComparer("SKUCategory"));
               dt = query.CopyToDataTable<DataRow>();

           }
           catch (InvalidOperationException e)
           {
               Logger.Error("Exception occur HomeService.getMenuDT()", e);
               dt = new DataTable();
           }
           List<MenuDTO> dtos = new List<MenuDTO>();
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               MenuDTO dto = new MenuDTO();
               dto.Heading = dt.Rows[i]["SKUCategory"] + "";
               dto.Url = ConfigUtil.hostURL() + "" + dt.Rows[i]["SKUCategory"] + "";
               DataTable dt1 = CategoriesService.getDistictProductByCat(dt.Rows[i]["SKUCategory"] + "");
               for (int j = 0; j < dt1.Rows.Count; j++)
               {
                   MenuDTO subDto = new MenuDTO();
                   subDto.Heading = dt1.Rows[j]["SKUBrand"] + "";
                       subDto.Url = ConfigUtil.hostURL() + "Shop-By-Brand/" + dt1.Rows[j]["SKUCategoryType"] + "?Brand=" + dt1.Rows[j]["SKUBrand"];
                   dto.addContent(subDto);
               }
               dtos.Add(dto);
               if(dtos!=null)
                HttpContext.Current.Application[Constant.Application.BRAND_MENU] = dtos;
           }
           return dtos;
       }

       public static DataTable getFavDT(string sessionId)
       {
           DataTable dt1 = new DataTable();
           if (HttpContext.Current.Session[Constant.Session.FAV_LIST] != null)
           {
               dt1= HttpContext.Current.Session[Constant.Session.FAV_LIST] as DataTable;
           }
           else
           {

               dt1 = FavDAO.getFavDT(sessionId);
               if (!CommonUtil.DT.isEmptyOrNull(dt1))
               {
                   DataTable dt = GenericService.getVewImageNewMasterDT();
                   DataTable dummy = dt.Clone();
                   dummy.Clear();
                   for (int i=0; i < dt1.Rows.Count; i++)
                   {
                       IEnumerable<DataRow> query =
                       from dr in dt.AsEnumerable()
                       where dr.Field<String>("SKUCode") == dt1.Rows[i]["SKU"]+""
                       select dr;
                       try
                       {
                           dummy.ImportRow(query.CopyToDataTable<DataRow>().Rows[0]);
                       }
                       catch (InvalidOperationException e)
                       {
                           Logger.Error("Exception occur HomeService.getMenuDT()", e);
                           dt1 = new DataTable();
                       }
                   }
                   HttpContext.Current.Session[Constant.Session.FAV_LIST] = dummy;
                   dt1 = dummy;
               }
           }
           return dt1;
       }

       public static DataTable getCartDT(string sessionId)
       {
          DataTable dt1 = new DataTable();
           if (HttpContext.Current.Session[Constant.Session.CART_ITEMS] != null)
           {
               dt1= HttpContext.Current.Session[Constant.Session.CART_ITEMS] as DataTable;
           }
           else
           {
               dt1 = CartDAO.getCartDT(sessionId);
               HttpContext.Current.Session[Constant.Session.CART_ITEMS] = dt1;
           }
           return dt1;
       }
       public static String getTotal()
       {
           String total = "";
           if (HttpContext.Current.Session[Constant.Session.TOTAL] != null)
           {
               total = HttpContext.Current.Session[Constant.Session.TOTAL] as String;
           }
           else
           {
               int t = 0;
               DataTable dt=HttpContext.Current.Session[Constant.Session.CART_ITEMS] as DataTable;
               if(!CommonUtil.DT.isEmptyOrNull(dt))
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       t += Int32.Parse(dt.Rows[i]["TOTAL"]+"");
                   }
                   total = t.ToString();
                   HttpContext.Current.Session[Constant.Session.TOTAL] = total;
               }
           }
           return total;
       }
    }
}