using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ScientificNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["arch"] == null)
                repFreshNews.DataSource = new ScientificNewsCode().GetFreshNews();
            else
                repFreshNews.DataSource = new ScientificNewsCode().GetArchiveNews();
            repFreshNews.DataBind();
        }
    }
}