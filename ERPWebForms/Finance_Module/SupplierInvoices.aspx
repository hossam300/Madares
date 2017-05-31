<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="SupplierInvoices.aspx.cs" Inherits="ERPWebForms.Finance_Module.SupplierInvoices" %>

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
                            <asp:Label ID="Label2" runat="server" Text="Supplier Invoices" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Create New Supplier Invoice" Theme="PlasticBlue" OnClick="ASPxButton3_Click" meta:resourcekey="ASPxButton3Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" OnClick="ASPxButton1_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" OnClick="ASPxButton2_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Moderno" AutoGenerateColumns="False" Width="100%" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" KeyFieldName="ID" meta:resourcekey="ASPxGridView1Resource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Caption="" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1" Width="50px">
                                    <EditFormSettings Visible="False"></EditFormSettings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="InvoiceNumber" Caption="Invoice Number" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2" Width="120px"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TotalAmount" Caption="Total Amount" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PaidAmount" Caption="Paid Amount" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="RemainingAmount" Caption="Remaining Amount" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource4" Width="135px"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" Caption="Description" VisibleIndex="9" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="SupplierName" Caption="Supplier Name" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource1" Width="200px">
                                    <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="Name" ValueField="ID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="CashGLAcct" Caption="Cash GL Acct" VisibleIndex="7" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                    <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="Name" ValueField="GLAccountID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="LiabilityGLAcct" Caption="Liability GL Acct" VisibleIndex="8" meta:resourcekey="GridViewDataComboBoxColumnResource3" Width="120px">
                                    <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="Name" ValueField="GLAccountID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="11" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource1">
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
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT Fin_SupplierInvoice.ID, Fin_SupplierInvoice.InvoiceNumber, Fin_Supplier.Name AS SupplierName, Fin_SupplierInvoice.PaidAmount, Fin_SupplierInvoice.RemainingAmount, Fin_SupplierInvoice.TotalAmount, Fin_SupplierInvoice.CashGLAcct, Fin_SupplierInvoice.LiabilityGLAcct, Fin_SupplierInvoice.Description FROM Fin_SupplierInvoice INNER JOIN Fin_Supplier ON Fin_SupplierInvoice.SupplierID = Fin_Supplier.ID INNER JOIN Fin_GLAccount ON Fin_SupplierInvoice.CashGLAcct = Fin_GLAccount.ID INNER JOIN Fin_GLAccount AS Fin_GLAccount_1 ON Fin_SupplierInvoice.LiabilityGLAcct = Fin_GLAccount_1.ID"></asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Fin_Supplier]"></asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="Select Fin_GLAccount.ID  as GLAccountID,Fin_GLAccount.Name,'gl' as [type] from Fin_GLAccount union select Fin_Bank.ID*-1 as GLAccountID,Fin_Bank.BankName,'dp' as [type]  from Fin_Bank"></asp:SqlDataSource>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>