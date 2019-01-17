using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.Search.NearBy;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Web.Services;
using System.Threading;

public partial class itineraryCreatorStep1 : System.Web.UI.Page
{
    string errorMsg;

    string realMessage;

    Dictionary<string, string> tools = new Dictionary<string, string>()
        {
            {"buttonEnabled", "Enabled" }, 
            { "iconColor", "Enabled" },
            {"placeSuggestion", "Enabled" }
        };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            loadingToolBoxSettings();
            int travelId = int.Parse(Session["travelId"].ToString());
            travelDetailsId.Value = travelId.ToString();
            toolBoxCheck userObj = new toolBoxCheck();
            toolBoxCheckDAO toolBoxDao = new toolBoxCheckDAO();

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

                //Start to load everything for the toolboxes
                if (values.Count != 0)
                {
                    //Loads importancy icon tool
                    foreach (KeyValuePair<string, string> item in values)
                    {
                        //check if importancy icon tool exists
                        if (values.ContainsKey("iconColor") == true)
                        {
                            changeImportancy.Visible = true;
                        }
                        else
                        {
                            changeImportancy.Visible = true;
                        }
                    }

                    //Loads placesuggestion tool
                    //Loads importancy icon tool
                    foreach (KeyValuePair<string, string> item in values)
                    {
                        //check if importancy icon tool exists
                        if (values.ContainsKey("placeSuggestion") == true)
                        {
                            changeImportancy.Visible = true;

                            ////Testing loading of api places
                            //Dictionary<string, string> places = new Dictionary<string, string>();

                            //string html = string.Empty;
                            //string newHtml = string.Empty;
                            //string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?pagetoken=CpQCAgEAAFxg8o-eU7_uKn7Yqjana-HQIx1hr5BrT4zBaEko29ANsXtp9mrqN0yrKWhf-y2PUpHRLQb1GT-mtxNcXou8TwkXhi1Jbk-ReY7oulyuvKSQrw1lgJElggGlo0d6indiH1U-tDwquw4tU_UXoQ_sj8OBo8XBUuWjuuFShqmLMP-0W59Vr6CaXdLrF8M3wFR4dUUhSf5UC4QCLaOMVP92lyh0OdtF_m_9Dt7lz-Wniod9zDrHeDsz_by570K3jL1VuDKTl_U1cJ0mzz_zDHGfOUf7VU1kVIs1WnM9SGvnm8YZURLTtMLMWx8-doGUE56Af_VfKjGDYW361OOIj9GmkyCFtaoCmTMIr5kgyeUSnB-IEhDlzujVrV6O9Mt7N4DagR6RGhT3g1viYLS4kO5YindU6dm3GIof1Q&key=AIzaSyB8X3vHKQpy-VEFBVOksi32bLhb7u6cUK0";

                            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            //using (Stream stream = response.GetResponseStream())
                            //using (StreamReader reader = new StreamReader(stream))
                            //{
                            //    string json = JsonConvert.SerializeObject(reader.ReadToEnd());
                            //    var resultsPlace = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                            //    Label1.Text = resultsPlace.ToString();
                            //    //newHtml = JsonConvert.SerializeObject(html);
                            //}
                        }
                        else
                        {
                            changeImportancy.Visible = true;
                        }
                    }
                }
                else
                {
                    //Adding default value into the account 
                    //Update the database table
                    string json = JsonConvert.SerializeObject(tools);
                    int insCnt = toolBoxDao.updateTools(json, 2);
                    if (insCnt == 1)
                    {
                        errorMsg = "success";
                    }
                    else
                    {
                        errorMsg = "failed";
                    }
                }
            }
            else
            {
                errorMsg = "No details found!";
            }
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

        int travelId = int.Parse(travelDetailsId.Value);

        itineraryDetailsDAO itineraryDao = new itineraryDetailsDAO();
        System.Diagnostics.Debug.WriteLine("travel id = " + travelId);
        int insCnt = itineraryDao.insertDetails(2, test, travelId, currentTime);
        if (insCnt == 1)
        {
            errorMsg = "Succesfully Saved!";
            Label1.Text = errorMsg;
            Response.Redirect("itineraryCreatorStep3.aspx");
        }
        else
        {
            errorMsg = "Unable to save itinerary details, please inform system administrator!";
            Label1.Text = errorMsg;
        }
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
}