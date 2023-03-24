using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DownloadFile
/// </summary>
public class TrainingCode
{
    public TrainingCode()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public DataSet GetDegreeList()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM Degree";
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

    public DataSet GetCourseList(string degreeID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM Course WHERE fk_DegreeID = " + degreeID;
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

    public DataSet GetLessonList(string courseID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM Lesson WHERE fk_CourseID = " + courseID;
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

    public DataSet GetAllPartList(string lessonID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM Part WHERE fk_LessonID = " + lessonID;
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

    public DataSet GetPartList(string lessonID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM Part WHERE Archive = false and fk_LessonID = " + lessonID;
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

    public DataSet GetLessonReserve(string fk_PartID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM LessonReserve WHERE fk_PartID = " + fk_PartID;
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

    public DataSet GetPartByID(string partID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM Part WHERE PartID = " + partID;
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

    public void InsertLessonReserve(string UserID, string Username, string FirstName, string LastName, string EmailAddress, string Tel, string MobileAlias, string fk_PartID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO LessonReserve(UserID, Username, FirstName, LastName, EmailAddress, Tel, MobileAlias, fk_PartID)" +
            " VALUES(" + UserID + ", '" + Username + "', '" + FirstName + "', '" + LastName + "', '" + EmailAddress + "', '" + Tel + "', '" + MobileAlias + "', " + fk_PartID + ")";
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
    
    public void InsertDegree(string DegreeName)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO Degree(DegreeName) VALUES('" + DegreeName + "')";
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

    public void DeleteDegree(string DegreeID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "DELETE FROM Degree WHERE DegreeID = " + DegreeID;
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

    public void InsertCourse(string CourseName, string fk_DegreeID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO Course(CourseName, fk_DegreeID) VALUES('" + CourseName + "', " + fk_DegreeID + ")";
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

    public void DeleteCourse(string CourseID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "DELETE FROM Course WHERE CourseID = " + CourseID;
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

    public void InsertLesson(string LessonName, string fk_CourseID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO Lesson(LessonName, fk_CourseID) VALUES('" + LessonName + "', " + fk_CourseID + ")";
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

    public void DeleteLesson(string LessonID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "DELETE FROM Lesson WHERE LessonID = " + LessonID;
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

    public void InsertPart(string PartName, string PartComment, string fk_LessonID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO Part(PartName, PartComment, fk_LessonID) VALUES('" + PartName + "', '" + PartComment + "', " + fk_LessonID + ")";
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

    public void DeletePart(string PartID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "DELETE FROM Part WHERE PartID = " + PartID;
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

    public void ArchivePart(string PartID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "Update Part SET Archive = true WHERE PartID = " + PartID;
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

    public void UpdatePart(string PartComment, string PartID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "Update Part SET PartComment ='" + PartComment + "' WHERE PartID = " + PartID;
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