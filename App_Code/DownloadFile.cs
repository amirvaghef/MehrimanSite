using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

/// <summary>
/// Summary description for DownloadFile
/// </summary>
public class DownloadFile
{
    public DownloadFile()
    {
        //
        // TODO: Add constructor logic here
        //
    }
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

    public DataSet GetCategory()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM DownloadFileQuery";
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

    public DataSet GetAllDownload()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM AllDownloadQuery";
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

    public DataSet GetDownloads(int categoryID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT DownloadID, DownloadName, DownloadComment, DownloadSource, DownloadSize, DownloadPrice, IsLink, fk_DownloadProfileID, '1' as Tags FROM Download WHERE fk_DownloadProfileID = " + categoryID;
        OleDbDataAdapter adapter = new OleDbDataAdapter(comstr, connection);
        try
        {

            connection.Open();
            adapter.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DataSet dsTags = new TagsCode().GetTags(5, long.Parse(row["DownloadID"].ToString()));
                string tags = String.Empty;
                foreach (DataRow tagRow in dsTags.Tables[0].Rows)
                {
                    tags += "<a href='Search.aspx?Tag=" + tagRow["Tags"].ToString() + "'>" + tagRow["Tags"].ToString() + "</a> , " ;
                }
                row["Tags"] = tags;
            }
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

    public DataSet GetDownloadByID(int downloadID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT DownloadID, DownloadName, DownloadComment, DownloadSource, DownloadSize, DownloadPrice, IsLink, fk_DownloadProfileID FROM Download WHERE DownloadID = " + downloadID;
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

    public void InsertCategory(string name, string comment, string source)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO DownloadProfile(DownloadProfileName, DownloadProfileComment, DownloadProfileSource) VALUES('" + name + "', '" + comment + "', '" + source + "')";
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

    public void DeleteCategory(string DownloadProfileID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "DELETE FROM DownloadProfile WHERE DownloadProfileID = " + DownloadProfileID;
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

    public void InsertDownload(string name, string comment, string source, int size, int price, Boolean isLink, int profileID, string tags)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "INSERT INTO Download(DownloadName, DownloadComment, DownloadSource, DownloadSize, DownloadPrice, IsLink, fk_DownloadProfileID) VALUES('" + name + "', '" + comment + "', '" + source + "', '" + size + "', '" + price + "', " + isLink + ", '" + profileID + "')";
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strDownloadID = "SELECT MAX(DownloadID) FROM Download";
            OleDbCommand commandDownloadID = new OleDbCommand(strDownloadID, connection, trans);
            string downloadID = commandDownloadID.ExecuteScalar().ToString();

            string strTags = "INSERT INTO Tags(SectionID, ItemID, Tags) VALUES('5', '" + downloadID + "', '" + tags + "')";
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

    public void InsertBuyDownload(string DownloadBuyID, string DownloadRefrenceID, int DownloadID, string DownloadBuyPrice, string fk_UserID, string fk_Username)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        try
        {
            string comstr = "INSERT INTO Download(DownloadBuyID, DownloadRefrenceID, DownloadID, DownloadBuyTime, DownloadBuyPrice, fk_UserID, fk_Username) VALUES('" + DownloadBuyID + "', '" + DownloadRefrenceID + "', " + DownloadID + ", '" + DateTime.Today + "', '" + DownloadBuyPrice + "', '" + fk_UserID + "', '" + fk_Username + "')";
            OleDbCommand command = new OleDbCommand(comstr, connection);
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

    public void DeleteDownload(string DownloadID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "DELETE FROM Download WHERE DownloadID = " + DownloadID;
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strTags = "DELETE FROM Tags WHERE SectionID=5 AND ItemID=" + DownloadID;
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