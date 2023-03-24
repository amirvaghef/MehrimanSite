using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_UCNewsBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            repFirstPageNews.DataSource = new NewsCode().GetFirstPageFreshNews();
            repFirstPageNews.DataBind();
        }
    }
}