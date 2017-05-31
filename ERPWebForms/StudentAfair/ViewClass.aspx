<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="ViewClass.aspx.cs" Inherits="ERPWebForms.StudentAfair.ViewClass" Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="View Class" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Class Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Class name" meta:resourcekey="Label2Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtClassName" placeholder="Class Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtClassNameResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Educational year" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="ddlEdtYear" runat="server" type="text" TabIndex="1" Style="width: 100%" meta:resourcekey="ddlEdtYearResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Number Of Students " meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtNoOfStudent" placeholder="Number Of Students" TextMode="Number" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtNoOfStudentResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label5" runat="server" Text="Supervisor" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="ddlSup" runat="server" type="text" TabIndex="1" Style="width: 100%;" meta:resourcekey="ddlSupResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label8" runat="server" Text="Students" meta:resourcekey="Label8Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView3" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" meta:resourcekey="ASPxGridView3Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0" Visible="false" meta:resourcekey="GridViewDataTextColumnResource4">
                                            <EditFormSettings Visible="False"></EditFormSettings>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Parent" Caption="Name" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT Std_Student.ID, Std_Student.Name  AS Parent FROM Std_Student INNER JOIN Std_Parent ON Std_Student.ParentID = Std_Parent.ID WHERE (Std_Student.StudClassID = @ID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="id" Name="ID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label6" runat="server" Text="Courses" meta:resourcekey="Label6Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" PreviewFieldName="ID" DataSourceID="SqlDataSource1" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" EnableCallBacks="False" meta:resourcekey="ASPxGridView2Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                            <EditFormSettings Visible="False"></EditFormSettings>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource1">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                    <Image IconID="actions_show_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                                <dx:GridViewCommandColumnCustomButton ID="btnDoc" meta:resourcekey="GridViewCommandColumnCustomButtonResource2">
                                                    <Image IconID="actions_open_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" />
                                    <SettingsCommandButton>
                                        <EditButton ButtonType="Image">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </EditButton>
                                    </SettingsCommandButton>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT Std_Course.ID, Std_Course.Name, Std_Course.Description FROM Std_Course INNER JOIN Std_CourseEdy ON Std_Course.ID = Std_CourseEdy.CourseID INNER JOIN Std_Class ON Std_CourseEdy.EdyID = Std_Class.EdyID WHERE (Std_Class.ID = @ID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="ID" Name="ID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <ul>
                                </ul>
                            </fieldset>
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label7" runat="server" Text="Teachers" meta:resourcekey="Label7Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" meta:resourcekey="ASPxGridView1Resource1">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" ReadOnly="True" meta:resourcekey="GridViewDataTextColumnResource1" Visible="False">
                                                        <EditFormSettings Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="CourseName" Caption="Course" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Teacher" FieldName="TeacherID" VisibleIndex="3" Name="clTeacher" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                                        <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="TeacherName" ValueField="TeacherID" EnableCallbackMode="false" />
                                                    </dx:GridViewDataComboBoxColumn>
                                                </Columns>
                                                <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                                                </SettingsPager>
                                                <Settings ShowFilterRow="True" />
                                                <SettingsCommandButton>
                                                    <EditButton ButtonType="Image">
                                                        <Image IconID="edit_edit_16x16">
                                                        </Image>
                                                    </EditButton>
                                                </SettingsCommandButton>
                                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                            </dx:ASPxGridView>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="select ID as TeacherID,Name as TeacherName from Std_Teacher"></asp:SqlDataSource>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <div class="form_grid_12">
                                <asp:Panel ID="panel" runat="server" meta:resourcekey="panelResource1"></asp:Panel>
                            </div>
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
