using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RaysonWebpages_edit : System.Web.UI.Page
{
    string errorMsg = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        int travelDetailsId = int.Parse(Session["travelDetailsId"].ToString());

        travelDetailsIdHidden.Value = travelDetailsId.ToString();

        travelDetails travelDetailsObj = new travelDetails();
        travelDetailsDAO travelDao = new travelDetailsDAO();

        travelDetailsObj = travelDao.getTravelDetailsData(travelDetailsId);

        if (travelDetailsObj != null)
        {
            tripNameLbl.Text = travelDetailsObj.tripNameClass;
            startDateLblVer2.Text = travelDetailsObj.startDateClass.ToString();
            endDateLbl.Text = travelDetailsObj.endDateClass.ToString();
            countryLbl.Text = travelDetailsObj.countryClass;
            stateLbl.Text = travelDetailsObj.stateClass;
            descriptionLbl.Text = travelDetailsObj.descriptionClass;
        }
        else
        {
            errorMsg = "No details";
        }
    }
    protected void editTravelDetailsButton_Click(object sender, EventArgs e)
    {
        Thread.Sleep(5000);

        string tripName, country, state, description;
        DateTime startDate, endDate;

        try
        {
            tripName = tripNameDetailsTextBox.Text;
            country = countryTextBox.Text;
            state = stateTextBox.Text;
            description = descriptionDetails.InnerText;
            startDate = DateTime.Parse(startDateInput.Text);
            endDate = DateTime.Parse(endDateInput.Text);

            if (String.IsNullOrEmpty(tripName))
            {
                errorMsg += "Please Enter A Trip Name!\n";
            }
            else if (String.IsNullOrEmpty(country))
            {
                errorMsg += "Please Enter A Country!\n";
            }
            else if (String.IsNullOrEmpty(description))
            {
                errorMsg += "Please Enter A Description!\n";
            }
            //else if (startDate > endDate)
            //{
            //    errorMsg += "Please Pick A Start Date Earlier Than End Date!\n";
            //}
            //else if (endDate < startDate)
            //{
            //    errorMsg += "Please Pick A End Date Later Than Start Date!\n";
            //}
            else
            {
                travelDetailsDAO travelDetailsDao = new travelDetailsDAO();
                travelDetails travelObj = new travelDetails();

                int travelDetailsId = int.Parse(travelDetailsIdHidden.Value);

                System.Diagnostics.Debug.WriteLine("id is = " + travelDetailsId);

                int insCnt = travelDetailsDao.updateTravelDetails(travelDetailsId, tripName, startDate, endDate, country, description, 0.00, state);
                if (insCnt == 1)
                {
                    Response.Redirect("itineraryHomepage.aspx");
                    System.Diagnostics.Debug.WriteLine("No error!");
                }
                else
                {
                    errorMsg += "Error While Updating Data!";
                    status.Text = errorMsg;
                    System.Diagnostics.Debug.WriteLine(errorMsg);
                }
            }
        }
        catch (Exception ex)
        {
            errorMsg += ex.ToString();
        }
    }
}