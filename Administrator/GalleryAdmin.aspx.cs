using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Configuration;

public partial class GalleryAdmin : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindCategory();
    }
    protected void BindCategory()
    {
        drpCategory.DataSource = new ImageGallery().GetCategoryOnly();
        drpCategory.DataTextField = "ImageProfileName";
        drpCategory.DataValueField = "ImageProfileID";
        drpCategory.DataBind();
    }
    protected void btCategorySubmit_Click(object sender, EventArgs e)
    {
        new ImageGallery().InsertCategory(txtCategory.Text, txtCategoryComment.Text, txtTags.Text);
        BindCategory();
        txtCategory.Text = "";
        txtCategoryComment.Text = "";
        txtTags.Text = "";
        plCategoryInsert.Visible = false;
    }
    protected void lbtnNew_Click(object sender, EventArgs e)
    {
        plCategoryInsert.Visible = true;
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            new ImageGallery().DeleteCategory(drpCategory.SelectedValue);
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
            tmp += "alert('این دسته شامل تصویر می باشد، لطفاً ابتدا تصویرها را حذف نمائید');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (fupImage.HasFile)
            {
                string fileName = fupImage.PostedFile.FileName.Substring(fupImage.PostedFile.FileName.LastIndexOf("\\")+1);
                fupImage.PostedFile.SaveAs(Server.MapPath("~/" + ConfigurationManager.AppSettings["ImagePath"] + fileName));
                System.Drawing.Image thumb = resizeImage(System.Drawing.Image.FromStream(fupImage.PostedFile.InputStream), new System.Drawing.Size(1000, 80));
                thumb.Save(Server.MapPath("~/" + ConfigurationManager.AppSettings["ImageThumbnailPath"] + fileName));

                new ImageGallery().InsertImage(txtImageName.Text, txtImageComment.Text, fileName, int.Parse(drpCategory.SelectedValue));

                txtImageComment.Text = "";
                txtImageName.Text = "";

                string tmp = "";
                tmp = "<script language='javascript'>";
                tmp += "alert('عملیات با موفقیت انجام شد');";
                tmp += "</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
            }
            else
            {
                string tmp = "";
                tmp = "<script language='javascript'>";
                tmp += "alert('هیچ فایلی انتخاب ننموده اید');";
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