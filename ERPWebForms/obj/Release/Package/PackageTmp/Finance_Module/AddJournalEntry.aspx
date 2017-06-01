<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="AddJournalEntry.aspx.cs" Inherits="ERPWebForms.Finance_Module.AddJournalEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Create Jornal Entry" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Journal Enry Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <label class="field_title">
                                            <asp:Label ID="Label2" runat="server" Text="Transaction Date" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:TextBox ID="txtTranDate" placeholder="Transaction Date" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtTranDateResource1"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CCTranDate" runat="server" TargetControlID="txtTranDate" BehaviorID="CCTranDate" />
                                            </div>
                                            <label class="field_title">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTranDate" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                &nbsp;<br />
                                                <asp:Label ID="Label3" runat="server" Text="Transaction Amount" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtTranAmount" placeholder="Transaction Amount" runat="server" type="text" Text="0" TabIndex="1" class="limiter required" meta:resourcekey="txtTranAmountResource1"></asp:TextBox>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtTranAmount" OnServerValidate="CustomValidator1_ServerValidate" ErrorMessage="<%$ resources:AmountNotEqual %>" ForeColor="Red"></asp:CustomValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="<%$ resources:AmountNotValid %>" ControlToValidate="txtTranAmount" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?"></asp:RegularExpressionValidator>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTranAmount" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Description" meta:resourcekey="Label4Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_8 Alpha">
                                                    <asp:TextBox ID="txtDesc" placeholder="Description" Width="94%" runat="server" TextMode="MultiLine" Columns="5" TabIndex="4" meta:resourcekey="txtDescResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <fieldset style="border: 1px solid">
                                            <legend>
                                                <asp:Label ID="Label5" runat="server" Text="Journal Enry Rows" meta:resourcekey="Label5Resource1"></asp:Label></legend>
                                            <div class="form_grid_12">
                                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID" OnRowDeleting="grid_RowDeleting"
                                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource1">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn Caption="Depit" FieldName="Depit" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource1" UnboundType="Decimal">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings>
                                                                    <RegularExpression ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ErrorText="Amount Not valid" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Credit" FieldName="Credit" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource2" UnboundType="Decimal">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings>
                                                                    <RegularExpression ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ErrorText="Amount Not valid" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Memo" FieldName="Memo" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource3">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataComboBoxColumn Caption="Account Name" FieldName="GLAccountID" UnboundType="String" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                                            <PropertiesComboBox DataSourceID="SqlDataSource1" TextField="Name" ValueField="GLAccountID">
                                                                <ValidationSettings>
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="7" meta:resourcekey="GridViewCommandColumnResource2">
                                                        </dx:GridViewCommandColumn>
                                                    </Columns>
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
                                            </div>
                                        </fieldset>
                                    </li>
                                </ul>
                            </fieldset>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <div class="form_input">
                                            <asp:Button ID="btnEdit" runat="server" Visible="False" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" CausesValidation="False" />
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="Select Fin_GLAccount.ID  as GLAccountID,Fin_GLAccount.Name,'gl' as [type] from Fin_GLAccount union select Fin_Bank.ID*-1 as GLAccountID,Fin_Bank.BankName,'dp' as [type]  from Fin_Bank"></asp:SqlDataSource>
</asp:Content>
