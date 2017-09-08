<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="ViewJournalEntry.aspx.cs" Inherits="ERPWebForms.Finance_Module.ViewJournalEntry" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label5" runat="server" Text="JournalEntry Details" meta:resourcekey="Label5Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="JournalEntry Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="JournalEntry ID" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblJournalEntryID" class="limiter required" meta:resourcekey="lblJournalEntryIDResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Amount" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblAmount" class="limiter required" meta:resourcekey="lblAmountResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Description" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblDescription" class="limiter required" meta:resourcekey="lblDescriptionResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label6" runat="server" Text="Creation Date" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblCreationDate" class="limiter required" meta:resourcekey="lblCreationDateResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;<asp:Label ID="Label7" runat="server" Text="Last Modified Date" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblLastModifiedDate" class="limiter required" meta:resourcekey="lblLastModifiedDateResource1"></asp:Label>
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
                                    <asp:Label ID="Label8" runat="server" Text="Journal Entry Rows" meta:resourcekey="Label8Resource1"></asp:Label></legend>
                                <div>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" KeyFieldName="ID" PreviewFieldName="ID" meta:resourcekey="gridResource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="Depit" FieldName="Depit" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Credit" FieldName="Credit" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Memo" FieldName="Memo" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource3">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Account Name" FieldName="GLAccountID" UnboundType="String" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                            <PropertiesComboBox DataSourceID="SqlDataSource1" TextField="Name" ValueField="GLAccountID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource4">
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
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="Select Fin_GLAccount.ID as GLAccountID,Fin_GLAccount.Name,'gl' as [type] from Fin_GLAccount union select Fin_Bank.ID*-1  as GLAccountID,Fin_Bank.BankName,'dp' as [type]  from Fin_Bank"></asp:SqlDataSource>
</asp:Content>
