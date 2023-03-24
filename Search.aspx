<%@ Page Title="انتشارات مهرایمان:: بخش جستجو::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPDefault.master" AutoEventWireup="true" CodeFile="Search.aspx.cs"
    Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="Images/HeaderPageSearch.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="740px">
        <tr>
            <td>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSearchList"
                    TypeName="TagsCode">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="&quot;&quot;" Name="tag" QueryStringField="Tag"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ListView ID="repTags" runat="server" DataSourceID="ObjectDataSource1">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="713px">
                            <tr dir="rtl" align="right">
                                <td style="padding-right: 25px; color: Black;">
                                    <a href='<%# Eval("Address")%>' target="_blank">
                                        <h3>
                                            <%# Eval("Title")%>
                                        </h3>
                                    </a>
                                </td>
                            </tr>
                            <tr dir="rtl" align="right">
                                <td style="padding-right: 25px; color: Black;">
                                    <%#  Eval("Text").ToString().Length < 100 ? Eval("Text").ToString(): Eval("Text").ToString().Substring(0,100)%>
                                </td>
                            </tr>
                            <tr dir="rtl" align="right">
                                <td style="padding-right: 25px; color: Black;">
                                    <a href='<%# Eval("Address")%>' target="_blank">http://main.mehriman.com/<%# Eval("Address")%></a>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemSeparatorTemplate>
                        <br />
                        <hr />
                    </ItemSeparatorTemplate>
                </asp:ListView>
                <br />
                <hr />
                <br />
                <asp:DataPager ID="DataPager1" PageSize="15" runat="server" PagedControlID="repTags">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True" ShowNextPageButton="False"
                            ShowPreviousPageButton="True" FirstPageText="<<" LastPageText=">>" NextPageText=">"
                            PreviousPageText="<" RenderDisabledButtonsAsLabels="false" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ShowNextPageButton="True"
                            ShowPreviousPageButton="False" RenderDisabledButtonsAsLabels="false" NextPageText=">"
                            LastPageText=">>" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
    </table>
</asp:Content>
