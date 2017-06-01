<%@ Page Title="" Language="C#" MasterPageFile="~/Settings/SettingMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewRole.aspx.cs" Inherits="ERPWebForms.Settings.ViewRole" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Create Role" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblBranchInformation" runat="server" Text="Role Information" meta:resourcekey="lblBranchInformationResource1"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblUserName" Text="Role Name" runat="server" meta:resourcekey="lblBranchNameResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:Label ID="txtRoleName" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBranchNameResource1"></asp:Label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label1" Text="Default Module" runat="server" meta:resourcekey="lblBranchNameResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:Label ID="ddlDefault" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBranchNameResource1"></asp:Label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label7" runat="server" Text="Permission" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_12 alpha">
                                                <div class="form_grid_3 alpha">
                                                    <fieldset>
                                                        <legend>
                                                            <asp:Label ID="Label8" runat="server" Text="Finance Module" meta:resourcekey="Label8Resource1"></asp:Label></legend>
                                                        <asp:CheckBoxList ID="chkPermissionFin" Enabled="False" runat="server" meta:resourcekey="chkPermissionFinResource1">
                                                        </asp:CheckBoxList>
                                                    </fieldset>
                                                </div>
                                                <div class="form_grid_3 alpha">
                                                    <fieldset>
                                                        <legend>
                                                            <asp:Label ID="Label9" runat="server" Text="Human Resource Module" meta:resourcekey="Label9Resource1"></asp:Label></legend>
                                                        <asp:CheckBoxList ID="chkPermissionHR" Enabled="False" runat="server" meta:resourcekey="chkPermissionHRResource1">
                                                        </asp:CheckBoxList>
                                                    </fieldset>
                                                </div>
                                                <div class="form_grid_3 alpha">
                                                    <fieldset>
                                                        <legend>
                                                            <asp:Label ID="Label10" runat="server" Text="Student Afair Module" meta:resourcekey="Label10Resource1"></asp:Label></legend>
                                                        <asp:CheckBoxList ID="chkPermissionST" runat="server" Enabled="False" meta:resourcekey="chkPermissionSTResource1">
                                                        </asp:CheckBoxList>
                                                    </fieldset>
                                                </div>
                                                <div class="form_grid_3 alpha">
                                                    <fieldset>
                                                        <legend>
                                                            <asp:Label ID="Label2" runat="server" Text="Student Afair Module" meta:resourcekey="Label10Resource1"></asp:Label></legend>
                                                        <asp:CheckBoxList ID="chkPermissionSettings" Enabled="False" runat="server" meta:resourcekey="chkPermissionSettingsResource1">
                                                        </asp:CheckBoxList>
                                                    </fieldset>
                                                </div>
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
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" meta:resourcekey="btnSaveResource1" OnClick="btnEdit_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" meta:resourcekey="btnCancelResource1" CausesValidation="False" OnClick="btnCancel_Click" />
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
