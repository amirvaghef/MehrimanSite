using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_TrainingReportAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDegree();

            drpCourse.Enabled = false;
            drpLesson.Enabled = false;
            drpPart.Enabled = false;
        }
    }

    private void BindDegree()
    {
        drpDegree.DataSource = new TrainingCode().GetDegreeList();
        drpDegree.DataTextField = "DegreeName";
        drpDegree.DataValueField = "DegreeID";
        drpDegree.DataBind();
        drpDegree.Items.Insert(0, new ListItem("", ""));
    }
    private void BindCourse()
    {
        drpCourse.DataSource = new TrainingCode().GetCourseList(drpDegree.SelectedValue);
        drpCourse.DataTextField = "CourseName";
        drpCourse.DataValueField = "CourseID";
        drpCourse.DataBind();
        drpCourse.Items.Insert(0, new ListItem("", ""));
    }
    private void BindLesson()
    {
        drpLesson.DataSource = new TrainingCode().GetLessonList(drpCourse.SelectedValue);
        drpLesson.DataTextField = "LessonName";
        drpLesson.DataValueField = "LessonID";
        drpLesson.DataBind();
        drpLesson.Items.Insert(0, new ListItem("", ""));
    }
    private void BindPart()
    {
        drpPart.DataSource = new TrainingCode().GetAllPartList(drpLesson.SelectedValue);
        drpPart.DataTextField = "PartName";
        drpPart.DataValueField = "PartID";
        drpPart.DataBind();
        drpPart.Items.Insert(0, new ListItem("", ""));
    }

    protected void drpDegree_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpDegree.SelectedIndex != 0)
        {
            BindCourse();

            drpCourse.Enabled = true;
            drpLesson.Enabled = false;
            drpPart.Enabled = false;
        }
        else
        {
            drpCourse.Enabled = false;
            drpLesson.Enabled = false;
            drpPart.Enabled = false;
        }
    }
    protected void drpCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpCourse.SelectedIndex != 0)
        {
            BindLesson();

            drpLesson.Enabled = true;
            drpPart.Enabled = false;
        }
        else
        {
            drpLesson.Enabled = false;
            drpPart.Enabled = false;
        }
    }
    protected void drpLesson_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpLesson.SelectedIndex != 0)
        {
            BindPart();

            drpPart.Enabled = true;
        }
        else
        {
            drpPart.Enabled = false;
        }
    }
    protected void drpPart_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpPart.SelectedIndex != 0)
        {
            gwLesson.DataSource = new TrainingCode().GetLessonReserve(drpPart.SelectedValue);
            gwLesson.DataBind();
        }
    }
    protected void gwLectures_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gwLesson.PageIndex = e.NewPageIndex;

        gwLesson.DataSource = new TrainingCode().GetLessonReserve(drpPart.SelectedValue);
        gwLesson.DataBind();
    }
}