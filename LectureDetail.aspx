<%@ Page Title="انتشارات مهرایمان::جزئیات همایش::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPDefault.master" AutoEventWireup="true" CodeFile="LectureDetail.aspx.cs"
    Inherits="LectureDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function reset() {
            document.getElementById("<%# txtName.ClientID %>").value = '';
            document.getElementById("<%# txtEmail.ClientID %>").value = '';
            document.getElementById("<%# txtSubject.ClientID %>").value = '';
            document.getElementById("<%# txtComment.ClientID %>").value = '';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="Images/HeaderPageLecture.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="740px">
        <tr>
            <td>
                <img src="Images/LectureBigHeader.gif" width="100" height="124" />
                <br />
                <asp:Repeater ID="repLecture" runat="server">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="740px">
                            <tr dir="rtl" align="right">
                                <td valign="top" style="background-image: url('images/HeaderContentNews.gif'); width: 740px;
                                    height: 96px; background-repeat: no-repeat; padding-right: 25px; color: Black;
                                    opacity: 0.95; filter: alpha(opacity=95)">
                                    <br />
                                    <b>
                                        <%# Page.Title = Eval("LectureName").ToString()%>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="background-color: White; width: 740px; background-repeat: no-repeat;
                                    padding-right: 15px; padding-left: 15px; color: Black; opacity: 0.95; filter: alpha(opacity=95)">
                                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="730px">
                                        <br />
                                        <%# Eval("LectureComment")%>
                                        <br />
                                        <b style="color: Red;">تاریخ همایش: </b>
                                        <%# Persia.Calendar.ConvertToPersian(DateTime.Parse(Eval("LectureDate").ToString())).Persian%>
                                        <br />
                                        <b style="color: Red;">مبلغ همایش: </b>
                                        <%# Eval("LecturePrice", "{0:#,###,###,###}")%>
                                        ریال
                                        <br />
                                        <b style="color: Red;">ظرفیت همایش: </b>
                                        <%# Eval("LectureCapacity")%>
                                        نفر
                                        <br />
                                        <b style="color: Red;">آخرین مهلت ثبت نام: </b>
                                        <%# Persia.Calendar.ConvertToPersian(DateTime.Parse(Eval("LectureTimeOut").ToString())).Persian%>
                                        <br />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr dir="rtl" align="center" valign="bottom">
                                <td valign="bottom" style="background-image: url('images/FooterContentLecture.gif');
                                    width: 740px; height: 96px; background-repeat: no-repeat; opacity: 0.95; filter: alpha(opacity=95)">
                                    <asp:ImageButton ID="imbRegister" ImageUrl="~/Images/Register.GIF" runat="server"
                                        PostBackUrl="../Users/LectureDiscount.aspx" />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>
                <br />
                <h3>
                    کلمات کلیدی:</h3>
                <asp:Repeater ID="repTags" runat="server">
                    <ItemTemplate>
                        <a href='Search.aspx?Tag=<%# Eval("Tags")%>'>
                            <%# Eval("Tags") %>
                        </a>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        &nbsp; , &nbsp;
                    </SeparatorTemplate>
                </asp:Repeater>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="background-image: url('Images/HR.gif'); background-repeat: repeat-x; width: 740px;">
                <br />
            </td>
        </tr>
        <tr>
            <td align="right">
                <table border="0" cellpadding="0" cellspacing="0" width="740px">
                    <tr>
                        <td style="width: 100px;">
                        </td>
                        <td align="right" style="width: 640px;">
                            <h3>
                                ارسال نظر:</h3>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            نام:
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtName" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            ایمیل:<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ErrorMessage="لطفاً ایمیل را بطور صحیح وارد نمائید" ControlToValidate="txtEmail"
                                SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic" ValidationGroup="Comments" ForeColor="Red">*</asp:RegularExpressionValidator>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtEmail" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            موضوع:
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtSubject" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            نظر:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاٌ نظر خود را وارد نمائید"
                                ControlToValidate="txtComment" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Comments"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtComment" SkinID="Multi" TextMode="MultiLine" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="BTSubmitComment" runat="server" Text="ارسال نظر" Width="150px" OnClick="BTSubmitComment_Click"
                                ValidationGroup="Comments" />
                            &nbsp; &nbsp; &nbsp; &nbsp;
                            <input id="BTReset" type="button" value="صرف نظر" style="width: 150px" onclick="reset()" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Repeater ID="repComments" runat="server" OnItemCommand="repComments_ItemCommand">
                                <HeaderTemplate>
                                    <h3>
                                        نظرات بینندگان:
                                    </h3>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="740px">
                                        <tr dir="rtl" align="right">
                                            <td valign="top" style="background-image: url('images/HeaderContentNews.gif'); width: 740px;
                                                height: 56px; background-repeat: no-repeat; padding-right: 25px; color: Black;
                                                opacity: 0.95; filter: alpha(opacity=95)">
                                                <br />
                                                <b><span><a href='mailto:<%# Eval("Email").ToString()%>'>
                                                    <%# Eval("Name").ToString()%>
                                                    -
                                                    <%# Eval("Subject").ToString()%>
                                                </a></span><span style="float: left; padding-left: 70px;">
                                                    <label dir="rtl">
                                                        <%# Persia.Calendar.ConvertToPersian(DateTime.Parse(Eval("CommentDate").ToString())).Persian %>
                                                    </label>
                                                </span></b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right" style="background-color: White; width: 740px; background-repeat: no-repeat;
                                                padding-right: 15px; padding-left: 15px; color: Black; opacity: 0.95; filter: alpha(opacity=95)">
                                                <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="740px">
                                                    <br />
                                                    <%# Eval("Comment")%>
                                                    <br />
                                                    <br />
                                                    <br />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    <br />
                                </SeparatorTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
