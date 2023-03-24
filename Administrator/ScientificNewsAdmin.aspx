<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScientificNewsAdmin.aspx.cs" Inherits="Administrator_ScientificNewsAdmin"
    ValidateRequest="false" %>

<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <title>انتشارات مهرایمان:: مدیریت اخبار</title>
</head>
<body style="font-family: tahoma; font-size: 12px; color: White;">
    <form id="form1" runat="server" dir="rtl">
    <cc1:JQLoader ID="JQLoader1" runat="server">
    </cc1:JQLoader>
    <div>
        <table align="center" width="1027" border="1" cellpadding="0" cellspacing="0">
            <tr style="height: 246px; width: 1027px; background-image: url('../images/HeaderBGNews.jpg');">
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
                            <td style="background-image: url('../Images/HeaderRightNews.gif'); width: 295px;
                                height: 246px;">
                            </td>
                            <td style="background-image: url('../Images/HeaderLeftNews.gif'); width: 732px; height: 246px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="1027" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" style="background-image: url('../Images/MainBGNews.jpg'); width: 1027px;
                                height: 789px;">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            عنوان خبر:
                                            <asp:TextBox ID="txtNewsTitle" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtNewsTitle" ValidationGroup="Submit">عنوان خبر مورد نیاز می باشد</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="color:White;">
                                            خلاصه خبر:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="color:White;">
                                            مشروح خبر:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <textarea cols="80" id="editor2" name="editor2" rows="10" runat="server" dir="rtl"></textarea>
                                            <script type="text/javascript">
			//<![CDATA[
                                                // This call can be placed at any point after the
                                                // <textarea>, or inside a <head><script> in a
                                                // window.onload event handler.

                                                // Replace the <textarea id="editor"> with an CKEditor
                                                // instance, using default configurations.
                                                CKEDITOR.replace('editor2',
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            تاریخ نمایش:
                                            <cc1:JQDatePicker ID="jqdtInsert" runat="server" ChangeMonth="true" ChangeYear="true"
                                                GotoCurrent="true" IsRTL="true" Regional="fa"></cc1:JQDatePicker>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                ControlToValidate="jqdtInsert" ValidationGroup="Submit">تاریخ نمایش مورد نیاز می باشد</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            تاریخ آرشیو:
                                            <cc1:JQDatePicker ID="jqdtArchive" runat="server" ChangeMonth="true" ChangeYear="true"
                                                GotoCurrent="true" IsRTL="true" Regional="fa"></cc1:JQDatePicker>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                                ControlToValidate="jqdtArchive" ValidationGroup="Submit">تاریخ آرشیو مورد نیاز می باشد</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            تگ ها:
                                            <br />
                                            <span style="color: Red">لطفاً تگ ها را با ویرگول(،) از هم جدا نمائید </span>
                                            <br />
                                            <asp:TextBox ID="txtTags" runat="server" TextMode="MultiLine" SkinID="Multi"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btSubmit" runat="server" Text="ثبت" OnClick="btSubmit_Click" ValidationGroup="Submit" />
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
                    <a href="ScientificNewsDeleteAdmin.aspx">حذف و تغییر اخبار علمی</a>
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
