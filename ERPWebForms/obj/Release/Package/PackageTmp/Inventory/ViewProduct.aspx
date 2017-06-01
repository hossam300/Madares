<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/InventoryMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="ERPWebForms.Inventory.ViewProduct" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
                            <asp:Label ID="lblHeader" runat="server" Text="Create Product" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblProductInformation" runat="server" Text="Product Information" meta:resourcekey="lblProductInformationResource1"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label2" runat="server" Text="Product Name" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                        <div class="form_input">

                                            <div class="form_grid_4 alpha">
                                                <asp:Label ID="txtName" placeholder="Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtNameResource1"></asp:Label>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;
                                                <asp:Label ID="Label3" runat="server" Text="Serial Number" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:Label ID="txtSerialNum" placeholder="Serial Number" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtSerialNumResource1"></asp:Label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label1" runat="server" Text="Initial Amount in Stock" meta:resourcekey="Label1Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:Label ID="txtInitialAmount" placeholder="Initial Amount" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtInitialAmountResource1"></asp:Label>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;
                                                <asp:Label ID="Label4" runat="server" Text="Unit Cost" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:Label ID="txtCost" placeholder="Cost" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtCostResource1"></asp:Label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label5" runat="server" Text="Price" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:Label ID="txtPrice" placeholder="Price" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtPriceResource1"></asp:Label>
                                            </div>

                                            <label class="field_title">
                                                &nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Barcode" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:Label ID="txtBarcode" placeholder="Barcode" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBarcodeResource1"></asp:Label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label7" runat="server" Text="Category" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:DropDownList ID="ddlCategory" Enabled="False" runat="server" class="chzn-select" AppendDataBoundItems="True" TabIndex="13" Width="100%" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlCategoryResource1">
                                                    <asp:ListItem meta:resourcekey="ListItemResource1">Choose Category</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString2 %>" SelectCommand="SELECT [ID], [Name] FROM [Inv_ProductCatrgory] WHERE ([Active] = @Active)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="1" Name="Active" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Low Quantity" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:Label ID="txtLowQuantity" placeholder="Low Quantity" TextMode="Number" runat="server" Width="100%" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtLowQuantityResource1"></asp:Label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <fieldset style="border: 1px solid">
                                            <legend>
                                                <asp:Label ID="lblWearhousesHeader" runat="server" Text="Wearhouses" meta:resourcekey="lblWearhousesHeaderResource1"></asp:Label></legend>
                                            <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" meta:resourcekey="gridResource1">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="true" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Warehouse" FieldName="WarehouseID" VisibleIndex="5" Width="150px" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                                        <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="Name" ValueField="WarehouseID" EnableCallbackMode="True">
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Cost" Caption="Unit Cost" UnboundType="Decimal" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource2">
                                                        <PropertiesTextEdit>
                                                            <ValidationSettings>
                                                                <RegularExpression ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ErrorText="Amount Not valid" />
                                                            </ValidationSettings>
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Price" Caption="Selling Price" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource3">
                                                        <PropertiesTextEdit>
                                                            <ValidationSettings>
                                                                <RegularExpression ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ErrorText="Amount Not valid" />
                                                            </ValidationSettings>
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Barcode" Caption="Barcode" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Quantity" UnboundType="Integer" Caption="Product Quantity" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource5">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsPager NumericButtonCount="1000" PageSize="1000" Visible="False">
                                                </SettingsPager>
                                                <SettingsCommandButton>
                                                    <NewButton ButtonType="Image">
                                                        <Image IconID="actions_add_16x16">
                                                        </Image>
                                                    </NewButton>
                                                    <EditButton ButtonType="Image">
                                                        <Image IconID="edit_edit_16x16">
                                                        </Image>
                                                    </EditButton>
                                                    <DeleteButton ButtonType="Image">
                                                        <Image IconID="actions_cancel_16x16">
                                                        </Image>
                                                    </DeleteButton>
                                                </SettingsCommandButton>
                                            </dx:ASPxGridView>
                                        </fieldset>
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [ID] as WarehouseID, [Name] FROM [Inv_Warehouse] WHERE ([Active] = @Active)">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
