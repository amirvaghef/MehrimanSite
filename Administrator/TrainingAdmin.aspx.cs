using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_TrainingAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDegree();

            drpCourse.Enabled = false;
            lbtnNewCourse.Enabled = false;
            lbtnDeleteCourse.Enabled = false;

            drpLesson.Enabled = false;
            lbtnNewLesson.Enabled = false;
            lbtnDeleteLesson.Enabled = false;

            drpPart.Enabled = false;
            lbtnNewPart.Enabled = false;
            lbtnDeletePart.Enabled = false;

            lbtnArchivePart.Enabled = false;
            editor1.Visible = false;
            btnSubmit.Visible = false;
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
        drpPart.DataSource = new TrainingCode().GetPartList(drpLesson.SelectedValue);
        drpPart.DataTextField = "PartName";
        drpPart.DataValueField = "PartID";
        drpPart.DataBind();
        drpPart.Items.Insert(0, new ListItem("", ""));
    }
    protected void lbtnNewDgree_Click(object sender, EventArgs e)
    {
        plDegreeInsert.Visible = true;
    }
    protected void lbtnDeleteDegree_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().DeleteDegree(drpDegree.SelectedValue);

            BindDegree();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
    protected void lbtnNewCourse_Click(object sender, EventArgs e)
    {
        plCourseInsert.Visible = true;
    }
    protected void lbtnDeleteCourse_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().DeleteCourse(drpCourse.SelectedValue);

            BindCourse();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
    protected void lbtnNewLesson_Click(object sender, EventArgs e)
    {
        plLessonInsert.Visible = true;
    }
    protected void lbtnDeleteLesson_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().DeleteLesson(drpLesson.SelectedValue);

            BindLesson();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
    protected void lbtnNewPart_Click(object sender, EventArgs e)
    {
        plPartInsert.Visible = true;
    }
    protected void lbtnDeletePart_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().DeletePart(drpPart.SelectedValue);

            BindPart();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
    protected void lbtnArchivePart_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().ArchivePart(drpPart.SelectedValue);

            BindPart();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
    protected void btCategorySubmit_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().InsertDegree(txtDegree.Text);
            txtDegree.Text = "";
            plDegreeInsert.Visible = false;

            BindDegree();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
    protected void btCourseSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().InsertCourse(txtCourse.Text, drpDegree.SelectedValue);
            txtCourse.Text = "";
            plCourseInsert.Visible = false;

            BindCourse();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
    protected void btnLessonSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().InsertLesson(txtLesson.Text, drpCourse.SelectedValue);
            txtLesson.Text = "";
            plLessonInsert.Visible = false;

            BindLesson();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
    protected void btnPartSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().InsertPart(txtPart.Text, editor2.Value, drpLesson.SelectedValue);
            txtPart.Text = "";
            editor2.Value = "";

            BindPart();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        plPartInsert.Visible = false;
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            new TrainingCode().UpdatePart(editor1.Value, drpPart.SelectedValue);

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
    protected void drpDegree_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpDegree.SelectedIndex != 0)
        {
            BindCourse();

            drpCourse.Enabled = true;
            lbtnNewCourse.Enabled = true;
            lbtnDeleteCourse.Enabled = true;

            drpLesson.Enabled = false;
            lbtnNewLesson.Enabled = false;
            lbtnDeleteLesson.Enabled = false;

            drpPart.Enabled = false;
            lbtnNewPart.Enabled = false;
            lbtnDeletePart.Enabled = false;

            lbtnArchivePart.Enabled = false;
            editor1.Visible = false;
            btnSubmit.Visible = false;
        }
        else
        {
            drpCourse.Enabled = false;
            lbtnNewCourse.Enabled = false;
            lbtnDeleteCourse.Enabled = false;

            drpLesson.Enabled = false;
            lbtnNewLesson.Enabled = false;
            lbtnDeleteLesson.Enabled = false;

            drpPart.Enabled = false;
            lbtnNewPart.Enabled = false;
            lbtnDeletePart.Enabled = false;

            lbtnArchivePart.Enabled = false;
            editor1.Visible = false;
            btnSubmit.Visible = false;
        }
    }
    protected void drpCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpCourse.SelectedIndex != 0)
        {
            BindLesson();

            drpLesson.Enabled = true;
            lbtnNewLesson.Enabled = true;
            lbtnDeleteLesson.Enabled = true;

            drpPart.Enabled = false;
            lbtnNewPart.Enabled = false;
            lbtnDeletePart.Enabled = false;

            lbtnArchivePart.Enabled = false;
            editor1.Visible = false;
            btnSubmit.Visible = false;
        }
        else
        {
            drpLesson.Enabled = false;
            lbtnNewLesson.Enabled = false;
            lbtnDeleteLesson.Enabled = false;

            drpPart.Enabled = false;
            lbtnNewPart.Enabled = false;
            lbtnDeletePart.Enabled = false;

            lbtnArchivePart.Enabled = false;
            editor1.Visible = false;
            btnSubmit.Visible = false;
        }
    }
    protected void drpLesson_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpLesson.SelectedIndex != 0)
        {
            BindPart();

            drpPart.Enabled = true;
            lbtnNewPart.Enabled = true;
            lbtnDeletePart.Enabled = true;

            lbtnArchivePart.Enabled = false;
            editor1.Visible = false;
            btnSubmit.Visible = false;
        }
        else
        {
            drpPart.Enabled = false;
            lbtnNewPart.Enabled = false;
            lbtnDeletePart.Enabled = false;

            lbtnArchivePart.Enabled = false;
            editor1.Visible = false;
            btnSubmit.Visible = false;
        }
    }
    protected void drpPart_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpPart.SelectedIndex != 0)
        {
            lbtnArchivePart.Enabled = true;
            editor1.Visible = true;
            editor1.Value = new TrainingCode().GetPartByID(drpPart.SelectedValue).Tables[0].Rows[0]["PartComment"].ToString();
            btnSubmit.Visible = true;
        }
        else
        {
            lbtnArchivePart.Enabled = false;
            editor1.Visible = false;
            editor1.Value = "";
            btnSubmit.Visible = false;
        }
    }
}