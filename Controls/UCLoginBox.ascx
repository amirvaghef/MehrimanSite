<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCLoginBox.ascx.cs" Inherits="Controls_UCLoginBox" %>
<table border="0" cellpadding="0" cellspacing="0" width="251px">
    <tr>
        <td style="background-image: url('../Images/LoginHeader.gif'); width: 251px; height: 46px;">
        </td>
    </tr>
    <tr align="center">
        <td style="background-image: url('../Images/Menu_bg.gif'); background-repeat: repeat-y;
            width: 221px; height: 4px;">
            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" LoginButtonText="ورود"
                        LoginButtonType="Link" PasswordLabelText="رمز عبور :" PasswordRequiredErrorMessage="رمز عبور مورد نیاز است."
                        TitleText="" UserNameLabelText="نام کاربری :" UserNameRequiredErrorMessage="نام کاربری مورد نیاز است."
                        FailureText="نام کاربری و یا رمز عبور اشتباه می باشد." VisibleWhenLoggedIn="False">
                        <LayoutTemplate>
                            <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                <tr>
                                    <td>
                                        <table cellpadding="0">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" ForeColor="Black">نام کاربری :</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server" SkinID="Login"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="نام کاربری مورد نیاز است." ToolTip="نام کاربری مورد نیاز است."
                                                        ValidationGroup="Login1" ForeColor="Black">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" ForeColor="Black">رمز عبور :</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" SkinID="Login"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ErrorMessage="رمز عبور مورد نیاز است." ToolTip="رمز عبور مورد نیاز است." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding-right: 10px;">
                                                    <asp:LinkButton ID="LoginLinkButton" runat="server" CommandName="Login" ValidationGroup="Login1">ورود</asp:LinkButton>
                                                    &nbsp; &nbsp; <a href="http://www.mehriman.com/register.aspx">ثبت نام</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="color: Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="251px">
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
                </LoggedInTemplate>
            </asp:LoginView>
        </td>
    </tr>
    <tr>
        <td style="background-image: url('../Images/Menu_bot.gif'); width: 251px; height: 27px;">
        </td>
    </tr>
</table>
