<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCLecture.ascx.cs" Inherits="Controls_UCLecture" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="background-image: url('../Images/LectureHeader.gif'); width: 251px; height: 69px;">
        </td>
    </tr>
    <tr>
        <td style="background-image: url('../Images/Menu_bg.gif'); background-repeat: repeat-y;
            width: 221px; height: 4px;">
            <asp:Repeater ID="repLectureList" runat="server">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="251px">
                        <tr dir="rtl" align="right">
                            <td style="width: 251px; height: 45px; padding-right: 25px;">
                                <a href='../LectureDetail.aspx?id=<%# Eval("LectureID")%>'><b>
                                    <%# Eval("LectureName")%>
                                </b></a>
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
        <td style="background-image: url('../Images/Menu_bot.gif'); width: 251px; height: 27px;">
        </td>
    </tr>
</table>
