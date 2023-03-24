using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for ImageGallery
/// </summary>
public class ImageGallery
{
	public ImageGallery()
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
        string comstr = "SELECT * FROM ImageProfile";
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

    public DataSet GetAllImage()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM AllImageQuery";
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
        string comstr = "SELECT * FROM ImageGalleryQuery";
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

    public DataSet GetImages(int categoryID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM ImageGallery WHERE fk_ImageProfileID = " + categoryID;
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

    public void InsertCategory(string name, string comment, string tags)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "INSERT INTO ImageProfile(ImageProfileName, ImageProfileComment) VALUES('" + name + "', '" + comment + "')";
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strImageID = "SELECT MAX(ImageProfileID) FROM ImageProfile";
            OleDbCommand commandImageID = new OleDbCommand(strImageID, connection, trans);
            string imageProfileID = commandImageID.ExecuteScalar().ToString();

            string strTags = "INSERT INTO Tags(SectionID, ItemID, Tags) VALUES('2', '" + imageProfileID + "', '" + tags + "')";
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

    public void DeleteCategory(string ImageProfileID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "DELETE FROM ImageProfile WHERE ImageProfileID = " + ImageProfileID;
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strTags = "DELETE FROM Tags WHERE SectionID=2 AND ItemID=" + ImageProfileID;
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

    public void InsertImage(string name, string comment, string source, int profileID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO ImageGallery(ImageName, ImageComment, ImageSource, fk_ImageProfileID) VALUES('" + name + "', '" + comment + "', '" + source + "', '" + profileID + "')";
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

    public void DeleteImage(string ImageID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "DELETE FROM ImageGallery WHERE ImageID = " + ImageID;
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strTags = "DELETE FROM Tags WHERE SectionID='2' AND ItemID='" + ImageID + "'";
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