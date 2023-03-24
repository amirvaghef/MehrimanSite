<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LectureReportAdmin.aspx.cs" Inherits="Administrator_LectureReportAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>انتشارات مهرایمان:: مدیریت همایشات</title>
</head>
<body style="font-family: tahoma; font-size: 12px;">
    <form id="form1" runat="server" dir="rtl">
    <div>
        <table align="center" width="1027" border="1" cellpadding="0" cellspacing="0">
            <tr style="height: 246px; width: 1027px; background-image: url('../images/HeaderBGLectures.jpg');">
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
                            <td style="background-image: url('../Images/HeaderRightLecture.gif'); width: 295px;
                                height: 246px;">
                            </td>
                            <td style="background-image: url('../Images/HeaderLeftLecture.gif'); width: 732px;
                                height: 246px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="1027" border="0" cellpadding="0" cellspacing="0" style="background-image: url('../Images/MainBGLecture.jpg'); width: 1027px;
                                height: 700px;">
                                <tr>
                                    <td>
                                        نام همایش: 
                                        <asp:DropDownList ID="drplectures" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="drplectures_SelectedIndexChanged" SkinID="a" 
                                            Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                        <tr>
                            <td valign="top" >
                                <asp:GridView ID="gwLectures" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                                    BorderWidth="1px" CellPadding="2" EnableModelValidation="True" ForeColor="Black"
                                    GridLines="None" PageSize="15" 
                                    OnPageIndexChanging="gwLectures_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <asp:BoundField DataField="LectureRefrenceID" HeaderText="شماره پیگیری" />
                                        <asp:BoundField DataField="fk_Username" HeaderText="نام کاربری" />
                                        <asp:BoundField DataField="fk_Firstname" HeaderText="نام" />
                                        <asp:BoundField DataField="fk_Lastname" HeaderText="نام خانوادگی" />
                                        <asp:BoundField DataField="fk_EmailAddress" HeaderText="ایمیل" 
                                            Visible="False" />
                                        <asp:BoundField DataField="fk_Tel" HeaderText="تلفن ثابت" Visible="False" />
                                        <asp:BoundField DataField="fk_MobileAlias" HeaderText="تلفن همراه" />
                                        <asp:BoundField DataField="LectureType" HeaderText="رده" />
                                        <asp:BoundField DataField="LectureBuyNumber" HeaderText="تعداد ثبت نام" />
                                        <asp:BoundField DataField="LectureBuyTime" HeaderText="زمان ثبت نام" />
                                        <asp:BoundField DataField="LectureBuyPrice" HeaderText="قیمت" />
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
