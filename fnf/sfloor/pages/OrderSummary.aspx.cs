using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SFloor.DAO;
using MFO.Constants;

public partial class sfloor_pages_OrderSummary : System.Web.UI.Page
{
    public DataTable shippingDT= new DataTable();
    public DataTable orderDT = new DataTable();
    public DataTable orderDetailsDT = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        string orderId = Session[Constant.Session.CURRENT_ORDER] + "";
        orderDT = OrderDAO.getOrder(orderId);
        orderDetailsDT = OrderDAO.getOrderDetails(orderId);
        shippingDT = ShippingDAO.getShipping(orderDT.Rows[0]["SHIPPING_ID"]+"");

    }
}