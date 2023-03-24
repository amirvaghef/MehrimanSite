using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for ImageGallery
/// </summary>
public class ImageFirstPageCode
{
    public ImageFirstPageCode()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet GetAllImages()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM ImageFirstPage";
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

    public DataSet GetTopImages()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM ImageFirstPage WHERE [Position]=0";
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

    public DataSet GetMiddleImages()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM ImageFirstPage WHERE [Position]=1";
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

    public DataSet GetBottomImages()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM ImageFirstPage WHERE [Position]=2";
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

    public void Insert(string name, string address, string link, short position)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        try
        {
            string comstr = "INSERT INTO ImageFirstPage(ImageName, ImageAddress, ImageLink, [Position]) VALUES('" + name + "', '" + address + "',  '" + link + "', '" + position + "')";
            OleDbCommand command = new OleDbCommand(comstr, connection);
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

    public void Delete(long imageID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        try
        {
            string comstr = "DELETE FROM ImageFirstPage WHERE ImageID = " + imageID;
            OleDbCommand command = new OleDbCommand(comstr, connection);
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