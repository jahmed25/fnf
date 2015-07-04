using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Collections.Specialized;
using System.Net.Mail;
using System.IO;
using System.Collections.Generic;
using MFO.DAO;
using MFO.Commom;
using MFO.Loggers;
using MFO.Services;
using MFO.Constants;
using MFO.Utils;
using SFloor.Pages;
using SFloor.DAO;
using SFloor.Services;
public partial class Categories : GenericPage
{

    int seq = 0;
    DataTable dt = null;
    public string catUrl;
    public string catName;
    public string subCatUrl;
    public string subCatName;
    public string pTypeUrl;
    public string pTypeName;
    public string hostURL = ConfigUtil.hostURL();
    public bool isExist;
    public DataTable catDT;
    public DataTable prodDt;
    public DataTable catNameDT;
    public DataTable brandDT;
    public string searchType =null;
    public string searchId = null;
    public override void load(object sender, EventArgs e)
    {
        this.isEnalbleCache = false;
        if (!IsPostBack)
        {
            seq = 0;
             BindGrid();
        }
    }
    private void BindGrid()
    {
        
        String productType = Request.Params["Pid"] == null ? null : Request.Params["Pid"].Trim();
        String catType = Request.Params["CategoryType"] == null ? null : Request.Params["CategoryType"].Trim();
        searchType = Request.Params["searchType"];
        searchId = Request.Params["searchId"];
        if (searchId != null)
        {
            searchId = Request.Params["searchId"].Trim();
            searchType = searchType.Trim().ToLower();
           
            switch (searchType)
            {
                case "product":{
                        prodDt = AjaxService.getProdBySKU(searchId);
                       // prodDt = addColm(prodDt);
                         //ProdList.DataBind();
                         if(!CommonUtil.DT.isEmptyOrNull(prodDt))
                                 productType = prodDt.Rows[0]["ProductTypeID"] as string;
                         break;
                }
                case "category":
                    {
                        catType = searchId;
                        prodDt = CategoriesService.getProductByCatType(searchId, 1);
                        break;
                    }
                case "subcategory":
                    {
                        productType = searchId;
                        prodDt= CategoriesService.getProductByPTypeId(searchId, 1);
                        break;
                    }
                case "brand":
                    {
                        prodDt = CategoriesService.getProductByBrand(searchId, 1);
                        break;
                    }
                case "sku":
                    {

                        prodDt = CategoriesService.getProductBySKU(searchId, 1);
                        productType = prodDt.Rows[0]["ProductTypeID"]+"";
                        break;
                    }
                case "free_search":
                    {
                        prodDt = CategoriesService.getProductByFREE_SEARCH(searchId, 1);
                        break;
                    }
            }
                

        }
        if (searchId == null || "sku".Equals(searchType) || "product".Equals(searchType))
        {
            if (!StringUtil.isNullOrEmpty(productType))
            {
                dt = CategoriesService.getProductByPTypeId(productType, 1);
                if (!CommonUtil.DT.isEmptyOrNull(dt))
                {
                    PType = productType;
                }
            }
            else if (!StringUtil.isNullOrEmpty(catType))
            {
                dt = CategoriesService.getProductByCatType(catType, 1);
            }
          //  CommonUtil.DtNullCheck(dt);
            

        }
      //  if (null != dt && dt.Rows.Count > 0)
        //{
            fillCategory(dt);
            fillCategoryNamePanal();
            fillBrandPanal();
        //}
        String pType = getProductType();
       
    }
    private void fillCategory(DataTable dt)
    {
      //  categories.DataSource = addColm(dt).DefaultView;
       // categories.DataBind();
        catDT = CategoriesService.addColm(dt);
        if (searchId == null)
        {
            
            catName = dt.Rows[0]["SKUCategory"] + "";
            catUrl = ConfigUtil.hostURL() + StringUtil.urlEncode(catName);

            subCatName = dt.Rows[0]["SKUCategoryType"] + "";
            subCatUrl = ConfigUtil.hostURL() + StringUtil.urlEncode(dt.Rows[0]["CategoryTypeUrlName"] + "");

            if (Request.Params["Pid"] != null)
            {
                pTypeName = dt.Rows[0]["SKUProductType"] + "";
                pTypeUrl = subCatUrl + "/" + StringUtil.urlEncode(pTypeName); ;
            }
        }
        else
        {
            prodDt = CategoriesService.addColm(prodDt);
            catName = "Search Result";
            catUrl = "#";
            subCatName = "Search Key- (" + searchId + ")";
          
        }
    }
    private void fillBrandPanal()
    {
        DataTable dt2 = null;
        if (searchId == null)
        {
             dt2 = CategoriesService.getDistictProductByBrand(dt.Rows[0]["CategoryTypeID"] + "");
        }
        else
        {
             dt2 = CategoriesService.getDistictBrand(prodDt );
        }
        if (!CommonUtil.DT.isEmptyOrNull(dt2))
        {
            brandDT = dt2;
        }
    }
   
    public void fillCategoryNamePanal()
    {
        DataTable dt = null;
        if (searchId == null)
        {
            if (!StringUtil.isNullOrEmpty(this.dt.Rows[0]["CategoryTypeID"] + ""))
            {
                dt = CategoriesService.getDistictProductByCatType(this.dt.Rows[0]["CategoryTypeID"] + "");
            }
        }
        else
        {
            dt = CategoriesService.getDistictCatType(prodDt);
        }
     //   CommonUtil.DtNullCheck(dt);
        if (dt.Rows.Count > 0)
        {
            //datalist_categoryname.DataSource = dt;
            catNameDT = dt;
            dt.Columns.Add("url", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["url"] = removeAND(dt.Rows[i]["CategoryTypeUrlName"] + "", dt.Rows[i]["SKUProductType"] + "");
            }
            //datalist_categoryname.DataSource = dt;
            //datalist_categoryname.DataBind();
            catNameDT = dt;
            MainCatHeader.InnerHtml = (String)dt.Rows[0]["SKUCategoryType"];
            String pType = getProductType();

        }
       
    }
    
    String removeAND(string caturl,String productType)
    {
          string url=ConfigUtil.hostURL() + "" +caturl+ "";
          productType = productType.Replace(" ", "-").Replace("&", "").Replace("--", "-");
          return url+="/" + productType;
    }
    
    private String _PType;
    public String PType
    {
        get { return _PType; }
        set { _PType = value; }
    }
    string getProductType()
    {
        String pType = "";
        String[] url = Request.RawUrl.Split('/');
        if (url.Length == 4)
        {
            pType = url[3];
        }
        return pType;
       
    }
    public string next() {
        return (seq++).ToString();
    }
    public string getIconName(object o)
    {
        isExist = FavDAO.isItemExist(Session.SessionID, o.ToString());
        if (isExist)
        {
            return ".wish-list1-active";
        }
        else
        {
            return ".wish-list1";
        }

    }
    public string getToolTip()
    {
        if (isExist)
        {
            return "remove from WishList";
        }
        else
        {
            return "save for Later";
        }
    }
}
