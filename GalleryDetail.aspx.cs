using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class GalleryDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            repTags.DataSource = new TagsCode().GetTags(2, long.Parse(Request.QueryString["cat"].ToString()));
            repTags.DataBind();

            DataSet categoryDS = new ImageGallery().GetCategory();
            if (categoryDS.Tables[0].Rows.Count != 0)
                Session["cat"] = categoryDS.Tables[0].Rows[0]["ImageProfileID"].ToString();
            else
                Session["cat"] = 0;

            repImageGallery.DataSource = new ImageGallery().GetImages(Request.QueryString["cat"] == null ? int.Parse(Session["cat"].ToString()) : int.Parse(Request.QueryString["cat"]));
            repImageGallery.DataBind();

            #region Comments
            repComments.DataSource = new CommentsCode().GetSubmitedComments(2, Request.QueryString["cat"] == null ? int.Parse(Session["cat"].ToString()) : long.Parse(Request.QueryString["cat"]));
            repComments.DataBind();
            #endregion
        }
    }

    protected void BTSubmitComment_Click(object sender, EventArgs e)
    {
        new CommentsCode().InsertComment(2, Request.QueryString["cat"] == null ? int.Parse(Session["cat"].ToString()) : long.Parse(Request.QueryString["cat"]), txtName.Text == String.Empty ? "ناشناس" : txtName.Text, txtSubject.Text, txtEmail.Text, txtComment.Text, Boolean.Parse(ConfigurationManager.AppSettings["Submit"]), DateTime.Today);

        txtComment.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtName.Text = String.Empty;
        txtSubject.Text = String.Empty;

        #region Comments
        repComments.DataSource = new CommentsCode().GetSubmitedComments(2, Request.QueryString["cat"] == null ? int.Parse(Session["cat"].ToString()) : long.Parse(Request.QueryString["cat"]));
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