using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class Users_GetBackDownload : System.Web.UI.Page
{
    public string refrenceNumber = string.Empty;
    public string reservationNumber = string.Empty;
    private string transactionState = string.Empty;
    private string merchantID = "02142011-137827"; // Every merchant has a special ID & password
    private string password = "966602";
    private string succeedMsg = string.Empty;
    private double result;

    string errorMsg = string.Empty;
    bool isError = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        com.sb24.acquirer.ReferencePayment SamanPaymentServices = new com.sb24.acquirer.ReferencePayment();
        if (RequestUnpack())
        {
            if (transactionState.Equals("OK"))            // Transaction is OK
            {
                ///////////////////////////////////////////////////////////////////////////////////
                //   *** IMPORTANT  ****   ATTENTION
                // Here you should check refrenceNumber in your DataBase tp prevent double spending
                ///////////////////////////////////////////////////////////////////////////////////

                Session["RefNum"] = refrenceNumber; // add refrenceNumber in session object
                try
                {
                    result = SamanPaymentServices.verifyTransaction(refrenceNumber, merchantID);

                    if (result > 0)
                    {
                        // when result >0, its amount of transaction
                        double clientAmount = GetClientAmount();
                        if (result > clientAmount)
                        {
                            int i = ReverseTransaction(result - clientAmount);
                            if (i == 1)
                            {
                                succeedMsg = "بانک صحت رسيد ديجيتالي شما را تصديق نمود. فرايند خريد تکميل گشت";
                                isError = false;

                                EnableDownloadLink();
                            }
                            else
                            {
                                //  reverse was not posible
                                result = i;
                            }
                        }
                        else if (result < clientAmount)
                        {
                            int i = ReverseTransaction(result);
                            if (i == 1)
                            {
                                errorMsg = "بروز خطا درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                isError = true; ;
                            }
                            else
                            {
                                //  reverse was not posible
                                result = i;
                            }
                        }
                        else if (result.Equals(clientAmount)) //Total Amount of Basket
                        {
                            isError = false;
                            succeedMsg = "بانک صحت رسيد ديجيتالي شما را تصديق نمود. فرايند خريد تکميل گشت";

                            EnableDownloadLink();
                        }

                    }
                    TransactionChecking((int)result);
                }
                catch (Exception ex)
                {
                    isError = true;
                    errorMsg = "سرور بانک براي تاييد رسيد ديجيتالي در دسترس نيست<br><br>" + ex.Message;
                }
            }
        }
        else
        {
            isError = true;
            errorMsg = "متاسفانه بانک خريد شما را تاييد نکرده است";

            if (transactionState.Equals("Canceled By User") || transactionState.Equals(string.Empty))
            {
                // Transaction was canceled by user
                isError = true;
                errorMsg = "تراكنش توسط خريدار كنسل شد";
            }
            else if (transactionState.Equals("Invalid Amount"))
            {
                // Amount of revers teransaction is more than teransaction
            }
            else if (transactionState.Equals("Invalid Transaction"))
            {
                // Can not find teransaction
            }
            else if (transactionState.Equals("Invalid Card Number"))
            {
                // Card number is wrong
            }
            else if (transactionState.Equals("No Such Issuer"))
            {
                // Issuer can not find
            }
            else if (transactionState.Equals("Expired Card Pick Up"))
            {
                // The card is expired
            }
            else if (transactionState.Equals("Allowable PIN Tries Exceeded Pick Up"))
            {
                // For third time user enter a wrong PIN so card become invalid
            }
            else if (transactionState.Equals("Incorrect PIN"))
            {
                // Pin card is wrong
            }
            else if (transactionState.Equals("Exceeds Withdrawal Amount Limit"))
            {
                // Exceeds withdrawal from amount limit
            }
            else if (transactionState.Equals("Transaction Cannot Be Completed"))
            {
                // PIN and PAD are currect but Transaction Cannot Be Completed
            }
            else if (transactionState.Equals("Response Received Too Late"))
            {
                // Timeout occur
            }
            else if (transactionState.Equals("Suspected Fraud Pick Up"))
            {
                // User did not insert cvv2 & expiredate or they are wrong.
            }
            else if (transactionState.Equals("No Sufficient Funds"))
            {
                // there are not suficient funds in the account
            }
            else if (transactionState.Equals("Issuer Down Slm"))
            {
                // The bank server is down
            }
            else if (transactionState.Equals("TME Error"))
            {
                // unknown error occur
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                      Page initialize
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (isError)
        {
            lblMsg.Text = errorMsg;
            lblMsg.Visible = true;
            linkDownload.Visible = false;
        }
        else
        {
            lblMsg.Text = succeedMsg;
            lblMsg.Visible = true;
            linkDownload.Visible = true;
        }

    }

    private void EnableDownloadLink()
    {
        if (Session["DwnID"] != null)
        {
            linkDownload.HRef = Session["DownloadSource"].ToString();
            new DownloadFile().InsertBuyDownload(reservationNumber, refrenceNumber, int.Parse(Session["DwnID"].ToString()), Session["DownloadPrice"].ToString(), Membership.GetUser().ProviderUserKey.ToString(), User.Identity.Name);
        }
        else
        {
            ReverseTransaction(double.Parse(Session["DownloadPrice"].ToString()));
            isError = true;
            errorMsg = "فایل مورد نظر موجود نبود، لطفاً دوباره تلاش نمائید. <br><b>در ضمن پرداختی شما برگشت داده شد.</b>";
        }
    }

    private bool RequestUnpack()
    {
        if (RequestFeildIsEmpity()) return false;

        refrenceNumber = Request.Form["RefNum"].ToString();
        reservationNumber = Request.Form["ResNum"].ToString();
        transactionState = Request.Form["state"].ToString();

        return true;
    }

    private bool RequestFeildIsEmpity()
    {
        if (Request.Form["RefNum"].ToString().Equals(string.Empty))
        {
            isError = true;
            errorMsg = "فرايند انتقال وجه با موفقيت انجام شده است اما فرايند تاييد رسيد ديجيتالي با خطا مواجه گشت";
            return true;
        }
        if (Request.Form["state"].ToString().Equals(string.Empty))
        {
            isError = true;
            errorMsg = "خريد شما توسط بانک تاييد شده است اما رسيد ديجيتالي شما تاييد نگشت! مشکلي در فرايند رزرو خريد شما پيش آمده است";
            return true;
        }
        if (Request.Form["ResNum"].ToString().Equals(string.Empty))
        {
            isError = true;
            errorMsg = "خطا در برقرار ارتباط با بانک";
            return true;
        }
        return false;
    }


    private double GetClientAmount()
    {
        return double.Parse(Session["DownloadPrice"].ToString());
        ////////////////////////////////////////////////////
        /// Atrtention                  توجه !
        /// شما بايد قيمت خريد را از قبل در بانك اطلاعات يا 
        ///  Session or Request
        /// ذخيره نموده باشيد. حال آنرا به روشي كه مي دانيد بازيابي كنيد
        /// 
        /// مثال 
        // double.Parse(Session["Amount"].ToString());
    }

    private int ReverseTransaction(double revAmount)
    {
        com.sb24.acquirer.ReferencePayment SamanPaymentServices = new com.sb24.acquirer.ReferencePayment();
        int res = SamanPaymentServices.reverseTransaction(refrenceNumber, merchantID, password, revAmount);
        return res;
    }

    private void TransactionChecking(int i)
    {

        switch (i)
        {

            case -1:		//TP_ERROR
                isError = true;
                errorMsg = "بروز خطا درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -2:		//ACCOUNTS_DONT_MATCH
                isError = true;
                errorMsg = "بروز خطا در هنگام تاييد رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -3:		//BAD_INPUT
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -4:		//INVALID_PASSWORD_OR_ACCOUNT
                isError = true;
                errorMsg = "خطاي دروني سيستم درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -5:		//DATABASE_EXCEPTION
                isError = true;
                errorMsg = "خطاي دروني سيستم درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -7:		//ERROR_STR_NULL
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -8:		//ERROR_STR_TOO_LONG
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -9:		//ERROR_STR_NOT_AL_NUM
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -10:	//ERROR_STR_NOT_BASE64
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -11:	//ERROR_STR_TOO_SHORT
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -12:		//ERROR_STR_NULL
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -13:		//ERROR IN AMOUNT OF REVERS TRANSACTION AMOUNT
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -14:	//INVALID TRANSACTION
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -15:	//RETERNED AMOUNT IS WRONG
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -16:	//INTERNAL ERROR
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -17:	// REVERS TRANSACTIN FROM OTHER BANK
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;
            case -18:	//INVALID IP
                isError = true;
                errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                break;

        }
    }
}