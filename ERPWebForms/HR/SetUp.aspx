<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="SetUp.aspx.cs" Inherits="ERPWebForms.HR.SetUp" %>

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
                            <asp:Label ID="Label5" runat="server" Text="Sallary Sheet Items" meta:resourcekey="Label5Resource2"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;<asp:Label ID="Label1" runat="server" Text="Information" meta:resourcekey="Label1Resource2"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Depit Account" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlDepitAcct" DataValueField="ID" DataTextField="Name" runat="server" DataSourceID="cashAcctDS" TabIndex="1" class="limiter required" meta:resourcekey="txtNameResource1"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="cashAcctDS" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="Select Fin_GLAccount.ID,Fin_GLAccount.Name,'gl' as [type] from Fin_GLAccount union select Fin_Bank.ID*-1,Fin_Bank.BankName,'dp' as [type]  from Fin_Bank"></asp:SqlDataSource>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label3" runat="server" Text="Credit Account" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlCreditAcct" DataValueField="ID" DataTextField="Name" runat="server" DataSourceID="cashAcctDS" TabIndex="1" class="limiter required" meta:resourcekey="txtNameResource1"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="AcctDS" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT Fin_GLAccount.ID As GLAccountID, Fin_GLAccount.Name FROM Fin_GLAccount "></asp:SqlDataSource>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource2" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource2" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="SallarySheetItemID" KeyFieldName="SallarySheetItemID" PreviewFieldName="SallarySheetItemID" OnRowDeleting="grid_RowDeleting"
                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource2">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource3">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="SallarySheetItemID" VisibleIndex="1" Caption="ID" UnboundType="Integer" Width="75px" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2" Caption="Name" UnboundType="String" Width="300px" meta:resourcekey="GridViewDataTextColumnResource5">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="8" meta:resourcekey="GridViewCommandColumnResource4" Caption="View/Edit">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Nature" FieldName="Nature" Name="Nature" VisibleIndex="4" meta:resourcekey="GridViewDataComboBoxColumnResource3">
                                            <PropertiesComboBox DataSourceID="NatureDS" ValueField="ID" TextField="Name"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Type" FieldName="Type" Name="Type" VisibleIndex="5" meta:resourcekey="GridViewDataComboBoxColumnResource4">
                                            <PropertiesComboBox DataSourceID="TypeDS" ValueField="ID" TextField="Name"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="Order" VisibleIndex="6" Caption="Order" UnboundType="String" Width="75px" meta:resourcekey="GridViewDataTextColumnResource6">
                                        </dx:GridViewDataTextColumn>
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
                                <asp:SqlDataSource runat="server" ID="TypeDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [HR_LUTType]"></asp:SqlDataSource>
                                <asp:SqlDataSource runat="server" ID="NatureDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [HR_LUTNature]"></asp:SqlDataSource>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
