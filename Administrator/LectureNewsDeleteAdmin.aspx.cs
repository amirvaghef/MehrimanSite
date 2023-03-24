using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_NewsDeleteAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gwNews.DataSource = new LectureNewsCode().GetAllNews();
            gwNews.DataBind();
        }
    }
    
    protected void gwNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        new LectureNewsCode().DeleteNews(gwNews.Rows[e.RowIndex].Cells[1].Text);

        gwNews.DataSource = new LectureNewsCode().GetAllNews();
        gwNews.DataBind();
    }
    protected void gwNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gwNews.PageIndex = e.NewPageIndex;

        gwNews.DataSource = new LectureNewsCode().GetAllNews();
        gwNews.DataBind();
    }
    protected void gwNews_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("LectureNewsAdmin.aspx?NID=" + gwNews.Rows[e.NewEditIndex].Cells[1].Text);   
    }
}