<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="AddBank.aspx.cs" Inherits="ERPWebForms.Finance_Module.AddBank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Create Bank" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblBankInformation" runat="server" Text="Bank Information" meta:resourcekey="lblBankInformationResource1"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblBankName" Text="Bank Name" runat="server" meta:resourcekey="lblBankNameResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:TextBox ID="txtBankName" placeholder="Bank Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBankNameResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBankName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="field_title">
                                                <asp:Label ID="lblAccountNumber" Text="Account Number" runat="server" meta:resourcekey="lblAccountNumberResource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtAccountNumber" placeholder="Account Number" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtAccountNumberResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAccountNumber" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblstartingBalance" Text="starting Balance" runat="server" meta:resourcekey="lblstartingBalanceResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:TextBox ID="txtstartingBalance" placeholder="starting Balance" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtstartingBalanceResource1" Text="0"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtstartingBalance" ErrorMessage="<%$ resources:AmountNotValid %>" ForeColor="Red" ValidationExpression="[0-9]{1,18}(\.[0-9]{1,3})?"></asp:RegularExpressionValidator>
                                            </div>
                                            <label class="field_title">
                                                <asp:Label ID="lblCurrentBalance" Text="Current Balance" runat="server" meta:resourcekey="lblCurrentBalanceResource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtCurrentBalance" placeholder="Current Balance" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtCurrentBalanceResource1" Text="0">0</asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCurrentBalance" ErrorMessage="<%$ resources:AmountNotValid %>" ForeColor="Red" ValidationExpression="[0-9]{1,18}(\.[0-9]{1,3})?"></asp:RegularExpressionValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblBranchAddress" Text="Bank Address" runat="server" meta:resourcekey="lblBranchAddressResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_8 alpha">
                                                <asp:TextBox TextMode="MultiLine" ID="txtlname" Columns="5" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtlnameResource1"></asp:TextBox>
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
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
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
