<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainingReportAdmin.aspx.cs"
    Inherits="Administrator_TrainingReportAdmin" %>

<%@ Register Assembly="MagicAjax" Namespace="MagicAjax.UI.Controls" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <title>انتشارات مهرایمان:: مدیریت آموزش</title>
</head>
<body style="font-family: tahoma; font-size: 12px;">
    <form id="form1" runat="server" dir="rtl">
    <div>
        <table align="center" width="1027" border="1" cellpadding="0" cellspacing="0">
            <tr style="height: 246px; width: 1027px; background-image: url('../images/HeaderBGTraining.jpg');">
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
                            <td style="background-image: url('../Images/HeaderRightTraining.gif'); width: 295px;
                                height: 246px;">
                            </td>
                            <td style="background-image: url('../Images/HeaderLeftTraining.gif'); width: 732px;
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
                            <td valign="top" style="background-image: url('../Images/MainBGTraining.jpg'); width: 1027px;
                                height: 700px;">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="2">
                                            <ajax:AjaxPanel ID="AjaxPanel5" runat="server">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top">
                                                            درجه:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpDegree" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDegree_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            رشته:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpCourse_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            دروس:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpLesson" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpLesson_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            دوره:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpPart" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPart_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="right" colspan="2">
                                                            <asp:GridView ID="gwLesson" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                                                EnableModelValidation="True" ForeColor="Black" GridLines="None" PageSize="15"
                                                                OnPageIndexChanging="gwLectures_PageIndexChanging">
                                                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Username" HeaderText="نام کاربری" />
                                                                    <asp:BoundField DataField="FirstName" HeaderText="نام" />
                                                                    <asp:BoundField DataField="LastName" HeaderText="نام خانوادگی" />
                                                                    <asp:BoundField DataField="EmailAddress" HeaderText="ایمیل" />
                                                                    <asp:BoundField DataField="Tel" HeaderText="تلفن ثابت" />
                                                                    <asp:BoundField DataField="MobileAlias" HeaderText="تلفن همراه" />
                                                                    <asp:BoundField DataField="Address" HeaderText="آدرس" />
                                                                </Columns>
                                                                <FooterStyle BackColor="Tan" />
                                                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                                <EmptyDataTemplate>
                                                                    هیچ همایش بدون ثبت نامی برای حذف موجود نمی باشد
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ajax:AjaxPanel>
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
