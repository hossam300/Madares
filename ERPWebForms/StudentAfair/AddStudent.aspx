<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="ERPWebForms.StudentAfair.AddStudent" Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                            <asp:Label ID="Label3" runat="server" Text="Create Student" meta:resourcekey="Label3Resource1"></asp:Label></h6>
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
                                                <asp:Label ID="Label2" runat="server" Text="Student name" meta:resourcekey="Label2Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtStudentName" placeholder="Student Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtStudentNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtStudentName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Parent Name" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <dx:ASPxComboBox ID="ddlParentName" DataSourceID="parentDS" TextField="Name" ValueField="ID" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="ddlParentNameResource1" OnSelectedIndexChanged="ddlParentName_SelectedIndexChanged" AutoPostBack="True">
                                                    </dx:ASPxComboBox>
                                                    <asp:SqlDataSource runat="server" ID="parentDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Std_parent]"></asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="ddlParentName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label25" runat="server" Text="User Name In English" meta:resourcekey="Label25Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtUserName" placeholder="UserName" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtStudentNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ControlToValidate="txtUserName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label11" runat="server" Text="Gender" meta:resourcekey="Label11Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:RadioButtonList ID="rblGender" runat="server" meta:resourcekey="rblGenderResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1">Male</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource2">Female</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="rblGender" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label12" runat="server" Text="Religion" meta:resourcekey="Label12Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:RadioButtonList ID="rblReligion" runat="server" meta:resourcekey="rblReligionResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource3">Muslim</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource4">Christian</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="ddlParentName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="BirthDate" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtBirthDate" placeholder="BirthDate" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtBirthDateResource1"></asp:TextBox>
                                                    <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtBirthDate" BehaviorID="CalendarExtender1" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtBirthDate" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Parent Job" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtParentJob" ReadOnly="True" placeholder="Parent Job" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtParentJobResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Phone" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtPhone" placeholder="Phone" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtPhoneResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtPhone" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Type" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <dx:ASPxComboBox ID="ddlType" AppendDataBoundItems="true" DataSourceID="datasourseType" TextField="Name" ValueField="ID" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlTypeResource1">
                                                    </dx:ASPxComboBox>
                                                    <asp:SqlDataSource runat="server" ID="datasourseType" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Std_StudentType]"></asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="ddlType" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label9" runat="server" Text="Address" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtAddress" placeholder="Address" Width="100%" TextMode="MultiLine" Columns="6" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtAddressResource1"></asp:TextBox>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="Class" meta:resourcekey="Label10Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <dx:ASPxComboBox ID="ddlClass" runat="server" AppendDataBoundItems="true" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" DataSourceID="SqlDataSource1" TextField="Name" ValueField="ID" meta:resourcekey="ddlClassResource1">
                                                    </dx:ASPxComboBox>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Std_Class]"></asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="ddlClass" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
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
                                                    <asp:CheckBox ID="cbtxtDisabilities" runat="server" Text="Learning Disabilities" meta:resourcekey="cbtxtDisabilitiesResource1" />
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label14" runat="server" Text="Note" meta:resourcekey="Label14Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtDisabilities" placeholder="Learning Disabilities" Width="100%" TextMode="MultiLine" Columns="6" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtAddressResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label15" runat="server" Text="Father Information" meta:resourcekey="Label15Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label17" runat="server" Text="Father" meta:resourcekey="Label17Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <dx:ASPxComboBox ID="ddlFather" DataSourceID="parentDS" Width="100%" TextField="Name" ValueField="ID" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="ddlParentNameResource1" OnSelectedIndexChanged="ddlFather_SelectedIndexChanged" AutoPostBack="True">
                                                    </dx:ASPxComboBox>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label19" runat="server" Text="Job" meta:resourcekey="Label19Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtfjob" placeholder="Job" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtfjobResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label20" runat="server" Text="Phone" meta:resourcekey="Label20Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtfPhone" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtPhoneResource1"></asp:TextBox>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label21" runat="server" Text="Address" meta:resourcekey="Label21Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtfAddress" placeholder="Address" Width="100%" TextMode="MultiLine" Columns="6" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtfAddressResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label16" runat="server" Text="Mother Information" meta:resourcekey="Label16Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label18" runat="server" Text="Mother" meta:resourcekey="Label18Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <dx:ASPxComboBox ID="ddlMpther" DataSourceID="parentDS" Width="100%" TextField="Name" ValueField="ID" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="ddlParentNameResource1" OnSelectedIndexChanged="ddlMpther_SelectedIndexChanged" AutoPostBack="True">
                                                    </dx:ASPxComboBox>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label22" runat="server" Text="Job" meta:resourcekey="Label22Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtmJob" placeholder="Job" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtmJobResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label23" runat="server" Text="Phone" meta:resourcekey="Label23Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtmphone" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtPhoneResource1"></asp:TextBox>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label24" runat="server" Text="Address" meta:resourcekey="Label24Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtmAddress" placeholder="Address" Width="100%" TextMode="MultiLine" Columns="6" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtmAddressResource1"></asp:TextBox>
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
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" />
                                            <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
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
