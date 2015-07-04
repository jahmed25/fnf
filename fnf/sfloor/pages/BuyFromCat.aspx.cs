using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MFO.Services;
using SFloor.Services;
using MFO.DAO;
using MFO.Commom;
using MFO.Utils;
using SFloor.DAO;

public partial class sfloor_pages_BuyFromCat : System.Web.UI.Page
{
    public string style;
    public string SKUClassification, VariantType;
    public string qty;
    public string size;
    public string color;
    public string isSize;
    public string isColor;
    public string isSku;
    public string avalibilty = "In Stock";
    public int? inventory = 0;
    public int index = 1;
    protected DataTable dt = new DataTable();
    protected DataTable relProductDT = new DataTable();
    protected DataTable recentProductTD = new DataTable();
    protected DataTable sizeDT = null;
    protected DataTable colorDT = null;


    public void Page_Load(object sender, EventArgs e)
    {
        style = Request.QueryString["bfc"];
        applypagging();
        qty = Request.QueryString["qty"];
        size = Request.QueryString["size"];
        color = Request.QueryString["color"];
        isSize = Request.QueryString["isSize"];
        isColor = "false";//Request.QueryString["isColor"];
        isSku = Request.QueryString["isSku"];
        updateRecentView(style);
        if (!IsPostBack)
        {
            dt = CategoryDetailsService.getDTBySKU(style);
            fillproductdetails();
            fillReatedProductType();
            fillRecentView();
            dt = CategoriesService.addColm(dt);
        }

    }

    public string getToolTip()
    {
       bool isExist = FavDAO.isItemExist(Session.SessionID, dt.Rows[0]["SKUCode"]+"");
        if (isExist)
        {
            return "Remove From Wish-List";
        }
        else
        {
            return "Add to Wish list";
        }

    }

   
    private void applypagging()
    {
        if (Request.QueryString["action"] != null)
        {
            index = Int32.Parse(Request.QueryString["index"]);
            if ("prev".Equals(Request.QueryString["action"]) && index == 0)
            {
                string[] str = CatDetailsService.getRelLastProduct(Request.QueryString["htm"]);
                style = str[0];
                index = Int32.Parse(str[1]);

            }
            else if ("next".Equals(Request.QueryString["action"]))
            {
                index = index + 1;
                string[] str = CatDetailsService.getRelProductDT(Request.QueryString["htm"], index);
                style = str[0];
                index = Int32.Parse(str[1]);

            }
            else
            {
                string[] str = CatDetailsService.getRelProductDT(Request.QueryString["htm"], index);
                style = str[0];
                index = Int32.Parse(str[1]);
            }
        }

    }
    private void updateRecentView(string skuOrStyle)
    {
        int? pId = new FrontViewProductDetailsDAO().getProductIDBySkuOrStyle(skuOrStyle);
        String userId = Session["UserID"] == null ? "" : Session["UserID"].ToString();
        String ip = CommonUtil.GetUser_IP();
        RecentViewDAO.addRecentViewItems(pId, userId, ip, DateTime.Now);
    }

    public void fillproductdetails()
    {
        style = dt.Rows[0]["StyleCode"] + "".Trim() == "" ? dt.Rows[0]["SKUCode"] + "".Trim() : dt.Rows[0]["StyleCode"] + "";
        isSize = "Size".Equals(dt.Rows[0]["VariantType"] + "") ? "true" : "false";
        if (!StringUtil.isNullOrEmpty(style))
        {
            if ("true".Equals(isSize))
                sizeDT = CatDetailsService.getSizeDT(style, true);
        }
        else
        {
            if ("true".Equals(isSize))
                sizeDT = CatDetailsService.getSizeDT(style, false);
        }
        if (!CommonUtil.DT.isEmptyOrNull(colorDT))
            isSku = StringUtil.isNullOrEmpty(dt.Rows[0]["StyleCode"] + "") ? "false" : "true";
        inventory = AjaxService.getInventory(dt.Rows[0]["SKUCode"] + "");
        if (inventory == 0)
        {
            avalibilty = "Sold Out.";
        }
    }

    public void fillReatedProductType()
    {
        relProductDT = CatDetailsService.getRelProductDT(dt.Rows[0]["SKUProductType"] + "");
    }
    private void fillRecentView()
    {
        String userId = "" + Session["UserID"];
        recentProductTD = RecentViewDAO.getRecentItemsByUserId(userId, CommonUtil.GetUser_IP());
        if (recentProductTD == null)
        {
            recentProductTD = new DataTable();
        }

    }
}