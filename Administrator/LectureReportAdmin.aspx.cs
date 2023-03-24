using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_LectureReportAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drplectures.DataSource = new LectureCode().GetAllLecture();
            drplectures.DataTextField = "LectureName";
            drplectures.DataValueField = "LectureID";
            drplectures.DataBind();
            drplectures.Items.Insert(0, new ListItem("","0"));
        }
    }
    protected void drplectures_SelectedIndexChanged(object sender, EventArgs e)
    {
        gwLectures.DataSource = new LectureCode().GetBuyLecture(drplectures.SelectedValue);
        gwLectures.DataBind();
    }
    protected void gwLectures_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gwLectures.PageIndex = e.NewPageIndex;

        gwLectures.DataSource = new LectureCode().GetBuyLecture(drplectures.SelectedValue);
        gwLectures.DataBind();
    }
}