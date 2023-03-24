<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageFirstPageAdmin.aspx.cs"
    Inherits="Administrator_ImageFirstPageAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>انتشارات مهرایمان:: مدیریت صفحه اول</title>
</head>
<body style="font-family: tahoma; font-size: 12px;">
    <form id="form1" runat="server" dir="rtl">
    <div>
        <table align="center" width="1027" border="1" cellpadding="0" cellspacing="0">
            <tr style="height: 246px; width: 1027px; background-image: url('../images/HeaderBGDownload.jpg');">
                <td align="right">
                    <div style="top: 230px; padding-left: 370px; position: absolute;">
                        <a href="ImageFirstPageAdmin.aspx" style="padding-left: 40px;">صفحه اصلی</a>
                        <a href="NewsAdmin.aspx" style="padding-left: 40px;">اخبار</a> <a href="LectureAdmin.aspx"
                            style="padding-left: 40px;">همایشات</a> <a href="GalleryAdmin.aspx" style="padding-left: 40px;">
                                گالری تصاویر</a> <a href="DownloadAdmin.aspx" style="padding-left: 40px;">دانلود</a>
                        <a href="TranslationAdmin.aspx" style="padding-left: 40px;">ترجمه</a> <a href="TrainingAdmin.aspx"
                            style="padding-left: 40px;">آموزش</a><a href="CommentAdmin.aspx" style="padding-left: 40px;">
                                کامنت ها</a> <a href="ScientificNewsAdmin.aspx" style="padding-left: 40px;">اخبار علمی</a>
                    </div>
                    <div style="top: 45px; padding-left: 730px; position: absolute;">
                        <table border="0" cellpadding="0" cellspacing="0" width="280px">
                            <tr align="center">
                                <td align="right" style="width: 70px">
                                    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="خروج" />
                                </td>
                                <td align="right" style="color: Black;">
                                    <asp:LoginName ID="LoginName1" runat="server" />
                                    ، خوش آمدید
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                </td>
                                <td align="right">
                                    <br />
                                    <a href="http://www.mehriman.com/UserInfo.aspx">ویرایش اطلاعات کاربری</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table width="1027" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-image: url('../Images/HeaderRightAdmin.gif'); width: 295px;
                                height: 246px;">
                            </td>
                            <td style="background-image: url('../Images/HeaderLeftAdmin.gif'); width: 732px;
                                height: 246px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="1027" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" style="background-image: url('../Images/MainBGDownload.jpg'); width: 1027px;
                                height: 700px;">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="plCategoryInsert" runat="server" BorderWidth="2">
                                                <br />
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="color: White;">
                                                            نام:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtName" runat="server" ValidationGroup="Category"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtName" ValidationGroup="Category">فیلد نام مورد نیاز می باشد</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td style="color: White;">
                                                            لینک:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLink" runat="server" ValidationGroup="Category"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtLink" ValidationGroup="Category">فیلد لینک مورد نیاز می باشد</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                                ControlToValidate="txtLink" ErrorMessage="*" 
                                                                ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" 
                                                                ValidationGroup="Category">فیلد لینک را با فرمت درست وارد نمائید</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" style="color: White;">
                                                            تصویر:
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="fupPic" runat="server" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                                ControlToValidate="fupPic" ValidationGroup="Category">تصویر مورد نیاز می باشد</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="color: White;">
                                                            موقعیت:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpPosition" runat="server">
                                                                <asp:ListItem Value="0">بالا</asp:ListItem>
                                                                <asp:ListItem Value="1">وسط</asp:ListItem>
                                                                <asp:ListItem Value="2">پائین</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="btCategorySubmit" runat="server" CausesValidation="true" Text="ثبت"
                                                                OnClick="btCategorySubmit_Click" ValidationGroup="Category" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 1027px; height: 25px; background-color: White;">
                    <a href="ImageFirstPageDeleteAdmin.aspx">حذف تصویر
            </tr>
            <tr style="height: 110px; width: 1027px; background-image: url('../images/FooterBG.jpg');">
                <td>
                    <table width="1027" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-image: url('../Images/FooterRight.gif'); width: 295px; height: 110px;">
                            </td>
                            <td style="background-image: url('../Images/FooterLeft.gif'); width: 732px; height: 110px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
