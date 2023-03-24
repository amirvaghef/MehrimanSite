<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainingAdmin.aspx.cs" Inherits="Administrator_TrainingAdmin"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <title>انتشارات مهرایمان:: مدیریت آموزش</title>
</head>
<body style="font-family: tahoma; font-size: 12px;">
    <form id="form1" runat="server" dir="rtl">
    <div>
        <table align="center" width="1027" border="1" cellpadding="0" cellspacing="0">
            <tr style="height: 246px; width: 1027px; background-image: url('../images/HeaderBGTraining.jpg');">
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
                            <td style="background-image: url('../Images/HeaderRightTraining.gif'); width: 295px;
                                height: 246px;">
                            </td>
                            <td style="background-image: url('../Images/HeaderLeftTraining.gif'); width: 732px;
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
                            <td valign="top" style="background-image: url('../Images/MainBGTraining.jpg'); width: 1027px;
                                height: 700px;">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="2">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top">
                                                            درجه:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpDegree" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDegree_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:LinkButton ID="lbtnNewDgree" runat="server" OnClick="lbtnNewDgree_Click">درجه جدید</asp:LinkButton>
                                                            &nbsp;&nbsp;<asp:LinkButton ID="lbtnDeleteDegree" runat="server" OnClick="lbtnDeleteDegree_Click">حذف</asp:LinkButton>
                                                            <br />
                                                            <asp:Panel ID="plDegreeInsert" runat="server" Visible="false" BorderWidth="2">
                                                                <br />
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            نام درجه:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDegree" runat="server" ValidationGroup="Degree"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                                                ControlToValidate="txtDegree" ValidationGroup="Degree">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <asp:Button ID="btCategorySubmit" runat="server" CausesValidation="true" Text="ثبت"
                                                                                ValidationGroup="Degree" OnClick="btCategorySubmit_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                            </asp:Panel>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            رشته:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpCourse_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:LinkButton ID="lbtnNewCourse" runat="server" OnClick="lbtnNewCourse_Click">رشته جدید</asp:LinkButton>
                                                            &nbsp;&nbsp;<asp:LinkButton ID="lbtnDeleteCourse" runat="server" OnClick="lbtnDeleteCourse_Click">حذف</asp:LinkButton>
                                                            <br />
                                                            <asp:Panel ID="plCourseInsert" runat="server" Visible="false" BorderWidth="2">
                                                                <br />
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            نام رشته:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCourse" runat="server" ValidationGroup="Course"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                                                ControlToValidate="txtCourse" ValidationGroup="Course">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <asp:Button ID="btCourseSubmit" runat="server" CausesValidation="true" Text="ثبت"
                                                                                ValidationGroup="Course" OnClick="btCourseSubmit_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                            </asp:Panel>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            دروس:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpLesson" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpLesson_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:LinkButton ID="lbtnNewLesson" runat="server" OnClick="lbtnNewLesson_Click">درس جدید</asp:LinkButton>
                                                            &nbsp;&nbsp;<asp:LinkButton ID="lbtnDeleteLesson" runat="server" OnClick="lbtnDeleteLesson_Click">حذف</asp:LinkButton>
                                                            <br />
                                                            <asp:Panel ID="plLessonInsert" runat="server" Visible="false" BorderWidth="2">
                                                                <br />
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            نام درس:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtLesson" runat="server" ValidationGroup="Lesson"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                                                                ControlToValidate="txtLesson" ValidationGroup="Lesson">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <asp:Button ID="btnLessonSubmit" runat="server" CausesValidation="true" Text="ثبت"
                                                                                ValidationGroup="Lesson" OnClick="btnLessonSubmit_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                            </asp:Panel>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            دوره:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpPart" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPart_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:LinkButton ID="lbtnNewPart" runat="server" OnClick="lbtnNewPart_Click">دوره جدید</asp:LinkButton>
                                                            &nbsp;&nbsp;<asp:LinkButton ID="lbtnDeletePart" runat="server" OnClick="lbtnDeletePart_Click">حذف</asp:LinkButton>
                                                            <br />
                                                            <asp:Panel ID="plPartInsert" runat="server" Visible="false" BorderWidth="2">
                                                                <br />
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            نام دوره:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPart" runat="server" ValidationGroup="Part"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                                                                ControlToValidate="txtPart" ValidationGroup="Part">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right" colspan="2">
                                                                            توضیحات:
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="right">
                                                                            <textarea cols="80" id="editor2" name="editor2" rows="10" runat="server" dir="rtl"></textarea>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                                                ControlToValidate="editor2" ValidationGroup="Part">*</asp:RequiredFieldValidator>
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
                                                                        <td colspan="2" align="center">
                                                                            <asp:Button ID="btnPartSubmit" runat="server" CausesValidation="true" Text="ثبت"
                                                                                ValidationGroup="Part" OnClick="btnPartSubmit_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                            </asp:Panel>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="right" colspan="2">
                                                            توضیحات: &nbsp;&nbsp;<asp:LinkButton ID="lbtnArchivePart" runat="server" OnClick="lbtnArchivePart_Click">آرشیو دوره</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right">
                                                            <textarea cols="80" id="editor1" name="editor1" rows="10" runat="server" dir="rtl"></textarea>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                                ControlToValidate="editor1" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
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
                                                        <td align="center" colspan="2">
                                                            <asp:Button ID="btnSubmit" runat="server" Text="به روز رسانی دوره" OnClick="btSubmit_Click"
                                                                ValidationGroup="Submit" CausesValidation="true" />
                                                        </td>
                                                    </tr>
                                                </table>
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
                    <a href="TrainingReportAdmin.aspx">گزارش آموزش</a>
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
