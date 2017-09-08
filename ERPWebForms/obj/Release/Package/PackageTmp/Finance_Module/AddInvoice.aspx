<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="AddInvoice.aspx.cs" Inherits="ERPWebForms.Finance_Module.AddInvoice" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
        <div id="Div1">
            <div class="grid_container">
                <div class="grid_12 full_block">
                    <div class="widget_wrap">
                        <div class="widget_top">
                            <span class="h_icon list"></span>
                            <h6>
                                <asp:Label ID="lblHeader" runat="server" Text="<%$ Resources:lblHeaderResource1.Text %>"></asp:Label></h6>
                        </div>
                        <div id="top_tabby">
                        </div>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <fieldset title="Invoice Information" style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="lblInvoiceInformation" runat="server" Text="Invoice Information" meta:resourcekey="lblInvoiceInformationResource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="lblInvoiceNumber" runat="server" Text="Invoice Number" meta:resourcekey="lblInvoiceNumberResource1"></asp:Label></label>
                                            <div class="form_input">

                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtinvoiceNum" placeholder="Invoice Number" runat="server" Style="width: 100%" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtinvoiceNumResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtinvoiceNum" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtinvoiceNum" ErrorMessage="<%$ resources:InvoiceNoRepeated %>" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCustomer" runat="server" Text="Customer" meta:resourcekey="lblCustomerResource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <dx:ASPxComboBox ID="ddlCustomer" runat="server" DataSourceID="SqlDataSource1" ValueField="ID" TextField="Name" ValueType="System.String" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AutoPostBack="True" Height="10px" Theme="Default" Width="100%"></dx:ASPxComboBox>
                                                    <%--<asp:DropDownList ID="ddlCustomer" runat="server" type="text" AutoPostBack="True" AppendDataBoundItems="True" TabIndex="1" Style="width: 100%" class="chzn-select" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" meta:resourcekey="ddlCustomerResource1">--%>
                                                    <%--<asp:ListItem Value="" Selected="True" meta:resourcekey="ListItemResource1">Choose Customer</asp:ListItem>--%>
                                                    <%--</asp:DropDownList>--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlCustomer" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Fin_Customer]"></asp:SqlDataSource>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="lblAmount" runat="server" Text="Amount" meta:resourcekey="lblAmountResource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtAmount" placeholder="Amount" AutoPostBack="True" Width="100%" runat="server" type="text" TabIndex="1" class="limiter required" OnTextChanged="txtAmount_TextChanged" meta:resourcekey="txtAmountResource1">0</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtAmount" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtProductPrice" ControlToValidate="txtAmount" ErrorMessage="<%$ resources:AmountPrice %>" ForeColor="Red" Operator="LessThanEqual"></asp:CompareValidator>
                                                    <asp:CustomValidator ID="CompareValidator2" runat="server" ControlToValidate="txtAmount" ErrorMessage="<%$ resources:AmountRemaining %>" ForeColor="Red" OnServerValidate="CompareValidator2_ServerValidate"></asp:CustomValidator>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;
                                            	&nbsp;&nbsp;
                                        <asp:Label ID="lblProduct" runat="server" Text="Product" meta:resourcekey="lblProductResource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <dx:ASPxComboBox ID="ddlProduct" runat="server" AutoPostBack="True" type="text" TabIndex="1" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TextField="Name" ValueField="ID" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" meta:resourcekey="ddlProductResource1">
                                                    </dx:ASPxComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlProduct" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <!-- <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Fin_Product]"></asp:SqlDataSource>-->
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="lblProductPrice" runat="server" Text="Product Price" meta:resourcekey="lblProductPriceResource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtProductPrice" placeholder="Amount" AutoPostBack="True" Width="100%" runat="server" type="text" TabIndex="1" class="limiter required" ReadOnly="True" meta:resourcekey="txtProductPriceResource1">0</asp:TextBox>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblGLAccount" runat="server" Text="GL Account" meta:resourcekey="lblGLAccountResource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <dx:ASPxComboBox ID="ddlGLAcct" runat="server" AutoPostBack="True" type="text" TabIndex="1" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" DataSourceID="SqlDataSource4" TextField="Name" ValueField="ID" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" meta:resourcekey="ddlGLAcctResource1">
                                                    </dx:ASPxComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlGLAcct" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <label class="field_title">
                                                    </label>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="Select Fin_GLAccount.ID,Fin_GLAccount.Name,'gl' as [type] from Fin_GLAccount union select Fin_Bank.ID*-1,Fin_Bank.BankName,'dp' as [type]  from Fin_Bank"></asp:SqlDataSource>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="lblRemainingAmount" runat="server" Text="Remaining Amount" meta:resourcekey="lblRemainingAmountResource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtRemainingAmount" placeholder="Amount" AutoPostBack="True" Width="100%" runat="server" type="text" TabIndex="1" class="limiter required" ReadOnly="True" meta:resourcekey="txtRemainingAmountResource1">0</asp:TextBox>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblDate" runat="server" Text="Invoice Date" meta:resourcekey="lblDateResource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtDate" runat="server" Width="100%"  Columns="5" TabIndex="4" meta:resourcekey="txtDateResource1"></asp:TextBox>
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDate" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                     <cc1:CalendarExtender ID="CCTranDate" runat="server" TargetControlID="txtDate" BehaviorID="CCTranDate"  Format="dd/MM/yyyy" />
                                                </div>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblDescription" runat="server" Text="Description" meta:resourcekey="lblDescriptionResource1"></asp:Label></label>
                                            <div class="form_grid_8">
                                                <asp:TextBox ID="txtDescription" runat="server" Width="100%" TextMode="MultiLine" Columns="5" TabIndex="4" meta:resourcekey="txtDescriptionResource1"></asp:TextBox>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset title="Price Items" style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="lblInvoicePriceItems" runat="server" Text="Invoice Price Items" meta:resourcekey="lblInvoicePriceItemsResource1"></asp:Label></legend>
                                <div>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID"
                                    OnRowInserting="grid_RowInserting" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" Caption="ID" UnboundType="Integer" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="TotalAmount" VisibleIndex="2" Caption="Total Amount" UnboundType="Decimal" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Balance" VisibleIndex="3" Caption="Balance" UnboundType="Integer" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Account Name" FieldName="GLAccountID" UnboundType="String" VisibleIndex="4" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                            <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="Name" ValueField="GLAccountID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100">
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
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <div class="form_input">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" CausesValidation="False" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="Select Fin_GLAccount.ID as GLAccountID,Fin_GLAccount.Name,'gl' as [type] from Fin_GLAccount union select Fin_Bank.ID*-1 as GLAccountID,Fin_Bank.BankName,'dp' as [type]  from Fin_Bank"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>