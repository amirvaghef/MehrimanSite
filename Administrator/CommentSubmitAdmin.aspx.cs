using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_CommentSubmitAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommentsCode comment = new CommentsCode();

            drpSection.DataSource = comment.GetPageList();
            drpSection.DataBind();
            drpSection.SelectedIndex = 0;

            drpItem.DataSource = comment.GetItemList(short.Parse(drpSection.SelectedValue.ToString()));
            drpItem.DataBind();
            drpSection.SelectedIndex = 0;

            grdComments.DataSource = comment.GetUnSubmitedComments(short.Parse(drpSection.SelectedValue.ToString()), drpItem.SelectedIndex == 0 ? 0 : long.Parse(drpItem.SelectedValue.ToString()));
            grdComments.DataBind();
        }
    }
    protected void drpSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommentsCode comment = new CommentsCode();

        drpItem.DataSource = comment.GetItemList(short.Parse(drpSection.SelectedValue.ToString()));
        drpItem.DataBind();

        grdComments.DataSource = comment.GetUnSubmitedComments(short.Parse(drpSection.SelectedValue.ToString()), drpItem.SelectedIndex == 0 ? 0 : long.Parse(drpItem.SelectedValue.ToString()));
        grdComments.DataBind();
    }
    protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdComments.DataSource = new CommentsCode().GetUnSubmitedComments(short.Parse(drpSection.SelectedValue.ToString()), drpItem.SelectedIndex == 0 ? 0 : long.Parse(drpItem.SelectedValue.ToString()));
        grdComments.DataBind();
    }
    protected void grdComments_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CommentsCode comment = new CommentsCode();

        grdComments.PageIndex = e.NewPageIndex;

        grdComments.DataSource = comment.GetUnSubmitedComments(short.Parse(drpSection.SelectedValue.ToString()), drpItem.SelectedIndex == 0 ? 0 : long.Parse(drpItem.SelectedValue.ToString()));
        grdComments.DataBind();
    }
    protected void grdComments_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CommentsCode comment = new CommentsCode();

        comment.DeleteComment(grdComments.Rows[e.RowIndex].Cells[1].Text);

        grdComments.DataSource = comment.GetUnSubmitedComments(short.Parse(drpSection.SelectedValue.ToString()), drpItem.SelectedIndex == 0 ? 0 : long.Parse(drpItem.SelectedValue.ToString()));
        grdComments.DataBind();
    }
    
    protected void grdComments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {
            CommentsCode comments = new CommentsCode();

            comments.SetSubmit(grdComments.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);

            grdComments.DataSource = comments.GetUnSubmitedComments(short.Parse(drpSection.SelectedValue.ToString()), drpItem.SelectedIndex == 0 ? 0 : long.Parse(drpItem.SelectedValue.ToString()));
            grdComments.DataBind();  
        }
    }
}