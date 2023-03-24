<%@ Page Title="انتشارات مهرایمان:: بخش گالری تصاویر::ناشر تخصصی معماری و شهرسازی"
    Language="C#" MasterPageFile="~/Masters/MPDefault.master" AutoEventWireup="true"
    CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="Images/HeaderPageGallery.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="740px">
        <tr>
            <td>
                <img src="Images/GalleryBigHeader.gif" width="100" height="124" />
                <asp:DataList ID="repCategory" RepeatDirection="Vertical" runat="server" RepeatColumns="4"
                    BorderWidth="1" BorderStyle="Dashed" CellSpacing="10" CellPadding="15" GridLines="Both"
                    RepeatLayout="Table">
                    <ItemTemplate>
                        <div style="text-align: center;">
                            <a href='GalleryDetail.aspx?cat=<%# Eval("ImageProfileID") %>'>
                                <img src='<%= System.Configuration.ConfigurationManager.AppSettings["ImageThumbnailPath"] %><%# Eval("ImageSource") %>'
                                    title='<%# Eval("ImageProfileComment") %>' alt='<%# Eval("ImageProfileComment") %>'
                                    height="80px">
                                <br />
                                <div align="center">
                                    <%# Eval("ImageProfileName") %>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>
