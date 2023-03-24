<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCDownloadBox.ascx.cs"
    Inherits="Controls_UCDownloadBox" %>
<table border="0" cellpadding="0" cellspacing="0" width="251px">
    <tr>
        <td style="background-image: url('../Images/DownloadHeader.gif'); width: 251px; height: 76px;">
        </td>
    </tr>
    <tr>
        <td style="background-image: url('../Images/Menu_bg.gif'); background-repeat: repeat-y;
            width: 221px; height: 4px;">
            <marquee direction="up" behavior="scroll" onmouseout="this.start()" onmouseover="this.stop()"
                scrollamount="2" scrolldelay="20" width="251px" style="text-align: center;">
                <asp:DataList ID="repCategory" RepeatDirection="Vertical" runat="server">
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
        <td style="background-image: url('../Images/Menu_bot.gif'); width: 251px; height: 27px;">
        </td>
    </tr>
</table>
