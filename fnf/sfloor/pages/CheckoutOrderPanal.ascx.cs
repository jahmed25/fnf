using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SFloor.Services;
using MFO.Constants;
using MFO.Utils;
using SFloor.DAO;

public partial class OrderSummary : System.Web.UI.UserControl
{
    public DataTable cartDT = new DataTable();
    public string total = "";
    public string subTotal = "";
    public Dictionary<string, string> invDic = new Dictionary<string, string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cartDT = HomeService.getCartDT(Session.SessionID);
            subTotal = HomeService.getTotal();
            total = (float.Parse(HomeService.getTotal()) + float.Parse(ConfigUtil.getValue("ShippigCharge"))).ToString();
            invDic = AjaxService.checkInventory(cartDT, Session.SessionID);

        }
        catch
        {
            invDic = new Dictionary<string, string>();
            cartDT = new DataTable();
        }

    }
}