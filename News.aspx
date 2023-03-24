<%@ Page Title="انتشارات مهرایمان:: بخش اخبار::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPDefault.master" AutoEventWireup="true" CodeFile="News.aspx.cs"
    Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="Images/HeaderPageNews.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="740px">
        <tr>
            <td colspan="2" style="width: 740px;" align="center">
                <marquee direction="right" behavior="scroll" onmouseout="this.start()" onmouseover="this.stop()"
                    scrollamount="2" scrolldelay="20" width="740px">
                <asp:DataList ID="repNewsCategory" RepeatDirection="Horizontal" runat="server"
                            BorderWidth="1" BorderStyle="Dashed" CellSpacing="5" CellPadding="5" 
                            GridLines="Both">
                    <ItemTemplate>
                        <div style="text-align:center;">
                        <a href='News.aspx?cat=<%# Eval("NewsCategoryID") %>' title='<%# Eval("NewsCategoryName")%>'>
                            <img src='<%= System.Configuration.ConfigurationManager.AppSettings["CategoryThumbnailPath"] %><%# Eval("NewsCategorySource") %>'
                                alt='<%# Eval("NewsCategoryName") %>' height="80px">
                            <br />
                            <div align="center">
                                <%# Eval("NewsCategoryName")%>
                            </div>
                        </a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                </marquee>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-image: url('Images/HR.gif'); background-repeat: repeat-x;
                width: 740px;">
                <br />
            </td>
        </tr>
        <tr>
            <td align="right">
                <img src="Images/News1BigHeader.gif" width="100" height="124" />
                <asp:Repeater ID="repFreshNews" runat="server">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="713px">
                            <tr dir="rtl" align="right">
                                <td style="background-image: url('images/HeaderContent.gif'); width: 713px; height: 51px;
                                    background-repeat: no-repeat; padding-right: 25px; color: Black; opacity: 0.9;
                                    filter: alpha(opacity=90)">
                                    <b><a href='NewsDetail.aspx?Item=<%# Eval("NewsID")%>'>
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
                                    <a href='NewsDetail.aspx?Item=<%# Eval("NewsID")%>'>ادامه مطلب </a>
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
                <a href='News.aspx?arch=<%= Request.QueryString["cat"] == null ? 1 : int.Parse(Request.QueryString["cat"]) %>'
                    title="آرشیو اخبار">آرشیو اخبار</a>
            </td>
        </tr>
    </table>
</asp:Content>
