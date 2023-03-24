<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommentAdmin.aspx.cs" Inherits="Administrator_CommentAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>انتشارات مهرایمان:: کنترل پنل</title>
</head>
<body style="font-family: tahoma; font-size: 12px;">
    <form id="form1" runat="server" dir="rtl">
    <div>
        <table align="center" width="1027" border="1" cellpadding="0" cellspacing="0">
            <tr style="height: 246px; width: 1027px; background-image: url('../images/HeaderBGEnter.jpg');">
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
                <td align="right">
                    <table width="1027" border="0" cellpadding="20" cellspacing="0" style="background-image: url('../Images/MainBGAdmin.gif'); background-repeat: repeat;">
                        <tr align="right">
                            <td align="right" colspan="2">
                                <span style="color:White"> بخش: </span>
                                <asp:DropDownList ID="drpSection" runat="server" AutoPostBack="True" 
                                    DataTextField="PageTitle" DataValueField="ID" 
                                    onselectedindexchanged="drpSection_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td align="right" colspan="2">
                                <span style="color:White"> جزء: </span>
                                <asp:DropDownList ID="drpItem" runat="server" AutoPostBack="True" 
                                    DataTextField="Title" DataValueField="ID" 
                                    onselectedindexchanged="drpItem_SelectedIndexChanged" TabIndex="1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td colspan="2">
                                <asp:GridView ID="grdComments" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" AutoGenerateDeleteButton="True" 
                                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                    CellPadding="2" EnableModelValidation="True" 
                                    ForeColor="Black" GridLines="None" onrowdeleting="grdComments_RowDeleting"
                                     PageSize="15" onpageindexchanging="grdComments_PageIndexChanging" Width="100%">
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <asp:BoundField DataField="CommentsID" HeaderText="شناسه" ReadOnly="True"/>
                                        <asp:BoundField DataField="Name" HeaderText="نام" ReadOnly="True" 
                                            SortExpression="Name" />
                                        <asp:BoundField DataField="Subject" HeaderText="موضوع" ReadOnly="True" 
                                            SortExpression="Subject" />
                                        <asp:BoundField DataField="Email" HeaderText="ایمیل" ReadOnly="True" 
                                            SortExpression="Email" />
                                        <asp:BoundField DataField="Comment" HeaderText="نظر" ReadOnly="True" 
                                            SortExpression="Comment" />
                                        <asp:BoundField DataField="CommentDate" HeaderText="تاریخ" ReadOnly="True" 
                                            SortExpression="CommentDate" />
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                        HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 1027px; height: 25px; background-color: White;">
                    <a href="CommentSubmitAdmin.aspx">تأئید کامنت ها</a>
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
