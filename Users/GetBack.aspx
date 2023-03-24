<%@ Page Title="انتشارات مهرایمان:: تأئید پرداخت::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPUsersDefault.master" AutoEventWireup="true" CodeFile="GetBack.aspx.cs"
    Inherits="Users_GetBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="../Images/HeaderPagePayment.gif" width="1022px" height="179px" />
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
            <td colspan="2" align="center">
                <br />
                <b style="color: Red;">شناسه پرداخت بانک: </b>
                <%= refrenceNumber%>
                <br />
                <b style="color: Red;">شناسه پرداخت سایت: </b>
                <%= reservationNumber%>
                <br />
                <asp:Panel ID="printPanel" Direction="RightToLeft" runat="server" Width="500px">
                    <asp:Panel ID="printPanelDakhel" Direction="RightToLeft" runat="server" Width="500px"
                        BorderWidth="2" BorderStyle="Double">
                        <table width="500px" border="0" cellpadding="0" cellspacing="0" style="font-family: Tahoma;">
                            <tr>
                                <td align="center" style="width: 500px; font-size: 10px; font-weight: bold;" colspan="2">
                                    بسمه تعالی
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 500px; font-size: 13px; font-weight: bold;" colspan="2">
                                    <asp:Label ID="LectureName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 500px; font-size: 12px; font-weight: bold;" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 250px">
                                    <b>تاریخ همایش:</b>
                                    <asp:Label ID="LectureDate" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="right" style="width: 250px">
                                    <b>تاریخ ثبت نام:</b>
                                    <asp:Label ID="LectureBuyTime" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 500; font-size: 12px; font-weight: bold;" colspan="2">
                                    <hr style="color: Gray" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 500" colspan="2">
                                    <b>شماره کاربری:</b>
                                    <asp:Label ID="fk_UserID" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 250px">
                                    <b>نام:</b>
                                    <asp:Label ID="fk_Firstname" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="right" style="width: 250px">
                                    <b>نام خانوادگی:</b>
                                    <asp:Label ID="fk_Lastname" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 250px">
                                    <b>وضعیت:</b>
                                    <asp:Label ID="LectureType" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="right" style="width: 250px">
                                    <b>تعداد نفرات:</b>
                                    <asp:Label ID="LectureBuyNumber" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 500px; font-size: 12px; font-weight: bold;" colspan="2">
                                    <hr style="color: Gray" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 500px; font-size: 10px;" colspan="2">
                                    <b>آدرس:</b> تبریز، فلکه دانشگاه، نبش پاساژ نسیم
                                    <br />
                                    <b>تلفن:</b> 0411-3360368
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="imbBack" ImageUrl="~/Images/back.GIF" runat="server" PostBackUrl="~/../Lecture.aspx" />
            </td>
            <td>
                <asp:ImageButton ID="imbPrint" ImageUrl="~/Images/print.GIF" runat="server" Visible="false"
                    OnClick="imbPrint_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
