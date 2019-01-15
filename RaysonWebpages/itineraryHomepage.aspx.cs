using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class RaysonWebpages_itineraryHomepage : System.Web.UI.Page
{
    string errorMsg;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    //public string tablesData()
    //{
    //    string html = "";
    //    itineraryDetailsDAO travelItineraryDao = new itineraryDetailsDAO();
    //    List<itineraryDetails> userList = new List<itineraryDetails>();

    //    userList = travelItineraryDao.getTravelDetails("2");
    //    if (userList != null)
    //    {
    //        foreach (var i  in userList)
    //        {
    //            html += "<tr><td class='column1'>" + "12/09/2000" + "</td><td class='column2'>" +  i.travelDetailsId + "</td><td class='column3'>" + i.tripNameClass + "</td><td class='column4'>" + i.startDateClass + "</td><td class='column5'>" + i.endDateClass + "</td><td class='column6'>" + i.countryClass + "</td><td class='column7'>" + i.stateClass + "</td><td class='column8'><asp:Button ID='button" + i.travelDetailsId + "' runat='server' class='btn btn-info' Text='Button' onclick='editItinerary_Click'/>" + "</td></tr>";
    //        }
    //        return html;
    //    }
    //    else
    //    {
    //        html = "<p>No details found!</p>";
    //        return html;
    //    }
    //}

    //void editItinerary_Click(object sender, EventArgs e)
    //{
    //    userNameLbl.Text = "worked!";
    //}
    
    public List<itineraryDetails> details()
    {
        itineraryDetailsDAO travelItineraryDao = new itineraryDetailsDAO();
        List<itineraryDetails> userList = new List<itineraryDetails>();

        userList = travelItineraryDao.getTravelDetails("2");
        if (userList != null)
        {
            return userList;
        }
        else
        {
            return userList;
        }
    }
}