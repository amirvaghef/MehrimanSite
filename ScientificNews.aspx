<%@ Page Title="انتشارات مهرایمان:: بخش اخبار علمی::ناشر تخصصی معماری و شهرسازی"
    Language="C#" MasterPageFile="~/Masters/MPDefault.master" AutoEventWireup="true"
    CodeFile="ScientificNews.aspx.cs" Inherits="ScientificNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="Images/HeaderPageScientific.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="740px">
        <tr>
            <td colspan="2" style="background-image: url('Images/HR.gif'); background-repeat: repeat-x;
                width: 740px;">
                <br />
            </td>
        </tr>
        <tr>
            <td align="right">
                <img src="Images/MatlabBigHeader.jpg" width="100" height="124" />
                <asp:Repeater ID="repFreshNews" runat="server">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="713px">
                            <tr dir="rtl" align="right">
                                <td style="background-image: url('images/HeaderContent.gif'); width: 713px; height: 51px;
                                    background-repeat: no-repeat; padding-right: 25px; color: Black; opacity: 0.9;
                                    filter: alpha(opacity=90)">
                                    <b><a href='ScientificNewsDetail.aspx?Item=<%# Eval("NewsID")%>'>
                                        <%# Eval("NewsTitle")%></a> </b>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="background-image: url('images/MainBGContent.gif'); width: 713px;
                                    height: 263px; background-repeat: no-repeat; padding-right: 15px; padding-left: 15px;
                                    color: Black; opacity: 0.9; filter: alpha(opacity=90)">
                                    <br />
                                    <%# Eval("NewsAbstract")%>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="background-image: url('images/FooterContent.gif'); width: 713px; height: 41px;
                                    background-repeat: no-repeat; padding-right: 30px; color: Black; opacity: 0.9;
                                    filter: alpha(opacity=90)">
                                    <a href='ScientificNewsDetail.aspx?Item=<%# Eval("NewsID")%>'>ادامه مطلب </a>
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
        <tr>
            <td colspan="2" style="background-image: url('Images/HR.gif'); background-repeat: repeat-x;
                width: 740px;">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <a href='News.aspx?arch=yes' title="آرشیو اخبار">آرشیو اخبار</a>
            </td>
        </tr>
    </table>
</asp:Content>
