<%@ Page Title="" Language="C#" MasterPageFile="~/Settings/SettingMasterPage.Master" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="ERPWebForms.Settings.AddRole" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#<%=chkboxSelectfinAll.ClientID%>").click(function () {
                if ($(this).is(":checked")) {
                    $("#<%=chkPermissionFin.ClientID%> input[type=checkbox]").attr("checked", "checked");
                }
                else {
                    $("#<%=chkPermissionFin.ClientID%> input[type=checkbox]").removeAttr("checked");
                }
            });
            $("#<%=chkPermissionFin.ClientID%>").click(function () {
                if ($("#<%=chkPermissionFin.ClientID%> input[type=checkbox]:checked").length == $("#<%=chkPermissionFin.ClientID%> input").length) {
                    $("#<%=chkboxSelectfinAll.ClientID%>").attr("checked", "checked");
                } else {
                    $("#<%=chkboxSelectfinAll.ClientID%>").removeAttr("checked");
                }
            });
        });
        $(function () {
            $("#<%=chkboxSelectHRAll.ClientID%>").click(function () {
                if ($(this).is(":checked")) {
                    $("#<%=chkPermissionHR.ClientID%> input[type=checkbox]").attr("checked", "checked");
                }
                else {
                    $("#<%=chkPermissionHR.ClientID%> input[type=checkbox]").removeAttr("checked");
                }
            });
            $("#<%=chkPermissionHR.ClientID%>").click(function () {
                if ($("#<%=chkPermissionHR.ClientID%> input[type=checkbox]:checked").length == $("#<%=chkPermissionHR.ClientID%> input").length) {
                    $("#<%=chkboxSelectHRAll.ClientID%>").attr("checked", "checked");
                } else {
                    $("#<%=chkboxSelectHRAll.ClientID%>").removeAttr("checked");
                }
            });
        });
        $(function () {
            $("#<%=chkboxSelectSTAll.ClientID%>").click(function () {
                if ($(this).is(":checked")) {
                    $("#<%=chkPermissionST.ClientID%> input[type=checkbox]").attr("checked", "checked");
                }
                else {
                    $("#<%=chkPermissionST.ClientID%> input[type=checkbox]").removeAttr("checked");
                }
            });
            $("#<%=chkPermissionST.ClientID%>").click(function () {
                if ($("#<%=chkPermissionST.ClientID%> input[type=checkbox]:checked").length == $("#<%=chkPermissionST.ClientID%> input").length) {
                    $("#<%=chkboxSelectSTAll.ClientID%>").attr("checked", "checked");
                } else {
                    $("#<%=chkboxSelectSTAll.ClientID%>").removeAttr("checked");
                }
            });
        });
        $(function () {
            $("#<%=chkboxSelectSettingsAll.ClientID%>").click(function () {
                if ($(this).is(":checked")) {
                    $("#<%=chkPermissionSettings.ClientID%> input[type=checkbox]").attr("checked", "checked");
             }
             else {
                 $("#<%=chkPermissionSettings.ClientID%> input[type=checkbox]").removeAttr("checked");
             }
            });
            $("#<%=chkPermissionSettings.ClientID%>").click(function () {
                if ($("#<%=chkPermissionSettings.ClientID%> input[type=checkbox]:checked").length == $("#<%=chkPermissionSettings.ClientID%> input").length) {
                 $("#<%=chkboxSelectSettingsAll.ClientID%>").attr("checked", "checked");
             } else {
                 $("#<%=chkboxSelectSettingsAll.ClientID%>").removeAttr("checked");
             }
         });
        });
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
                                                <asp:TextBox ID="txtRoleName" placeholder="Role Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBranchNameResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRoleName" ErrorMessage="*" ForeColor="Red" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
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
                                                <asp:DropDownList ID="ddlDefault" runat="server" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="txtBranchNameResource1">
                                                    <asp:ListItem meta:resourcekey="ListItemResource1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                    <asp:ListItem meta:resourcekey="ListItemResource3"></asp:ListItem>
                                                    <asp:ListItem meta:resourcekey="ListItemResource4"></asp:ListItem>
                                                </asp:DropDownList>
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
                                                        <asp:CheckBox ID="chkboxSelectfinAll" runat="server" Text="Select All" />
                                                        <asp:CheckBoxList ID="chkPermissionFin" runat="server" meta:resourcekey="chkPermissionFinResource1">
                                                        </asp:CheckBoxList>
                                                    </fieldset>
                                                </div>
                                                <div class="form_grid_3 alpha">
                                                    <fieldset>
                                                        <legend>
                                                            <asp:Label ID="Label9" runat="server" Text="Human Resource Module" meta:resourcekey="Label9Resource1"></asp:Label></legend>
                                                        <asp:CheckBox ID="chkboxSelectHRAll" runat="server" Text="Select All" />
                                                        <asp:CheckBoxList ID="chkPermissionHR" runat="server" meta:resourcekey="chkPermissionHRResource1">
                                                        </asp:CheckBoxList>
                                                    </fieldset>
                                                </div>
                                                <div class="form_grid_3 alpha">
                                                    <fieldset>
                                                        <legend>
                                                            <asp:Label ID="Label10" runat="server" Text="Student Afair Module" meta:resourcekey="Label10Resource1"></asp:Label></legend>
                                                        <asp:CheckBox ID="chkboxSelectSTAll" runat="server" Text="Select All" />
                                                        <asp:CheckBoxList ID="chkPermissionST" runat="server" meta:resourcekey="chkPermissionSTResource1">
                                                        </asp:CheckBoxList>
                                                    </fieldset>
                                                </div>
                                                <div class="form_grid_3 alpha">
                                                    <fieldset>
                                                        <legend>
                                                            <asp:Label ID="Label2" runat="server" Text="Student Afair Module" meta:resourcekey="Label10Resource1"></asp:Label></legend>
                                                        <asp:CheckBox ID="chkboxSelectSettingsAll" runat="server" Text="Select All" />
                                                        <asp:CheckBoxList ID="chkPermissionSettings" runat="server" meta:resourcekey="chkPermissionSettingsResource1">
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

