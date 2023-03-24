<%@ Page Title="انتشارات مهرایمان:: تخفیف همایشات::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPUsersDefault.master" AutoEventWireup="true" CodeFile="LectureDiscount.aspx.cs"
    Inherits="Users_LectureDiscount" %>

<%@ Register Assembly="MagicAjax" Namespace="MagicAjax.UI.Controls" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="../Images/HeaderPageLecture.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" colspan="2" style="background-image: url('../Images/TranslationGuide.gif');
                background-repeat: no-repeat; width: 740px; height: 100px; color: Black; opacity: 0.9;
                filter: alpha(opacity=90);">
                <b>لطفاً جهت ثبت نام گروهی هر عضو به صورت جداگانه ثبت نام نموده و مبلغ را با توجه به
                    تخفیف گروهی پرداخت نماید
                    <br />
                    ولی در روز همایش حضور تمامی اعضای گروه در هنگام ورود به همایش الزامی می باشد.</b>
            </td>
        </tr>
    </table>
    <ajax:AjaxPanel ID="AjaxPanel1" runat="server" >
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background-image: url('../Images/ContentBG.gif');
            background-repeat: no-repeat; width: 740px; height: 350px; color: Black; opacity: 0.9;
            filter: alpha(opacity=90);">
            <tr>
                <td>
                    <asp:Label ID="lbDate" runat="server" Text=""></asp:Label>
                    بابت زمان ثبت نام
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbDiscountType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbDiscountType_SelectedIndexChanged">
                    </asp:RadioButtonList>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbNumberDiscount" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbNumberDiscount_SelectedIndexChanged">
                        <asp:ListItem Text="انفرادی" Value="1"></asp:ListItem>
                        <asp:ListItem Text="گروهی" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    تعداد نفرات:
                    <asp:TextBox ID="txtNumber" runat="server" Enabled="false" SkinID="Little" AutoPostBack="True"
                        OnTextChanged="txtNumber_TextChanged"></asp:TextBox>
                    <asp:Label ID="lbNumber" runat="server" Text=""></asp:Label>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    مبلغ نهایی با اعمال تمامی تخفیفات برابر است با:
                    <asp:Label ID="lbPrice" runat="server" Text="Label"></asp:Label>
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:ImageButton ID="imbRegister" ImageUrl="~/Images/Pay.GIF" runat="server" OnClick="imbRegister_Click" />
                </td>
            </tr>
        </table>
    </ajax:AjaxPanel>
</asp:Content>
