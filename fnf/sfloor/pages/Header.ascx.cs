using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SFloor.Services;

public partial class Header : System.Web.UI.UserControl
{
    DataTable favDT;
    DataTable cartDT;
    string total = "";
    public DataTable FavDT
    {
        get {
            favDT=HomeService.getFavDT(Session.SessionID);
            favDT = favDT == null ? new DataTable() : favDT;
            return favDT; 
        }
    }
    public DataTable CartDT
    {
        get
        {
            cartDT=HomeService.getCartDT(Session.SessionID);
            cartDT = cartDT == null ? new DataTable() : cartDT;
            return cartDT;
        }
    }
    public String Total
    {
        get
        {
            total=HomeService.getTotal();
            return total;
        }
    }
   

}