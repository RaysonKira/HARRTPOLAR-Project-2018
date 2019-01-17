using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class RaysonWebpages_itineraryHomepage : System.Web.UI.Page
{
    string errorMsg;

    protected void Page_Load(object sender, EventArgs e)
    {
        itineraryDetailsDAO travelItineraryDao = new itineraryDetailsDAO();
        List<itineraryDetails> userList = new List<itineraryDetails>();

        userList = travelItineraryDao.getTravelDetails("2");
        if (userList != null)
        {
            gv1.DataSource = userList;
            gv1.DataBind();
        } 
        else
        {
            errorMsg = "null";
        }
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

    protected void delete_Click(object sender, EventArgs e)
    {
        Button refBtn = (Button)(sender);

        int testTravelDetailsId = 30;

        itineraryDetailsDAO itineraryDao = new itineraryDetailsDAO();
        travelDetailsDAO travelDao = new travelDetailsDAO();

        int insCnt = itineraryDao.deleteItineraryDetailsInfo(testTravelDetailsId);
        if (insCnt == 1)
        {
            System.Diagnostics.Debug.WriteLine("Itinerary Details Removed!");
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Itinerary Details Removing Failed!");
        }

        int insCntVer2 = travelDao.deleteTravelDetailsInfo(testTravelDetailsId);
        if (insCntVer2 == 1)
        {
            System.Diagnostics.Debug.WriteLine("Travel Details Removed!!");
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Travel Details Removing Failed!");
        }
    }

    protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void deleteAndEditRow(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv1.Rows[index];

            int testTravelDetailsId = int.Parse(row.Cells[1].Text);

            Session["travelDetailsId"] = testTravelDetailsId;

            Response.Redirect("edit.aspx");
        }

        else if (e.CommandName == "deleteButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv1.Rows[index];

            int testTravelDetailsId = int.Parse(row.Cells[1].Text);

            System.Diagnostics.Debug.WriteLine("row removed = " + testTravelDetailsId);

            itineraryDetailsDAO itineraryDao = new itineraryDetailsDAO();
            travelDetailsDAO travelDao = new travelDetailsDAO();

            int insCnt = itineraryDao.deleteItineraryDetailsInfo(testTravelDetailsId);
            if (insCnt == 1)
            {
                System.Diagnostics.Debug.WriteLine("Itinerary Details Removed!");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Itinerary Details Removing Failed!");
            }

            int insCntVer2 = travelDao.deleteTravelDetailsInfo(testTravelDetailsId);
            if (insCntVer2 == 1)
            {
                System.Diagnostics.Debug.WriteLine("Travel Details Removed!!");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Travel Details Removing Failed!");
            }

            Response.Redirect("itineraryHomepage.aspx");
        }

        else if (e.CommandName == "editItinerary")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv1.Rows[index];

            int testTravelDetailsId = int.Parse(row.Cells[1].Text);

            Session["travelDetailsId"] = testTravelDetailsId;

            System.Diagnostics.Debug.WriteLine("travel id is =" + testTravelDetailsId);

            Response.Redirect("editItinerary.aspx");
        }
    }
}