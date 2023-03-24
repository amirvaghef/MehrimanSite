using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;

public partial class Administrator_LectureNewsAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["NID"] != null)
            {
                DataSet ds = new LectureNewsCode().GetNews(int.Parse(Request.QueryString["NID"]));

                txtNewsTitle.Text = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                editor1.Value = ds.Tables[0].Rows[0]["NewsAbstract"].ToString();
                editor2.Value = ds.Tables[0].Rows[0]["NewsContent"].ToString();
                txtTags.Text = new TagsCode().GetTagsOriginal(3, long.Parse(Request.QueryString["NID"].ToString())).Tables[0].Rows[0]["Tags"].ToString();
            }
        }
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime insertDate = DateTime.Today;

            if (Request.QueryString["NID"] != null)
                new LectureNewsCode().UpdateNews(int.Parse(Request.QueryString["NID"]), txtNewsTitle.Text, editor1.Value, editor2.Value, insertDate, txtTags.Text);
            else
                new LectureNewsCode().InsertNews(txtNewsTitle.Text, editor1.Value, editor2.Value, insertDate, txtTags.Text);

            txtNewsTitle.Text = "";
            editor1.Value = "";
            editor2.Value = "";
            txtTags.Text = "";

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);

        }
        catch (Exception ex)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با مشکل مواجه شده است');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
}