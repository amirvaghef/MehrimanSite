<%@ Page Title="انتشارات مهرایمان:: بخش آموزش::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPWithoutLeft.master" AutoEventWireup="true" CodeFile="Training.aspx.cs"
    Inherits="Training" %>

<%@ Register src="Controls/UCLoginBox.ascx" tagname="UCLoginBox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="Images/HeaderPageTraining.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Right" runat="Server">
    <table cellpadding="0" cellspacing="0" border="0" width="251px">
        <tr>
            <td>
                <uc2:UCLoginBox ID="UCLoginBox1" runat="server" />
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" style="width: 242px; height: 789px;">
                <asp:Panel ID="plTree" ScrollBars="Auto" runat="server" Width="240px" Height="780px"
                    BorderWidth="2px" BorderStyle="Groove" Style="opacity: 0.7; filter: alpha(opacity=70);
                    background-color: White; text-align: right; color: Black; padding-right: 5px;
                    padding-top: 10px;">
                    <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                    </asp:TreeView>
                </asp:Panel>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Left" runat="Server">
    <asp:Panel ID="plContent" ScrollBars="Auto" runat="server" Width="740px" Height="780px"
        BorderWidth="2px" BorderStyle="Groove" Style="opacity: 0.7; filter: alpha(opacity=70);
        background-color: White; text-align: right; color: Black; padding-right: 5px;
        padding-top: 10px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="right">
                    <asp:Label ID="lbContent" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:ImageButton ID="imbtnSubmit" runat="server" Visible="false" ImageUrl="~/Images/Reserve.gif"
                        OnClick="imbtnSubmit_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
