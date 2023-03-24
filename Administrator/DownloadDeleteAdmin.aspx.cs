using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_DownloadDeleteAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gwDownloads.DataSource = new DownloadFile().GetAllDownload();
            gwDownloads.DataBind();
        }
    }
    protected void gwDownloads_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        new DownloadFile().DeleteDownload(gwDownloads.Rows[e.RowIndex].Cells[1].Text);

        gwDownloads.DataSource = new DownloadFile().GetAllDownload();
        gwDownloads.DataBind();
    }
    protected void gwDownloads_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gwDownloads.PageIndex = e.NewPageIndex;

        gwDownloads.DataSource = new DownloadFile().GetAllDownload();
        gwDownloads.DataBind();
    }
}