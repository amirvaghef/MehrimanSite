using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Mail;

public partial class Administrator_TranslationAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["DS"] = new TranslationCode().GetRequestPriceList();
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
        string url = HttpContext.Current.Request.Url.Host;
        url = "http://" + url + "/Users/SendTranslation.aspx?TransID=" + ((Label)DetailsView1.Rows[0].FindControl("TranslationID")).Text;
        objEmail.Body = editor1.Value + "<br /> " +
                            "<a href='" + url + "' target='_blank'>پرداخت هزینه و ثبت فایل برای ترجمه</a>" + "<br /> " +
                            "<b>قیمت ترجمه: </b>" + ((TextBox)DetailsView1.Rows[0].FindControl("txtEditTranslationPrice")).Text + "ریال <br/>" +
                            "<b>مدت زمان ترجمه: </b>" + ((TextBox)DetailsView1.Rows[0].FindControl("txtEditTranslationDeliveryDay")).Text + "روز <br/>";
        objEmail.BodyFormat = MailFormat.Html;
        objEmail.BodyEncoding = System.Text.Encoding.UTF8;
        objEmail.Priority = MailPriority.High;
        //objEmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //basic authentication
        //objEmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "admin@mehriman.com" ); //set your username here
        //objEmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "sofbq81v" ); //set your password here
        SmtpMail.SmtpServer = "72.55.165.179";
        try
        {
            SmtpMail.Send(objEmail);
            Response.Write("Your Email has been sent sucessfully - Thank You");

            new TranslationCode().UpdateCheck(((TextBox)DetailsView1.Rows[0].FindControl("txtEditTranslationPrice")).Text, ((TextBox)DetailsView1.Rows[0].FindControl("txtEditTranslationDeliveryDay")).Text, editor1.Value, ((Label)DetailsView1.Rows[0].FindControl("TranslationID")).Text);
            Session["DS"] = new TranslationCode().GetRequestPriceList();
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
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        GridView1.DataSource = (DataSet)Session["DS"];
        GridView1.DataBind();
    }
}