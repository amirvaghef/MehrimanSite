using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_Send : System.Web.UI.Page
{
    public string TotalAmount = string.Empty;
    public string ReservationNumber = string.Empty;
    public string MerchantID = string.Empty;
    public string RedirectURL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        MerchantID = "02142011-137827";
        RedirectURL = "http://main.mehriman.com/Users/GetBack.aspx";
        ReservationNumber = Session["ReservationNumber"].ToString();
        TotalAmount = Session["LecturePrice"].ToString();
    }
}