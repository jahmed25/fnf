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

public partial class sfloor_pages_checkoutPage2 : System.Web.UI.Page
{
    public DataTable cartDT = new DataTable();
    public DataTable shipDT = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cartDT = HomeService.getCartDT(Session.SessionID);
            String userId = Session[Constant.Session.LOGED_IN_USER_ID] + "";
            if (!StringUtil.isNullOrEmpty(userId))
                shipDT = ShippingDAO.getShippinByUserID(userId);
            else
                shipDT = ShippingDAO.getShippinByEmailID(Session[Constant.Session.SHIPING_EMAIL] + "");
        }
        catch
        {
            cartDT = new DataTable();
            shipDT = new DataTable();
        }

    }
}