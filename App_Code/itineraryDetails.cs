using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for itineraryDetails
/// </summary>
public class itineraryDetails
{
    public itineraryDetails()
    {

    }
    public itineraryDetails(string id, string tripName, DateTime startDate, DateTime endDate, string country, string description, double expectedExpenses, string state, string userId, string itineraryHtml, int travelId)
    {
        travelDetailsId = id;
        travelIdClass = travelId;
        tripNameClass = tripName;
        startDateClass = startDate;
        endDateClass = endDate;
        countryClass = country;
        descriptionClass = description;
        expectedExpensesClass = expectedExpenses;
        stateClass = state;
        userIdClass = userId;
        itineraryHtmlClass = itineraryHtml;
    }
    public string travelDetailsId { get; set; }
    public int travelIdClass { get; set; }
    public string tripNameClass { get; set; }
    public string userIdClass { get; set; }
    public DateTime startDateClass { get; set; }
    public DateTime endDateClass { get; set; }
    public string countryClass { get; set; }
    public string itineraryHtmlClass { get; set; }
    public string descriptionClass { get; set; }
    public double expectedExpensesClass { get; set; }
    public string stateClass { get; set; }
}