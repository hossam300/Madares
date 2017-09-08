<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="BusList.aspx.cs" Inherits="ERPWebForms.StudentAfair.BusList" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                            <asp:Label ID="Label3" runat="server" Text="Buses" meta:resourcekey="Label3Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="btnNewDriver" runat="server" Text="Create New Bus" Theme="PlasticBlue" OnClick="btnNewDriver_Click" meta:resourcekey="btnNewDriverResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportDriverx" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportDriverx_Click" meta:resourcekey="btnExportDriverxResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportDriverw" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportDriverw_Click" meta:resourcekey="btnExportDriverwResource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" DataSourceID="SqlDataSource1" meta:resourcekey="ASPxGridView1Resource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False"></EditFormSettings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="BusNumber" Caption="Bus Number" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="EndLicenseDate" Caption="End License Date" VisibleIndex="2" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="NumberOfSeats" Caption="Number Of Seats" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="BusCondition" Caption="Bus Condition" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="DriverId" Caption="Driver" VisibleIndex="5" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                    <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="Name" ValueField="DriverId">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource1">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                            <Image IconID="actions_show_16x16">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsPager NumericButtonCount="50" PageSize="50" Visible="true">
                            </SettingsPager>
                            <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" ShowFooter="true" />
                            <SettingsCommandButton>
                                <EditButton ButtonType="Image">
                                    <Image IconID="edit_edit_16x16">
                                    </Image>
                                </EditButton>
                            </SettingsCommandButton>
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [BusNumber], [EndLicenseDate], [NumberOfSeats], [BusCondition], [DriverId] FROM [Buses]"></asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID] as DriverId, [Name] FROM [Drivers]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
