using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Users_Downloading : System.Web.UI.Page
{
    public string TotalAmount = string.Empty;
    public string ReservationNumber = string.Empty;
    public string MerchantID = string.Empty;
    public string RedirectURL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            if (Request.QueryString["DwnID"] != null)
            {
                Session["DwnID"] = Request.QueryString["DwnID"];
                ds = new DownloadFile().GetDownloadByID(int.Parse(Request.QueryString["DwnID"]));

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string downloadSource = ds.Tables[0].Rows[0]["DownloadSource"].ToString();
                        if (double.Parse(ds.Tables[0].Rows[0]["DownloadPrice"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["DownloadPrice"].ToString()) <= 0)
                        {
                            if (Boolean.Parse(ds.Tables[0].Rows[0]["IsLink"].ToString()))
                                Response.Redirect(downloadSource);
                            else
                            {
                                string path = MapPath("../" + System.Configuration.ConfigurationManager.AppSettings["FilePath"] + downloadSource);
                                //byte[] bytes = File.ReadAllBytes(path);
                                Response.Clear();
                                Response.ClearContent();
                                Response.ClearHeaders();
                                Response.Buffer = true;
                                Response.AppendHeader("content-disposition", "attachment; filename=" + downloadSource);
                                Response.ContentType = GetContentType(downloadSource);
                                Response.TransmitFile(path);
                                Response.Flush();
                                Response.End();

                                //Response.BinaryWrite(bytes);
                            }
                        }
                        else
                        {
                            Session["DownloadPrice"] = TotalAmount = ds.Tables[0].Rows[0]["DownloadPrice"].ToString();
                            Session["DownloadSource"] = downloadSource;
                            string guid = Guid.NewGuid().ToString();
                            MerchantID = "02142011-137827";
                            RedirectURL = "http://main.mehriman.com/Users/GetBackDownload.aspx";
                            ReservationNumber = guid;
                        }
                    }
                    else
                        Response.Write("فایل مورد نظر موجود نبود، لطفاً دوباره تلاش نمائید.");
                }
                else
                    Response.Write("فایل مورد نظر موجود نبود، لطفاً دوباره تلاش نمائید.");
            }
            else
                Response.Write("فایل مورد نظر موجود نبود، لطفاً دوباره تلاش نمائید.");
        }
    }

    private string GetContentType(string fileName)
    {
        string contentType = "application/octetstream";
        string ext = System.IO.Path.GetExtension(fileName).ToLower();
        try
        {
            var valueInTable = MIMEType.MimeTypes.Value[ext];
            if (valueInTable != null)
                return valueInTable as string;
        }
        catch (KeyNotFoundException ex)
        {
        }
        Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (registryKey != null && registryKey.GetValue("Content Type") != null)
            contentType = registryKey.GetValue("Content Type").ToString();
        return contentType;
    }
}