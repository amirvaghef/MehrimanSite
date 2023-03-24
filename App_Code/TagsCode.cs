using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

/// <summary>
/// Summary description for CommentsCode
/// </summary>
public class TagsCode
{
    public TagsCode()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetSearchList(string tag)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT 'LectureDetail.aspx?id='&LectureID as Address, LectureName as Title, LectureComment as [Text] FROM Lecture WHERE LectureName LIKE '%" + tag + "%' or LectureComment LIKE '%" + tag + "%' UNION ALL" +
            " SELECT 'GalleryDetail.aspx?cat='&ImageProfileID as Address, ImageProfileName as Title, ImageProfileComment as [Text] FROM ImageProfile WHERE ImageProfileName LIKE '%" + tag + "%' or ImageProfileComment LIKE '%" + tag + "%' UNION ALL" +
            " SELECT 'NewsDetail.aspx?Item='&NewsID as Address, NewsTitle as Title, NewsAbstract as [Text] FROM News WHERE NewsTitle LIKE '%" + tag + "%' or NewsAbstract LIKE '%" + tag + "%' or NewsContent LIKE '%" + tag + "%' UNION ALL" +
            " SELECT 'ScientificNewsDetail.aspx?Item='&NewsID as Address, NewsTitle as Title, NewsAbstract as [Text] FROM ScientificNews WHERE NewsTitle LIKE '%" + tag + "%' or NewsAbstract LIKE '%" + tag + "%' or NewsContent LIKE '%" + tag + "%' UNION ALL" +
            " SELECT 'LectureNewsDetail.aspx?Item='&NewsID as Address, NewsTitle as Title, NewsAbstract as [Text] FROM LectureNews WHERE NewsTitle LIKE '%" + tag + "%' or NewsAbstract LIKE '%" + tag + "%' or NewsContent LIKE '%" + tag + "%' UNION ALL" +
            " SELECT 'Download.aspx?cat='&fk_DownloadProfileID as Address, DownloadName as Title, DownloadComment as [Text] FROM Download WHERE DownloadName LIKE '%" + tag + "%' or DownloadComment LIKE '%" + tag + "%'";
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

    public DataSet GetTagsOriginal(short sectionID, long itemID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = String.Empty;
        if (itemID == 0)
            comstr = "SELECT * FROM Tags WHERE SectionID = " + sectionID;
        else
            comstr = "SELECT * FROM Tags WHERE SectionID = " + sectionID + " AND ItemID = " + itemID;

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

    public DataSet GetTags(short sectionID, long itemID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = String.Empty;
        if(itemID == 0) 
            comstr = "SELECT * FROM Tags WHERE SectionID = " + sectionID;
        else
            comstr = "SELECT * FROM Tags WHERE SectionID = " + sectionID + " AND ItemID = " + itemID;

        OleDbDataAdapter adapter = new OleDbDataAdapter(comstr, connection);
        try
        {

            connection.Open();
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                string TagsID = ds.Tables[0].Rows[0]["TagsID"].ToString();
                short SectionID = short.Parse(ds.Tables[0].Rows[0]["SectionID"].ToString());
                long ItemID = long.Parse(ds.Tables[0].Rows[0]["ItemID"].ToString());
                string[] tags = ds.Tables[0].Rows[0]["Tags"].ToString().Split(new string[] { ",", "،" }, StringSplitOptions.None);
                ds.Clear();
                foreach (string tag in tags)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["TagsID"] = TagsID;
                    dr["SectionID"] = SectionID;
                    dr["ItemID"] = ItemID;
                    dr["Tags"] = tag.Trim();
                    ds.Tables[0].Rows.Add(dr);
                }
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

    //public DataSet GetUnSubmitedComments(short sectionID, long itemID)
    //{
    //    //itemID=0 yani faghat sectionharo biar va item mohem nist
    //    DataSet ds = new DataSet();
    //    string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
    //    OleDbConnection connection = new OleDbConnection(constr);
    //    string comstr = "SELECT * FROM Comments WHERE SectionID = " + sectionID + " AND ItemID = " + itemID + " AND Submit=false";
    //    OleDbDataAdapter adapter = new OleDbDataAdapter(comstr, connection);
    //    try
    //    {
    //        connection.Open();
    //        adapter.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        connection.Close();
    //    }
    //}

    //public DataSet GetSubmitedComments(short sectionID, long itemID)
    //{
    //    //itemID=0 yani faghat sectionharo biar va item mohem nist
    //    DataSet ds = new DataSet();
    //    string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
    //    OleDbConnection connection = new OleDbConnection(constr);
    //    string comstr = "SELECT * FROM Comments WHERE SectionID = " + sectionID + " AND ItemID = " + itemID + " AND Submit=true";
    //    OleDbDataAdapter adapter = new OleDbDataAdapter(comstr, connection);
    //    try
    //    {
    //        connection.Open();
    //        adapter.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        connection.Close();
    //    }
    //}

    //public void SetSubmit(long commentsID)
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
    //    OleDbConnection connection = new OleDbConnection(constr);
    //    string comstr = "UPDATE Comments SET Submit= true WHERE CommentsID=" + commentsID;
    //    OleDbCommand command = new OleDbCommand(comstr, connection);
    //    try
    //    {
    //        connection.Open();
    //        command.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        connection.Close();
    //    }
    //}

    //public void InsertComment(short sectionID, long itemID, string name, string subject, string email, string comment, Boolean submit, DateTime date)
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
    //    OleDbConnection connection = new OleDbConnection(constr);
    //    string comstr = "INSERT INTO Comments(SectionID, ItemID, Name, Subject, Email, Comment, Submit, CommentDate) " +
    //        "VALUES(" + sectionID + ", " + itemID + ", '" + name + "', '" + subject + "', '" + email + "', '" + comment + "', " + submit + ", '" + date + "')";
    //    OleDbCommand command = new OleDbCommand(comstr, connection);
    //    try
    //    {
    //        connection.Open();
    //        command.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        connection.Close();
    //    }
    //}

    //public void UpdateComment(long commentsID, short sectionID, long itemID, string name, string subject, string email, string comment, Boolean submit, DateTime date)
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
    //    OleDbConnection connection = new OleDbConnection(constr);
    //    string comstr = "UPDATE Comments SET SectionID=" + sectionID + ", ItemID=" + itemID + ", Name='" + name + "', Subject='" + subject + "', Email='" + email +
    //        "', Comment='" + comment + "', Submit=" + submit + ", CommentDate='" + date + "' WHERE CommentsID=" + commentsID;
    //    OleDbCommand command = new OleDbCommand(comstr, connection);
    //    try
    //    {
    //        connection.Open();
    //        command.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        connection.Close();
    //    }
    //}

    //public void DeleteComment(string CommentsID)
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
    //    OleDbConnection connection = new OleDbConnection(constr);
    //    string comstr = "DELETE FROM Comments WHERE CommentsID = " + CommentsID;
    //    OleDbCommand command = new OleDbCommand(comstr, connection);
    //    try
    //    {
    //        connection.Open();
    //        command.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        connection.Close();
    //    }
    //}
}