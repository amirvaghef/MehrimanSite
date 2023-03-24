using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_ScientificNewsDeleteAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gwNews.DataSource = new ScientificNewsCode().GetAllNews();
            gwNews.DataBind();
        }
    }
    
    protected void gwNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        new ScientificNewsCode().DeleteNews(gwNews.Rows[e.RowIndex].Cells[1].Text);

        gwNews.DataSource = new ScientificNewsCode().GetAllNews();
        gwNews.DataBind();
    }
    protected void gwNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gwNews.PageIndex = e.NewPageIndex;

        gwNews.DataSource = new ScientificNewsCode().GetAllNews();
        gwNews.DataBind();
    }
    protected void gwNews_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("ScientificNewsAdmin.aspx?NID=" + gwNews.Rows[e.NewEditIndex].Cells[1].Text);   
    }
}