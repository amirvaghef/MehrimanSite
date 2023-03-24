<%@ Page Title="انتشارات مهرایمان:: بخش ترجمه::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPDefault.master" AutoEventWireup="true" CodeFile="Translation.aspx.cs"
    Inherits="Translation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="Images/HeaderPageTranslation.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <img src="Images/TranslationBigHeader.gif" width="100" height="124" />
    <br />
    <table width="740px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" valign="top" style="width: 740px; padding-top: 10px;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" colspan="2" style="background-image: url('Images/TranslationGuide.gif');
                            background-repeat: no-repeat; width: 740px; height: 100px; color: Black; opacity: 0.9;
                            filter: alpha(opacity=90);">
                            <b>لطفاً فایلی را که می خواهید ترجمه گردد در پائین انتخاب نموده و برای ما ارسال نمائید
                                تا در اسرع وقت قیمت
                                <br />
                                ترجمه را ارزیابی نموده و همراه با لینک پرداخت آنلاین برای شما میل نمائیم.</b>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" style="background-image: url('Images/ContentBG.gif');
                    background-repeat: no-repeat; width: 740px; height: 350px; color: Black; opacity: 0.9;
                    filter: alpha(opacity=90);">
                    <tr>
                        <td>
                            فایل ترجمه:
                        </td>
                        <td>
                            <asp:FileUpload ID="fupTranslationFile" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fupTranslationFile"
                                ErrorMessage="این فیلد ضروری می باشد" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            توضیحات:
                        </td>
                        <td>
                            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" SkinID="Multi"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ImageButton ID="imbSubmit" ImageUrl="~/Images/Send.GIF" runat="server" OnClick="imbSubmit_Click" />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
