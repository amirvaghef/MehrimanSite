using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Configuration;

public partial class Translation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imbSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (!String.IsNullOrEmpty(User.Identity.Name))
        {
            string id = Membership.GetUser().ProviderUserKey.ToString();
            DataSet ds = new UsersCode().GetUser(id);

            string fileName = fupTranslationFile.PostedFile.FileName;
            fupTranslationFile.PostedFile.SaveAs(Server.MapPath("~/" + ConfigurationManager.AppSettings["TranslationFilePath"] + fileName));

            new TranslationCode().InsertTranslation(id, User.Identity.Name, ds.Tables[0].Rows[0]["FirstName"].ToString(),
                ds.Tables[0].Rows[0]["LastName"].ToString(), ds.Tables[0].Rows[0]["EmailAddress"].ToString(), ds.Tables[0].Rows[0]["Tel"].ToString(),
                ds.Tables[0].Rows[0]["MobileAlias"].ToString(), txtComment.Text, fileName);

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('عملیات با موفقیت انجام شد');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);

            txtComment.Text = "";
        }
        else
        {
            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('لطفاً ابتدا لاگین نمائید');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);
        }
    }
}