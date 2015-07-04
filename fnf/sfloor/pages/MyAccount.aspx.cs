using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFloor.Pages;
using System.Data;
using SFloor.DAO;
using MFO.Constants;

public partial class sfloor_pages_MyAccount : GenericPage
{
    public DataTable userDT = new DataTable();
    public DataTable addressDT = new DataTable();
    public DataTable orderDT = new DataTable();

    public override void load(object sender, EventArgs e)
    {
        this.isEnalbleCache = false;
        string email=Session[Constant.Session.LOGED_IN_EMAIL] + "";
        addressDT = ShippingDAO.getShippinByUserID(Session[Constant.Session.LOGED_IN_USER_ID] + "");
        if (addressDT == null)
            addressDT = new DataTable();
        userDT = RegisterDAO.getUser(email);
        if (userDT == null)
            userDT = new DataTable();
        orderDT = OrderDAO.getOrderByEmail(email);
        if (orderDT == null)
            orderDT = new DataTable();
       
    }
    public DataTable getOrderDetails(String orderNo)
    {
        return OrderDAO.getOrderDetails(orderNo);
    }
    public DataTable getStatus(String orderNo)
    {
        return OrderDAO.getOrderStatus(orderNo);
    }
}