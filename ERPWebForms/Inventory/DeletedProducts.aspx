<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/InventoryMasterPage.Master" AutoEventWireup="true" CodeBehind="DeletedProducts.aspx.cs" Inherits="ERPWebForms.Inventory.DeletedProducts" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12 full_block">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Deleted Products " meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="btnProduct" runat="server" Text="Create New Product" Theme="PlasticBlue" OnClick="btnProduct_Click" meta:resourcekey="btnProductResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportExcel" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportExcel_Click" meta:resourcekey="btnExportExcelResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportWord" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportWord_Click" meta:resourcekey="btnExportWordResource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Moderno" AutoGenerateColumns="False" EnableTheming="True" Width="100%" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1" DataSourceID="SqlDataSource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Caption="ID"  ReadOnly="True" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False"></EditFormSettings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="SerialNumber" Caption="Serial Number" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Category" FieldName="Category" VisibleIndex="3" Width="150px" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                    <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="Catrgory" ValueField="CatrgoryID" EnableCallbackMode="True">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Warehouse" FieldName="Warehouse" VisibleIndex="4" Width="150px" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                    <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="Warehouse" ValueField="Warehouse" EnableCallbackMode="True">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="Quantity" Caption="Quantity" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Cost" Caption="Cost" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Price" Caption="Price" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Barcode" Caption="Barcode" VisibleIndex="8" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" Caption="View/Active" ShowEditButton="True" VisibleIndex="10" meta:resourcekey="GridViewCommandColumnResource1">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnView" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                            <Image IconID="actions_show_16x16">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="btnActive" meta:resourcekey="GridViewCommandColumnCustomButtonResource2">
                                            <Image IconID="actions_refresh2_16x16">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="9" meta:resourcekey="GridViewDataCheckColumnResource1">
                                </dx:GridViewDataCheckColumn>
                            </Columns>
                            <SettingsPager NumericButtonCount="1000" PageSize="1000" Visible="False">
                            </SettingsPager>
                            <Settings ShowFilterRow="True"></Settings>
                            <SettingsCommandButton>

                                <EditButton ButtonType="Image">
                                    <Image IconID="edit_edit_16x16">
                                    </Image>
                                </EditButton>

                            </SettingsCommandButton>
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT Inv_Products.ID, Inv_Products.Name, Inv_Products.SerialNumber, Inv_Products.Category, Inv_Warehouse.Name AS Warehouse, Inv_ProductWearhous.Active, Inv_ProductWearhous.Quantity, Inv_ProductWearhous.Cost, Inv_ProductWearhous.Price, Inv_ProductWearhous.Barcode FROM Inv_Products INNER JOIN Inv_ProductWearhous ON Inv_Products.ID = Inv_ProductWearhous.ProductID INNER JOIN Inv_Warehouse ON Inv_ProductWearhous.WarehouseID = Inv_Warehouse.ID WHERE (dbo.Inv_ProductWearhous.Active = 0)"></asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [Name] as Warehouse FROM [Inv_Warehouse] Where Active=1"></asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID] as CatrgoryID, [Name] as Catrgory FROM [Inv_ProductCatrgory] WHERE ([Active] = @Active)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
