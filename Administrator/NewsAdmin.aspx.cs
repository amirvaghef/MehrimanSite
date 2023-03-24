using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;

public partial class Administrator_NewsAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();

            if (Request.QueryString["NID"] != null)
            {
                DataSet ds = new NewsCode().GetNews(int.Parse(Request.QueryString["NID"]));

                txtNewsTitle.Text = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                editor1.Value = ds.Tables[0].Rows[0]["NewsAbstract"].ToString();
                editor2.Value = ds.Tables[0].Rows[0]["NewsContent"].ToString();
                jqdtInsert.Date = DateTime.Parse(ds.Tables[0].Rows[0]["InsertDate"].ToString());
                jqdtArchive.Date = DateTime.Parse(ds.Tables[0].Rows[0]["ArchiveDate"].ToString());
                chbfirstPage.Checked = Boolean.Parse(ds.Tables[0].Rows[0]["NewsFirstPage"].ToString());
                drpCategory.SelectedValue = ds.Tables[0].Rows[0]["fk_NewsCategoryID"].ToString();
                txtTags.Text = new TagsCode().GetTagsOriginal(3, long.Parse(Request.QueryString["NID"].ToString())).Tables[0].Rows[0]["Tags"].ToString();
            }
        }
    }

    protected void BindCategory()
    {
        drpCategory.DataSource = new NewsCode().GetCategoryOnly();
        drpCategory.DataTextField = "NewsCategoryName";
        drpCategory.DataValueField = "NewsCategoryID";
        drpCategory.DataBind();
    }

    protected void lbtnNew_Click(object sender, EventArgs e)
    {
        plCategoryInsert.Visible = true;
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            new NewsCode().DeleteCategory(drpCategory.SelectedValue);
            BindCategory();

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
        catch (Exception)
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('این دسته شامل اخبار می باشد، لطفاً ابتدا اخبار را حذف نمائید');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }

    protected void btCategorySubmit_Click(object sender, EventArgs e)
    {
        string fileName = fupPic.PostedFile.FileName;
        System.Drawing.Image thumb = resizeImage(System.Drawing.Image.FromStream(fupPic.PostedFile.InputStream), new System.Drawing.Size(1000, 80));
        thumb.Save(Server.MapPath("~/" + ConfigurationManager.AppSettings["CategoryThumbnailPath"] + fileName));

        new NewsCode().InsertCategory(txtCategory.Text, fileName);
        BindCategory();
        txtCategory.Text = "";
        plCategoryInsert.Visible = false;
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime insertDate = Persia.Calendar.ConvertToGregorian(int.Parse(jqdtInsert.Text.Substring(6, 4)), int.Parse(jqdtInsert.Text.Substring(3, 2)), int.Parse(jqdtInsert.Text.Substring(0, 2)), Persia.DateType.Persian);
            DateTime archiveDate = Persia.Calendar.ConvertToGregorian(int.Parse(jqdtArchive.Text.Substring(6, 4)), int.Parse(jqdtArchive.Text.Substring(3, 2)), int.Parse(jqdtArchive.Text.Substring(0, 2)), Persia.DateType.Persian);

            if (Request.QueryString["NID"] != null)
                new NewsCode().UpdateNews(int.Parse(Request.QueryString["NID"]), txtNewsTitle.Text, editor1.Value, editor2.Value, insertDate, archiveDate, chbfirstPage.Checked, int.Parse(drpCategory.SelectedValue), txtTags.Text);
            else
            {
                new NewsCode().InsertNews(txtNewsTitle.Text, editor1.Value, editor2.Value, insertDate, archiveDate, chbfirstPage.Checked, int.Parse(drpCategory.SelectedValue), txtTags.Text);

                txtNewsTitle.Text = "";
                editor1.Value = "";
                editor2.Value = "";
                jqdtInsert.Text = "";
                jqdtArchive.Text = "";
                chbfirstPage.Checked = false;
                drpCategory.SelectedIndex = -1;
                txtTags.Text = "";
            }

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

    private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
    {
        int sourceWidth = imgToResize.Width;
        int sourceHeight = imgToResize.Height;

        float nPercent = 0;
        //float nPercentW = 0;
        //float nPercentH = 0;

        //nPercentW = ((float)size.Width / (float)sourceWidth);
        //nPercentH = ((float)size.Height / (float)sourceHeight);
        nPercent = ((float)size.Height / (float)sourceHeight);

        //if (nPercentH < nPercentW)
        //nPercent = nPercentH;
        //else
        //    nPercent = nPercentW;

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap b = new Bitmap(destWidth, destHeight);
        Graphics g = Graphics.FromImage((System.Drawing.Image)b);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
        g.Dispose();

        return (System.Drawing.Image)b;
    }
}