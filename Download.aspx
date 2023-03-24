<%@ Page Title="انتشارات مهرایمان:: بخش دانلود::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPDefault.master" AutoEventWireup="true" CodeFile="Download.aspx.cs"
    Inherits="Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="Images/HeaderPageDownload.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="740px">
        <tr>
            <td>
                <marquee direction="right" behavior="scroll" onmouseout="this.start()" onmouseover="this.stop()"
                    scrollamount="2" scrolldelay="20" width="740px">
                <asp:DataList ID="repDownloadsCategory" RepeatDirection="Horizontal" runat="server"
                            BorderWidth="1" BorderStyle="Dashed" CellSpacing="5" CellPadding="5" 
                            GridLines="Both">
                    <ItemTemplate>
                        <div style="text-align:center;">
                        <a href='../Download.aspx?cat=<%# Eval("DownloadProfileID") %>' style="border-style:none;">
                            <img src='../<%= System.Configuration.ConfigurationManager.AppSettings["CategoryThumbnailPath"] %><%# Eval("DownloadProfileSource") %>'
                                title='<%# Eval("DownloadProfileComment") %>' alt='<%# Eval("DownloadProfileComment") %>' width="100px">
                            <br />
                            <div align="center">
                                <%# Eval("DownloadProfileName")%>
                            </div>
                            <br />
                        </a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                </marquee>
            </td>
        </tr>
        <tr>
            <td>
                <img src="Images/DownloadBigHeader.gif" width="100" height="124" />
                <br />
                <asp:Repeater ID="repDownloadGallery" runat="server">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="713px">
                            <tr dir="rtl" align="right">
                                <td style="background-image: url('images/HeaderContent.gif'); width: 713px; height: 51px;
                                    background-repeat: no-repeat; padding-right: 25px; color: Black; opacity: 0.9;
                                    filter: alpha(opacity=90)">
                                    <b>
                                        <%# Eval("DownloadName")%></b>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="background-image: url('images/MainBGContent.gif'); width: 713px;
                                    height: 263px; background-repeat: no-repeat; padding-right: 15px; padding-left: 15px;
                                    color: Black; opacity: 0.9; filter: alpha(opacity=90)">
                                    <br />
                                    <%# Eval("DownloadComment") %>
                                    <br />
                                    <br />
                                    <b>حجم (در صورت لینک مستقیم) :</b>
                                    <%# Eval("DownloadSize")%>
                                    بایت
                                    <br />
                                    <b>کلمات کلیدی:</b>
                                    <%# Eval("Tags") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-image: url('images/FooterContent.gif'); width: 713px; height: 41px;
                                    background-repeat: no-repeat; padding-right: 30px; color: Black; opacity: 0.9;
                                    filter: alpha(opacity=90)">
                                    <%--<a href='<%= System.Configuration.ConfigurationManager.AppSettings["FilePath"] %><%# Eval("DownloadSource") %>'>--%>
                                    <a href='Users/Downloading.aspx?DwnId=<%# Eval("DownloadID") %>' target="_blank">دانلود
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
