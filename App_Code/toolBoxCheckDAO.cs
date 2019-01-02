using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for toolBoxCheckDAO
/// </summary>
public class toolBoxCheckDAO
{

    // Place the DBConnect to class variable to be shared by all the methodsin this class
    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

    public toolBoxCheck getUsersData(string userId)
    {
        //Get data to see which user is is 

        SqlDataAdapter da;
        DataSet ds = new DataSet();

        //Create Adapter
        //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
        StringBuilder sqlCommand = new StringBuilder();
        sqlCommand.AppendLine("Select * from users where");
        sqlCommand.AppendLine("Id = @paraUserId");

        toolBoxCheck obj = new toolBoxCheck();

        SqlConnection myConn = new SqlConnection(DBConnect);

        da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
        da.SelectCommand.Parameters.AddWithValue("paraUserId", userId);

        da.Fill(ds, "userTable");
        int rec_cnt = ds.Tables["userTable"].Rows.Count;
        if (rec_cnt > 0)
        {
            DataRow row = ds.Tables["userTable"].Rows[0];
            obj.userIdClass = row["Id"].ToString();
            obj.userNameClass = row["username"].ToString();
            obj.passwordClass = row["password"].ToString();
            obj.buttonEnabledClass = row["buttonEnabled"].ToString();
            obj.emailClass = row["email"].ToString();
            obj.toolsClass = row["tools"].ToString();
        }
        else
        {
            obj = null;
        }

        return obj;
    }

    public int updateTable(string buttonStatus, int id)
    {
        StringBuilder sqlStr = new StringBuilder();
        int result = 0;    // Execute NonQuery return an integer value
        SqlCommand sqlCmd = new SqlCommand();
        // Step1 : Create SQL insert command to add record to TDMaster using     

        //         parameterised query in values clause
        //
        StringBuilder sqlCommand = new StringBuilder();
        sqlStr.AppendLine("UPDATE users SET buttonEnabled = @paraButtonStatus");
        sqlStr.AppendLine("WHERE Id = @paraUserId");
        // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

        SqlConnection myConn = new SqlConnection(DBConnect);

        sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

        // Step 3 : Add each parameterised query variable with value
        //          complete to add all parameterised queries

        sqlCmd.Parameters.AddWithValue("@paraButtonStatus", buttonStatus);
        sqlCmd.Parameters.AddWithValue("@paraUserId", id);
        // Step 4 Open connection the execute NonQuery of sql command   

        myConn.Open();
        result = sqlCmd.ExecuteNonQuery();

        // Step 5 :Close connection
        myConn.Close();

        return result;
    }

    public int updateTools(string tools, int id)
    {
        StringBuilder sqlStr = new StringBuilder();
        int result = 0;    // Execute NonQuery return an integer value
        SqlCommand sqlCmd = new SqlCommand();
        // Step1 : Create SQL insert command to add record to TDMaster using     

        //         parameterised query in values clause
        //
        StringBuilder sqlCommand = new StringBuilder();
        sqlStr.AppendLine("UPDATE users SET tools = @paraTools");
        sqlStr.AppendLine("WHERE Id = @paraUserId");
        // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

        SqlConnection myConn = new SqlConnection(DBConnect);

        sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

        // Step 3 : Add each parameterised query variable with value
        //          complete to add all parameterised queries

        sqlCmd.Parameters.AddWithValue("@paraTools", tools);
        sqlCmd.Parameters.AddWithValue("@paraUserId", id);
        // Step 4 Open connection the execute NonQuery of sql command   

        myConn.Open();
        result = sqlCmd.ExecuteNonQuery();

        // Step 5 :Close connection
        myConn.Close();

        return result;
    }
}