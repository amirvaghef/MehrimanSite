using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class ScientificNewsDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScientificNewsCode newsCode = new ScientificNewsCode();
            repFreshNews.DataSource = newsCode.GetNews(Request.QueryString["Item"] == null ? 1 : int.Parse(Request.QueryString["Item"]));
            repFreshNews.DataBind();

            repTags.DataSource = new TagsCode().GetTags(7, Request.QueryString["Item"] == null ? 1 : long.Parse(Request.QueryString["Item"]));
            repTags.DataBind();

            #region Comments
            repComments.DataSource = new CommentsCode().GetSubmitedComments(7, Request.QueryString["Item"] == null ? 1 : long.Parse(Request.QueryString["Item"]));
            repComments.DataBind();
            #endregion
        }
    }
    protected void BTSubmitComment_Click(object sender, EventArgs e)
    {
        new CommentsCode().InsertComment(7, Request.QueryString["Item"] == null ? 1 : long.Parse(Request.QueryString["Item"]), txtName.Text == String.Empty ? "ناشناس" : txtName.Text, txtSubject.Text, txtEmail.Text, txtComment.Text, Boolean.Parse(ConfigurationManager.AppSettings["Submit"]), DateTime.Today);

        txtComment.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtName.Text = String.Empty;
        txtSubject.Text = String.Empty;

        #region Comments
        repComments.DataSource = new CommentsCode().GetSubmitedComments(7, Request.QueryString["Item"] == null ? 1 : long.Parse(Request.QueryString["Item"]));
        repComments.DataBind();
        #endregion
    }
    protected void repComments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch(e.CommandName.ToLower())
        {
            case "update":
                break;

            case "delete":
                break;
        }
    }
}