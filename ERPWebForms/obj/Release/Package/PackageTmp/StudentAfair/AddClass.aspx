<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="ERPWebForms.StudentAfair.AddClass" %>

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
                            <asp:Label ID="Label3" runat="server" Text="Create Class" meta:resourcekey="Label3Resource1"></asp:Label></h6>
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
                                                    <asp:TextBox ID="txtClassName" placeholder="Class Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtClassNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtClassName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label4" runat="server" Text="Educational year" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlEdtYear" AppendDataBoundItems="True" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlEdtYear_SelectedIndexChanged" meta:resourcekey="ddlEdtYearResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1"> Choose Year</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] as Name FROM [Std_EducationalYear]"></asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="<%$ Resources:ListItemResource1.Text %>" runat="server" ForeColor="Red" ControlToValidate="ddlEdtYear" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label6" runat="server" Text="Supervisor" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlSup" DataSourceID="teacherDS" AppendDataBoundItems="True" DataTextField="Name" DataValueField="ID" runat="server" type="text" TabIndex="1" Style="width: 100%;" class="chzn-select" meta:resourcekey="ddlSupResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource2"> Choose Supervisor</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="teacherDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] as Name FROM [Std_Teacher]"></asp:SqlDataSource>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" OnStartRowEditing="ASPxGridView1_StartRowEditing" OnRowUpdating="grid_RowUpdating" meta:resourcekey="ASPxGridView1Resource1">
                                                <Columns>
                                                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" ReadOnly="True" meta:resourcekey="GridViewDataTextColumnResource1">
                                                        <EditFormSettings Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="CourseName" Caption="Course" VisibleIndex="2" Width="200px" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Teacher" FieldName="TeacherName" VisibleIndex="3" Name="clTeacher" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                                        <PropertiesComboBox TextField="TeacherName" ValueField="TeacherID" EnableCallbackMode="false" />
                                                    </dx:GridViewDataComboBoxColumn>
                                                </Columns>
                                                <SettingsPager NumericButtonCount="100" PageSize="100" Visible="False">
                                                </SettingsPager>
                                                <Settings ShowFilterRow="True" />
                                                <SettingsCommandButton>
                                                    <EditButton ButtonType="Image">
                                                        <Image IconID="edit_edit_16x16">
                                                        </Image>
                                                    </EditButton>
                                                </SettingsCommandButton>
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
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="False" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                            <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
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
