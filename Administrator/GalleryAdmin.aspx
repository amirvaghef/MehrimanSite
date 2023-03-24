<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GalleryAdmin.aspx.cs" Inherits="GalleryAdmin" %>

<%@ Register Assembly="MagicAjax" Namespace="MagicAjax.UI.Controls" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>انتشارات مهرایمان:: مدیریت گالری تصاویر</title>
</head>
<body style="font-family: tahoma; font-size: 12px;">
    <form id="form1" runat="server" dir="rtl">
    <div>
        <table align="center" width="1027" border="1" cellpadding="0" cellspacing="0">
            <tr style="height: 246px; width: 1027px; background-image: url('../images/HeaderBGGallery.jpg');">
                <td align="right">
                    <div style="top: 230px; padding-left:370px; position: absolute;">
                        <a href="ImageFirstPageAdmin.aspx" style="padding-left: 40px;">صفحه اصلی</a> <a href="NewsAdmin.aspx"
                            style="padding-left: 40px;">اخبار</a> <a href="LectureAdmin.aspx" style="padding-left: 40px;">
                                همایشات</a> <a href="GalleryAdmin.aspx" style="padding-left: 40px;">گالری تصاویر</a>
                        <a href="DownloadAdmin.aspx" style="padding-left: 40px;">دانلود</a> <a href="TranslationAdmin.aspx"
                            style="padding-left: 40px;">ترجمه</a> <a href="TrainingAdmin.aspx" style="padding-left: 40px;">
                                آموزش</a><a href="CommentAdmin.aspx" style="padding-left: 40px;">
                                کامنت ها</a>
                                <a href="ScientificNewsAdmin.aspx" style="padding-left: 40px;">اخبار علمی</a>
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
                            <td style="background-image: url('../Images/HeaderRightGallery.gif'); width: 295px;
                                height: 246px;">
                            </td>
                            <td style="background-image: url('../Images/HeaderLeftGallery.gif'); width: 732px;
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
                            <td valign="top" style="background-image: url('../Images/MainBGGallery.jpg'); width: 1027px;
                                height: 700px;">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top"style="color:White;">
                                            دسته بندی:
                                        </td>
                                        <td>
                                            <ajax:AjaxPanel ID="AjaxPanel1" runat="server">
                                                <asp:DropDownList ID="drpCategory" runat="server">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="lbtnNew" runat="server" OnClick="lbtnNew_Click">دسته جدید</asp:LinkButton>
                                                &nbsp;&nbsp;<asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click">حذف</asp:LinkButton>
                                                <br />
                                                <asp:Panel ID="plCategoryInsert" runat="server" Visible="false" BorderWidth="2">
                                                    <br />
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="color:White;">
                                                                نام دسته:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                                    ControlToValidate="txtCategory" ValidationGroup="Category">نام دسته مورد نیاز می باشد</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="color:White;">
                                                                توضیحات:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCategoryComment" TextMode="MultiLine" runat="server" SkinID="Multi"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="color:White;">
                                                                :تگ ها
                                                            </td>
                                                            <td>
                                                                <span style="color: Red">لطفاً تگ ها را با ویرگول(،) از هم جدا نمائید </span>
                                                                <br />
                                                                <asp:TextBox ID="txtTags" runat="server" TextMode="MultiLine" SkinID="Multi"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                                <asp:Button ID="btCategorySubmit" runat="server" Text="ثبت" OnClick="btCategorySubmit_Click"
                                                                    ValidationGroup="Category" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </asp:Panel>
                                                <br />
                                            </ajax:AjaxPanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="color:White;">
                                            نام تصویر:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtImageName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtImageName" ValidationGroup="Submit">نام تصویر مورد نیاز می باشد</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="color:White;">
                                            توضیحات:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtImageComment" TextMode="MultiLine" runat="server" SkinID="Multi"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="color:White;">
                                            تصویر:
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fupImage" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                ControlToValidate="fupImage" ValidationGroup="Submit">تصویر مورد نیاز می باشد</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btSubmit" runat="server" Text="ثبت" OnClick="btSubmit_Click" ValidationGroup="Submit" />
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
                    <a href="GalleryDeleteAdmin.aspx">حذف تصویر</a>
                </td>
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
