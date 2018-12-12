using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RoomCalculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
   
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int studentNumber = 0;
        studentNumber = Int32.Parse(numberStudent.Text);
        if (studentNumber != 0)
        {
            resultLabel.Text = studentNumber.ToString();
            result.Visible = true;
        }

    }
}