using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet categoryDS = new NewsCode().GetCategory();
            repNewsCategory.DataSource = categoryDS;
            repNewsCategory.DataBind();

            if (categoryDS.Tables[0].Rows.Count != 0)
                Session["cat"] = categoryDS.Tables[0].Rows[0]["NewsCategoryID"].ToString();
            else
                Session["cat"] = 0;
        }
        if (Request.QueryString["arch"] == null)
            repFreshNews.DataSource = new NewsCode().GetFreshNews(Request.QueryString["cat"] == null ? int.Parse(Session["cat"].ToString()) : int.Parse(Request.QueryString["cat"]));
        else
            repFreshNews.DataSource = new NewsCode().GetArchiveNews(int.Parse(Request.QueryString["arch"]));
        repFreshNews.DataBind();
    }
}