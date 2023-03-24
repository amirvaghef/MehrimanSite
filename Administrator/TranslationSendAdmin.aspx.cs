using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Mail;
using System.IO;

public partial class Administrator_TranslationSendAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["DS"] = new TranslationCode().GetRequestTranslationList();
            GridView1.DataSource = (DataSet)Session["DS"];
            GridView1.DataBind();
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        btSubmit.Visible = true;
        PanelComment.Visible = true;
        DataSet ds = (DataSet)Session["DS"];
        DetailsView1.DataSource = new TranslationCode().GetTranslationByID(int.Parse(GridView1.SelectedDataKey.Value.ToString()));
        DetailsView1.DataBind();
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        //Send Mail
        MailMessage objEmail = new MailMessage();
        objEmail.To = ((Label)DetailsView1.Rows[0].FindControl("EmailAddress")).Text;
        objEmail.From = "admin@mehriman.com";
        objEmail.Subject = "کروه ترجمه مهرایمان";
        string attach1 = "";
        if (inpAttachment1.PostedFile != null)
        {
            /* Get a reference to PostedFile object */
            HttpPostedFile attFile = inpAttachment1.PostedFile;
            /* Get size of the file */
            int attachFileLength = attFile.ContentLength;
            /* Make sure the size of the file is > 0  */
            if (attachFileLength > 0)
            {
                /* Get the file name */
                string strFileName = Path.GetFileName(inpAttachment1.PostedFile.FileName);
                /* Save the file on the server */
                inpAttachment1.PostedFile.SaveAs(Server.MapPath(strFileName));
                /* Create the email attachment with the uploaded file */
                MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
                /* Attach the newly created email attachment */
                objEmail.Attachments.Add(attach);
                /* Store the attach filename so we can delete it later */
                attach1 = strFileName;
            }
        }
        string url = HttpContext.Current.Request.Url.Host;
        url = "http://" + url + "/Users/SendTranslation.aspx?TransID=" + ((Label)DetailsView1.Rows[0].FindControl("TranslationID")).Text;
        objEmail.Body = editor1.Value;
        objEmail.BodyFormat = MailFormat.Html;
        objEmail.Priority = MailPriority.High;
        SmtpMail.SmtpServer = "smtp.mehriman.com";
        try
        {
            SmtpMail.Send(objEmail);
            Response.Write("Your Email has been sent sucessfully - Thank You");

            new TranslationCode().UpdateSent(((Label)DetailsView1.Rows[0].FindControl("TranslationID")).Text);
            Session["DS"] = new TranslationCode().GetRequestTranslationList();
            GridView1.DataSource = (DataSet)Session["DS"];
            GridView1.DataBind();
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
            btSubmit.Visible = false;
            PanelComment.Visible = false;
            editor1.Value = "";
        }
        catch (Exception exc)
        {
            Response.Write("Send failure: " + exc.ToString());
        }
        finally
        {
            if (attach1 != null)
                File.Delete(Server.MapPath(attach1));
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        GridView1.DataSource = (DataSet)Session["DS"];
        GridView1.DataBind();
    }
}