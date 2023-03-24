using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

/// <summary>
/// Summary description for Users
/// </summary>
public class UsersCode
{
	public UsersCode()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet GetUser(string userID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["ASPNETConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM aspnet_Users WHERE UserId=" + userID;
        OleDbDataAdapter adapter = new OleDbDataAdapter(comstr, connection);
        try
        {

            connection.Open();
            adapter.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }
}