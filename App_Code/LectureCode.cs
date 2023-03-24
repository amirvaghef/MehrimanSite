using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

/// <summary>
/// Summary description for News
/// </summary>
public class LectureCode
{
    public LectureCode()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet GetLectureTypeDiscount(int lectureID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM LectureTypeDiscountQuery WHERE LectureID = " + lectureID;
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

    public DataSet GetTimeDiscount(int lectureID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM LectureTimeDiscount WHERE LectureID= " + lectureID;
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

    public DataSet GetNumberDiscount(int lectureID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM LectureNumberDiscount WHERE  LectureID= " + lectureID;
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

    public DataSet GetLecture(int lectureID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM Lecture WHERE LectureID=" + lectureID;
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

    public DataSet GetUnBuyLecture()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM LectureUnBuyQuery";
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

    public DataSet GetValidLectureList()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM LectureListQuery";
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

    public DataSet GetAllLecture()
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT LectureID, LectureName FROM Lecture";
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

    public DataSet GetBuyLecture(string LectureID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM LectureBuy WHERE LectureID = " + LectureID;
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

    public DataSet GetLectureLectureBuy(string lectureBuyID)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "SELECT * FROM LectureLectureBuyQuery WHERE LectureBuyID ='" + lectureBuyID + "'";
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

    public void InsertLecture(string lectureName, string lectureComment, DateTime lectureDate, int lecturePrice, int lectureCapacity, DateTime lectureTimeOut,
        int studentDiscount, int ostadDiscount, int freeDiscount, int number1From, int number1Til, int number2From, int number2Til, int number3From,
        int number3Til, int number1Discount, int number2Discount, int number3Discount, DateTime date1From, DateTime date1Til, DateTime date2From, DateTime date2Til,
        DateTime date3From, DateTime date3Til, int date1Discount, int date2Discount, int date3Discount, string tags)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {


            string comstrMain = "INSERT INTO Lecture(LectureName, LectureComment, LectureDate, LecturePrice, LectureCapacity, LectureTimeOut) VALUES('" + lectureName + "', '" + lectureComment + "', '" + lectureDate + "', '" + lecturePrice + "', '" + lectureCapacity + "', '" + lectureTimeOut + "')";
            OleDbCommand commandMain = new OleDbCommand(comstrMain, connection, trans);
            string strLectureID = "SELECT MAX(LectureID) FROM Lecture";
            OleDbCommand commandLectureID = new OleDbCommand(strLectureID, connection, trans);

            commandMain.ExecuteNonQuery();
            string lectureid = commandLectureID.ExecuteScalar().ToString();

            string strLectureTypeDiscount1 = "INSERT INTO LectureTypeDiscount(LectureID, LectureTypeID, LectureTypeDiscountPercent) VALUES('" + lectureid + "', '1', '" + studentDiscount + "')";
            string strLectureTypeDiscount2 = "INSERT INTO LectureTypeDiscount(LectureID, LectureTypeID, LectureTypeDiscountPercent) VALUES('" + lectureid + "', '2', '" + ostadDiscount + "')";
            string strLectureTypeDiscount3 = "INSERT INTO LectureTypeDiscount(LectureID, LectureTypeID, LectureTypeDiscountPercent) VALUES('" + lectureid + "', '3', '" + freeDiscount + "')";
            OleDbCommand commandLectureType1 = new OleDbCommand(strLectureTypeDiscount1, connection, trans);
            commandLectureType1.ExecuteNonQuery();
            OleDbCommand commandLectureType2 = new OleDbCommand(strLectureTypeDiscount2, connection, trans);
            commandLectureType2.ExecuteNonQuery();
            OleDbCommand commandLectureType3 = new OleDbCommand(strLectureTypeDiscount3, connection, trans);
            commandLectureType3.ExecuteNonQuery();

            string strLectureNumber = "INSERT INTO LectureNumberDiscount(LectureID, Number1From, Number1Til, Number2From, Number2Til, Number3From, Number3Til, Number1Discount, Number2Discount, Number3Discount) VALUES('" +
                lectureid + "', '" + number1From + "', '" + number1Til + "', '" + number2From + "', '" + number2Til + "', '" + number3From + "', '" + number3Til + "', '" + number1Discount + "', '" + number2Discount + "', '" + number3Discount + "')";
            OleDbCommand commandLectureNumber = new OleDbCommand(strLectureNumber, connection, trans);
            commandLectureNumber.ExecuteNonQuery();

            string strLectureDate = "INSERT INTO LectureTimeDiscount(LectureID, Date1From, Date1Til, Date2From, Date2Til, Date3From, Date3Til, Date1Discount, Date2Discount, Date3Discount) VALUES('" +
                lectureid + "', '" + date1From + "', '" + date1Til + "', '" + date2From + "', '" + date2Til + "', '" + date3From + "', '" + date3Til + "', '" + date1Discount + "', '" + date2Discount + "', '" + date3Discount + "')";
            OleDbCommand commandLectureDate = new OleDbCommand(strLectureDate, connection, trans);
            commandLectureDate.ExecuteNonQuery();

            string strTags = "INSERT INTO Tags(SectionID, ItemID, Tags) VALUES('1', '" + lectureid + "', '" + tags + "')";
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

    public void UpdateLecture(int lectureID, string lectureName, string lectureComment, DateTime lectureDate, int lecturePrice, int lectureCapacity, DateTime lectureTimeOut,
        int studentDiscount, int ostadDiscount, int freeDiscount, int number1From, int number1Til, int number2From, int number2Til, int number3From,
        int number3Til, int number1Discount, int number2Discount, int number3Discount, DateTime date1From, DateTime date1Til, DateTime date2From, DateTime date2Til,
        DateTime date3From, DateTime date3Til, int date1Discount, int date2Discount, int date3Discount, string tags)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {


            string comstrMain = "UPDATE Lecture SET LectureName='" + lectureName +
                                "', LectureComment='" + lectureComment +
                                "', LectureDate='" + lectureDate +
                                "', LecturePrice='" + lecturePrice +
                                "', LectureCapacity='" + lectureCapacity + 
                                "', LectureTimeOut='" + lectureTimeOut + 
                                "' WHERE LectureID=" + lectureID;
            OleDbCommand commandMain = new OleDbCommand(comstrMain, connection, trans);
            commandMain.ExecuteNonQuery();

            string strLectureTypeDiscount1 = "UPDATE LectureTypeDiscount SET LectureTypeDiscountPercent='" + studentDiscount + "' WHERE LectureID=" + lectureID + " AND LectureTypeID=1";
            string strLectureTypeDiscount2 = "UPDATE LectureTypeDiscount SET LectureTypeDiscountPercent='" + ostadDiscount + "' WHERE LectureID=" + lectureID + " AND LectureTypeID=2";
            string strLectureTypeDiscount3 = "UPDATE LectureTypeDiscount SET LectureTypeDiscountPercent='" + freeDiscount + "' WHERE LectureID=" + lectureID + " AND LectureTypeID=3";
            OleDbCommand commandLectureType1 = new OleDbCommand(strLectureTypeDiscount1, connection, trans);
            commandLectureType1.ExecuteNonQuery();
            OleDbCommand commandLectureType2 = new OleDbCommand(strLectureTypeDiscount2, connection, trans);
            commandLectureType2.ExecuteNonQuery();
            OleDbCommand commandLectureType3 = new OleDbCommand(strLectureTypeDiscount3, connection, trans);
            commandLectureType3.ExecuteNonQuery();

            string strLectureNumber = "UPDATE LectureNumberDiscount SET Number1From='" + number1From +
                                      "', Number1Til='" + number1Til +
                                      "', Number2From='" + number2From +
                                      "', Number2Til='" + number2Til +
                                      "', Number3From='" + number3From +
                                      "', Number3Til='" + number3Til +
                                      "', Number1Discount='" + number1Discount +
                                      "', Number2Discount='" + number2Discount +
                                      "', Number3Discount='" + number3Discount + 
                                      "' WHERE LectureID=" + lectureID;
            OleDbCommand commandLectureNumber = new OleDbCommand(strLectureNumber, connection, trans);
            commandLectureNumber.ExecuteNonQuery();

            string strLectureDate = "UPDATE LectureTimeDiscount SET Date1From='" + date1From +
                                    "', Date1Til='" + date1Til +
                                    "', Date2From='" + date2From +
                                    "', Date2Til='" + date2Til +
                                    "', Date3From='" + date3From +
                                    "', Date3Til='" + date3Til +
                                    "', Date1Discount='" + date1Discount +
                                    "', Date2Discount='" + date2Discount +
                                    "', Date3Discount='" + date3Discount + 
                                    "' WHERE LectureID=" + lectureID;
            OleDbCommand commandLectureDate = new OleDbCommand(strLectureDate, connection, trans);
            commandLectureDate.ExecuteNonQuery();

            string strTags = "UPDATE Tags SET Tags='" + tags +
                            "' WHERE SectionID=1 AND ItemID=" + lectureID;
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

    public void InsertLectureBuy(string LectureBuyID, string LectureID, string LectureType, string LectureBuyNumber, string LectureBuyPrice, string fk_UserID, 
        string fk_Username, string fk_Firstname, string fk_Lastname, string fk_Address, string fk_EmailAddress, string fk_Tel, string fk_MobileAlias)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "INSERT INTO LectureBuy(LectureBuyID, LectureID, LectureType, LectureBuyNumber, LectureBuyTime, LectureBuyPrice, fk_UserID, fk_Username, fk_Firstname, fk_Lastname, fk_Address, fk_EmailAddress, fk_Tel, fk_MobileAlias) " +
            "VALUES('" + LectureBuyID + "', " + LectureID + ", '" + LectureType + "', '" + LectureBuyNumber + "', '" + DateTime.Today + "', '" + LectureBuyPrice + "', '" + fk_UserID + "', '" + fk_Username + "', '" + fk_Firstname + "', '" + fk_Lastname + "', '" + fk_Address + "', '" + fk_EmailAddress + "', '" + fk_Tel + "', '" + fk_MobileAlias + "')";
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

    public void UpdateLectureBuy(string LectureRefrenceID, string LectureBuyID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        string comstr = "UPDATE LectureBuy SET LectureRefrenceID = '" + LectureRefrenceID + "' WHERE LectureBuyID = '" + LectureBuyID + "'";
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

    public void DeleteLecture(string LectureID)
    {
        string constr = ConfigurationManager.ConnectionStrings["MehrimanConnectionString"].ConnectionString;
        OleDbConnection connection = new OleDbConnection(constr);
        connection.Open();
        OleDbTransaction trans = connection.BeginTransaction();
        try
        {
            string comstr = "DELETE FROM Lecture WHERE LectureID = " + LectureID;
            OleDbCommand command = new OleDbCommand(comstr, connection, trans);
            command.ExecuteNonQuery();

            string strTags = "DELETE FROM Tags WHERE SectionID=1 AND ItemID=" + LectureID + "";
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