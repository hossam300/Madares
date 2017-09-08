<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="ViewStudent.aspx.cs" Inherits="ERPWebForms.StudentAfair.ViewStudent" Culture="auto" UICulture="auto" meta:resourcekey="PageResource1" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function OnNewClick(s, e) {
            grid.AddNewRow();
        }
        function OnEditClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.StartEditRow(index);
        }
        function OnSaveClick(s, e) {
            grid.UpdateEdit();
        }
        function OnCancelClick(s, e) {
            grid.CancelEdit();
        }
        function OnDeleteClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.DeleteRow(index);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label2" runat="server" Text="Student Details" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Student Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Student ID" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblStudentID" class="limiter required" meta:resourcekey="lblStudentIDResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;<asp:Label ID="Label4" runat="server" Text="Student Name" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblStudentName" class="limiter required" meta:resourcekey="lblStudentNameResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="Parent Name" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblParentName" class="limiter required" meta:resourcekey="lblParentNameResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;<asp:Label ID="Label6" runat="server" Text="Parent Job" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblParentJob" class="limiter required" meta:resourcekey="lblParentJobResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label19" runat="server" Text="Gender" meta:resourcekey="Label19Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="lblGender" runat="server" meta:resourcekey="lblGenderResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label20" runat="server" Text="Religion" meta:resourcekey="Label20Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="lblReligion" runat="server" meta:resourcekey="lblReligionResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="BirthDate" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblBirthDate" class="limiter required" meta:resourcekey="lblBirthDateResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;<asp:Label ID="Label8" runat="server" Text="Phone" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblPhone" class="limiter required" meta:resourcekey="lblPhoneResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label9" runat="server" Text="Age At 1 OCt" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lbl1oct" class="limiter required" meta:resourcekey="lbl1octResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;<asp:Label ID="Label10" runat="server" Text="Type" meta:resourcekey="Label10Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="ddlType" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="ddlTypeResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label11" runat="server" Text="Address" meta:resourcekey="Label11Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblAddress" class="limiter required" meta:resourcekey="lblAddressResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;<asp:Label ID="Label12" runat="server" Text="Class" meta:resourcekey="Label12Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblClass" class="limiter required" meta:resourcekey="lblClassResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label13" runat="server" Text="Learning Disabilities" meta:resourcekey="Label13Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:CheckBox ID="cbtxtDisabilities" runat="server" Enabled="False" Text="Learning Disabilities" meta:resourcekey="cbtxtDisabilitiesResource1" />
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label14" runat="server" Text="Note" meta:resourcekey="Label14Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtDisabilities" placeholder="Learning Disabilities" Enabled="False" Width="100%" TextMode="MultiLine" Columns="6" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtDisabilitiesResource2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ControlToValidate="txtDisabilities" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator9Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label21" runat="server" Text="Father Information" meta:resourcekey="Label21Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label22" runat="server" Text="Father" meta:resourcekey="Label22Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="lblFather" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="lblFatherResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label23" runat="server" Text="Job" meta:resourcekey="Label23Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txtfjob" placeholder="Job" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtfjobResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label24" runat="server" Text="Phone" meta:resourcekey="Label24Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtfPhone" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtfPhoneResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label25" runat="server" Text="Address" meta:resourcekey="Label25Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtfAddress" placeholder="Address" Enabled="False" Width="100%" TextMode="MultiLine" Columns="6" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtfAddressResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label26" runat="server" Text="Mother Information" meta:resourcekey="Label26Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label27" runat="server" Text="Mother" meta:resourcekey="Label27Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="ddlMpther" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="ddlMptherResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label28" runat="server" Text="Job" meta:resourcekey="Label28Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txtmJob" placeholder="Job" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtmJobResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label29" runat="server" Text="Phone" meta:resourcekey="Label29Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtmphone" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtmphoneResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label30" runat="server" Text="Address" meta:resourcekey="Label30Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtmAddress" Enabled="False" placeholder="Address" Width="100%" TextMode="MultiLine" Columns="6" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtmAddressResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <div class="form_input">
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                        </div>
                                    </div>
                                </li>
                            </ul>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label18" runat="server" Text="Follow Ups" meta:resourcekey="Label18Resource1"></asp:Label></legend>
                                <div>
                                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="ASPxButton1_Click" meta:resourcekey="ASPxButton1Resource1"></dx:ASPxButton>
                                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="ASPxButton2_Click" meta:resourcekey="ASPxButton2Resource1"></dx:ASPxButton>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" PreviewFieldName="ID" KeyFieldName="ID" EnableCallBacks="False" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="TeacherID" VisibleIndex="2" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                            <PropertiesComboBox DataSourceID="SqlDataSource2" ValueField="ID" TextField="Teacher">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="CourseID" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                            <PropertiesComboBox DataSourceID="SqlDataSource3" ValueField="ID" TextField="Course">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewCommandColumn VisibleIndex="0" ShowNewButtonInHeader="True" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource2">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                    <Image IconID="actions_show_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="10" PageSize="10" Visible="true">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" />
                                    <SettingsCommandButton>
                                        <NewButton>
                                            <Image IconID="actions_add_16x16">
                                            </Image>
                                        </NewButton>
                                        <UpdateButton>
                                            <Image IconID="actions_apply_16x16">
                                            </Image>
                                        </UpdateButton>
                                        <CancelButton>
                                            <Image IconID="edit_delete_16x16">
                                            </Image>
                                        </CancelButton>
                                        <EditButton ButtonType="Image">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </EditButton>
                                        <DeleteButton ButtonType="Image">
                                            <Image IconID="actions_cancel_16x16">
                                            </Image>
                                        </DeleteButton>
                                    </SettingsCommandButton>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] AS Teacher  FROM [Std_Teacher]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] AS Course  FROM [Std_Course]"></asp:SqlDataSource>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [TeacherID], [Description], [CourseID] FROM [Std_FollowUp] WHERE ([StudentID] = @StudentID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="id" Name="StudentID" Type="Int32"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label15" runat="server" Text="Absent Days" meta:resourcekey="Label15Resource1"></asp:Label></legend>
                                <div>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="absentGrid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" PreviewFieldName="ID" EnableCallBacks="False" AutoGenerateColumns="False" meta:resourcekey="absentGridResource1">
                                    <TotalSummary>
                                        <dx:ASPxSummaryItem SummaryType="Count" FieldName="Date" DisplayFormat="Count of Absent Days= ####" ShowInColumn="Date" ShowInGroupFooterColumn="Date" meta:resourcekey="ASPxSummaryItemResource1"></dx:ASPxSummaryItem>
                                    </TotalSummary>
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="0" Caption="ID" UnboundType="Integer" Visible="false" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="AbsentDate" UnboundType="String" Caption="Date" VisibleIndex="1" meta:resourcekey="GridViewDataDateColumnResource1">
                                            <PropertiesDateEdit DisplayFormatString=""></PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" ShowFooter="True" />
                                </dx:ASPxGridView>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label16" runat="server" Text="Courses" meta:resourcekey="Label16Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="coursesGrid" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" meta:resourcekey="coursesGridResource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" VisibleIndex="1" ReadOnly="True" Visible="false" meta:resourcekey="GridViewDataTextColumnResource4">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" Caption="Course name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" />
                                    <SettingsCommandButton>
                                    </SettingsCommandButton>
                                </dx:ASPxGridView>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label17" runat="server" Text="Exams" meta:resourcekey="Label17Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" meta:resourcekey="ASPxGridView3Resource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource3">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" VisibleIndex="1" ReadOnly="True" Visible="false" meta:resourcekey="GridViewDataTextColumnResource6">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ExamName" Caption="Exam name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ExamType" Caption="Exam Type" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource8"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Degree" Caption="Degree" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource9"></dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="ASPxGridView1" runat="server"></dx:ASPxGridViewExporter>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
