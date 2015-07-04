using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MFO.Utils;
using MFO.Services;
using MFO.Commom;
using System.Collections.Specialized;
using MFO.Loggers;
using System.Web.UI.HtmlControls;
using MFO.DAO;
using SFloor.DAO;
using System.Web.Script.Serialization;

public partial class CategoriesScroll : System.Web.UI.Page
{
    private string categoryKey;
    private string categoryId;
    private string categoryTypeKey;
    private string categoryTypeId;
    public string selectPtype = null;
    public int seq = 0;
    public DataTable catDT;
    public bool isExist;
    private void assignRequestParam()
    {
        NameValueCollection n = Request.QueryString;
        if (n.HasKeys())
        {
            try
            {
                categoryKey = n.GetKey(0);
                categoryId = n.Get(0);
                categoryTypeKey = n.GetKey(1);
                categoryTypeId = n.Get(1);
            }
            catch (Exception ex)
            {
                Logger.Error("Error Occur While fatching the Request Param ", ex);
            }
        }
    }

    private String pageNo;
    public String PageNo
    {
        get { return pageNo; }
        set { pageNo = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        assignRequestParam();
        BindGrid();
    }
    private void BindGrid()
    {
        DataTable dt = null;
        String pType = Request.Params["PType"] == null ? null : Request.Params["PType"].Trim();
        String pBrand = Request.Params["PBrand"] == null ? null : Request.Params["PBrand"].Trim();
        String cat = Request.Params["cat"] == null ? null : Request.Params["cat"].Trim();
        String sub = Request.Params["subCat"] == null ? null : Request.Params["subCat"].Trim(); 
        String sortPrice = Request.Params["SortPrice"];
        String min = Request.Params["min"] == null ? null : Request.Params["min"].Trim();
        String max = Request.Params["max"] == null ? null : Request.Params["max"].Trim();
        int currentPage = 1;
        if (!StringUtil.isNullOrEmpty(Request.Params["pageNo"]))
            currentPage = Int32.Parse(Request.Params["pageNo"]);
        pageNo = (currentPage + 1).ToString();
        seq=16*Int32.Parse(pageNo);
            
        if (!StringUtil.isNullOrEmpty(sortPrice))
        {
            int sp = Int32.Parse(sortPrice);
            dt = CategoriesService.sortToggle(cat, sub, sp, pType, pBrand.ToLower().Replace('~',' '), (currentPage+1));
        }
        else if (!StringUtil.isNullOrEmpty(min))
        {
            dt = CategoriesService.sort(cat.Trim(), sub.Trim(), min, max, pType, pBrand.ToLower().Replace('~', ' '), (currentPage + 1));
        }
        else if (!StringUtil.isNullOrEmpty(pBrand))
        {
            dt = CategoriesService.getProductByBrand(cat.Trim(), sub.Trim(), pBrand.ToLower().Replace('~',' ').Trim(),(currentPage+1));
        }
        else if (!StringUtil.isNullOrEmpty(pType))
        {
            dt = CategoriesService.getProductByPTypeId(pType, (currentPage + 1));
        }
        else if (!StringUtil.isNullOrEmpty(cat) && !StringUtil.isNullOrEmpty(sub)) {
            dt = CategoriesService.getProductByCatSub(cat, sub, (currentPage + 1));
        }
        else if (!StringUtil.isNullOrEmpty(categoryKey) && !StringUtil.isNullOrEmpty(categoryTypeKey))
        {
            dt = CategoriesService.getProductByCatType(categoryTypeId, (currentPage + 1));
        }
        if (!CommonUtil.DT.isEmptyOrNull(dt))
        {
            fillCategory(dt);
        }
        else {
            sendResponse("not_found");
        }
    }
    private void sendResponse(object response)
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        string errorStr = ser.Serialize(response);
        Response.Write(errorStr);
        Response.AddHeader("Content-Length", errorStr.Length.ToString());
        Response.ContentType = "application/json";
        Response.Flush();
        Response.Close();
    }
    private void fillCategory(DataTable dt)
    {
        catDT = addColm(dt);
       // categories.DataBind();
    }
    DataTable addColm(DataTable dt)
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
        Logger.Info("End addColm()");
        return dt;
    }

    public string next()
    {
        return (seq++).ToString();
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
    public string getIconName(object o)
    {
        isExist = FavDAO.isItemExist(Session.SessionID, o.ToString());
        if (isExist)
        {
            return "fav-active";
        }
        else
        {
            return "fav-inactive";
        }

    }
}