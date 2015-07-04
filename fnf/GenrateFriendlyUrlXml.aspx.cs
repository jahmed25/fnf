using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFloor.Services;

public partial class GenrateFriendlyUrlXml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        string genstring=GenrateFriendlyUrlServices.Genrate();
        genText.Value = genstring;
        
    }
}