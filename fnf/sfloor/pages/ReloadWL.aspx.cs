using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SFloor.Services;

public partial class sfloor_pages_ReloadeWL : System.Web.UI.Page
{
    public DataTable favDT = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        favDT = HomeService.getFavDT(Session.SessionID);
    }
}