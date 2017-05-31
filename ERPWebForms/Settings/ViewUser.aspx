<%@ Page Title="" Language="C#" MasterPageFile="~/Settings/SettingMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="ERPWebForms.Settings.ViewUser" %>

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
                                                <asp:Label ID="txtUserName" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBranchNameResource1"></asp:Label>
                                            </div>
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
                                                <asp:Label ID="txtPassword" Columns="5" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtlnameResource1"></asp:Label>
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
                                                <asp:Label ID="ddlRole" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="ddlRoleResource1"></asp:Label>
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
