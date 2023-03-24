<%@ Page Title="انتشارات مهرایمان::ناشر تخصصی معماری و شهرسازی" Language="C#" MasterPageFile="~/Masters/MPDefault.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Scripts/themes/default/default.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme1/nivo-slider.css" rel="Stylesheet" type"text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0"
        width="1024" height="173" title="انتشارات مهرایمان">
        <param name="movie" value="Images/Header.swf" />
        <param name="quality" value="high" />
        <embed src="Images/Header.swf" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash"
            type="application/x-shockwave-flash" width="1024" height="173"></embed>
    </object>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="740px">
        <tr>
            <td colspan="2" align="center">
                <marquee direction="left" behavior="scroll" onmouseout="this.start()" onmouseover="this.stop()"
                    scrollamount="2" scrolldelay="20" width="740px">
                    <asp:DataList ID="repTopImages" RepeatDirection="Horizontal" runat="server">
                        <ItemTemplate>
                            <a href='<%# Eval("ImageLink") %>' title='<%# Eval("ImageName")%>'>
                                <img src='<%= System.Configuration.ConfigurationManager.AppSettings["CategoryThumbnailPath"] %><%# Eval("ImageAddress") %>'
                                    alt='<%# Eval("ImageName") %>' height="150px">
                            </a>
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
            <td style="width: 370px; height" align="center" valign="top">
                <div class="slider-wrapper theme-default">
                    <div class="ribbon">
                    </div>
                    <div id="slider" class="nivoSlider" style="width: 370px; height: 500px;">
                        <asp:Repeater ID="repNivo" runat="server">
                            <ItemTemplate>
                                <a href='<%# Eval("ImageLink") %>' title='<%# Eval("ImageName")%>' style="width: 370px;
                                    text-align: center;">
                                    <img src='<%= System.Configuration.ConfigurationManager.AppSettings["CategoryThumbnailPath"] %><%# Eval("ImageAddress") %>'
                                        alt='<%# Eval("ImageName") %>'>
                                </a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </td>
            <td style="width: 370px;" align="right" valign="top">
                <img src="Images/NewsBigHeader.gif" width="134px" height="79px" />
                <br />
                <asp:Repeater ID="repFirstPageNews" runat="server">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="370px">
                            <tr>
                                <td valign="top" style="width: 370px; padding-right: 10px; padding-left: 10px;">
                                    <b><a href='NewsDetail.aspx?Item=<%# Eval("NewsID")%>'>
                                        <%# Eval("NewsTitle")%></a> </b>
                                    <br />
                                    <%# Eval("NewsAbstract")%>
                                    <a href='NewsDetail.aspx?Item=<%# Eval("NewsID")%>'>ادامه مطلب... </a>
                                    <br />
                                    <hr />
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
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <marquee direction="left" behavior="scroll" onmouseout="this.start()" onmouseover="this.stop()"
                    scrollamount="2" scrolldelay="20" width="740px">
                    <asp:DataList ID="repBottomImages" RepeatDirection="Horizontal" runat="server">
                        <ItemTemplate>
                            <a href='<%# Eval("ImageLink") %>' title='<%# Eval("ImageName")%>'>
                                <img src='<%= System.Configuration.ConfigurationManager.AppSettings["CategoryThumbnailPath"] %><%# Eval("ImageAddress") %>'
                                    alt='<%# Eval("ImageName") %>' height="100px" >
                            </a>
                        </ItemTemplate>
                    </asp:DataList>
                </marquee>
            </td>
        </tr>
    </table>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.nivo.slider.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>
</asp:Content>
