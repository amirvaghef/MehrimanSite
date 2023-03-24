using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

/// <summary>
/// Summary description for DownloadFile
/// </summary>
public class TranslationCode
{
    public TranslationCode()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /*
    public DataSet GetCategoryOnly()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM DownloadProfile";
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
    */
    public DataSet GetRequestTranslationList()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM TranslationTable WHERE TranslationPaid = true and TranslationSent = false";
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
    
    public DataSet GetRequestPriceList()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM TranslationTable WHERE TranslationCheck = false";
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
    
    public DataSet GetTranslationByID(int translationID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM TranslationTable WHERE TranslationID = " + translationID;
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

    public void InsertTranslation(string UserID, string Username, string Firstname, string Lastname, string EmailAddress, string Tel, string MobileAlias, string TranslationComment, string TranslationSource)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO TranslationTable(UserID, Username, Firstname, Lastname, EmailAddress, Tel, MobileAlias, TranslationComment, TranslationSource)" + 
            " VALUES('" + UserID + "', '" + Username + "', '" + Firstname + "', '" + Lastname + "', '" + EmailAddress + "', '" + Tel + "', '" + MobileAlias + "', '" + TranslationComment + "', '" + TranslationSource + "')";
        OleDbCommand command = new OleDbCommand(comstr, connection);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
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

    public void UpdateCheck(string TranslationPrice, string TranslationDeliveryDay, string TranslationEmailComment, string TranslationID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "UPDATE TranslationTable SET TranslationPrice= " + TranslationPrice + ", TranslationDeliveryDay = " + TranslationDeliveryDay + ", TranslationEmailComment = '" + TranslationEmailComment + "', TranslationCheck = true WHERE TranslationID= " + TranslationID ;
        OleDbCommand command = new OleDbCommand(comstr, connection);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
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

    public void UpdatePaid(string TranslationID, string TranslationRefrenceID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "UPDATE TranslationTable SET TranslationPaid = true, TranslationRefrenceID = '" + TranslationRefrenceID + "' WHERE TranslationID= " + TranslationID;
        OleDbCommand command = new OleDbCommand(comstr, connection);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
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

    public void UpdateSent(string TranslationID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "UPDATE TranslationTable SET TranslationSent = true WHERE TranslationID= " + TranslationID;
        OleDbCommand command = new OleDbCommand(comstr, connection);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
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