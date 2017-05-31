<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="AddSupplierInvoice.aspx.cs" Inherits="ERPWebForms.Finance_Module.AddSupplierInvoice" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function OnNewClick(s, e) {
            grid.AddNewRow();
        }
        function OnEditClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.StartEditRow(index);
        }
        function OnSaveClick(s, e) {
            grid.UpdateEdit();
        }
        function OnCancelClick(s, e) {
            grid.CancelEdit();
        }
        function OnDeleteClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.DeleteRow(index);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12 full_block">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Add New Supplier Invoice" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                        <div id="top_tabby">
                        </div>
                    </div>
                    <div class="widget_content">
                        <h3>
                            <asp:Label ID="Label9" runat="server" Text="Supplier Invoice" meta:resourcekey="Label9Resource1"></asp:Label></h3>
                        <div id="form103" class="form_container left_label">
                            <fieldset id="Fieldset1" title="" style="border: 1px solid" runat="server">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Supplier Invoice Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <p>
                                    <asp:Label ID="Label2" runat="server" Text="Fill out the required fields to help identify the Supplier Invoice Information." meta:resourcekey="Label2Resource1"></asp:Label>
                                </p>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Supplier" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">

                                                <div class="form_grid_4">
                                                    <dx:ASPxComboBox ID="ddlSupplier" runat="server" AppendDataBoundItems="true" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" DataSourceID="SqlDataSource2" TextField="Name" ValueField="ID" meta:resourcekey="ddlSupplierResource1">
                                                    </dx:ASPxComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlSupplier" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Fin_Supplier]"></asp:SqlDataSource>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="Invoice Number" meta:resourcekey="Label10Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtInvoiceNumber" placeholder="Invoice Number" runat="server" type="Number" Style="width: 100%" TabIndex="1" class="limiter required" meta:resourcekey="txtInvoiceNumberResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtInvoiceNumber" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <br />
                                                <asp:Label ID="Label4" runat="server" Text="Cash GlAccount" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4">
                                                    <dx:ASPxComboBox ID="ddlCashGlAccount" runat="server" AppendDataBoundItems="true" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" DataSourceID="SqlDataSource3" TextField="Name" ValueField="ID" meta:resourcekey="ddlCashGlAccountResource1">
                                                    </dx:ASPxComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlCashGlAccount" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="Select Fin_GLAccount.ID,Fin_GLAccount.Name,'gl' as [type] from Fin_GLAccount union select Fin_Bank.ID*-1,Fin_Bank.BankName,'dp' as [type]  from Fin_Bank"></asp:SqlDataSource>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="liability GlAccount" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <dx:ASPxComboBox ID="ddlliabilityGlAccount" runat="server" AppendDataBoundItems="true" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" DataSourceID="SqlDataSource5" TextField="Name" ValueField="ID" meta:resourcekey="ddlliabilityGlAccountResource1">
                                                    </dx:ASPxComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlliabilityGlAccount" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource5" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="Select Fin_GLAccount.ID,Fin_GLAccount.Name,'gl' as [type] from Fin_GLAccount union select Fin_Bank.ID*-1,Fin_Bank.BankName,'dp' as [type]  from Fin_Bank"></asp:SqlDataSource>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label6" runat="server" Text="Total Amount" meta:resourcekey="Label6Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_2">
                                                    <asp:TextBox ID="txtTotalAmount" placeholder="Total Amount" runat="server" type="Number" TabIndex="1" class="limiter required" meta:resourcekey="txtTotalAmountResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtTotalAmount" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label11" runat="server" Text="Paid Amount" meta:resourcekey="Label11Resource1"></asp:Label></label>
                                                <div class="form_grid_2">
                                                    <asp:TextBox ID="txtPaidAmount" placeholder="PaidAmount" runat="server" type="Number" TabIndex="1" class="limiter required" meta:resourcekey="txtPaidAmountResource1" AutoPostBack="True" OnTextChanged="txtPaidAmount_TextChanged"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtPaidAmount" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="CustomValidator1_ServerValidate" ErrorMessage="<%$ resources:BalanceNotEnough %>" ForeColor="Red"></asp:CustomValidator>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label13" runat="server" Text="Remaining" meta:resourcekey="Label13Resource1"></asp:Label></label>
                                                <div class="form_grid_2">
                                                    <asp:TextBox ID="txtRemaining" placeholder="Remaining" runat="server" type="Number" TabIndex="1" class="limiter required" meta:resourcekey="txtRemainingResource1" ReadOnly="True"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label12" runat="server" Text="Description" meta:resourcekey="Label12Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_8 alpha">
                                                    <asp:TextBox ID="txtDescription" placeholder="Description" runat="server" TextMode="MultiLine" Columns="5" Style="width: 100%" TabIndex="1" class="limiter required" meta:resourcekey="txtDescriptionResource1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset id="Fieldset2" title="" runat="server">
                                <legend>
                                    <asp:Label ID="Label7" runat="server" Text="Products" meta:resourcekey="Label7Resource1"></asp:Label></legend>
                                <p>
                                    <asp:Label ID="Label8" runat="server" Text="Add Products for this Invioce ." meta:resourcekey="Label8Resource1"></asp:Label>
                                </p>
                                <div>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID" OnRowDeleting="grid_RowDeleting"
                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" Caption="ID" UnboundType="Integer" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="ProductID" VisibleIndex="2" Caption="Product" UnboundType="String" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                            <PropertiesComboBox DataSourceID="SqlDataSource4" TextField="Name" ValueField="ProductID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="6" meta:resourcekey="GridViewCommandColumnResource2">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Account Name" FieldName="GLAccountID" UnboundType="String" VisibleIndex="5" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                            <PropertiesComboBox DataSourceID="SqlDataSource1" TextField="Name" ValueField="GLAccountID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Item Price" FieldName="itemprice" UnboundType="Decimal" VisibleIndex="3">
                                            <PropertiesSpinEdit DisplayFormatString="g">
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Quantity" FieldName="Quantity" UnboundType="Integer" VisibleIndex="4">
                                            <PropertiesSpinEdit DisplayFormatString="g">
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="False">
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
                            <asp:Button runat="server" ID="btnEdit" Text="Edit" CssClass="finish" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                            <asp:Button runat="server" ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" Text="Save" CssClass="finish" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="finish" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" CausesValidation="False" />
                        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT Fin_GLAccount.ID As GLAccountID, Fin_GLAccount.Name FROM Fin_GLAccount "></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [ID] As ProductID, [Name] FROM [Fin_Product]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>