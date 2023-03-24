using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_ImageFirstPageDeleteAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gwImageFirstPage.DataSource = new ImageFirstPageCode().GetAllImages();
            gwImageFirstPage.DataBind();
        }
    }
    protected void gwImageFirstPage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ImageFirstPageCode imageFirstPage = new ImageFirstPageCode();
        imageFirstPage.Delete(long.Parse(gwImageFirstPage.Rows[e.RowIndex].Cells[1].Text));

        gwImageFirstPage.DataSource = imageFirstPage.GetAllImages();
        gwImageFirstPage.DataBind();
    }
    protected void gwImageFirstPage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gwImageFirstPage.PageIndex = e.NewPageIndex;

        gwImageFirstPage.DataSource = new ImageFirstPageCode().GetAllImages();
        gwImageFirstPage.DataBind();
    }
}