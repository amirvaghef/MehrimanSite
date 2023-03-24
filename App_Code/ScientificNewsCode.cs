using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

/// <summary>
/// Summary description for News
/// </summary>
public class ScientificNewsCode
{
    public ScientificNewsCode()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet GetArchiveNews()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM ArchiveScientificNewsQuery";
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

    public DataSet GetFreshNews()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM FreshScientificNewsQuery ORDER BY InsertDate DESC";
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

    public DataSet GetAllNews()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM ScientificNews ORDER BY InsertDate DESC";
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

    public DataSet GetNews(int newsID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM ScientificNews WHERE NewsID = " + newsID;
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

    public void UpdateNews(int newsID,string newsTitle, string newsAbstract, string newsContent, DateTime insertDate, DateTime archiveDate, string tags)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "UPDATE ScientificNews SET NewsTitle='" + newsTitle + "', NewsAbstract='" + newsAbstract + "', NewsContent='" + newsContent + "', InsertDate='" + insertDate + "', ArchiveDate='" + archiveDate + "' WHERE NewsID = " + newsID;
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strTags = "UPDATE Tags SET Tags='" + tags +
                            "' WHERE SectionID=7 AND ItemID=" + newsID;
            OleDbCommand commandTags = new OleDbCommand(strTags, connection, trans);
            commandTags.ExecuteNonQuery();

            trans.Commit();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public void InsertNews(string newsTitle, string newsAbstract, string newsContent, DateTime insertDate, DateTime archiveDate, string tags)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "INSERT INTO ScientificNews(NewsTitle, NewsAbstract, NewsContent, InsertDate, ArchiveDate) VALUES('" + newsTitle + "', '" + newsAbstract + "', '" + newsContent + "', '" + insertDate + "', '" + archiveDate + "')";
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strNewsID = "SELECT MAX(NewsID) FROM ScientificNews";
            OleDbCommand commandNewsID = new OleDbCommand(strNewsID, connection, trans);
            string newsID = commandNewsID.ExecuteScalar().ToString();

            string strTags = "INSERT INTO Tags(SectionID, ItemID, Tags) VALUES('7', '" + newsID + "', '" + tags + "')";
            OleDbCommand commandTagsInsert = new OleDbCommand(strTags, connection, trans);
            commandTagsInsert.ExecuteNonQuery();

            trans.Commit();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public void DeleteNews(string NewsID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "DELETE FROM ScientificNews WHERE NewsID = " + NewsID;
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strTags = "DELETE FROM Tags WHERE SectionID=7 AND ItemID=" + NewsID;
            OleDbCommand commandTagsDelete = new OleDbCommand(strTags, connection, trans);
            commandTagsDelete.ExecuteNonQuery();

            trans.Commit();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }
}