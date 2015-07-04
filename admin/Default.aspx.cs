using System;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

        if (Session["isLoginIn"] == "True")
        {
           
        }
        else
        {

            string id = Request.Params["userId"];
            string pwd = Request.Params["pwd"];
            if (pwd == "123@fabnfresh" && id == "fabnfresh")
            {
                Session["isLoginIn"] = "True";
            }
            else
            {
                Response.Redirect("login.html");
            }
        }
        System.Collections.IList visibleTables = ASP.global_asax.DefaultModel.VisibleTables;
        if (visibleTables.Count == 0) {
            throw new InvalidOperationException("There are no accessible tables. Make sure that at least one data model is registered in Global.asax and scaffolding is enabled or implement custom pages.");
        }
        Menu1.DataSource = visibleTables;
        Menu1.DataBind();
    }

}
