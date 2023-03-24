<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"  CodeFile="LectureAdmin.aspx.cs"
    Inherits="Administrator_LectureAdmin"%>

<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <title>انتشارات مهرایمان:: مدیریت همایشات</title>
</head>
<body style="font-family: tahoma; font-size: 12px;">
    <form id="form1" runat="server" dir="rtl">
    <cc1:JQLoader ID="JQLoader1" runat="server">
    </cc1:JQLoader>
    <div>
        <table align="center" width="1027" border="1" cellpadding="0" cellspacing="0">
            <tr style="height: 246px; width: 1027px; background-image: url('../images/HeaderBGLectures.jpg');">
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
                            <td style="background-image: url('../Images/HeaderRightLecture.gif'); width: 295px;
                                height: 246px;">
                            </td>
                            <td style="background-image: url('../Images/HeaderLeftLecture.gif'); width: 732px;
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
                            <td valign="top" style="background-image: url('../Images/MainBGLecture.jpg'); width: 1027px;
                                height: 700px;">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td valign="top" colspan="2">
                                                <span  style="color:White;"> نام همایش:</span>
                                                <asp:TextBox ID="txtLectureName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtLectureName" ValidationGroup="Submit">نام همایش مورد نیاز می باشد</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2" style="color:White;">
                                                توضیحات:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
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
                                                مبلغ همایش:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLecturePrice" runat="server"></asp:TextBox>
                                                ریال
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtLecturePrice" ValidationGroup="Submit">مبلغ همایش مورد نیاز می باشد</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="لطفاً مبلغ را صحیح وارد نمائید"
                                                    ValidationGroup="Submit" ControlToValidate="txtLecturePrice" ValidationExpression="\d{1,}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="color:White;">
                                                ظرفیت همایش:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtCapacity" ValidationGroup="Submit">ظرفیت همایش مورد نیاز می باشد</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="لطفاً ظرفیت را صحیح وارد نمائید"
                                                    ValidationGroup="Submit" ControlToValidate="txtCapacity" ValidationExpression="\d{1,}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="color:White;">
                                                تاریخ همایش:
                                                </td>
                                                <td>
                                                <cc1:JQDatePicker ID="jqdtLecture" runat="server" ChangeMonth="true" ChangeYear="true"
                                                    GotoCurrent="true" IsRTL="true" Regional="fa"></cc1:JQDatePicker>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                    ControlToValidate="jqdtLecture" ValidationGroup="Submit">تاریخ همایش مورد نیاز می باشد</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="color:White;">
                                                مهلت ثبت نام:
                                                </td>
                                                <td>
                                                <cc1:JQDatePicker ID="jgdtTimeOut" runat="server" ChangeMonth="true" ChangeYear="true"
                                                    GotoCurrent="true" IsRTL="true" Regional="fa"></cc1:JQDatePicker>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                                    ControlToValidate="jgdtTimeOut" ValidationGroup="Submit">مهلت ثبت نام مورد نیاز می باشد</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="color:White;">
                                                <b>انواع تخفیف ها</b>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                دانشجویی:
                                                </td>
                                                <td>
                                                <asp:TextBox ID="txtStudentDiscount" runat="server" SkinID="Little" Text="0" MaxLength="2">0</asp:TextBox>درصد
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtStudentDiscount" ValidationGroup="Submit">تخفیف دانشجویی مورد نیاز می باشد</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="لطفاً تخفیف دانشجویی را صحیح وارد نمائید"
                                                    ValidationGroup="Submit" ControlToValidate="txtStudentDiscount" ValidationExpression="\d{1,2}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                هیأت علمی:
                                                </td>
                                                <td>
                                                <asp:TextBox ID="txtOstadDiscount" runat="server" SkinID="Little" Text="0" MaxLength="2">0</asp:TextBox>درصد
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtOstadDiscount" ValidationGroup="Submit">تخفیف هیأت علمی مورد نیاز می باشد</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="لطفاً تخفیف هیأت علمی را صحیح وارد نمائید"
                                                    ValidationGroup="Submit" ControlToValidate="txtOstadDiscount" ValidationExpression="\d{1,2}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                آزاد:
                                                 </td>
                                                <td>
                                                <asp:TextBox ID="txtFree" runat="server" SkinID="Little" Text="0" MaxLength="2"></asp:TextBox>درصد
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtFree" ValidationGroup="Submit">تخفیف آزاد مورد نیاز می باشد</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="لطفاً تخفیف آزاد را صحیح وارد نمائید"
                                                    ValidationGroup="Submit" ControlToValidate="txtFree" ValidationExpression="\d{1,2}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <hr style="width: 70%;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2">
                                                گروهی:
                                                <br />
                                                از
                                                <asp:TextBox ID="txtNumber1From" runat="server" SkinID="Little" Text="0"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtNumber1From" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="لطفاً عدد را صحیح وارد نمائید"
                                                    ValidationGroup="Submit" ControlToValidate="txtNumber1From" ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>
                                                نفر تا
                                                <asp:TextBox ID="txtNumber1Til" runat="server" SkinID="Little" Text="0"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtNumber1Til" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="لطفاً عدد را صحیح وارد نمائید"
                                                    ValidationGroup="Submit" ControlToValidate="txtNumber1Til" ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>
                                                نفر تخفیف
                                                <asp:TextBox ID="txtNumber1Discount" runat="server" SkinID="Little" Text="0" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtNumber1Discount" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="لطفاً عدد را صحیح وارد نمائید"
                                                    ValidationGroup="Submit" ControlToValidate="txtNumber1Discount" ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>درصد
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2">
                                                از
                                                <asp:TextBox ID="txtNumber2From" runat="server" SkinID="Little" Text="0" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtNumber2From" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                    ErrorMessage="لطفاً عدد را صحیح وارد نمائید" ValidationGroup="Submit" ControlToValidate="txtNumber2From"
                                                    ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>
                                                نفر تا
                                                <asp:TextBox ID="txtNumber2Til" runat="server" SkinID="Little" Text="0"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtNumber2Til" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                    ErrorMessage="لطفاً عدد را صحیح وارد نمائید" ValidationGroup="Submit" ControlToValidate="txtNumber2Til"
                                                    ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>
                                                نفر تخفیف
                                                <asp:TextBox ID="txtNumber2Discount" runat="server" SkinID="Little" Text="0" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtNumber2Discount" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                    ErrorMessage="لطفاً عدد را صحیح وارد نمائید" ValidationGroup="Submit" ControlToValidate="txtNumber2Discount"
                                                    ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>درصد
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2">
                                                از
                                                <asp:TextBox ID="txtNumber3From" runat="server" SkinID="Little" Text="0" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtNumber3From" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                    ErrorMessage="لطفاً عدد را صحیح وارد نمائید" ValidationGroup="Submit" ControlToValidate="txtNumber3From"
                                                    ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>
                                                نفر تا
                                                <asp:TextBox ID="txtNumber3Til" runat="server" SkinID="Little" Text="0" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtNumber3Til" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                    ErrorMessage="لطفاً عدد را صحیح وارد نمائید" ValidationGroup="Submit" ControlToValidate="txtNumber3Til"
                                                    ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>
                                                نفر تخفیف
                                                <asp:TextBox ID="txtNumber3Discount" runat="server" SkinID="Little" Text="0" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtNumber3Discount" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                    ErrorMessage="لطفاً عدد را صحیح وارد نمائید" ValidationGroup="Submit" ControlToValidate="txtNumber3Discount"
                                                    ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>درصد
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr style="width: 70%;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2">
                                                از تاریخ
                                                <cc1:JQDatePicker ID="jqdtDate1From" runat="server" ChangeMonth="true" ChangeYear="true"
                                                    GotoCurrent="true" IsRTL="true" Regional="fa"></cc1:JQDatePicker>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*"
                                                    ControlToValidate="jqdtDate1From" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                تا تاریخ
                                                <cc1:JQDatePicker ID="jqdtDate1Til" runat="server" ChangeMonth="true" ChangeYear="true"
                                                    GotoCurrent="true" IsRTL="true" Regional="fa"></cc1:JQDatePicker>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*"
                                                    ControlToValidate="jqdtDate1Til" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                تخفیف
                                                <asp:TextBox ID="txtDate1Discount" runat="server" SkinID="Little" Text="0" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtDate1Discount" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                                                    ErrorMessage="لطفاً عدد را صحیح وارد نمائید" ValidationGroup="Submit" ControlToValidate="txtDate1Discount"
                                                    ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>درصد
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2">
                                                از تاریخ
                                                <cc1:JQDatePicker ID="jqdtDate2From" runat="server" ChangeMonth="true" ChangeYear="true"
                                                    GotoCurrent="true" IsRTL="true" Regional="fa" ></cc1:JQDatePicker>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*"
                                                    ControlToValidate="jqdtDate2From" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                تا تاریخ
                                                <cc1:JQDatePicker ID="jqdtDate2Til" runat="server" ChangeMonth="true" ChangeYear="true"
                                                    GotoCurrent="true" IsRTL="true" Regional="fa"></cc1:JQDatePicker>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*"
                                                    ControlToValidate="jqdtDate2Til" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                تخفیف
                                                <asp:TextBox ID="txtDate2Discount" runat="server" SkinID="Little" Text="0" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtDate2Discount" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                                    ErrorMessage="لطفاً عدد را صحیح وارد نمائید" ValidationGroup="Submit" ControlToValidate="txtDate2Discount"
                                                    ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>درصد
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2">
                                                از تاریخ
                                                <cc1:JQDatePicker ID="jqdtDate3From" runat="server" ChangeMonth="true" ChangeYear="true"
                                                    GotoCurrent="true" IsRTL="true" Regional="fa" ></cc1:JQDatePicker>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*"
                                                    ControlToValidate="jqdtDate3From" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                تا تاریخ
                                                <cc1:JQDatePicker ID="jqdtDate3Til" runat="server" ChangeMonth="true" ChangeYear="true"
                                                    GotoCurrent="true" IsRTL="true" Regional="fa"></cc1:JQDatePicker>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*"
                                                    ControlToValidate="jqdtDate3Til" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                تخفیف
                                                <asp:TextBox ID="txtDate3Discount" runat="server" SkinID="Little" Text="0" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtDate3Discount" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                    ErrorMessage="لطفاً عدد را صحیح وارد نمائید" ValidationGroup="Submit" ControlToValidate="txtDate3Discount"
                                                    ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>درصد
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                تگ ها:
                                                <br />
                                                <span style="color:Red">
                                                    لطفاً تگ ها را با ویرگول(،) از هم جدا نمائید
                                                </span>
                                                <br />
                                                <asp:TextBox ID="txtTags" runat="server" TextMode="MultiLine" SkinID="Multi"></asp:TextBox>   
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="btSubmit" runat="server" Text="ثبت" ValidationGroup="Submit" CausesValidation="true"
                                                    OnClick="btSubmit_Click" />
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                </tr> </table> </td>
            </tr>
            <tr>
                <td style="width: 1027px; height: 25px; background-color: White;">
                    <a href="LectureDeleteAdmin.aspx">ویرایش همایش</a>&nbsp;&nbsp;&nbsp;<a href="LectureReportAdmin.aspx">گزارش همایش</a>
                    &nbsp;&nbsp;&nbsp;<a href="LectureNewsAdmin.aspx">اخبار همایش</a>
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
