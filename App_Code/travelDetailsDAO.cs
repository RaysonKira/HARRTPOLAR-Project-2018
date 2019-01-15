using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Summary description for travelDetailsDAO
/// </summary>
public class travelDetailsDAO
{
    // Place the DBConnect to class variable to be shared by all the methodsin this class
    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
    public int insertTravelDetailsInfo(string tripName, DateTime startDate, DateTime endDate, string country, string description, double expectedExpense, string state, string userId)
    {

        StringBuilder sqlStr = new StringBuilder();
        int result = 0;    // Execute NonQuery return an integer value
        SqlCommand sqlCmd = new SqlCommand();
        // Step1 : Create SQL insert command to add record to TDMaster using     

        //         parameterised query in values clause
        //
        StringBuilder sqlCommand = new StringBuilder();
        sqlStr.AppendLine("INSERT INTO travelDetails (tripName, startDate, endDate, country, ");
        sqlStr.AppendLine("description, expectedExpense, state, userId)");
        sqlStr.AppendLine("VALUES (@paraTripName, @paraStartDate, @paraEndDate, @paraCountry,");
        sqlStr.AppendLine("@paraDescription, @paraExpectedExpense, @paraState, @paraUserId)");
        // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

        SqlConnection myConn = new SqlConnection(DBConnect);

        sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

        // Step 3 : Add each parameterised query variable with value
        //          complete to add all parameterised queries

        sqlCmd.Parameters.AddWithValue("@paraTripName", tripName);
        sqlCmd.Parameters.AddWithValue("@paraStartDate", startDate);
        sqlCmd.Parameters.AddWithValue("@paraEndDate", endDate);
        sqlCmd.Parameters.AddWithValue("@paraCountry", country);
        sqlCmd.Parameters.AddWithValue("@paraDescription", description);
        sqlCmd.Parameters.AddWithValue("@paraExpectedExpense", expectedExpense);
        sqlCmd.Parameters.AddWithValue("@paraState", state);
        sqlCmd.Parameters.AddWithValue("@paraUserId", userId);

        // Step 4 Open connection the execute NonQuery of sql command   

        myConn.Open();
        result = sqlCmd.ExecuteNonQuery();

        // Step 5 :Close connection
        myConn.Close();

        return result;
    }
}