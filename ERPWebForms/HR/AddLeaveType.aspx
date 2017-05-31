<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="AddLeaveType.aspx.cs" Inherits="ERPWebForms.HR.AddLeaveType" %>

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
                            <asp:Label ID="Label6" runat="server" Text="Create Leave Type" meta:resourcekey="Label6Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;<asp:Label ID="Label2" runat="server" Text="Information" meta:resourcekey="Label2Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label1" runat="server" Text="Leave Type" meta:resourcekey="Label1Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtLeaveType" placeholder="Leave Type" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtLeaveTypeResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtLeaveType" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Balance %>"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtBalance" placeholder="Balance" runat="server" type="text" TabIndex="1" class="limiter required"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtBalance" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Deduction %>"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4">
                                                    <asp:CheckBox ID="cbDeduction" runat="server" AutoPostBack="true" OnCheckedChanged="cbDeduction_CheckedChanged" />
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="lblDayValue" Visible="false" runat="server" Text="<%$ Resources:DayValue %>"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtDays" placeholder="Day Value" runat="server" Visible="false" type="Number" TabIndex="1" class="limiter required"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form_grid_4">
                                                <label class="field_title">
                                                    <asp:Label ID="lblDays" runat="server" Text="<%$ Resources:Days %>" Visible="false"></asp:Label></label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                                <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
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
