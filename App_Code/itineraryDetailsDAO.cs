﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;


/// <summary>
/// Summary description for itineraryDetailsDAO
/// </summary>
public class itineraryDetailsDAO
{
    // Place the DBConnect to class variable to be shared by all the methodsin this class
    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

    public List<itineraryDetails> getTravelDetails(string Id)
    {
        List<itineraryDetails> tdList = new List<itineraryDetails>();

        SqlDataAdapter da;
        DataSet ds = new DataSet();

        //Create Adapter
        //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
        StringBuilder sqlCommand = new StringBuilder();
        sqlCommand.AppendLine("Select * from travelDetails where");
        sqlCommand.AppendLine("userId = @paraUserId");

        SqlConnection myConn = new SqlConnection(DBConnect);
        da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
        da.SelectCommand.Parameters.AddWithValue("paraUserId", Id);
        // fill dataset
        da.Fill(ds, "travelDetailsTable");
        int rec_cnt = ds.Tables["travelDetailsTable"].Rows.Count;
        if (rec_cnt > 0)
        {
            foreach(DataRow row in ds.Tables["travelDetailsTable"].Rows)
            {
                itineraryDetails myTD = new itineraryDetails();

                myTD.travelDetailsId = row["Id"].ToString();
                myTD.tripNameClass = row["tripName"].ToString();
                myTD.startDateClass = DateTime.Parse(row["startDate"].ToString());
                myTD.endDateClass = DateTime.Parse(row["endDate"].ToString());
                myTD.expectedExpensesClass = double.Parse(row["expectedExpense"].ToString());
                myTD.countryClass = row["country"].ToString();
                myTD.stateClass = row["state"].ToString();
                myTD.userIdClass = row["userId"].ToString();

                tdList.Add(myTD);
            }
        }
        else
        {
            tdList = null;
        }
        return tdList;
    }

    public int insertDetails(int id, string itineraryHtml, int travelId)
    {
        StringBuilder sqlStr = new StringBuilder();
        int result = 0;    // Execute NonQuery return an integer value
        SqlCommand sqlCmd = new SqlCommand();
        // Step1 : Create SQL insert command to add record to TDMaster using     

        //         parameterised query in values clause
        //
        StringBuilder sqlCommand = new StringBuilder();
        sqlStr.AppendLine("INSERT INTO itineraryDetails (itineraryHtml, travelDetailsId,");
        sqlStr.AppendLine("userId)");
        sqlStr.AppendLine("VALUES (@paraItineraryHtml, @paraTravelId,");
        sqlStr.AppendLine("@paraUserId)");
        // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

        SqlConnection myConn = new SqlConnection(DBConnect);

        sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

        // Step 3 : Add each parameterised query variable with value
        //          complete to add all parameterised queries

        sqlCmd.Parameters.AddWithValue("@paraItineraryHtml", itineraryHtml);
        sqlCmd.Parameters.AddWithValue("@paraUserId", id);
        sqlCmd.Parameters.AddWithValue("@paraTravelId", travelId);
        // Step 4 Open connection the execute NonQuery of sql command   

        myConn.Open();
        result = sqlCmd.ExecuteNonQuery();

        // Step 5 :Close connection
        myConn.Close();

        return result;
    }
}