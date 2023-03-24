using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Administrator_LectureAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["LecID"] != null)
            {
                int lectureID = int.Parse(Request.QueryString["LecID"]);
                LectureCode lectCode = new LectureCode();
                DataSet ds = lectCode.GetLecture(lectureID);
                DataSet typeDiscountDS = lectCode.GetLectureTypeDiscount(lectureID);
                DataSet timeDiscountDS = lectCode.GetTimeDiscount(lectureID);
                DataSet numberDiscountDS = lectCode.GetNumberDiscount(lectureID);
                DataRow[] typeDiscountRow = typeDiscountDS.Tables[0].Select("", "LectureTypeID Asc");

                txtLectureName.Text = ds.Tables[0].Rows[0]["LectureName"].ToString();
                editor1.Value = ds.Tables[0].Rows[0]["LectureComment"].ToString();
                txtLecturePrice.Text = int.Parse(ds.Tables[0].Rows[0]["LecturePrice"].ToString(), NumberStyles.Currency).ToString();
                txtCapacity.Text = ds.Tables[0].Rows[0]["LectureCapacity"].ToString();
                jqdtLecture.Date = DateTime.Parse(ds.Tables[0].Rows[0]["LectureDate"].ToString());
                jgdtTimeOut.Date = DateTime.Parse(ds.Tables[0].Rows[0]["LectureTimeOut"].ToString());
                txtStudentDiscount.Text = typeDiscountRow[0]["LectureTypeDiscountPercent"].ToString();
                txtOstadDiscount.Text = typeDiscountRow[1]["LectureTypeDiscountPercent"].ToString();
                txtFree.Text = typeDiscountRow[2]["LectureTypeDiscountPercent"].ToString();
                txtNumber1From.Text = numberDiscountDS.Tables[0].Rows[0]["Number1From"].ToString();
                txtNumber1Til.Text = numberDiscountDS.Tables[0].Rows[0]["Number1Til"].ToString();
                txtNumber1Discount.Text = numberDiscountDS.Tables[0].Rows[0]["Number1Discount"].ToString();
                txtNumber2From.Text = numberDiscountDS.Tables[0].Rows[0]["Number2From"].ToString();
                txtNumber2Til.Text = numberDiscountDS.Tables[0].Rows[0]["Number2Til"].ToString();
                txtNumber2Discount.Text = numberDiscountDS.Tables[0].Rows[0]["Number2Discount"].ToString();
                txtNumber3From.Text = numberDiscountDS.Tables[0].Rows[0]["Number3From"].ToString();
                txtNumber3Til.Text = numberDiscountDS.Tables[0].Rows[0]["Number3Til"].ToString();
                txtNumber3Discount.Text = numberDiscountDS.Tables[0].Rows[0]["Number3Discount"].ToString();
                jqdtDate1From.Date = DateTime.Parse(timeDiscountDS.Tables[0].Rows[0]["Date1From"].ToString());
                jqdtDate1Til.Date = DateTime.Parse(timeDiscountDS.Tables[0].Rows[0]["Date1Til"].ToString());
                txtDate1Discount.Text = timeDiscountDS.Tables[0].Rows[0]["Date1Discount"].ToString();
                jqdtDate2From.Date = DateTime.Parse(timeDiscountDS.Tables[0].Rows[0]["Date2From"].ToString());
                jqdtDate2Til.Date = DateTime.Parse(timeDiscountDS.Tables[0].Rows[0]["Date2Til"].ToString());
                txtDate2Discount.Text = timeDiscountDS.Tables[0].Rows[0]["Date2Discount"].ToString();
                jqdtDate3From.Date = DateTime.Parse(timeDiscountDS.Tables[0].Rows[0]["Date3From"].ToString());
                jqdtDate3Til.Date = DateTime.Parse(timeDiscountDS.Tables[0].Rows[0]["Date3Til"].ToString());
                txtDate3Discount.Text = timeDiscountDS.Tables[0].Rows[0]["Date3Discount"].ToString();
                DataSet tagsDS = new TagsCode().GetTagsOriginal(1, lectureID);
                if (tagsDS.Tables[0].Rows.Count > 0)
                    txtTags.Text = tagsDS.Tables[0].Rows[0]["Tags"].ToString();
            }
        }
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime lectureDate = Persia.Calendar.ConvertToGregorian(int.Parse(jqdtLecture.Text.Substring(6, 4)), int.Parse(jqdtLecture.Text.Substring(3, 2)), int.Parse(jqdtLecture.Text.Substring(0, 2)), Persia.DateType.Persian);
            DateTime lectureTimeOut = Persia.Calendar.ConvertToGregorian(int.Parse(jgdtTimeOut.Text.Substring(6, 4)), int.Parse(jgdtTimeOut.Text.Substring(3, 2)), int.Parse(jgdtTimeOut.Text.Substring(0, 2)), Persia.DateType.Persian);

            DateTime date1From = Persia.Calendar.ConvertToGregorian(int.Parse(jqdtDate1From.Text.Substring(6, 4)), int.Parse(jqdtDate1From.Text.Substring(3, 2)), int.Parse(jqdtDate1From.Text.Substring(0, 2)), Persia.DateType.Persian);
            DateTime date1Til = Persia.Calendar.ConvertToGregorian(int.Parse(jqdtDate1Til.Text.Substring(6, 4)), int.Parse(jqdtDate1Til.Text.Substring(3, 2)), int.Parse(jqdtDate1Til.Text.Substring(0, 2)), Persia.DateType.Persian);
            DateTime date2From = Persia.Calendar.ConvertToGregorian(int.Parse(jqdtDate2From.Text.Substring(6, 4)), int.Parse(jqdtDate2From.Text.Substring(3, 2)), int.Parse(jqdtDate2From.Text.Substring(0, 2)), Persia.DateType.Persian);
            DateTime date2Til = Persia.Calendar.ConvertToGregorian(int.Parse(jqdtDate2Til.Text.Substring(6, 4)), int.Parse(jqdtDate2Til.Text.Substring(3, 2)), int.Parse(jqdtDate2Til.Text.Substring(0, 2)), Persia.DateType.Persian);
            DateTime date3From = Persia.Calendar.ConvertToGregorian(int.Parse(jqdtDate3From.Text.Substring(6, 4)), int.Parse(jqdtDate3From.Text.Substring(3, 2)), int.Parse(jqdtDate3From.Text.Substring(0, 2)), Persia.DateType.Persian);
            DateTime date3Til = Persia.Calendar.ConvertToGregorian(int.Parse(jqdtDate3Til.Text.Substring(6, 4)), int.Parse(jqdtDate3Til.Text.Substring(3, 2)), int.Parse(jqdtDate3Til.Text.Substring(0, 2)), Persia.DateType.Persian);

            if (Request.QueryString["LecID"] != null)
                new LectureCode().UpdateLecture(int.Parse(Request.QueryString["LecID"]), txtLectureName.Text, editor1.Value, lectureDate, int.Parse(txtLecturePrice.Text), int.Parse(txtCapacity.Text), lectureTimeOut, int.Parse(txtStudentDiscount.Text), int.Parse(txtOstadDiscount.Text),
                    int.Parse(txtFree.Text), int.Parse(txtNumber1From.Text), int.Parse(txtNumber1Til.Text), int.Parse(txtNumber2From.Text), int.Parse(txtNumber2Til.Text), int.Parse(txtNumber3From.Text), int.Parse(txtNumber3Til.Text), int.Parse(txtNumber1Discount.Text),
                    int.Parse(txtNumber2Discount.Text), int.Parse(txtNumber3Discount.Text), date1From, date1Til, date2From, date2Til, date3From, date3Til, int.Parse(txtDate1Discount.Text), int.Parse(txtDate2Discount.Text), int.Parse(txtDate3Discount.Text), txtTags.Text);
            else
                new LectureCode().InsertLecture(txtLectureName.Text, editor1.Value, lectureDate, int.Parse(txtLecturePrice.Text), int.Parse(txtCapacity.Text), lectureTimeOut, int.Parse(txtStudentDiscount.Text), int.Parse(txtOstadDiscount.Text), int.Parse(txtFree.Text),
                    int.Parse(txtNumber1From.Text), int.Parse(txtNumber1Til.Text), int.Parse(txtNumber2From.Text), int.Parse(txtNumber2Til.Text), int.Parse(txtNumber3From.Text), int.Parse(txtNumber3Til.Text), int.Parse(txtNumber1Discount.Text), int.Parse(txtNumber2Discount.Text),
                    int.Parse(txtNumber3Discount.Text), date1From, date1Til, date2From, date2Til, date3From, date3Til, int.Parse(txtDate1Discount.Text), int.Parse(txtDate2Discount.Text), int.Parse(txtDate3Discount.Text), txtTags.Text);

            txtLectureName.Text = "";
            editor1.Value = "";
            txtLecturePrice.Text = "";
            txtCapacity.Text = "";
            jqdtLecture.Text = "";
            jgdtTimeOut.Text = "";
            txtStudentDiscount.Text = "0";
            txtOstadDiscount.Text = "0";
            txtFree.Text = "0";
            txtNumber1From.Text = "0";
            txtNumber1Til.Text = "0";
            txtNumber1Discount.Text = "0";
            txtNumber2From.Text = "0";
            txtNumber2Til.Text = "0";
            txtNumber2Discount.Text = "0";
            txtNumber3From.Text = "0";
            txtNumber3Til.Text = "0";
            txtNumber3Discount.Text = "0";
            jqdtDate1From.Text = "";
            jqdtDate1Til.Text = "";
            txtDate1Discount.Text = "0";
            jqdtDate2From.Text = "";
            jqdtDate2Til.Text = "";
            txtDate2Discount.Text = "0";
            jqdtDate3From.Text = "";
            jqdtDate3Til.Text = "";
            txtDate3Discount.Text = "0";
            txtTags.Text = "";

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
}