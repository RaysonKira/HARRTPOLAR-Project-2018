using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RaysonWebpages_editItinerary : System.Web.UI.Page
{
    string realMessage;

    string errorMsg;

    Dictionary<string, string> tools = new Dictionary<string, string>()
        {
            {"buttonEnabled", "Enabled" },
            { "iconColor", "Enabled" },
            {"placeSuggestion", "Enabled" }
        };

    protected void Page_Load(object sender, EventArgs e)
    {
        int travelDetailsId = int.Parse(Session["travelDetailsId"].ToString());
        itineraryDetailsDAO itineraryDetailsDao = new itineraryDetailsDAO();
        itineraryDetails itiObj = new itineraryDetails();

        itiObj = itineraryDetailsDao.getItineraryDetailsData(travelDetailsId);

        travellID.Value = travelDetailsId.ToString();

        travelId.Value = (itiObj.itineraryHtmlClass).ToString();

        if (itiObj != null)
        {
            System.Diagnostics.Debug.WriteLine("html is = " + itiObj.itineraryHtmlClass + " and travelid is = " + travelDetailsId);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("nth is shown");
        }
    }

    public string postingHtml()
    {
        string htmlDetails = travelId.Value;
        return htmlDetails;
    }

    public void loadingToolBoxSettings()
    {
        toolBoxCheck userObj = new toolBoxCheck();
        toolBoxCheckDAO toolBoxDao = new toolBoxCheckDAO();

        string json = JsonConvert.SerializeObject(tools);

        userObj = toolBoxDao.getUsersData("2");
        if (userObj != null)
        {
            string userName = userObj.userNameClass;
            string userId = userObj.userIdClass;
            string password = userObj.passwordClass;
            string buttonEnabledData = userObj.buttonEnabledClass;
            string email = userObj.emailClass;
            string toolsString = userObj.toolsClass;

            userNameLbl.Text = "Username: " + userName;
            emailLbl.Text = "Email: " + email;

            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(toolsString);
            if (values.Count == 0)
            {
                //Adding default value into the account 
                //Update the database table
                int insCnt = toolBoxDao.updateTools(json, 2);
                if (insCnt == 1)
                {
                    realMessage = "success";
                }
                else
                {
                    realMessage = "failed";
                }
            }
            else
            {
                //Loads auto complete tool
                foreach (KeyValuePair<string, string> item in values)
                {
                    //check if button enabled key exists
                    if (values.ContainsKey("buttonEnabled") == true)
                    {
                        autoCompleteSettingsActivate.Enabled = false;
                        autoCompleteSettingsDeactivate.Enabled = true;
                    }
                    else if (values.ContainsKey("buttonEnabled") == false)
                    {
                        autoCompleteSettingsDeactivate.Enabled = false;
                        autoCompleteSettingsActivate.Enabled = true;
                    }
                }
                //ends 

                //Loading of place suggestion
                foreach (KeyValuePair<string, string> item in values)
                {
                    //check if button enabled key exists
                    if (values.ContainsKey("iconColor") == true)
                    {
                        importancyColorSettingActivate.Enabled = false;
                        importancyColorSettingDeactivate.Enabled = true;
                    }
                    else if (values.ContainsKey("iconColor") == false)
                    {
                        importancyColorSettingDeactivate.Enabled = false;
                        importancyColorSettingActivate.Enabled = true;
                    }
                }

                //Loading of importancy tools
                foreach (KeyValuePair<string, string> item in values)
                {
                    //check if button enabled key exists
                    if (values.ContainsKey("placeSuggestion") == true)
                    {
                        placeSuggestSettingActivate.Enabled = false;
                        placeSuggestSettingDeactivate.Enabled = true;
                    }
                    else if (values.ContainsKey("placeSuggestion") == false)
                    {
                        placeSuggestSettingDeactivate.Enabled = false;
                        placeSuggestSettingActivate.Enabled = true;
                    }
                }
            }
        }
    }

    protected void importancyColorSettingActivate_Click(object sender, EventArgs e)
    {
        changeImportancy.Visible = true;
        string errorMessage;

        toolBoxCheck userObj = new toolBoxCheck();
        toolBoxCheckDAO toolBoxDao = new toolBoxCheckDAO();
        //search in the database for user 2 datas
        userObj = toolBoxDao.getUsersData("2");

        // remove the item from the database's dictionary 
        if (userObj != null)
        {
            string userName = userObj.userNameClass;
            string userId = userObj.userIdClass;
            string password = userObj.passwordClass;
            string buttonEnabledData = userObj.buttonEnabledClass;
            string toolsString = userObj.toolsClass;

            // Performing loading of tools 
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(toolsString);
            foreach (KeyValuePair<string, string> item in values)
            {
                if (values.ContainsKey("iconColor") == false)
                {
                    values.Add("iconColor", "Enabled");
                    string json = JsonConvert.SerializeObject(values);
                    int insCnt = toolBoxDao.updateTools(json, 2);
                    if (insCnt == 1)
                    {
                        errorMessage = "No error!";
                        break;
                    }
                }
            }
        }
        else
        {
            errorMessage = "No details found!";
        }
    }

    protected void placeSuggestSettingActivate_Click(object sender, EventArgs e)
    {
        placeSuggestions.Visible = true;
        string errorMessage;

        toolBoxCheck userObj = new toolBoxCheck();
        toolBoxCheckDAO toolBoxDao = new toolBoxCheckDAO();
        //search in the database for user 2 datas
        userObj = toolBoxDao.getUsersData("2");

        // remove the item from the database's dictionary 
        if (userObj != null)
        {
            string userName = userObj.userNameClass;
            string userId = userObj.userIdClass;
            string password = userObj.passwordClass;
            string buttonEnabledData = userObj.buttonEnabledClass;
            string toolsString = userObj.toolsClass;

            // Performing loading of tools 
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(toolsString);
            foreach (KeyValuePair<string, string> item in values)
            {
                if (values.ContainsKey("placeSuggestion") == false)
                {
                    values.Add("placeSuggestion", "Enabled");
                    string json = JsonConvert.SerializeObject(values);
                    int insCnt = toolBoxDao.updateTools(json, 2);
                    if (insCnt == 1)
                    {
                        errorMessage = "No error!";
                        break;
                    }
                }
            }
        }
        else
        {
            errorMessage = "No details found!";
        }
    }

    protected void importancyIconRemove_Click(object sender, EventArgs e)
    {
        string errorMessage;

        toolBoxCheck userObj = new toolBoxCheck();
        toolBoxCheckDAO toolBoxDao = new toolBoxCheckDAO();
        //search in the database for user 2 datas
        userObj = toolBoxDao.getUsersData("2");

        // remove the item from the database's dictionary 
        if (userObj != null)
        {
            string userName = userObj.userNameClass;
            string userId = userObj.userIdClass;
            string password = userObj.passwordClass;
            string buttonEnabledData = userObj.buttonEnabledClass;
            string toolsString = userObj.toolsClass;

            changeImportancy.Visible = false;

            // Performing loading of tools 
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(toolsString);
            foreach (KeyValuePair<string, string> item in values)
            {
                if (item.Key == "iconColor")
                {
                    values.Remove("iconColor");
                    string json = JsonConvert.SerializeObject(values);
                    int insCnt = toolBoxDao.updateTools(json, 2);
                    if (insCnt == 1)
                    {
                        errorMessage = "No error!";
                        break;
                    }
                }
            }
        }
        else
        {
            errorMessage = "No details found!";
        }
    }

    protected void saveBtn_Click(object sender, EventArgs e)
    {
        string test = html.Value;
        string currentTime = DateTime.Now.ToShortTimeString();

        Thread.Sleep(5000);

        System.Diagnostics.Debug.WriteLine("travel id first = " + travellID.Value);

        int travelIdDetails = int.Parse(travellID.Value);

        itineraryDetailsDAO itineraryDao = new itineraryDetailsDAO();
        System.Diagnostics.Debug.WriteLine("travel id = " + travelIdDetails);
        int insCnt = itineraryDao.updateItinerary(test, travelIdDetails);
        if (insCnt == 1)
        {
            errorMsg = "Succesfully Saved!";
            Label1.Text = errorMsg;
            Response.Redirect("itineraryHomepage.aspx");
        }
        else
        {
            errorMsg = "Unable to save itinerary details, please inform system administrator!";
            Label1.Text = errorMsg;
        }
    }
}