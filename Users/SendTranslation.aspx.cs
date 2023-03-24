using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Users_SendTranslation : System.Web.UI.Page
{
    public string TotalAmount = string.Empty;
    public string ReservationNumber = string.Empty;
    public string MerchantID = string.Empty;
    public string RedirectURL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new TranslationCode().GetTranslationByID(int.Parse(Request.QueryString["TransID"].ToString()));
        if (ds != null)
        {
            if (!bool.Parse(ds.Tables[0].Rows[0]["TranslationPaid"].ToString()) && bool.Parse(ds.Tables[0].Rows[0]["TranslationCheck"].ToString()))
            {
                MerchantID = "02142011-137827";
                RedirectURL = "http://main.mehriman.com/Users/GetBackTranslation.aspx";
                ReservationNumber = Request.QueryString["TransID"].ToString();
                Session["TransPrice"] = ds.Tables[0].Rows[0]["TranslationPrice"].ToString();
                TotalAmount = Session["TransPrice"].ToString();
            }
        }
    }
}