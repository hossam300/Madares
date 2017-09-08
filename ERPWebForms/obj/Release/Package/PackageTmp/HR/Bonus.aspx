<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="Bonus.aspx.cs" Inherits="ERPWebForms.HR.Bonus" %>

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
                            <asp:Label ID="Label2" runat="server" Text="Bonus" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Create New bonus" Theme="PlasticBlue" OnClick="ASPxButton3_Click" meta:resourcekey="ASPxButton3Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" OnClick="ASPxButton1_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" OnClick="ASPxButton2_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div id="grid">
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" KeyFieldName="BonceID" PreviewFieldName="BonceID" meta:resourcekey="ASPxGridView1Resource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="BonceID" Caption="ID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="EmpID" Caption="Employee" VisibleIndex="2" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                    <PropertiesComboBox DataSourceID="SqlDataSource2" ValueField="EmpID" TextField="EmpName"></PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="Type" Caption="Type" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Value" Caption="Value" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Month" Caption="Month" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Year" Caption="Year" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource5">
                                </dx:GridViewDataTextColumn>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT HR_Bonces.BonceID, HR_Employees.EmpName, HR_Bonces.Type, HR_Bonces.Value FROM HR_Bonces INNER JOIN HR_Employees ON HR_Bonces.EmpID = HR_Employees.EmpName"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [EmpID], [EmpName] FROM [HR_Employees]"></asp:SqlDataSource>
                    </div>
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                </div>
            </div>
        </div>
    </div>
</asp:Content>