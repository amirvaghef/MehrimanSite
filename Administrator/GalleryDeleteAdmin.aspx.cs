using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_GalleryDeleteAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gwImages.DataSource = new ImageGallery().GetAllImage();
            gwImages.DataBind();
        }
    }
    protected void gwImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        new ImageGallery().DeleteImage(gwImages.Rows[e.RowIndex].Cells[1].Text);

        gwImages.DataSource = new ImageGallery().GetAllImage();
        gwImages.DataBind();
    }
    
    protected void gwImages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gwImages.PageIndex = e.NewPageIndex;

        gwImages.DataSource = new ImageGallery().GetAllImage();
        gwImages.DataBind();
    }
}