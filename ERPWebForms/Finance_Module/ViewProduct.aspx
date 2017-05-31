﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="ERPWebForms.Finance_Module.ViewProduct" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowLoginWindow() {
            pcLogin.Show();
        }
        function ShowCreateAccountWindow() {
            pcCreateAccount.Show();
            tbUsername.Focus();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label5" runat="server" Text="Product Details" meta:resourcekey="Label5Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Product Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Product ID" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblProductID" class="limiter required" meta:resourcekey="lblProductIDResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Product Name" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblProductName" class="limiter required" meta:resourcekey="lblProductNameResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Cost" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblCost" class="limiter required" meta:resourcekey="lblCostResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;<asp:Label ID="Label6" runat="server" Text="Price" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblPrice" class="limiter required" meta:resourcekey="lblPriceResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Creation Date" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblCreationDate" class="limiter required" meta:resourcekey="lblCreationDateResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;<asp:Label ID="Label8" runat="server" Text="Last Modified Date" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblLastModifiedDate" class="limiter required" meta:resourcekey="lblLastModifiedDateResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label9" runat="server" Text="Type" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblType" class="limiter required" meta:resourcekey="lblTypeResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label10" runat="server" Text="Price Items" meta:resourcekey="Label10Resource1"></asp:Label></legend>
                                <div>
                                    <br />
                                </div>
                                <div>
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView2" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView2_CustomButtonCallback" OnStartRowEditing="ASPxGridView2_StartRowEditing" AutoGenerateColumns="False" meta:resourcekey="ASPxGridView2Resource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="false" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" Caption="ID" UnboundType="Integer" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Description" UnboundType="String" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Amount" VisibleIndex="3" Caption="Amount" UnboundType="Decimal" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Seq" VisibleIndex="4" Caption="Sequence" UnboundType="Integer" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Account Name" FieldName="GLAccountID" UnboundType="String" VisibleIndex="5" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                            <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="Name" ValueField="GLAccountID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="False">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" />
                                </dx:ASPxGridView>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT Fin_ProductPriceItems.Description, Fin_ProductPriceItems.Amount, Fin_ProductPriceItems.Seq, Fin_GLAccount.Name FROM Fin_ProductPriceItems INNER JOIN Fin_GLAccount ON Fin_ProductPriceItems.GLAccountID = Fin_GLAccount.ID WHERE (Fin_ProductPriceItems.ProductID = @ProductID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="ID" Name="ProductID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label11" runat="server" Text="Customer Items" meta:resourcekey="Label11Resource1"></asp:Label></legend>
                                <div>
                                    <dx:ASPxButton ID="btnNewCustomerItem" runat="server" Text="Create New Customer Item" Theme="PlasticBlue" meta:resourcekey="btnNewCustomerItemResource1">
                                        <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }" />
                                    </dx:ASPxButton>
                                    <br />
                                    <dx:ASPxPopupControl ID="pcLogin2" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcLogin" Width="750px" Height="400px"
                                        HeaderText="Create New Customer Item" AllowDragging="True" PopupAnimationType="None" EnableViewState="False" ContentUrl="~/Finance_Module/CreateCustomerItem.aspx">
                                        <ContentStyle>
                                            <Paddings PaddingBottom="5px" />
                                        </ContentStyle>
                                    </dx:ASPxPopupControl>
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Balance" Caption="Balance" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" VisibleIndex="1" ReadOnly="True" meta:resourcekey="GridViewDataTextColumnResource6">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn Caption="Select" ShowSelectCheckbox="True" VisibleIndex="0" ShowClearFilterButton="True" meta:resourcekey="GridViewCommandColumnResource2">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource3">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                    <Image IconID="actions_show_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="False">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" />
                                    <SettingsCommandButton>
                                        <EditButton ButtonType="Image">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </EditButton>
                                    </SettingsCommandButton>
                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server"></dx:ASPxGridViewExporter>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString2 %>' SelectCommand="SELECT Fin_CustomerItems.Balance, Fin_CustomerItems.ID, Fin_Customer.Name, Fin_Customer.TotalBalance, Fin_Customer.TotalBuyedAmount FROM Fin_CustomerItems INNER JOIN Fin_Customer ON Fin_CustomerItems.CustomerID = Fin_Customer.ID WHERE (Fin_CustomerItems.ProductID = @ID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="ID" Name="ID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT Fin_GLAccount.ID As GLAccountID, Fin_GLAccount.Name FROM Fin_GLAccount "></asp:SqlDataSource>
</asp:Content>