﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="ExcelSheetStyle.aspx.cs" Inherits="ERPWebForms.HR.ExcelSheetStyle" %>

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
                            <asp:Label ID="Label2" runat="server" Text="Excel Sheet Styles" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Create New Excel Sheet Style" Theme="PlasticBlue" OnClick="ASPxButton3_Click" meta:resourcekey="ASPxButton3Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" OnClick="ASPxButton1_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" OnClick="ASPxButton2_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" KeyFieldName="SheetStyleID" PreviewFieldName="SheetStyleID" meta:resourcekey="ASPxGridView1Resource1" DataSourceID="SqlDataSource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="SheetStyleID" Caption="ID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="SheetStyleName" Caption="Sheet Style Name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="CreationDate" Caption="CreationDate" VisibleIndex="3" meta:resourcekey="GridViewDataDateColumnResource1">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource2">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                            <Image IconID="actions_show_16x16">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowSelectCheckbox="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsPager NumericButtonCount="999999999" PageSize="999999999" Visible="False">
                            </SettingsPager>
                            <Settings ShowFilterRow="True"></Settings>
                            <SettingsCommandButton>
                                <EditButton ButtonType="Image">
                                    <Image IconID="edit_edit_16x16">
                                    </Image>
                                </EditButton>
                            </SettingsCommandButton>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [SheetStyleID], [SheetStyleName], [CreationDate] FROM [HR_ExcelSheetStyle]"></asp:SqlDataSource>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>