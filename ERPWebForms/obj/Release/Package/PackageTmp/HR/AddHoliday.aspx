<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="AddHoliday.aspx.cs" Inherits="ERPWebForms.HR.AddHoliday" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="Create Leave" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;
                                    <asp:Label ID="Label1" runat="server" Text="Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Name" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtName" placeholder="Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>

                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label3" runat="server" Text="Date" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtDate" placeholder="Date" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtDateResource1"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" BehaviorID="CalendarExtender1" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Repeats Annually" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:CheckBox ID="cbRepeats" runat="server" meta:resourcekey="cbRepeatsResource1" />
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label5" runat="server" Text="Full Day/Half Day" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" meta:resourcekey="ddlTypeResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1">Choose Type</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource2">Full Day</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource3">Half Day</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="ddlType" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                                <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>