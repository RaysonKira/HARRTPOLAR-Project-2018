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
    public int insertTravelDetailsInfo(string tripName, DateTime startDate, DateTime endDate, string country, string description, double expectedExpense, string state, string userId, string currentTime)
    {

        StringBuilder sqlStr = new StringBuilder();
        int result = 0;    // Execute NonQuery return an integer value
        SqlCommand sqlCmd = new SqlCommand();
        // Step1 : Create SQL insert command to add record to TDMaster using     

        //         parameterised query in values clause
        //
        StringBuilder sqlCommand = new StringBuilder();
        sqlStr.AppendLine("INSERT INTO travelDetails (tripName, startDate, endDate, country, ");
        sqlStr.AppendLine("description, expectedExpense, state, userId, dateEntered)");
        sqlStr.AppendLine("VALUES (@paraTripName, @paraStartDate, @paraEndDate, @paraCountry,");
        sqlStr.AppendLine("@paraDescription, @paraExpectedExpense, @paraState, @paraUserId, @paraCurrentTime)");
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
        sqlCmd.Parameters.AddWithValue("@paraCurrentTime", currentTime);

        // Step 4 Open connection the execute NonQuery of sql command   

        myConn.Open();
        result = sqlCmd.ExecuteNonQuery();

        // Step 5 :Close connection
        myConn.Close();

        return result;
    }

    public int deleteTravelDetailsInfo(int travelDetailsId)
    {

        StringBuilder sqlStr = new StringBuilder();
        int result = 0;    // Execute NonQuery return an integer value
        SqlCommand sqlCmd = new SqlCommand();
        // Step1 : Create SQL insert command to add record to TDMaster using     

        //         parameterised query in values clause
        //
        StringBuilder sqlCommand = new StringBuilder();
        sqlStr.AppendLine("DELETE FROM travelDetails");
        sqlStr.AppendLine("WHERE Id = @paraTravelDetailsId");
        // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

        SqlConnection myConn = new SqlConnection(DBConnect);

        sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

        // Step 3 : Add each parameterised query variable with value
        //          complete to add all parameterised queries

        sqlCmd.Parameters.AddWithValue("@paraTravelDetailsId", travelDetailsId);

        // Step 4 Open connection the execute NonQuery of sql command   

        myConn.Open();
        result = sqlCmd.ExecuteNonQuery();

        // Step 5 :Close connection
        myConn.Close();

        return result;
    }

    public travelDetails getTravelDetailsData(int travelDetailsId)
    {
        //Get data to see which user is is 

        SqlDataAdapter da;
        DataSet ds = new DataSet();

        //Create Adapter
        //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
        StringBuilder sqlCommand = new StringBuilder();
        sqlCommand.AppendLine("Select * from travelDetails where");
        sqlCommand.AppendLine("Id = @paraTravelDetailsId");

        travelDetails obj = new travelDetails();

        SqlConnection myConn = new SqlConnection(DBConnect);

        da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
        da.SelectCommand.Parameters.AddWithValue("paraTravelDetailsId", travelDetailsId);

        da.Fill(ds, "travelTable");
        int rec_cnt = ds.Tables["travelTable"].Rows.Count;
        if (rec_cnt > 0)
        {
            DataRow row = ds.Tables["travelTable"].Rows[0];
            obj.userIdClass = row["Id"].ToString();
            obj.tripNameClass = row["tripName"].ToString();
            obj.startDateClass = DateTime.Parse(row["startDate"].ToString());
            obj.endDateClass = DateTime.Parse(row["endDate"].ToString());
            obj.countryClass = row["country"].ToString();
            obj.descriptionClass = row["description"].ToString();
            obj.expectedExpensesClass = double.Parse(row["expectedExpense"].ToString());
            obj.stateClass = row["state"].ToString();
            obj.userIdClass = row["userId"].ToString();
            obj.currentTimeClass = row["dateEntered"].ToString();
        }
        else
        {
            obj = null;
        }

        return obj;
    }

    public int updateTravelDetails(int id, string tripName, DateTime startDate, DateTime endDate, string country, string description, double expectedExpense, string state)
    {
        StringBuilder sqlStr = new StringBuilder();
        int result = 0;    // Execute NonQuery return an integer value
        SqlCommand sqlCmd = new SqlCommand();
        // Step1 : Create SQL insert command to add record to TDMaster using     

        //         parameterised query in values clause
        //
        StringBuilder sqlCommand = new StringBuilder();
        sqlStr.AppendLine("UPDATE travelDetails SET tripName = @paraTripName,");
        sqlStr.AppendLine("startDate = @paraStartDate, endDate = @paraEndDate,");
        sqlStr.AppendLine("country = @paraCountry, description = @paraDescription,");
        sqlStr.AppendLine("expectedExpense = @paraExpectedExpense, state = @paraState");
        sqlStr.AppendLine("WHERE Id = @paraTravelId");
        // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

        SqlConnection myConn = new SqlConnection(DBConnect);

        sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

        // Step 3 : Add each parameterised query variable with value
        //          complete to add all parameterised queries

        sqlCmd.Parameters.AddWithValue("@paraTripName", tripName);
        sqlCmd.Parameters.AddWithValue("@paraTravelId", id);
        sqlCmd.Parameters.AddWithValue("@paraStartDate", startDate);
        sqlCmd.Parameters.AddWithValue("@paraEndDate", endDate);
        sqlCmd.Parameters.AddWithValue("@paraCountry", country);
        sqlCmd.Parameters.AddWithValue("@paraDescription", description);
        sqlCmd.Parameters.AddWithValue("@paraExpectedExpense", expectedExpense);
        sqlCmd.Parameters.AddWithValue("@paraState", state);
        // Step 4 Open connection the execute NonQuery of sql command   

        myConn.Open();
        result = sqlCmd.ExecuteNonQuery();

        // Step 5 :Close connection
        myConn.Close();

        return result;
    }
}