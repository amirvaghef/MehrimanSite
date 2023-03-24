using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Download : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet categoryDS = new DownloadFile().GetCategory();

            if (categoryDS.Tables[0].Rows.Count != 0)
                Session["cat"] = categoryDS.Tables[0].Rows[0]["DownloadProfileID"].ToString();
            else
                Session["cat"] = 0;

            repDownloadsCategory.DataSource = categoryDS;
            repDownloadsCategory.DataBind();
        }
        repDownloadGallery.DataSource = new DownloadFile().GetDownloads(Request.QueryString["cat"] == null ? int.Parse(Session["cat"].ToString()) : int.Parse(Request.QueryString["cat"]));
        repDownloadGallery.DataBind();

        //Repeater repTemp = ((Repeater)repDownloadGallery.FindControl("repTags"));
        //repTemp.DataSource = new TagsCode().GetTags(5, Request.QueryString["cat"] == null ? long.Parse(Session["cat"].ToString()) : long.Parse(Request.QueryString["cat"]));
        //repTemp.DataBind();
    }
}