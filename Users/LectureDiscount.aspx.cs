using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class Users_LectureDiscount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int lectureID = int.Parse(Session["LectureID"].ToString());

            DataSet dsLecture = new LectureCode().GetLecture(lectureID);
            Page.Title = dsLecture.Tables[0].Rows[0]["LectureName"].ToString();
            double price = double.Parse(dsLecture.Tables[0].Rows[0]["LecturePrice"].ToString());

            #region Free Lecture (Price==0)
            if (price == 0)
            {
                try
                {
                    string lectureBuyID = Guid.NewGuid().ToString();
                    Session["ReservationNumber"] = lectureBuyID;

                    string userid = Membership.GetUser().ProviderUserKey.ToString();
                    DataSet ds = new UsersCode().GetUser(userid);

                    new LectureCode().InsertLectureBuy(lectureBuyID, Session["LectureID"].ToString(), "همایش آزاد", "1", "0", userid, User.Identity.Name, ds.Tables[0].Rows[0]["FirstName"].ToString(),
                        ds.Tables[0].Rows[0]["LastName"].ToString(), ds.Tables[0].Rows[0]["Address"].ToString(), ds.Tables[0].Rows[0]["EmailAddress"].ToString(), ds.Tables[0].Rows[0]["Tel"].ToString(),
                        ds.Tables[0].Rows[0]["MobileAlias"].ToString());
                    Response.Redirect("GetBackFree.aspx");
                }
                catch (Exception ex)
                {
                    string tmp = "";
                    tmp = "<script language='javascript'>";
                    tmp += "alert('سیستم با مشکل مواجه شده است. لطفاً دوباره تلاش نمائید.');";
                    tmp += "</script>";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
                }
            } 
            #endregion

            DataSet dsDate = new LectureCode().GetTimeDiscount(lectureID);
            if (DateTime.Parse(dsDate.Tables[0].Rows[0]["Date1From"].ToString()) >= DateTime.Today || (DateTime.Today > DateTime.Parse(dsDate.Tables[0].Rows[0]["Date1From"].ToString()) && DateTime.Today <= DateTime.Parse(dsDate.Tables[0].Rows[0]["Date1Til"].ToString())))
            {
                price = price - (price * int.Parse(dsDate.Tables[0].Rows[0]["Date1Discount"].ToString())) / 100;
                lbDate.Text = dsDate.Tables[0].Rows[0]["Date1Discount"].ToString() + " درصد تخفیف";
            }
            else
                if (DateTime.Today > DateTime.Parse(dsDate.Tables[0].Rows[0]["Date2From"].ToString()) && DateTime.Today <= DateTime.Parse(dsDate.Tables[0].Rows[0]["Date2Til"].ToString()))
                {
                    price = price - (price * int.Parse(dsDate.Tables[0].Rows[0]["Date2Discount"].ToString())) / 100;
                    lbDate.Text = dsDate.Tables[0].Rows[0]["Date2Discount"].ToString() + " درصد تخفیف";
                }
                else
                    if (DateTime.Today > DateTime.Parse(dsDate.Tables[0].Rows[0]["Date3From"].ToString()) && DateTime.Today <= DateTime.Parse(dsDate.Tables[0].Rows[0]["Date3Til"].ToString()))
                    {
                        price = price - (price * int.Parse(dsDate.Tables[0].Rows[0]["Date3Discount"].ToString())) / 100;
                        lbDate.Text = dsDate.Tables[0].Rows[0]["Date3Discount"].ToString() + " درصد تخفیف";
                    }
            lbPrice.Text = price.ToString();
            Session["LecturePrice"] = price;
            Session["MainLecturePrice"] = price;

            DataSet dsTypeDiscount = new LectureCode().GetLectureTypeDiscount(lectureID);
            foreach (DataRow dr in dsTypeDiscount.Tables[0].Rows)
                dr["LectureTypeName"] = dr["LectureTypeName"] + "(" + dr["LectureTypeDiscountPercent"] + "درصد تخفیف" + ")";

            rbDiscountType.DataSource = dsTypeDiscount;
            rbDiscountType.DataTextField = "LectureTypeName";
            rbDiscountType.DataValueField = "LectureTypeDiscountPercent";
            rbDiscountType.DataBind();
        }
    }
    protected void rbDiscountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        NumberDiscount();       
    }
    protected void rbNumberDiscount_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbNumberDiscount.SelectedIndex == 1)
            txtNumber.Enabled = true;
        else
            txtNumber.Enabled = false;
        txtNumber.Text = "";

        NumberDiscount();
    }
    protected void txtNumber_TextChanged(object sender, EventArgs e)
    {
        NumberDiscount();
    }
    protected void NumberDiscount()
    {
        int price = int.Parse(Session["MainLecturePrice"].ToString());
        if (rbDiscountType.SelectedIndex >= 0)
            price = price - (price * int.Parse(rbDiscountType.SelectedValue)) / 100;

        int number = 0;
        if (txtNumber.Text != String.Empty)
            number = int.Parse(txtNumber.Text);

        if (number > 0)
        {
            int lectureID = int.Parse(Session["LectureID"].ToString());
            DataSet dsLecture = new LectureCode().GetNumberDiscount(lectureID);
            if (int.Parse(dsLecture.Tables[0].Rows[0]["Number3Til"].ToString()) <= number || (number >= int.Parse(dsLecture.Tables[0].Rows[0]["Number3From"].ToString()) && number < int.Parse(dsLecture.Tables[0].Rows[0]["Number3Til"].ToString())))
            {
                price = price - (price * int.Parse(dsLecture.Tables[0].Rows[0]["Number3Discount"].ToString())) / 100;
                lbNumber.Text = dsLecture.Tables[0].Rows[0]["Number3Discount"].ToString() + " درصد تخفیف";
            }
            else
                if (number >= int.Parse(dsLecture.Tables[0].Rows[0]["Number2From"].ToString()) && number < int.Parse(dsLecture.Tables[0].Rows[0]["Number2Til"].ToString()))
                {
                    price = price - (price * int.Parse(dsLecture.Tables[0].Rows[0]["Number2Discount"].ToString())) / 100;
                    lbNumber.Text = dsLecture.Tables[0].Rows[0]["Number2Discount"].ToString() + " درصد تخفیف";
                }
                else
                    if (number >= int.Parse(dsLecture.Tables[0].Rows[0]["Number1From"].ToString()) && number < int.Parse(dsLecture.Tables[0].Rows[0]["Number1Til"].ToString()))
                    {
                        price = price - (price * int.Parse(dsLecture.Tables[0].Rows[0]["Number1Discount"].ToString())) / 100;
                        lbNumber.Text = dsLecture.Tables[0].Rows[0]["Number1Discount"].ToString() + " درصد تخفیف";
                    }
            price = price * number;
        }

        lbPrice.Text = price.ToString();
        Session["LecturePrice"] = price;
    }
    protected void imbRegister_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string lectureBuyID = Guid.NewGuid().ToString();
            Session["ReservationNumber"] = lectureBuyID;

            string lectureDiscountName = "آزاد";
            if(rbDiscountType.SelectedItem != null)
                lectureDiscountName = rbDiscountType.SelectedItem.Text;

            string userid = Membership.GetUser().ProviderUserKey.ToString();
            DataSet ds = new UsersCode().GetUser(userid);

            new LectureCode().InsertLectureBuy(lectureBuyID, Session["LectureID"].ToString(), lectureDiscountName, txtNumber.Text, Session["LecturePrice"].ToString(), userid, User.Identity.Name, ds.Tables[0].Rows[0]["FirstName"].ToString(),
                ds.Tables[0].Rows[0]["LastName"].ToString(), ds.Tables[0].Rows[0]["Address"].ToString(), ds.Tables[0].Rows[0]["EmailAddress"].ToString(), ds.Tables[0].Rows[0]["Tel"].ToString(),
                ds.Tables[0].Rows[0]["MobileAlias"].ToString());
            Response.Redirect("Send.aspx");
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('سیستم با مشکل مواجه شده است. لطفاً دوباره تلاش نمائید.');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
}