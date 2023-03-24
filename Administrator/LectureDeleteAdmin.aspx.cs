using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_LectureDeleteAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gwLectures.DataSource = new LectureCode().GetUnBuyLecture();
            gwLectures.DataBind();
        }
    }
    protected void gwLectures_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        new LectureCode().DeleteLecture(gwLectures.Rows[e.RowIndex].Cells[1].Text);

        gwLectures.DataSource = new LectureCode().GetUnBuyLecture();
        gwLectures.DataBind();
    }
    protected void gwLectures_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gwLectures.PageIndex = e.NewPageIndex;

        gwLectures.DataSource = new LectureCode().GetUnBuyLecture();
        gwLectures.DataBind();
    }
    protected void gwLectures_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("LectureAdmin.aspx?LecID=" + gwLectures.Rows[e.NewEditIndex].Cells[1].Text, true);
    }
}