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
using System.Text.RegularExpressions;
using System.Collections.Generic;
using MFO.DAO;
using MFO.Commom;
using MFO.services;
using MFO.Services;
using MFO.Constants;
using MFO.Utils;
using MFO.Common;
using SFloor.Services;

public partial class sfloor_pages_quickview : System.Web.UI.Page
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

    protected DataTable dt = new DataTable();
    protected DataTable sizeDT = null;
    protected DataTable colorDT = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        style = Request.QueryString["sku"];
        qty = Request.QueryString["qty"];
        size = Request.QueryString["size"];
        color = Request.QueryString["color"];
        isSize = Request.QueryString["isSize"];
        isColor = Request.QueryString["isColor"];
        isSku = Request.QueryString["isSku"];
        updateRecentView(style);
        if (!IsPostBack)
        {
            dt = CategoryDetailsService.getDTBySKU(style);
            fillproductdetails();
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
            colorDT = CatDetailsService.getColorDT(style, true);
        }
        else
        {
            if ("true".Equals(isSize))
                sizeDT = CatDetailsService.getSizeDT(style, false);
            colorDT = CatDetailsService.getColorDT(dt.Rows[0]["SKUCode"] + "", false);
        }
        if (!CommonUtil.DT.isEmptyOrNull(colorDT))
            color = colorDT.Rows[0]["Color"] + "";
        isColor = CommonUtil.DT.isEmptyOrNull(colorDT) ? "false" : "true";
        isSku = StringUtil.isNullOrEmpty(dt.Rows[0]["StyleCode"] + "") ? "false" : "true";
        inventory = AjaxService.getInventory(dt.Rows[0]["SKUCode"] + "");
        if (inventory < 20)
        {
            if (inventory == 0)
            {
                avalibilty = "Sold Out.";
            }
        }
    }
}