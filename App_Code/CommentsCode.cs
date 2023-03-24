using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

/// <summary>
/// Summary description for CommentsCode
/// </summary>
public class CommentsCode
{
    public CommentsCode()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetPageList()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM Pages";
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

    public DataSet GetItemList(short sectionID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = String.Empty;
        switch (sectionID)
        {
            case 1:
                comstr = "SELECT LectureID as ID, LectureName as Title FROM Lecture";
                break;

            case 2:
                comstr = "SELECT ImageProfileID as ID, ImageProfileName as Title FROM ImageProfile";
                break;

            case 3:
                comstr = "SELECT NewsID as ID, NewsTitle as Title FROM News";
                break;

            case 7:
                comstr = "SELECT NewsID as ID, NewsTitle as Title FROM ScientificNews";
                break;

            default:
                return null;
        }
        OleDbDataAdapter adapter = new OleDbDataAdapter(comstr, connection);
        try
        {
            connection.Open();
            adapter.Fill(ds);

            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = 0;
            dr[1] = "-----انتخاب کنید-----";

            ds.Tables[0].Rows.InsertAt(dr, 0);
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

    public DataSet GetAllCommentsList(short sectionID, long itemID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = String.Empty;
        if(itemID == 0) 
            comstr = "SELECT * FROM Comments WHERE SectionID = " + sectionID;
        else
            comstr = "SELECT * FROM Comments WHERE SectionID = " + sectionID + " AND ItemID = " + itemID;

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

    public DataSet GetUnSubmitedComments(short sectionID, long itemID)
    {
        //itemID=0 yani faghat sectionharo biar va item mohem nist
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = String.Empty;
        if (itemID == 0)
            comstr = "SELECT * FROM Comments WHERE SectionID = " + sectionID + " AND Submit=false";
        else
            comstr = "SELECT * FROM Comments WHERE SectionID = " + sectionID + " AND ItemID = " + itemID +" AND Submit=false";

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

    public DataSet GetSubmitedComments(short sectionID, long itemID)
    {
        //itemID=0 yani faghat sectionharo biar va item mohem nist
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM Comments WHERE SectionID = " + sectionID + " AND ItemID = " + itemID + " AND Submit=true";
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

    public void SetSubmit(string commentsID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "UPDATE Comments SET Submit=true WHERE CommentsID='{" + commentsID + "}'";
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

    public void InsertComment(short sectionID, long itemID, string name, string subject, string email, string comment, Boolean submit, DateTime date)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO Comments(SectionID, ItemID, Name, Subject, Email, Comment, Submit, CommentDate) " +
            "VALUES(" + sectionID + ", " + itemID + ", '" + name + "', '" + subject + "', '" + email + "', '" + comment + "', " + submit + ", '" + date + "')";
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

    public void UpdateComment(long commentsID, short sectionID, long itemID, string name, string subject, string email, string comment, Boolean submit, DateTime date)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "UPDATE Comments SET SectionID=" + sectionID + ", ItemID=" + itemID + ", Name='" + name + "', Subject='" + subject + "', Email='" + email +
            "', Comment='" + comment + "', Submit=" + submit + ", CommentDate='" + date + "' WHERE CommentsID='{" + commentsID + "}'";
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

    public void DeleteComment(string CommentsID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "DELETE FROM Comments WHERE CommentsID = '{" + CommentsID + "}'";
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