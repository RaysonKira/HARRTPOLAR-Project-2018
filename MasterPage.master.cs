﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void linkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("RaysonWebPages/itineraryCreatorStep1.aspx");
    }
}
