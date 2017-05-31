<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="ERPWebForms.Finance_Module.AddCustomer" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="<%$ Resources: lblHeaderResource1 %>"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="lblCustomerHeader" runat="server" Text="<%$ Resources:CustomerHeader %>"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="lblCustomerName" runat="server" Text="<%$ Resources:lblCustomerNameResource1 %>"></asp:Label></label>
                                            <div class="form_input">

                                                <div class="form_grid_8 alpha">
                                                    <asp:TextBox ID="txtCustomerName" placeholder="Customer Name" runat="server" type="text" TabIndex="1" class="limiter required"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="<%$ Resources:btnEditResource1 %>" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                                <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSaveResource1 %>" class="btn_small btn_blue" OnClick="btnSave_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                                <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:btnCancelResource1 %>" class="btn_small btn_orange" CausesValidation="False" OnClick="btnCancel_Click" />
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