<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/InventoryMasterPage.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="ERPWebForms.Inventory.AddCustomer" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="Create Customer"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblCustomerInformation" runat="server" Text="Customer Information"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label2" runat="server" Text="Customer Name"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:TextBox ID="txtName" placeholder="Name" runat="server" type="text" TabIndex="1" class="limiter required"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtmail" placeholder="Email" TextMode="Email" runat="server" type="text" TabIndex="1" class="limiter required"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtmail" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label1" runat="server" Text="Phone"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:TextBox ID="txtPhone" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtPhone" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label4" runat="server" Text="Remarks"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtRemarks" placeholder="Remarks" TextMode="MultiLine" runat="server" type="text" TabIndex="1" class="limiter required"></asp:TextBox>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:DropDownList ID="ddlType" runat="server" class="chzn-select" TabIndex="13" Width="100%">
                                                    <asp:ListItem>Choose Type</asp:ListItem>
                                                    <asp:ListItem Value="1">Individual</asp:ListItem>
                                                    <asp:ListItem Value="2">Company</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="ddlType" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtAddress" placeholder="Address" TextMode="MultiLine" runat="server" type="text" TabIndex="1" class="limiter required"></asp:TextBox>
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
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" CausesValidation="False" />
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
