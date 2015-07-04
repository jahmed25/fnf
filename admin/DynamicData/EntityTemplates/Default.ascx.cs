﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DefaultEntityTemplate : System.Web.DynamicData.EntityTemplateUserControl {
    private MetaColumn currentColumn;

    protected override void OnLoad(EventArgs e) {
        if (Session["isLoginIn"] == "True")
        {
            foreach (MetaColumn column in Table.GetScaffoldColumns(Mode, ContainerType))
            {
                currentColumn = column;
                Control item = new _NamingContainer();
                EntityTemplate1.ItemTemplate.InstantiateIn(item);
                EntityTemplate1.Controls.Add(item);
            }

        }
        else {
            Response.Redirect("login.html");
        }
        
    }

    protected void Label_Init(object sender, EventArgs e) {
        Label label = (Label)sender;
        label.Text = currentColumn.DisplayName;
    }

    protected void DynamicControl_Init(object sender, EventArgs e) {
        DynamicControl dynamicControl = (DynamicControl)sender;
        dynamicControl.DataField = currentColumn.Name;
    }

    public class _NamingContainer : Control, INamingContainer { }

}