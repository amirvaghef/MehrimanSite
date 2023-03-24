using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class Administrator_ImageFirstPageAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btCategorySubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (fupPic.HasFile)
            {
                string fileName = fupPic.PostedFile.FileName.Substring(fupPic.PostedFile.FileName.LastIndexOf("\\") + 1);
                System.Drawing.Image thumb = null;
                switch (drpPosition.SelectedValue)
                {
                    case "0":
                        thumb = resizeImage(System.Drawing.Image.FromStream(fupPic.PostedFile.InputStream), new System.Drawing.Size(1000, 150));
                        break;
                    case "1":
                        thumb = System.Drawing.Image.FromStream(fupPic.PostedFile.InputStream);
                        if (thumb.Width > 370)
                            thumb = resizeImage(System.Drawing.Image.FromStream(fupPic.PostedFile.InputStream), new System.Drawing.Size(370, 1000));
                        break;
                    case "2":
                        thumb = resizeImage(System.Drawing.Image.FromStream(fupPic.PostedFile.InputStream), new System.Drawing.Size(1000, 100));
                        break;
                    default:
                        thumb = resizeImage(System.Drawing.Image.FromStream(fupPic.PostedFile.InputStream), new System.Drawing.Size(1000, 150));
                        break;
                }

                thumb.Save(Server.MapPath("~/" + ConfigurationManager.AppSettings["CategoryThumbnailPath"] + fileName));
                new ImageFirstPageCode().Insert(txtName.Text, fileName, txtLink.Text, short.Parse(drpPosition.SelectedValue));

                txtName.Text = "";
                txtLink.Text = "";
                drpPosition.SelectedIndex = -1;

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
                tmp += "alert('هیچ تصویری انتخاب ننموده اید');";
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