<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TranslationAdmin.aspx.cs"
    Inherits="Administrator_TranslationAdmin" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <title>انتشارات مهرایمان:: درخواست قیمت</title>
</head>
<body style="font-family: tahoma; font-size: 12px;">
    <form id="form1" runat="server" dir="rtl">
    <div>
        <table align="center" width="1027" border="1" cellpadding="0" cellspacing="0">
            <tr style="height: 246px; width: 1027px; background-image: url('../images/HeaderBGTranslation.jpg');">
                <td align="right">
                    <div style="top: 230px; padding-left:370px; position: absolute;">
                        <a href="ImageFirstPageAdmin.aspx" style="padding-left: 40px;">صفحه اصلی</a> <a href="NewsAdmin.aspx"
                            style="padding-left: 40px;">اخبار</a> <a href="LectureAdmin.aspx" style="padding-left: 40px;">
                                همایشات</a> <a href="GalleryAdmin.aspx" style="padding-left: 40px;">گالری تصاویر</a>
                        <a href="DownloadAdmin.aspx" style="padding-left: 40px;">دانلود</a> <a href="TranslationAdmin.aspx"
                            style="padding-left: 40px;">ترجمه</a> <a href="TrainingAdmin.aspx" style="padding-left: 40px;">
                                آموزش</a><a href="CommentAdmin.aspx" style="padding-left: 40px;">
                                کامنت ها</a>
                                <a href="ScientificNewsAdmin.aspx" style="padding-left: 40px;">اخبار علمی</a>
                    </div>
                    <div style="top: 45px; padding-left: 730px; position: absolute;">
                        <table border="0" cellpadding="0" cellspacing="0" width="280px">
                            <tr align="center">
                                <td align="right" style="width: 70px">
                                    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="خروج" />
                                </td>
                                <td align="right" style="color: Black;">
                                    <asp:LoginName ID="LoginName1" runat="server" />
                                    ، خوش آمدید
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                </td>
                                <td align="right">
                                    <br />
                                    <a href="http://www.mehriman.com/UserInfo.aspx">ویرایش اطلاعات کاربری</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table width="1027" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-image: url('../Images/HeaderRightTranslation.gif'); width: 295px;
                                height: 246px;">
                            </td>
                            <td style="background-image: url('../Images/HeaderLeftTranslation.gif'); width: 732px;
                                height: 246px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="1027" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" style="background-image: url('../Images/MainBGTranslation.jpg');
                                width: 1027px; height: 700px;">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            افرادی که ترجمه می خواهند:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" AutoGenerateSelectButton="True" BackColor="LightGoldenrodYellow"
                                                BorderColor="Tan" BorderWidth="1px" CellPadding="2" EnableModelValidation="True"
                                                EnableTheming="True" ForeColor="Black" GridLines="None" DataKeyNames="TranslationID"
                                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                                                onpageindexchanging="GridView1_PageIndexChanging">
                                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                <Columns>
                                                    <asp:BoundField DataField="TranslationID" HeaderText="TranslationID" Visible="False" />
                                                    <asp:BoundField DataField="Firstname" HeaderText="نام" />
                                                    <asp:BoundField DataField="Lastname" HeaderText="نام خانوادگی" />
                                                    <asp:BoundField DataField="EmailAddress" HeaderText="ایمیل" />
                                                    <asp:BoundField DataField="Tel" HeaderText="تلفن ثابت" />
                                                    <asp:BoundField DataField="MobileAlias" HeaderText="تلفن همراه" />
                                                </Columns>
                                                <FooterStyle BackColor="Tan" />
                                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="right">
                                            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="100%" AutoGenerateRows="False"
                                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                                EnableModelValidation="True" ForeColor="Black" GridLines="None">
                                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                <EditRowStyle BackColor="PaleGoldenrod"/>
                                                <Fields>
                                                    <asp:TemplateField HeaderText="شماره" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="TranslationID" runat="server" Text='<%# Bind("TranslationID") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="نام کاربری:">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Username" runat="server" Text='<%# Bind("Username") %>' Width="850px"></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="نام:">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Firstname" runat="server" Text='<%# Bind("Firstname") %>' CssClass="Normal"></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="نام خانوادگی:">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Lastname" runat="server" Text='<%# Bind("Lastname") %>' CssClass="Normal"></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ایمیل:">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="EmailAddress" runat="server" Text='<%# Bind("EmailAddress") %>' CssClass="Normal"></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تلفن ثابت:">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Tel" runat="server" Text='<%# Bind("Tel") %>' CssClass="Normal"></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تلفن همراه:">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="MobileAlias" runat="server" Text='<%# Bind("MobileAlias") %>' CssClass="Normal"></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="توضیحات فرستنده:">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="TranslationComment" runat="server" Text='<%# Bind("TranslationComment") %>'
                                                                CssClass="Normal"></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="فایل ترجمه:">
                                                        <EditItemTemplate>
                                                            <a href='../<%= System.Configuration.ConfigurationManager.AppSettings["TranslationFilePath"] %><%# Eval("TranslationSource")%>'
                                                                target="_blank">دانلود</a>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="قیمت:">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtEditTranslationPrice" runat="server" Text='<%# Bind("TranslationPrice") %>' />
                                                            ریال
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEditTranslationPrice"
                                                                runat="server" ErrorMessage="*">*</asp:RequiredFieldValidator>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="مدت زمان تحویل:">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtEditTranslationDeliveryDay" runat="server" Text='<%# Bind("TranslationDeliveryDay") %>'
                                                                MaxLength="3" />
                                                            روز
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEditTranslationDeliveryDay"
                                                                runat="server" ErrorMessage="*">*</asp:RequiredFieldValidator>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                </Fields>
                                                <FooterStyle BackColor="Tan" />
                                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                            </asp:DetailsView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="PanelComment" runat="server" Visible="false" BackColor="PaleGoldenrod" ForeColor="Black">
                                                توضیحات اضافی:
                                                <textarea cols="80" id="editor1" name="editor1" rows="10" runat="server" dir="rtl"></textarea>
                                                <script type="text/javascript">

			//<![CDATA[

                                                    // This call can be placed at any point after the
                                                    // <textarea>, or inside a <head><script> in a
                                                    // window.onload event handler.

                                                    // Replace the <textarea id="editor"> with an CKEditor
                                                    // instance, using default configurations.
                                                    CKEDITOR.replace('editor1',
 {
     filebrowserBrowseUrl: '../ckfinder/ckfinder.html',
     filebrowserImageBrowseUrl: '../ckfinder/ckfinder.html?type=Images',
     filebrowserFlashBrowseUrl: '../ckfinder/ckfinder.html?type=Flash',
     filebrowserUploadUrl: '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
     filebrowserImageUploadUrl: '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
     filebrowserFlashUploadUrl: '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
 }
 );
			//]]>
                                                </script>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btSubmit" runat="server" Text="ثبت" OnClick="btSubmit_Click" Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 1027px; height: 25px; background-color: White;">
                    <a href="TranslationSendAdmin.aspx">درخواست ترجمه</a>
                </td>
            </tr>
            <tr style="height: 110px; width: 1027px; background-image: url('../images/FooterBG.jpg');">
                <td>
                    <table width="1027" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-image: url('../Images/FooterRight.gif'); width: 295px; height: 110px;">
                            </td>
                            <td style="background-image: url('../Images/FooterLeft.gif'); width: 732px; height: 110px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
