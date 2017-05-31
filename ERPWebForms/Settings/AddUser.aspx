<%@ Page Title="" Language="C#" MasterPageFile="~/Settings/SettingMasterPage.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="ERPWebForms.Settings.AddUser" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="Create User" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblBranchInformation" runat="server" Text="User Information" meta:resourcekey="lblBranchInformationResource2"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblUserName" Text="User Name" runat="server" meta:resourcekey="lblUserNameResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_8 alpha">
                                                <asp:TextBox ID="txtUserName" placeholder="User Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBranchNameResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="Red" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:Label runat="server" ID="error" Font-Bold="true" Font-Size="Larger" Visible="false" Text="" ForeColor="Red"></asp:Label>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblPassword" Text="Password" runat="server" meta:resourcekey="lblPasswordResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_8 alpha">
                                                <asp:TextBox ID="txtPassword" Columns="5" runat="server" type="Password" TabIndex="1" class="limiter required" meta:resourcekey="txtlnameResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label1" Text="Confirm Password" runat="server" meta:resourcekey="Label1Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_8 alpha">
                                                <asp:TextBox ID="txtConfirmPassword" Columns="5" runat="server" type="Password" TabIndex="1" class="limiter required" meta:resourcekey="txtlnameResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="*" ForeColor="Red" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" runat="server" ErrorMessage="Password not matched" meta:resourcekey="CompareValidator1Resource1"></asp:CompareValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label2" Text="Role" runat="server" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_8 alpha">
                                                <asp:DropDownList ID="ddlRole" Columns="5" DataTextField="Name" DataValueField="ID" runat="server" DataSourceID="RoleDS" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlRoleResource1"></asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="RoleDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [UserRoles]"></asp:SqlDataSource>
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
                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" CausesValidation="False" />
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
