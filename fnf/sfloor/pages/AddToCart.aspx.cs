using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SFloor.Services;
using MFO.Commom;
using SFloor.DAO;
using MFO.Utils;
using SFloor.Pages;

public partial class sfloor_pages_AddToCart : GenericPage
{

    public DataTable cartDT = new DataTable();
    public string total = "";
    public override void load(object sender, EventArgs e)
    {
        isEnalbleCache = false;
        cartDT = HomeService.getCartDT(Session.SessionID);
        total = HomeService.getTotal();
    }
   
}