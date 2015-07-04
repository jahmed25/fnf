using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SFloor.Services;

public partial class sfloor_pages_checkoutPage1 : System.Web.UI.Page
{
    public DataTable cartDT = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cartDT = HomeService.getCartDT(Session.SessionID);
        }
        catch
        {
            cartDT = new DataTable();
        }

    }
}