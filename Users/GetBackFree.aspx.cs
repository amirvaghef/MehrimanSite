using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class Users_GetBackFree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdatePrintPanel();
        }
    }

    private void UpdatePrintPanel()
    {
        DataSet ds = new LectureCode().GetLectureLectureBuy(Session["ReservationNumber"].ToString());

        LectureName.Text = ds.Tables[0].Rows[0]["LectureName"].ToString();
        LectureDate.Text = Persia.Calendar.ConvertToPersian(DateTime.Parse(ds.Tables[0].Rows[0]["LectureDate"].ToString())).Persian;
        LectureBuyTime.Text = Persia.Calendar.ConvertToPersian(DateTime.Parse(ds.Tables[0].Rows[0]["LectureBuyTime"].ToString())).Persian;
        fk_UserID.Text = ds.Tables[0].Rows[0]["fk_UserID"].ToString();
        fk_Firstname.Text = ds.Tables[0].Rows[0]["fk_Firstname"].ToString();
        fk_Lastname.Text = ds.Tables[0].Rows[0]["fk_Lastname"].ToString();
        LectureBuyNumber.Text = ds.Tables[0].Rows[0]["LectureBuyNumber"].ToString();
        LectureType.Text = ds.Tables[0].Rows[0]["LectureType"].ToString();
    }

    protected void imbPrint_Click(object sender, ImageClickEventArgs e)
    {
        //Session["ctrl"] = Panel1;
        //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
        
        PrintHelper.PrintWebControl(printPanel);
    }
}