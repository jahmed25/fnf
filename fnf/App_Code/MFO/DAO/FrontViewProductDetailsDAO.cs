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
using MFO.Common;
/// <summary>
/// Summary description for FrontViewProductDetailsClass


namespace MFO.DAO
{
    public class FrontViewProductDetailsDAO
    {

        public DataTable getallhomepagetopbanner()
        {
            return
               GenericDAO.getDataTable("select CategoryName,CategoryTypeName,BrandName,ProductTypeAlias,CategoryTypeAlias,CategoryAlias,ProductTypeName,'http://admin.megafactoryoutlet.com/' + FilePath as FilePath from View_Banner_Master where PageTypeName='Home page' and BannerTypeName = 'Body Banner' order by (PageTypeName) desc");
        }
        public DataTable getallhomepagebanner()
        {
            return GenericDAO.getDataTable("select * from BannerMaster_New where PageTypeName='Home page' order by (PageTypeName) desc ");
        }
        public DataTable getallwomenpagebanner()
        {
            return GenericDAO.getDataTable("select * from BannerMaster_New where PageTypeName='Woman Page' order by (PageTypeName) desc");
        }
        public DataTable getallmenpagebanner()
        {
            return GenericDAO.getDataTable("select * from BannerMaster_New where PageTypeName='Men Page' order by PageTypeName");
        }
        public DataTable getallbabyandkidspagebanner()
        {
            return GenericDAO.getDataTable("select * from View_Banner_Master where PageTypeName='Baby & Kids Page' order by PageTypeName");
        }
        public DataTable getallhomeanddecorpagebanner()
        {

            return
              GenericDAO.getDataTable("select * from BannerMaster_New where PageTypeName='Home & Décor Page' order by PageTypeName");
        }
        public DataTable getskuidwithcolor(string stylecode, string color)
        {

            return
               GenericDAO.getDataTable("select * from PRODUCTS where StyleCode='" + stylecode + "' and Color='" + color + "'");


        }
        public DataTable getskuidwithsize(string stylecode, string skucode)
        {
            return
              GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + stylecode + "' and StyleCode='" + skucode + "' ");

        }
        public DataTable getskuidwithsizeformorethanone(string skucode)
        {

            return
               GenericDAO.getDataTable("select * from PRODUCTS where SKUCode ='" + skucode + "'");
        }
        public DataTable getskuidwithsize(string stylecode)
        {
            return
               GenericDAO.getDataTable("( select distinct(Size), case Size when 'xs' then 1 when 's' then 2  WHEN 'M' THEN 3  WHEN 'L' THEN 4  WHEN 'XL' THEN 5 when 'XXL' then 6 ELSE 0  END as SizeSortOrder   from PRODUCTS   where StyleCode='" + stylecode + "' and StyleCode!='' and StyleCode is not null )  order by SizeSortOrder asc");
        }
        public DataTable getsizealldata(string stylecode)
        {
            return
                  GenericDAO.getDataTable("( select distinct(Size), case Size when 'xs' then 1 when 's' then 2  WHEN 'M' THEN 3  WHEN 'L' THEN 4  WHEN 'XL' THEN 5 when 'XXL' then 6 ELSE 0 END as SizeSortOrder from PRODUCTS  where StyleCode='" + stylecode + "' and StyleCode!='' and StyleCode is not null )order by SizeSortOrder asc");
        }
        public DataTable getcoloralldata(string stylecode)
        {
            return
                GenericDAO.getDataTable("select distinct(Color),ColorCode from PRODUCTS where StyleCode='" + stylecode + "' and Color!='' and Color is not null");
        }

        public DataTable getsmallimagedifferentcolordata(string stylecode, string color)
        {
            return
               GenericDAO.getDataTable("select Top 1 PathInternaldetailsSmallImage,SKUCode from PRODUCTS where StyleCode='" + stylecode + "' and Color='" + color + "' and Color!='' and Color is not null");
        }
        public DataTable gethoverimage(string productskucode)
        {
            return
                  GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + productskucode + "'");
        }
        public DataTable gethoverimage(string productskucode, string imageHover)
        {
            return
              GenericDAO.getDataTable("select * from PRODUCTS where StyleCode='" + productskucode + "' and PathInternaldetailsHoverImage = '" + imageHover + "' union select * from PRODUCTS where StyleCode='" + productskucode + "' and PathInternaldetailsHoverImage = '" + imageHover + "' union select * from PRODUCTS where StyleCode='" + productskucode + "' and PathInternaldetailsHoverImage = '" + imageHover + "'");
        }
        public DataTable getsmallimage(string smallproductskucode)
        {
            return
               GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + smallproductskucode + "'");
        }
        public DataTable geproductdetails()
        {
            return
                 GenericDAO.getDataTable("select * from View_Product_Master where ImageTypeName='Mega Sale'");
        }
        public DataTable geproductdetailsnewarrivals()
        {
            return
                GenericDAO.getDataTable("select Top 8 * from PRODUCTS where CategoryID = 'WO' and CategoryTypeID = 'WOB' and SKUBrand = 'Joey & Phoebe' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = 'WO' and CategoryTypeID = 'WOB'  and SKUBrand = 'Joey & Phoebe' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = 'WO' and CategoryTypeID = 'WOB'  and SKUBrand = 'Joey & Phoebe' and VariantType='Color' and (StyleCode='' or StyleCode is null)");
        }
        public DataTable geproductdetailspopularpic()
        {
            return
                  GenericDAO.getDataTable("select Top 8 * from PRODUCTS where CategoryID = 'WO' and CategoryTypeID = 'WOCL' and SKUBrand = 'Diva Collection' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = 'WO' and CategoryTypeID = 'WOCL'  and SKUBrand = 'Diva Collection' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = 'WO' and CategoryTypeID = 'WOCL'  and SKUBrand = 'Diva Collection' and VariantType='Color' and (StyleCode='' or StyleCode is null)");
        }
        public DataTable getcategorytypedetails()
        {
            return
                GenericDAO.getDataTable("select * from View_Product_Master");
        }
        public DataTable getrandomimage()
        {
            return
                  GenericDAO.getDataTable("SELECT TOP 1 * FROM View_Product_Master where ImageTypeName='Bags Offer' ORDER BY newid()");

        }
        public DataTable getcategorydetails(string productskucode)
        {
            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + productskucode + "'");

        }
        public DataTable getcategorydetails(string productskucode, string styleCode)
        {
            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + productskucode + "' or StyleCode='" + styleCode + "'");

        }
        public DataTable isStyleCode(string productskucode)
        {
            return
                   GenericDAO.getDataTable("select * from PRODUCTS where StyleCode='" + productskucode + "' order by  Size asc");

        }
        public DataTable getProdByStyleColorSize(String styleCode, string color, String size)
        {
            return
                GenericDAO.getDataTable("select * from PRODUCTS where StyleCode='" + styleCode + "' and Color='" + color + "' and Size='" + size + "'");

        }
        public DataTable getProdBySkuColorSize(String sku, string color, String size)
        {
            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + sku + "' and Color='" + color + "' and Size='" + size + "'");

        }
        public DataTable getVarientProduct(String style, string color, String size)
        {
            return
                GenericDAO.getDataTable("select * from PRODUCTS where StyleCode='" + style + "' and Color='" + color + "' and Size='" + size + "'");
        }
        public DataTable getSkuCode1(String styleCode, string color, String size)
        {
            return
                 GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + styleCode + "' and Color='" + color + "' and Size='" + size + "'");

        }
        public DataTable getProdByStyleColor(String styleCode, string color)
        {
            return
                  GenericDAO.getDataTable("select * from PRODUCTS where StyleCode='" + styleCode + "' and Color='" + color + "'");

        }
        public DataTable getSkuCodeByColor1(String styleCode, string color)
        {
            return
                 GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + styleCode + "' and Color='" + color + "'");

        }
        public DataTable getProdByStyleSize(String styleCode, string size)
        {
            return
                 GenericDAO.getDataTable("select * from PRODUCTS where StyleCode='" + styleCode + "' and Size='" + size + "'");

        }
        public DataTable getSkuCodeBySize1(String styleCode, string size)
        {
            return
                  GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + styleCode + "' and Size='" + size + "'");


        }
        public DataTable getaddtowishlistdetails(string SKUCode)
        {
            return
                  GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + SKUCode + "'");

        }
        public DataTable getindexinternalproductdetails()
        {

            return
              GenericDAO.getDataTable("select * from PRODUCTS where SKUProductType='Coaster & Lamps'");


        }
        public DataTable gethomebodybannerindexinternalproductdetails()
        {
            return
                  GenericDAO.getDataTable("select * from PRODUCTS where SKUProductType='Saree'");


        }
        public DataTable getmenuwomenallsalesindexinternalproductdetails()
        {
            return
                 GenericDAO.getDataTable("select * from PRODUCTS where SKUCategory='Women'");


        }
        public DataTable getshopbybrandsbasedalldata(string SKUCategoryType, string SKUBrand)
        {
            SKUBrand = SKUBrand.Replace("'", "\''");
            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and SKUBrand like '%" + SKUBrand + "' and SKUClassification='Normal' and SKUStatus='Active' union select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and SKUBrand like '%" + SKUBrand + "'and VariantType='Size' and SKUStatus='Active' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and SKUBrand like '%" + SKUBrand + "'and VariantType='Color' and SKUStatus='Active' and (StyleCode='' or StyleCode is null) order by PRODUCTS desc");



        }
        public DataTable getshopbybrandsbasedalldata(string SKUCategoryType)
        {

            return
               GenericDAO.getDataTable("select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "'  and SKUClassification='Normal' union select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and VariantType='Color' and (StyleCode='' or StyleCode is null)");



        }
        public DataTable getwomenhomebagsdatatest(string SKUCategory, string SKUCategoryType, string SKUBrand)
        {
            return
                 GenericDAO.getDataTable("select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and CategoryTypeID = '" + SKUCategoryType + "' and SKUBrand like '" + SKUBrand + "%' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and CategoryTypeID = '" + SKUCategoryType + "'  and SKUBrand like '" + SKUBrand + "%' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and CategoryTypeID = '" + SKUCategoryType + "'  and SKUBrand like '" + SKUBrand + "%' and VariantType='Color' and (StyleCode='' or StyleCode is null)");



        }
        public DataTable getwomenhomebagsdata(string SKUCategory, string SKUCategoryType, string pType, string brand)
        {
            return
                   GenericDAO.getDataTable(@"select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and CategoryTypeID = '" + SKUCategoryType + "'"
                                   + " and ProductTypeID='" + pType + "' and SKUBrand='" + brand + "' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = '" + SKUCategory + "'"
                                   + "and CategoryTypeID = '" + SKUCategoryType + "'and ProductTypeID='" + pType + "' and SKUBrand='" + brand + "' and VariantType='Size' and (StyleCode='' or StyleCode is null)"
                                   + "union select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and CategoryTypeID = '" + SKUCategoryType + "'"
                                   + " and ProductTypeID='" + pType + "' and SKUBrand='" + brand + "' and VariantType='Color' and (StyleCode!='' and StyleCode is not null) ORDER BY (SpecialPrice) DESC");

        }
        public DataTable getProductType(string SKUCategory, string SKUCategoryType)
        {

            return
                GenericDAO.getDataTable("select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID,SKUStatus,RecordStatus from PRODUCTS where CategoryID = '" + SKUCategory + "' and CategoryTypeID = '" + SKUCategoryType + "' and SKUStatus='Active' and RecordStatus='1' and SKUClassification='Normal' union select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID,SKUStatus,RecordStatus from PRODUCTS where CategoryID = '" + SKUCategory + "' and CategoryTypeID = '" + SKUCategoryType + "' and SKUStatus='Active' and RecordStatus='1' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID,SKUStatus,RecordStatus from PRODUCTS where CategoryID = '" + SKUCategory + "' and CategoryTypeID = '" + SKUCategoryType + "' and SKUStatus='Active' and RecordStatus='1' and VariantType='Color' and (StyleCode!='' and StyleCode is not null) ORDER BY (SKUProductType)");

        }
        public DataTable getProductTypeBySKUBrand(string SKUCategory, string SKUBrand)
        {
            return
                   GenericDAO.getDataTable("select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID,SKUStatus from PRODUCTS where SKUCategoryType = '" + SKUCategory + "' and SKUBrand = '" + SKUBrand + "' and SKUStatus='Active' and SKUClassification='Normal' union select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID,SKUStatus from PRODUCTS where SKUCategoryType = '" + SKUCategory + "' and SKUBrand = '" + SKUBrand + "' and SKUStatus='Active' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID,SKUStatus from PRODUCTS where SKUCategoryType = '" + SKUCategory + "' and SKUBrand = '" + SKUBrand + "' and SKUStatus='Active' and VariantType='Color' and (StyleCode!='' and StyleCode is not null) ORDER BY (SKUProductType)");

        }

        // MenShirt Query *****************************************************************************



        public DataTable getProductTypeBySKUBrandType(string SKUCategory, string SKUBrand)
        {

            return
               GenericDAO.getDataTable("select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID from PRODUCTS where CategoryTypeID = '" + SKUCategory + "' and SKUBrand = '" + SKUBrand + "' and SKUClassification='Normal' union select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID from PRODUCTS where CategoryTypeID = '" + SKUCategory + "' and SKUBrand = '" + SKUBrand + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID from PRODUCTS where CategoryTypeID = '" + SKUCategory + "' and SKUBrand = '" + SKUBrand + "' and VariantType='Color' and (StyleCode!='' and StyleCode is not null) ORDER BY (SKUProductType)");



        }
        public DataTable getProductTypeID(string productTypeID)
        {
            return
                 GenericDAO.getDataTable("select * from PRODUCTS where  ProductTypeID = '" + productTypeID + "' and SKUStatus='Active' and RecordStatus='1' and SKUClassification='Normal' union select * from PRODUCTS where  ProductTypeID = '" + productTypeID + "' and SKUStatus='Active' and RecordStatus='1' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where  ProductTypeID = '" + productTypeID + "' and SKUStatus='Active' and RecordStatus='1' and VariantType='Color' and (StyleCode!='' and StyleCode is not null) Order by SKUBrand asc");


        }
        public DataTable getProductType_1(string SKUCategoryType, string SKUBrand)
        {
            return
                   GenericDAO.getDataTable("select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID from PRODUCTS where SKUBrand = '" + SKUBrand + "' and CategoryTypeID = '" + SKUCategoryType + "' and SKUClassification='Normal' union select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID from PRODUCTS where SKUBrand = '" + SKUBrand + "' and CategoryTypeID = '" + SKUCategoryType + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select distinct(SKUProductType),SKUCategory,SKUCategoryType,CategoryTypeID,ProductTypeID from PRODUCTS where SKUBrand = '" + SKUBrand + "' and CategoryTypeID = '" + SKUCategoryType + "' and VariantType='Color' and (StyleCode!='' and StyleCode is not null) ORDER BY (SKUProductType)");


        }
        public DataTable getProductByProductTypeId(string productTypeID, string SKUBrand)
        {
            return
                   GenericDAO.getDataTable("select * from PRODUCTS where  ProductTypeID = '" + productTypeID + "' and SKUBrand ='" + SKUBrand + "' and SKUClassification='Normal' union select * from PRODUCTS where  ProductTypeID = '" + productTypeID + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where  ProductTypeID = '" + productTypeID + "'and SKUBrand ='" + SKUBrand + "' and VariantType='Color' and (StyleCode!='' and StyleCode is not null) ORDER BY (SKUProductType)");


        }

        public DataTable getsearchbycategorydata(string CategoryID, Int32 randamVal)
        {
            switch (randamVal)
            {
                case 1:
                    return GenericDAO.getDataTable("select * from PRODUCTS where CategoryID = '" + CategoryID + "' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Color' and (StyleCode='' or StyleCode is null) ORDER BY (PRODUCTS) DESC");
                case 2:
                    return GenericDAO.getDataTable("select * from PRODUCTS where CategoryID = '" + CategoryID + "' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Color' and (StyleCode='' or StyleCode is null) ORDER BY (PRODUCTS)");
                case 3:
                    return GenericDAO.getDataTable("select * from PRODUCTS where CategoryID = '" + CategoryID + "' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Color' and (StyleCode='' or StyleCode is null) ORDER BY (CategoryID) DESC");
                case 4:
                    return GenericDAO.getDataTable("select * from PRODUCTS where CategoryID = '" + CategoryID + "' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Color' and (StyleCode='' or StyleCode is null) ORDER BY (CategoryID)");
                default:
                    return GenericDAO.getDataTable("select * from PRODUCTS where CategoryID = '" + CategoryID + "' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = '" + CategoryID + "' and VariantType='Color' and (StyleCode='' or StyleCode is null) ORDER BY (VariantType) ");
            }
        }
        public DataTable getsearchbycategorytypedata(string SKUCategoryType)
        {
            return
                  GenericDAO.getDataTable("select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and SKUClassification='Normal' union select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and VariantType='Color' and (StyleCode='' or StyleCode is null) ORDER BY (PRODUCTS) DESC");


        }
        public DataTable getsearchbyproducttypebydata(string SKUProductType)
        {
            return
                  GenericDAO.getDataTable("select * from PRODUCTS where SKUProductType = '" + SKUProductType + "' and SKUClassification='Normal' union select * from PRODUCTS where SKUProductType = '" + SKUProductType + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where SKUProductType = '" + SKUProductType + "' and VariantType='Color' and (StyleCode='' or StyleCode is null) ORDER BY (PRODUCTS) DESC");


        }
        public DataTable getsearchsingleproductdata(string SKUName)
        {
            return
                   GenericDAO.getDataTable("select * from PRODUCTS where SKUName = '" + SKUName + "'");



        }
        public DataTable getsitemapallbranddata(string SKUBrand)
        {

            SKUBrand = SKUBrand.Replace("'", "\''");
            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUBrand Like '" + SKUBrand + "%' and SKUClassification='Normal' union select * from PRODUCTS where SKUBrand Like '" + SKUBrand + "%' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where SKUBrand Like '" + SKUBrand + "%' and VariantType='Color' and (StyleCode='' or StyleCode is null)");




        }
        public DataTable getmenuwomenbrandindexinternalproductdetails(string womenbrand)
        {

            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUBrand='" + womenbrand + "'");


        }
        public DataTable getsizeproductdetails()
        {

            return
                GenericDAO.getDataTable("select * from View_Product_Size_InsertTable");




        }
        public DataTable gettestimage()
        {
            return
                   GenericDAO.getDataTable("select * from View_Product_Master where Product_ID=33");
        }
        public DataTable getskucatcattypebrandproducttype1(string SKUCategoryType)
        {
            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUCategoryType='" + SKUCategoryType + "'");
        }
        public DataTable getskucatcattypebrandproducttype(string SKUID)
        {
            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUBrand='" + SKUID + "'");
        }
        public DataTable getbrandselecteddata(string SKUCategory, string SKUCategoryType, string SKUBrand)
        {
            SKUBrand = SKUBrand.Replace("'", "\''");
            return
                GenericDAO.getDataTable("select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and SKUCategoryType = '" + SKUCategoryType + "' and SKUBrand like '" + SKUBrand + "%' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and SKUCategoryType = '" + SKUCategoryType + "'  and SKUBrand like '" + SKUBrand + "%' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and SKUCategoryType = '" + SKUCategoryType + "'  and SKUBrand like '" + SKUBrand + "%' and VariantType='Color' and (StyleCode='' or StyleCode is null)");
        }
        public DataTable getviewallbycategorybrandselecteddata(string SKUCategory, string SKUBrand)
        {
            return
                   GenericDAO.getDataTable("select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and SKUBrand like '" + SKUBrand + "%' and SKUClassification='Normal' union select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and SKUBrand like '" + SKUBrand + "%' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where CategoryID = '" + SKUCategory + "' and SKUBrand like '" + SKUBrand + "%' and VariantType='Color' and (StyleCode='' or StyleCode is null)");
        }
        public DataTable getsitemapbrandselecteddata(string SKUBrand)
        {
            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUBrand like '" + SKUBrand + "%' and SKUClassification='Normal' union select * from PRODUCTS where SKUBrand like '" + SKUBrand + "%' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where SKUBrand like '" + SKUBrand + "%' and VariantType='Color' and (StyleCode='' or StyleCode is null)");
        }
        public DataTable getsitemapbrandselectedcategorydata(string SKUCategoryType)
        {
            return
                   GenericDAO.getDataTable("select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and SKUClassification='Normal' union select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "'  and VariantType='Color' and (StyleCode='' or StyleCode is null)");

        }
        public DataTable getbrandselectedcategorydata(string SKUCategory, string SKUCategoryType)
        {
            return
                   GenericDAO.getDataTable("select * from PRODUCTS where SKUCategory = '" + SKUCategory + "' and SKUCategoryType = '" + SKUCategoryType + "' and SKUClassification='Normal' union select * from PRODUCTS where SKUCategory = '" + SKUCategory + "' and SKUCategoryType = '" + SKUCategoryType + "' and VariantType='Size' and (StyleCode='' or StyleCode is null) union select * from PRODUCTS where SKUCategory = '" + SKUCategory + "' and SKUCategoryType = '" + SKUCategoryType + "'  and VariantType='Color' and (StyleCode='' or StyleCode is null)");


        }
        public DataTable getbrandbycategorydata(string SKUCategory, string SKUCategoryType)
        {
            return
                  GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where SKUCategory = '" + SKUCategory + "' and SKUCategoryType = '" + SKUCategoryType + "'");
        }
        public DataTable getsitmapbrandbycategorydata(string SKUCategoryType)
        {
            return
                   GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where SKUCategoryType = '" + SKUCategoryType + "'");
        }

        public DataTable getsitemapbranddata(string SKUBrand)
        {
            return
               GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where SKUBrand like '" + SKUBrand + "%'");
        }
        public DataTable getbranddata(string SKUCategory, string SKUCategoryType)
        {
            return
                 GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where CategoryID='" + SKUCategory + "' and CategoryTypeID='" + SKUCategoryType + "'");
        }

        public DataTable getbrandtoptenbranddata(string SKUCategory, string SKUBrand)
        {
            return
                 GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where CategoryID='" + SKUCategory + "' and SKUBrand like '" + SKUBrand + "%'");
        }
        public DataTable getbrandsearchcategorydata(string CategoryID)
        {
            return
                 GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where CategoryID='" + CategoryID + "'");
        }
        public DataTable getbrandsearchcategorytypedata(string SKUCategoryType)
        {
            return
                  GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where SKUCategoryType='" + SKUCategoryType + "'");
        }
        public DataTable getbrandsearchproducttypedata(string SKUProductType)
        {
            return
                 GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where SKUProductType='" + SKUProductType + "'");
        }
        public DataTable getbrandsearchskunamedata(string SKUName)
        {
            return
                  GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where SKUName='" + SKUName + "'");
        }
        public DataTable getbrandshopalldata(string SKUCategory)
        {
            return
                  GenericDAO.getDataTable("select distinct(SKUBrand) from PRODUCTS where CategoryID='" + SKUCategory + "'");
        }
        public DataTable getsearchbycategoriesdata(string CategoryID)
        {
            return
                GenericDAO.getDataTable("select distinct(SKUCategoryType) from PRODUCTS where CategoryID='" + CategoryID + "'");
        }

        public DataTable getsearchbycategoriestypedata(string SKUCategoryType)
        {
            return
                  GenericDAO.getDataTable("select distinct(SKUCategoryType) from PRODUCTS where SKUCategoryType='" + SKUCategoryType + "'");
        }
        public DataTable getsearchbyproducttypedata(string SKUProductType)
        {
            return
                  GenericDAO.getDataTable("select distinct(SKUCategoryType) from PRODUCTS where SKUProductType='" + SKUProductType + "'");
        }
        public DataTable getsearchbyskunamedata(string SKUName)
        {
            return
                   GenericDAO.getDataTable("select distinct(SKUCategoryType) from PRODUCTS where SKUName='" + SKUName + "'");
        }
        public DataTable getcategoriesdata(string SKUCategory)
        {
            return
                 GenericDAO.getDataTable("select distinct(SKUCategoryType) from PRODUCTS where CategoryID='" + SKUCategory + "'");
        }
        public DataTable getsitemapcategoriesdata()
        {
            return
                  GenericDAO.getDataTable("select distinct(SKUCategoryType) from PRODUCTS where SKUCategoryType is not null and SKUCategoryType!='' order by SKUCategoryType");
        }

        public DataTable getcategorydetailsscrolldata(string ScrollProductType)
        {
            return
                  GenericDAO.getDataTable("select * from PRODUCTS where SKUProductType='" + ScrollProductType + "' and SKUStatus='Active' and RecordStatus='1' and (SKUClassification='Normal' or SKUClassification='Style') Order by SKUBrand asc ");
        }
        public DataTable getcategorysizedata()
        {
            return
               GenericDAO.getDataTable("select * from PRODUCTS");
        }
        public DataTable getallstate()
        {
            return
                 GenericDAO.getDataTable("select * from View_StateMaster");

        }
        public DataTable getsitemapalldata(string SKUCode)
        {
            return
                 GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + SKUCode + "'");
        }
        #region FillProductType
        public DataTable getproducttypeonclickbanner(string SKUCategory, string SKUCategoryType)
        {
            return
                  GenericDAO.getDataTable("select distinct(SKUProductType) from PRODUCTS where CategoryID='" + SKUCategory + "' and CategoryTypeID='" + SKUCategoryType + "'");
        }
        public DataTable getproducttypeonclickbrand(string SKUBrand)
        {
            return
                  GenericDAO.getDataTable("select distinct(SKUProductType) from PRODUCTS where SKUBrand like'" + SKUBrand + "%'");
        }


        public DataTable getOfferImage()
        {
            return
                 GenericDAO.getDataTable("select * from BannerMaster_New where PageTypeName='Mega Offer Page' order by (PageTypeName)desc ");
        }

        #endregion

        public int? getProductIDBySkuOrStyle(String skuOrStyle)
        {
            int? pId = null;
            if (null == skuOrStyle || "".Equals(skuOrStyle.Trim()))
                return null;
            else
            {
                DataTable pIdStr = GenericDAO.getDataTable("Select top(1) ProductNewID  from PRODUCTS where StyleCode='' AND SKUCode='" + skuOrStyle + "'");
                if (null == pIdStr || pIdStr.Rows.Count == 0)
                {
                    pIdStr = GenericDAO.getDataTable("Select top(1)  StyleCode from PRODUCTS where SKUCode= '" + skuOrStyle + "'");
                    if (pIdStr != null && pIdStr.Rows.Count > 0)
                        pIdStr = GenericDAO.getDataTable("Select top(1) ProductNewID  from PRODUCTS where StyleCode='' AND SKUCode='" + pIdStr.Rows[0]["StyleCode"] + "'");
                }
                if (pIdStr != null && pIdStr.Rows.Count > 0)
                    pId = Int32.Parse(pIdStr.Rows[0]["ProductNewID"].ToString());
            }
            return pId;
        }

        public DataTable getProdBySkuColor(string sku, string color)
        {
            return
                 GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + sku + "' and Color='" + color + "'");
        }

        public DataTable getProdBySkuSize(string sku, string size)
        {
            return
                GenericDAO.getDataTable("select * from PRODUCTS where SKUCode='" + sku + "' and Size='" + size + "'");
        }
    }
}