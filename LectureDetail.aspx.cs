using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class LectureDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            repTags.DataSource = new TagsCode().GetTags(1, long.Parse(Request.QueryString["id"].ToString()));
            repTags.DataBind();

            repLecture.DataSource = new LectureCode().GetLecture(Request.QueryString["id"] == null ? 1 : int.Parse(Request.QueryString["id"]));
            repLecture.DataBind();

            DataSet ds = new LectureCode().GetValidLectureList();
            DataRow[] dr = ds.Tables[0].Select("LectureID=" + Request.QueryString["id"]);

            if (dr.Length > 0)
                if ((int.Parse(dr[0]["BuyCount"].ToString()) >= int.Parse(dr[0]["LectureCapacity"].ToString())))
                    ((ImageButton)repLecture.Items[0].FindControl("imbRegister")).Visible = false;
                else
                    if ((DateTime.Parse(dr[0]["LectureTimeOut"].ToString()) < DateTime.Today))
                        ((ImageButton)repLecture.Items[0].FindControl("imbRegister")).Visible = false;
                    else
                    {
                        ((ImageButton)repLecture.Items[0].FindControl("imbRegister")).Visible = true;
                        Session["LectureID"] = Request.QueryString["id"];
                    }
            else
                ((ImageButton)repLecture.Items[0].FindControl("imbRegister")).Visible = false;

            #region Comments
            repComments.DataSource = new CommentsCode().GetSubmitedComments(1, Request.QueryString["id"] == null ? 1 : long.Parse(Request.QueryString["id"]));
            repComments.DataBind();
            #endregion
        }
    }

    protected void BTSubmitComment_Click(object sender, EventArgs e)
    {
        new CommentsCode().InsertComment(1, Request.QueryString["id"] == null ? 1 : long.Parse(Request.QueryString["id"]), txtName.Text == String.Empty ? "ناشناس" : txtName.Text, txtSubject.Text, txtEmail.Text, txtComment.Text, Boolean.Parse(ConfigurationManager.AppSettings["Submit"]), DateTime.Today);

        txtComment.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtName.Text = String.Empty;
        txtSubject.Text = String.Empty;

        #region Comments
        repComments.DataSource = new CommentsCode().GetSubmitedComments(1, Request.QueryString["id"] == null ? 1 : long.Parse(Request.QueryString["id"]));
        repComments.DataBind();
        #endregion
    }
    protected void repComments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName.ToLower())
        {
            case "update":
                break;

            case "delete":
                break;
        }
    }
}