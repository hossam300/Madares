﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/InventoryMasterPage.Master" AutoEventWireup="true" CodeBehind="AddNewItemToStock.aspx.cs" Inherits="ERPWebForms.Inventory.AddNewItemToStock" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="Add New Item To Stock" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblProductCategoryInformation" runat="server" Text="Restock Information" meta:resourcekey="lblProductCategoryInformationResource1"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label2" runat="server" Text="Product Name" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:DropDownList ID="ddlProduct" runat="server" class="chzn-select" AppendDataBoundItems="True" TabIndex="13" Width="100%" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlProductResource1">
                                                    <asp:ListItem meta:resourcekey="ListItemResource1">Choose Product</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString2 %>' SelectCommand="SELECT [ID], [Name] FROM [Inv_Products] WHERE ([Active] = @Active)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="ddlProduct" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label3" runat="server" Text="Supplier" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:DropDownList ID="ddlSupplier" runat="server" class="chzn-select" AppendDataBoundItems="True" TabIndex="13" Width="100%" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlSupplierResource1">
                                                    <asp:ListItem meta:resourcekey="ListItemResource2">Choose Supplier</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString2 %>' SelectCommand="SELECT [ID], [Name] FROM [Inv_Supplier] WHERE ([Active] = @Active)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="ddlSupplier" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label1" runat="server" Text="Warehouse" meta:resourcekey="Label1Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:DropDownList ID="ddlWarehouse" runat="server" class="chzn-select" AppendDataBoundItems="True" TabIndex="13" Width="100%" DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlWarehouseResource1">
                                                    <asp:ListItem meta:resourcekey="ListItemResource3">Choose Warehouse</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString2 %>' SelectCommand="SELECT [ID], [Name] FROM [Inv_Warehouse] WHERE ([Active] = @Active)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="ddlWarehouse" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label4" runat="server" Text="Quantity" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtQuantity" placeholder="Quantity" TextMode="Number" Width="100%" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtQuantityResource1"></asp:TextBox>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label5" runat="server" Text="Total Cost" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:TextBox ID="txtTotalCost" placeholder="Total Cost" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtTotalCostResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtTotalCost" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator4Resource1"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label6" runat="server" Text="Unit Cost" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtUnitCost" placeholder="Unit Cost" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtUnitCostResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="txtUnitCost" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator5Resource1"></asp:RequiredFieldValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label7" runat="server" Text="Upload zip of receipts" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:FileUpload ID="FileUpload1" runat="server" meta:resourcekey="FileUpload1Resource1" />
                                                <a href="#" runat="server" id="hrefURL" name="hrefURL" visible="false"></a>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks" meta:resourcekey="lblRemarksResource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox TextMode="MultiLine" ID="txtRemarks" placeholder="Remarks" Columns="5" Rows="5" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtRemarksResource1"></asp:TextBox>
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
                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" meta:resourcekey="btnSaveResource1" />
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
