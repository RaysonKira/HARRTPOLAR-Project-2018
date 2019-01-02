using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class travelDetails
{
    public travelDetails()
    {
    }
    public travelDetails(int id, string tripName, DateTime startDate, DateTime endDate, string country, string description, double expectedExpenses)
    {
        travelDetailsId = id;
        tripNameClass = tripName;
        startDateClass = startDate;
        endDateClass = endDate;
        countryClass = country;
        descriptionClass = description;
        expectedExpensesClass = expectedExpenses;
    }
    public int travelDetailsId { get; set; }
    public string tripNameClass { get; set; }
    public DateTime startDateClass { get; set; }
    public DateTime endDateClass { get; set; }
    public string countryClass { get; set; }
    public string descriptionClass { get; set; }
    public double expectedExpensesClass { get; set; }
}