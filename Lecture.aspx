<%@ Page Title="انتشارات مهرایمان:: بخش همایشات::ناشر تخصصی معماری و شهرسازی" Language="C#"
    MasterPageFile="~/Masters/MPDefault.master" AutoEventWireup="true" CodeFile="Lecture.aspx.cs"
    Inherits="Lecture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="Server">
    <img src="Images/HeaderPageLecture.gif" width="1022px" height="179px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 740px;">
        <tr>
            <td>
                <img src="Images/LectureBigHeader.gif" width="100" height="124" />
                <br />
                <asp:Repeater ID="repLectureList" runat="server">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="713px">
                            <tr dir="rtl" align="right">
                                <td style="background-image: url('images/LectureListBG.gif'); width: 740px; height: 45px;
                                    background-repeat: no-repeat; padding-right: 25px; color: Black; opacity: 0.9;
                                    filter: alpha(opacity=90);">
                                    <a href='LectureDetail.aspx?id=<%# Eval("LectureID")%>'><b>
                                        <%# Eval("LectureName")%>
                                    </b><span style="color: Red; text-decoration: blink;">
                                        <%# (int.Parse(Eval("BuyCount").ToString()) >= int.Parse(Eval("LectureCapacity").ToString()))? "- ظرفیت تکمیل می باشد" : "" %></span>
                                        <span style="color: Red; text-decoration: blink;">
                                            <%# (DateTime.Parse(Eval("LectureTimeOut").ToString()) < DateTime.Today) ? "- مهلت ثبت نام به پایان رسیده است" : "" %></span>
                                        - (<%# Persia.Calendar.ConvertToPersian(DateTime.Parse(Eval("LectureDate").ToString())).Persian%>)
                                    </a>
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
            <td>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllNews"
                    TypeName="LectureNewsCode"></asp:ObjectDataSource>
                <asp:ListView ID="repNews" runat="server" DataSourceID="ObjectDataSource1">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="713px">
                            <tr dir="rtl" align="right">
                                <td style="background-image: url('images/HeaderContent.gif'); width: 713px; height: 51px;
                                    background-repeat: no-repeat; padding-right: 25px; color: Black; opacity: 0.9;
                                    filter: alpha(opacity=90)">
                                    <b><a href='LectureNewsDetail.aspx?Item=<%# Eval("NewsID")%>'>
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
                                    <a href='LectureNewsDetail.aspx?Item=<%# Eval("NewsID")%>'>ادامه مطلب </a>
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
                <asp:DataPager ID="DataPager1" PageSize="10" runat="server" PagedControlID="repNews">
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
