using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class Training : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet degreeDS = new TrainingCode().GetDegreeList();
            foreach (DataRow degreeRow in degreeDS.Tables[0].Rows)
            {
                TreeNode DegreeNode = new TreeNode(degreeRow["DegreeName"].ToString(), degreeRow["DegreeID"].ToString());
                DegreeNode.SelectAction = TreeNodeSelectAction.Expand;

                DataSet courseDS = new TrainingCode().GetCourseList(degreeRow["DegreeID"].ToString());
                foreach (DataRow courseRow in courseDS.Tables[0].Rows)
                {
                    TreeNode CourseNode = new TreeNode(courseRow["CourseName"].ToString(), courseRow["CourseID"].ToString());
                    CourseNode.SelectAction = TreeNodeSelectAction.Expand;

                    DataSet lessonDS = new TrainingCode().GetLessonList(courseRow["CourseID"].ToString());
                    foreach (DataRow lessonRow in lessonDS.Tables[0].Rows)
                    {
                        TreeNode LessonNode = new TreeNode(lessonRow["LessonName"].ToString(), lessonRow["LessonID"].ToString());
                        LessonNode.SelectAction = TreeNodeSelectAction.Expand;

                        DataSet partDS = new TrainingCode().GetPartList(lessonRow["LessonID"].ToString());
                        foreach (DataRow partRow in partDS.Tables[0].Rows)
                        {
                            TreeNode PartNode = new TreeNode(partRow["PartName"].ToString(), partRow["PartID"].ToString());
                            PartNode.ImageToolTip = partRow["PartComment"].ToString();
                            
                            LessonNode.ChildNodes.Add(PartNode);
                        }
                        CourseNode.ChildNodes.Add(LessonNode);
                    }
                    DegreeNode.ChildNodes.Add(CourseNode);
                }
                TreeView1.Nodes.Add(DegreeNode);
            }
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        lbContent.Text = TreeView1.SelectedNode.ImageToolTip;
        if (TreeView1.SelectedNode.ImageToolTip != String.Empty)
            imbtnSubmit.Visible = true;
        else
            imbtnSubmit.Visible = false;
    }
    protected void imbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            string id = Membership.GetUser().ProviderUserKey.ToString();
            DataSet ds = new UsersCode().GetUser(id);

            try
            {
                new TrainingCode().InsertLessonReserve(id, User.Identity.Name, ds.Tables[0].Rows[0]["FirstName"].ToString(),
                    ds.Tables[0].Rows[0]["LastName"].ToString(), ds.Tables[0].Rows[0]["EmailAddress"].ToString(), ds.Tables[0].Rows[0]["Tel"].ToString(),
                    ds.Tables[0].Rows[0]["MobileAlias"].ToString(), TreeView1.SelectedValue);

                string tmp = "";
                tmp = "<script language='javascript'>";
                tmp += "alert('شما برای این کلاس رزرو شدید، در اسرع وقت برای ثبت نام نهایی به شرکت مراجع نمائید');";
                tmp += "</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
            }
            catch (Exception)
            {
                string tmp = "";
                tmp = "<script language='javascript'>";
                tmp += "alert('شما قبلاً ثبت نام نموده اید.');";
                tmp += "</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
            }
        }
        else
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('لطفاً ابتدا به سیستم لاگین نمائید');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
}