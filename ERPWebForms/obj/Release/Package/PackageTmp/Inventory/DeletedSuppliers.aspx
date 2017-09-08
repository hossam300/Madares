﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/InventoryMasterPage.Master" AutoEventWireup="true" CodeBehind="DeletedSuppliers.aspx.cs" Inherits="ERPWebForms.Inventory.DeletedSuppliers" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="Deleted Suppliers" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="btnSupplier" runat="server" Text="Create New Supplier" Theme="PlasticBlue" OnClick="btnSupplier_Click" meta:resourcekey="btnSupplierResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportExcel" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportExcel_Click" meta:resourcekey="btnExportExcelResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportWord" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportWord_Click" meta:resourcekey="btnExportWordResource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Moderno" AutoGenerateColumns="False" KeyFieldName="ID" EnableTheming="True" Width="100%" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1" DataSourceID="SqlDataSource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Caption="ID"  VisibleIndex="0" ReadOnly="True" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Address" Caption="Address" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Email" Caption="Email" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Phone" Caption="Phone" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="Active" Caption="Active" VisibleIndex="6" meta:resourcekey="GridViewDataCheckColumnResource1">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" Caption="View/Active" ShowEditButton="True" VisibleIndex="8" meta:resourcekey="GridViewCommandColumnResource1">
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
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name], [Address], [Email], [Phone], [Remarks], [Active] FROM [Inv_Supplier] Where Active=0"></asp:SqlDataSource>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
