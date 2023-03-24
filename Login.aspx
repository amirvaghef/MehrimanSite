<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Administrator_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>انتشارات مهرایمان:: ورود به سیستم::ناشر تخصصی معماری و شهرسازی</title>
    <script src="Scripts/mm.js" type="text/javascript"></script>
</head>
<body onload="MM_preloadImages('../images/nav_about_on.gif','../images/nav_Download_on.png','../images/nav_news_on.gif','../images/nav_home_on.gif', '../images/nav_tarjomeh_on.gif','../images/nav_ImGallery_on.png','../images/nav_Lecture_on.png','../images/nav_Training_on.png','../images/nav_ScienceNew_on.gif')"
    dir="rtl" style="font-family: tahoma; font-size: 12px;">
    <form id="form2" runat="server" dir="rtl">
    <div align="center">
        <table width="1024px" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td colspan="2">
                    <img src="Images/HeaderPageLogin.gif" width="1022px" height="179px" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="background-image: url('Images/HR.gif'); background-repeat: repeat-x;
                    width: 1022px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" height="48" valign="top" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" height="48px">
                        <tr>
                            <td valign="top">
                                <a id="A8" runat="server" href="http://www.mehriman.com/Default.aspx" onmouseout="MM_swapImgRestore()"
                                    onmouseover="MM_swapImage('Image1','','images/nav_home_on.gif',1)">
                                    <img id="imgHome" runat="server" alt="صفحه اصلی" border="0" height="48" name="Image1"
                                        src="Images/nav_home.gif" width="85"></a>
                            </td>
                            <td valign="top">
                                <a id="A6" runat="server" href="../News.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image4','','images/nav_news_on.gif',1)">
                                    <img id="imgNews" runat="server" alt="اخبار" border="0" height="48" name="Image4"
                                        src="Images/nav_news.gif" width="57"></a>
                            </td>
                            <td valign="bottom">
                                <a id="A9" runat="server" href="../ScientificNews.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('imgScience','','images/nav_ScienceNew_on.gif',1)">
                                    <img id="imgScience" runat="server" alt="اخبار علمی" border="0" height="45" name="imgScience" src="Images/nav_ScienceNew.gif"
                                        width="109"></a>
                            </td>
                            <td valign="top">
                                <a id="A5" runat="server" href="../Lecture.aspx" onmouseout="MM_swapImgRestore()"
                                    onmouseover="MM_swapImage('Image8','','images/nav_Lecture_on.png',1)">
                                    <img id="imgLecture" runat="server" alt="همایشات" border="0" height="48" name="Image8"
                                        src="Images/nav_Lecture.png" width="91"></a>
                            </td>
                            <td valign="top">
                                <a id="A4" runat="server" href="../Gallery.aspx" onmouseout="MM_swapImgRestore()"
                                    onmouseover="MM_swapImage('Image5','','images/nav_ImGallery_on.png',1)">
                                    <img id="img1" runat="server" alt="گالری تصاویر" border="0" height="48" name="Image5"
                                        src="Images/nav_ImGallery.png" width="91"></a>
                            </td>
                            <td valign="top">
                                <a id="A3" runat="server" href="../Download.aspx" onmouseout="MM_swapImgRestore()"
                                    onmouseover="MM_swapImage('Image6','','images/nav_Download_on.png',1)">
                                    <img id="img2" runat="server" alt="دانلود" border="0" height="48" name="Image6" src="Images/nav_Download.png"
                                        width="62"></a>
                            </td>
                            <td valign="top">
                                <a id="A2" runat="server" href="../Translation.aspx" onmouseout="MM_swapImgRestore()"
                                    onmouseover="MM_swapImage('imgTranslate','','images/nav_tarjomeh_on.gif',1)">
                                    <img id="imgTranslate" runat="server" alt="ترجمه" border="0" height="48" name="imgTranslate"
                                        src="Images/nav_Tarjomeh.gif" width="70"></a>
                            </td>
                            <td valign="top">
                                <a id="A1" runat="server" href="../Training.aspx" onmouseout="MM_swapImgRestore()"
                                    onmouseover="MM_swapImage('Image7','','images/nav_Training_on.png',1)">
                                    <img id="img3" runat="server" alt="آموزش" border="0" height="48" name="Image7" src="Images/nav_Training.png"
                                        width="67"></a>
                            </td>
                            <td valign="top">
                                <a id="A7" runat="server" href="http://www.mehriman.com/about.aspx" onmouseout="MM_swapImgRestore()"
                                    onmouseover="MM_swapImage('Image2','','images/nav_about_on.gif',1)">
                                    <img id="imgAbout" runat="server" alt="درباره ما" border="0" height="48" name="Image2"
                                        src="Images/nav_about.gif" width="73"></a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="background-image: url('Images/HR.gif'); background-repeat: repeat-x;
                    width: 1022px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" valign="top">
                    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" LoginButtonText="ورود"
                        PasswordLabelText="رمز عبور: " PasswordRequiredErrorMessage="پسورد مورد نیاز می باشد."
                        TitleText="ورود" UserNameLabelText="نام کاربری: " UserNameRequiredErrorMessage="نام کاربری مورد نیاز می باشد."
                        OnLoggedIn="Login1_LoggedIn">
                        <LayoutTemplate>
                            <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                <tr>
                                    <td>
                                        <table cellpadding="0">
                                            <tr>
                                                <td align="center" colspan="2">
                                                    ورود
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">نام کاربری: </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="نام کاربری مورد نیاز می باشد." ToolTip="نام کاربری مورد نیاز می باشد."
                                                        ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">رمز عبور: </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ErrorMessage="پسورد مورد نیاز می باشد." ToolTip="پسورد مورد نیاز می باشد." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="ورود" ValidationGroup="Login1" />
                                                    &nbsp;&nbsp;&nbsp; <a href="http://www.mehriman.com/register.aspx">ثبت نام</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="background-image: url('Images/HR.gif'); background-repeat: repeat-x;
                    width: 1022px;">
                    &nbsp;
                </td>
            </tr>
        </table>
        <div align="center">
            <!-- PersianStat -->
            <!-- URL: http://www.mehriman.com -->
            <script language='javascript' type='text/javascript' src='http://www.persianstat.com/service/stat.js'></script>
            <script language='javascript' type='text/javascript'>
                persianstat(10127791, 0);
            </script>
            <!-- /PersianStat -->
        </div>
    </div>
    </form>
</body>
</html>
