using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class Administrator_DownloadAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindCategory();
    }

    protected void BindCategory()
    {
        drpCategory.DataSource = new DownloadFile().GetCategoryOnly();
        drpCategory.DataTextField = "DownloadProfileName";
        drpCategory.DataValueField = "DownloadProfileID";
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
            new DownloadFile().DeleteCategory(drpCategory.SelectedValue);
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
            tmp += "alert('این دسته شامل فایل می باشد، لطفاً ابتدا فایل ها را حذف نمائید');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }

    protected void btCategorySubmit_Click(object sender, EventArgs e)
    {
        string fileName = fupPic.PostedFile.FileName.Substring(fupPic.PostedFile.FileName.LastIndexOf("\\") + 1);
        System.Drawing.Image thumb = resizeImage(System.Drawing.Image.FromStream(fupPic.PostedFile.InputStream), new System.Drawing.Size(1000, 80));
        thumb.Save(Server.MapPath("~/" + ConfigurationManager.AppSettings["CategoryThumbnailPath"] + fileName));
        new DownloadFile().InsertCategory(txtCategory.Text, txtCategoryComment.Text, fileName);
        BindCategory();
        txtCategory.Text = "";
        txtCategoryComment.Text = "";
        plCategoryInsert.Visible = false;
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (fupFile.HasFile)
            {
                string fileName = fupFile.PostedFile.FileName.Substring(fupFile.PostedFile.FileName.LastIndexOf("\\") + 1);
                fupFile.PostedFile.SaveAs(Server.MapPath("~/" + ConfigurationManager.AppSettings["FilePath"] + fileName));

                new DownloadFile().InsertDownload(txtFileName.Text, txtFileComment.Value, fileName, fupFile.PostedFile.ContentLength, int.Parse(txtPrice.Text), false, int.Parse(drpCategory.SelectedValue), txtTags.Text);

                txtFileComment.Value = "";
                txtFileName.Text = "";
                txtLink.Text = "";
                txtPrice.Text = "0";
                txtTags.Text = "";

                string tmp = "";
                tmp = "<script language='javascript'>";
                tmp += "alert('عملیات با موفقیت انجام شد');";
                tmp += "</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
            }
            else
            {
                new DownloadFile().InsertDownload(txtFileName.Text, txtFileComment.Value, txtLink.Text, 0, int.Parse(txtPrice.Text), true, int.Parse(drpCategory.SelectedValue), txtTags.Text);

                txtFileComment.Value = "";
                txtFileName.Text = "";
                txtLink.Text = "";
                txtPrice.Text = "0";
                txtTags.Text = "";

                string tmp = "";
                tmp = "<script language='javascript'>";
                tmp += "alert('عملیات با موفقیت انجام شد');";
                tmp += "</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
            }
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