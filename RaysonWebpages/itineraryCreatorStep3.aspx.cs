﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RaysonWebpages_itineraryCreatorStep3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void itineraryManagerButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("itineraryHomepage.aspx");
    }
}