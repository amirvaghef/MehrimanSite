<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MPPaymentDefault.master" AutoEventWireup="true" CodeFile="Downloading.aspx.cs" Inherits="Users_Downloading" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" Runat="Server">
    <img src="Images/HeaderPageDownload.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <input type="hidden" name="Amount" value="<%= TotalAmount %>" />
    <input type="hidden" name="ResNum" value="<%= ReservationNumber %>" />
    <input type="hidden" name="MID" value="<%= MerchantID %>" />
    <input type="hidden" name="RedirectURL" value="<%= RedirectURL %>" />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" colspan="2" style="background-image: url('../Images/TranslationGuide.gif');
                background-repeat: no-repeat; width: 740px; height: 100px; color: Black; opacity: 0.9;
                filter: alpha(opacity=90);">
                <b>
                    <br />
                    به خاطر سپردن شناسه پرداخت سایت و همچنین شناسه پرداخت بانک که متعاقباً اعلام می
                    شود برای پیگیری های بعدی الزامی می باشد.</b>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background-image: url('../Images/ContentBG.gif');
        background-repeat: no-repeat; width: 740px; height: 350px; color: Black; opacity: 0.9;
        filter: alpha(opacity=90);">
        <tr>
            <td>
                <br />
                <b style="color: Red;">شناسه پرداخت سایت: </b>
                <%= ReservationNumber%>
                <br />
                <b style="color: Red;">مبلغ قابل پرداخت: </b>
                <%= TotalAmount%>
                ریال
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <%--<asp:ImageButton ID="imbRegister" ImageUrl="~/Images/Pay.GIF" runat="server" />--%>
                <input id="btnsend" type="submit" value="پرداخت سامان" width="98px"/>
            </td>
        </tr>
    </table>
</asp:Content>

