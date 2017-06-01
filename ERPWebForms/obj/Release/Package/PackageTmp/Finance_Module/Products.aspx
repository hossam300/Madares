﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ERPWebForms.Finance_Module.Products" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12 full_block">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label2" runat="server" Text="Products" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Create New Product" Theme="PlasticBlue" OnClick="ASPxButton3_Click" meta:resourcekey="ASPxButton3Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" OnClick="ASPxButton1_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" OnClick="ASPxButton2_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Moderno" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False"></EditFormSettings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OperatorID" Caption="Operator ID" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Cost" Caption="Cost" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Price" Caption="Price" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TypeID" Caption="Type ID" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="CreationDate" Caption="Creation Date" VisibleIndex="7" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource1">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                            <Image IconID="actions_show_16x16">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Caption="Select" SelectAllCheckboxMode="AllPages" ShowClearFilterButton="True" meta:resourcekey="GridViewCommandColumnResource2">
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsCommandButton>

                                <EditButton ButtonType="Image">
                                    <Image IconID="edit_edit_16x16">
                                    </Image>
                                </EditButton>
                            </SettingsCommandButton>
                            <SettingsPager NumericButtonCount="50" PageSize="50" Visible="true">
                            </SettingsPager>

                            <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" ShowFooter="true" />
                            <Settings ShowFilterRow="True"></Settings>
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>