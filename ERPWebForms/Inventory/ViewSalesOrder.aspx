<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/InventoryMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewSalesOrder.aspx.cs" Inherits="ERPWebForms.Inventory.ViewSalesOrder" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                            <asp:Label ID="lblHeader" runat="server" Text="Sales Order Items" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblProductInformation" runat="server" Text="Order Information" meta:resourcekey="lblProductInformationResource1"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <fieldset style="border: 1px solid">
                                            <legend>
                                                <asp:Label ID="lblWearhousesHeader" runat="server" Text="Products" meta:resourcekey="lblWearhousesHeaderResource1"></asp:Label></legend>
                                            <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID"  meta:resourcekey="gridResource1" EnableCallBacks="False">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="true" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Product" FieldName="ProductID" VisibleIndex="1" meta:resourcekey="GridViewDataComboBoxColumnResource1" Width="150px">
                                                        <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="Name" ValueField="ProductID" EnableCallbackMode="True">
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Price" Caption="Unit Price" UnboundType="Decimal" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2">
                                                        <PropertiesTextEdit>
                                                            <ValidationSettings>
                                                                <RegularExpression ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ErrorText="Amount Not valid" />
                                                            </ValidationSettings>
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Quantity" UnboundType="Integer" Caption="Product Quantity" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Discount" UnboundType="Integer" Caption="Product Quantity" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Total" UnboundType="Integer" Caption="Total" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource5">
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
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label2" runat="server" Text="Customers" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:DropDownList ID="ddlCustomer" Enabled="False" runat="server" class="chzn-select" AppendDataBoundItems="True" TabIndex="13" Width="100%" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlCustomerResource1">
                                                    <asp:ListItem meta:resourcekey="ListItemResource1">Choose Customer</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString2 %>" SelectCommand="SELECT [ID], [Name] FROM [Inv_Customer] WHERE ([Active] = @Active)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="1" Name="Active" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;
                                                <asp:Label ID="Label3" runat="server" Text="Delivery Date" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:Label ID="txtDeliveryDate" placeholder="Delivery Date" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtDeliveryDateResource1"></asp:Label>
                                               </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblRemarks" runat="server" Text="Remarks" meta:resourcekey="lblRemarksResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_10 alpha">
                                                <asp:TextBox TextMode="MultiLine" Enabled="False" ID="txtRemarks" placeholder="Remarks" Columns="5" Rows="5" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtRemarksResource1"></asp:TextBox>
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT Inv_ProductWearhous.ID AS ProductID, 'W: ' + Inv_Warehouse.Name + ' P: ' + Inv_Products.Name AS Name FROM Inv_Products INNER JOIN Inv_ProductWearhous ON Inv_Products.ID = Inv_ProductWearhous.ProductID INNER JOIN Inv_Warehouse ON Inv_ProductWearhous.WarehouseID = Inv_Warehouse.ID WHERE (Inv_Products.Active = @Active)">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
