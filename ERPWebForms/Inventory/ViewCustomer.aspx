﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/InventoryMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewCustomer.aspx.cs" Inherits="ERPWebForms.Inventory.ViewCustomer" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                            <asp:Label ID="lblHeader" runat="server" Text="Create Customer" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblCustomerInformation" runat="server" Text="Customer Information" meta:resourcekey="lblCustomerInformationResource1"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label2" runat="server" Text="Customer Name" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:Label ID="txtName" placeholder="Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtNameResource1"></asp:Label>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label3" runat="server" Text="Email" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:Label ID="txtmail" placeholder="Email" TextMode="Email" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtmailResource1"></asp:Label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label1" runat="server" Text="Phone" meta:resourcekey="Label1Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:Label ID="txtPhone" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtPhoneResource1"></asp:Label>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label4" runat="server" Text="Remarks" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtRemarks" Enabled="False" placeholder="Remarks" TextMode="MultiLine" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtRemarksResource1"></asp:TextBox>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label5" runat="server" Text="Phone" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:DropDownList ID="ddlType" runat="server" Enabled="False" class="chzn-select" TabIndex="13" Width="100%" meta:resourcekey="ddlTypeResource1">
                                                    <asp:ListItem meta:resourcekey="ListItemResource1">Choose Type</asp:ListItem>
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">Individual</asp:ListItem>
                                                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">Company</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label6" runat="server" Text="Address" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:Label ID="txtAddress" placeholder="Address" TextMode="MultiLine" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtAddressResource1"></asp:Label>
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
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" meta:resourcekey="btnEditResource1" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" CausesValidation="False" meta:resourcekey="btnCancelResource1" />
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
