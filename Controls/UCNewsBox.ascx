<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCNewsBox.ascx.cs" Inherits="Controls_UCNewsBox" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="background-image: url('../Images/NewsHeader.gif'); width: 251px; height: 76px;">
        </td>
    </tr>
    <tr align="center">
        <td style="background-image: url('../Images/Menu_bg.gif'); background-repeat: repeat-y;
            width: 251px; height: 4px;" align="center">
            <marquee direction="up" behavior="scroll" onmouseout="this.start()" onmouseover="this.stop()"
                scrollamount="2" scrolldelay="20" width="251px">
            <asp:Repeater ID="repFirstPageNews" runat="server">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="251px">
                        <tr>
                            <td valign="top" style="width: 231px; padding-right: 10px; padding-left: 10px;">
                                <br />
                                <a href='../NewsDetail.aspx?Item=<%# Eval("NewsID")%>'>
                                    <%# Eval("NewsTitle")%>
                                </a>
                                <br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
            </marquee>
        </td>
    </tr>
    <tr>
        <td style="background-image: url('../Images/Menu_bot.gif'); width: 251px; height: 27px;">
        </td>
    </tr>
</table>
