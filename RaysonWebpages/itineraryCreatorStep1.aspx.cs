﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using Newtonsoft.Json;

public partial class itineraryCreatorStep1 : System.Web.UI.Page
{

    public delegate void EventDelegate(object sender, EventArgs e);

    string buttonEnabled;

    Dictionary<string, string> tools = new Dictionary<string, string>()
        {
            {"buttonEnabled", "Enabled" },
            { "Test", "Test" }
        };

    string realMessage;

    public event EventDelegate sendingData;

    protected void Page_Load(object sender, EventArgs e)
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
                    Session["status"] = "success";
                }
                else
                {
                    Session["status"] = "failed";
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
                        //Loading of button Enabled
                        if (item.Value == "Enabled")
                        {
                            
                            countryTextBox.Attributes.Add("autocomplete", "true");
                            disableAutoButton.Enabled = true;
                            enableAutoButton.Enabled = false;
                        }

                        else if (item.Value == "Disabled")
                        {
                            countryTextBox.Attributes.Add("autocomplete", "false");
                            disableAutoButton.Enabled = false;
                            enableAutoButton.Enabled = true;
                        }
                    }
                    else if (values.ContainsKey("buttonEnabled") == false)
                    {
                        autoComplete.Visible = false;
                    }
                }
                //ends 
            }
        }
        else
        {
            realMessage = "No details found!";
        }
    }

    protected void addTravelDetails_Click(object sender, EventArgs e)
    {
        Thread.Sleep(5000);
        status.Text = "";

        // Initialize all variables 
        string tripName, email, country, description;
        DateTime startDate, endDate;
        double expectedExpense;

        //Getting information from textBoxes <need to add validations>
        tripName = tripNameDetails.Text.ToString();
        email = emailDetails.Text.ToString();
        country = countryTextBox.Text.ToString();
        description = descriptionDetails.InnerText; // Will change once textarea bug is fixed
        startDate = DateTime.Parse(startDateInput.Text);
        endDate = DateTime.Parse(endDateInput.Text);
        expectedExpense = 0.00;

        //Validate
        string errorMessage;

        try
        {            
            travelDetailsDAO tdDAO = new travelDetailsDAO();
            int insCnt = tdDAO.insertTravelDetailsInfo(tripName, startDate, endDate, country, description, expectedExpense);
            if (insCnt == 1)
            {
                errorMessage = "No error!";
                status.Text = "Data Successfully Added! Redirecting you to the next page.";
                Thread.Sleep(5000);
                Response.Redirect("RaysonWebPages/itineraryCreatorStep2.aspx");
            }
            else
            {
                errorMessage = "Unable to insert travel details, please inform system administrator!";
                
                status.Text = errorMessage;
                Thread.Sleep(5000);
                Response.Redirect("RaysonWebPages/itineraryCreatorStep1.aspx");
            }
        }
        catch (FormatException)
        {
            errorMessage = "Reached Catch!";
        }

    }

    protected string Testing(string test)
    {
        return test;
    }

    protected void disableAutoButton_Click(object sender, EventArgs e)
    {
        string errorMessage;

        countryTextBox.Attributes.Add("autocomplete", "off");
        disableAutoButton.Enabled = false;
        enableAutoButton.Enabled = true;

        //Save this details into the database for first timer

        // Update Info
        buttonEnabled = "Disabled";

        toolBoxCheck userObj = new toolBoxCheck();
        toolBoxCheckDAO toolBoxDao = new toolBoxCheckDAO();
        userObj = toolBoxDao.getUsersData("2");
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
                if (item.Key == "buttonEnabled")
                {
                    if (item.Value != buttonEnabled)
                    {
                        //Update the database table
                        values[item.Key] = "Disabled";
                        string json = JsonConvert.SerializeObject(values);
                        int insCnt = toolBoxDao.updateTools(json, 2);
                        if (insCnt == 1)
                        {
                            errorMessage = "No error!";
                            break;
                        }
                        else
                        {
                            errorMessage = "Unable to insert travel details, please inform system administrator!";
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            errorMessage = "No details found!";
        }
    }

    protected void enableAutoButton_Click(object sender, EventArgs e)
    {
        string errorMessage;

        countryTextBox.Attributes.Add("autocomplete", "on");
        enableAutoButton.Enabled = false;
        disableAutoButton.Enabled = true;

        //Save this details into the database for first timer

        // Update Info
        buttonEnabled = "Enabled";

        toolBoxCheck userObj = new toolBoxCheck();
        toolBoxCheckDAO toolBoxDao = new toolBoxCheckDAO();
        userObj = toolBoxDao.getUsersData("2");
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
                if (item.Key == "buttonEnabled")
                {
                    if (item.Value != buttonEnabled)
                    {
                        //Update the database table
                        values[item.Key] = "Enabled";
                        string json = JsonConvert.SerializeObject(values);
                        int insCnt = toolBoxDao.updateTools(json, 2);
                        if (insCnt == 1)
                        {
                            errorMessage = "No error!";
                            break;
                        }
                        else
                        {
                            errorMessage = "Unable to insert travel details, please inform system administrator!";
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            errorMessage = "No details found!";
        }
    }

    protected void autoCompleteButton_Click(object sender, EventArgs e)
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

            autoComplete.Visible = false;

            // Performing loading of tools 
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(toolsString);
            foreach (KeyValuePair<string, string> item in values)
            {
                if(item.Key == "buttonEnabled")
                {
                    values.Remove("buttonEnabled");
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