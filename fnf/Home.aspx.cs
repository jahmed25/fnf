using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFloor.Pages;

public partial class Home : GenericPage
{
    public override void load(object sender, EventArgs e)
    {
        isEnalbleCache = false;
    }
    
}