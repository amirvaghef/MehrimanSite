<%@ Page Title="انتشارات مهرایمان:: تأئید پرداخت::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPUsersDefault.master" AutoEventWireup="true" CodeFile="GetBackTranslation.aspx.cs"
    Inherits="Users_GetBackTranslation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="../Images/HeaderPageTranslation.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" colspan="2" style="background-image: url('../Images/TranslationGuide.gif');
                background-repeat: no-repeat; width: 740px; height: 100px; color: Black; opacity: 0.9;
                filter: alpha(opacity=90);">
                <b>
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Red"
                        Visible="False"></asp:Label></b>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background-image: url('../Images/ContentBG.gif');
        background-repeat: no-repeat; width: 740px; height: 350px; color: Black; opacity: 0.9;
        filter: alpha(opacity=90);">
        <tr>
            <td>
                <br />
                <b style="color: Red;">شناسه پرداخت بانک: </b>
                <%= refrenceNumber%>
                <br />
                <b style="color: Red;">شناسه پرداخت سایت: </b>
                <%= reservationNumber%>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="imbBack" ImageUrl="~/Images/back.GIF" runat="server" PostBackUrl="~/../Translation.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
