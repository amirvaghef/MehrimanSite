using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

/// <summary>
/// Summary description for News
/// </summary>
public class LectureNewsCode
{
    public LectureNewsCode()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet GetAllNews()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM LectureNews ORDER BY InsertDate DESC";
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
        string comstr = "SELECT * FROM LectureNews WHERE NewsID = " + newsID;
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

    public void UpdateNews(int newsID,string newsTitle, string newsAbstract, string newsContent, DateTime insertDate, string tags)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "UPDATE LectureNews SET NewsTitle='" + newsTitle + "', NewsAbstract='" + newsAbstract + "', NewsContent='" + newsContent + "', InsertDate='" + insertDate + "' WHERE NewsID = " + newsID;
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strTags = "UPDATE Tags SET Tags='" + tags +
                            "' WHERE SectionID=8 AND ItemID=" + newsID;
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

    public void InsertNews(string newsTitle, string newsAbstract, string newsContent, DateTime insertDate, string tags)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "INSERT INTO LectureNews(NewsTitle, NewsAbstract, NewsContent, InsertDate) VALUES('" + newsTitle + "', '" + newsAbstract + "', '" + newsContent + "', '" + insertDate + "')";
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strNewsID = "SELECT MAX(NewsID) FROM LectureNews";
            OleDbCommand commandNewsID = new OleDbCommand(strNewsID, connection, trans);
            string newsID = commandNewsID.ExecuteScalar().ToString();

            string strTags = "INSERT INTO Tags(SectionID, ItemID, Tags) VALUES('8', '" + newsID + "', '" + tags + "')";
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
            string comstr = "DELETE FROM LectureNews WHERE NewsID = " + NewsID;
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strTags = "DELETE FROM Tags WHERE SectionID=8 AND ItemID=" + NewsID;
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