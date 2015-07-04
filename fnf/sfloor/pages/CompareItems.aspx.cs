using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFloor.Pages;
using System.Data;
using SFloor.Services;

public partial class CompareItems : GenericPage
{
    public DataTable compDT;
    public override void load(object sender, EventArgs e)
    {
        string sku1 = Request.Params["sku0"];
        string sku2 = Request.Params["sku1"];
        string sku3 = Request.Params["sku2"];
        string sku4 = Request.Params["sku3"];
        compDT = CompareService.getDTBySKUs(sku1,sku2,sku3,sku4);
    }
    public string getSizes(string sku)
    {
        DataTable dt = CompareService.getSizeDTBySKUs(sku);
        String sizes = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sizes += "," + dt.Rows[i]["Size"];
        }
        return sizes.Length > 1 ? sizes.Substring(1, sizes.Length - 1) : "N/A";
    }
    public string getColor(string sku)
    {
        DataTable dt = CompareService.getColorsDTBySKUs(sku);
        String colors = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            colors += "," + dt.Rows[i]["Color"];
        }
        return colors.Length > 1 ? colors.Substring(1, colors.Length-1) : "N/A";
    }
    public String totalDiscount(object mrp, object price)
    {
        return (float.Parse(mrp+"") - float.Parse(price+"")).ToString();
    }
    public String availbilty(string sku)
    {
       int inventory = AjaxService.getInventory(sku);
        if (inventory == 0)
        {
            return  "Sold Out.";
        }
        return "Available In Stock";
    }
}