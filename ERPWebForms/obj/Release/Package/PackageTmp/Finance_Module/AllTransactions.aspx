<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="AllTransactions.aspx.cs" Inherits="ERPWebForms.Finance_Module.AllTransactions" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="All Transactions" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="btnExportToXlsx" runat="server" Text="Export to XLSX" OnClick="btnExportToXlsx_Click" meta:resourcekey="btnExportToXlsxResource1" />
                        <dx:ASPxButton ID="btnExportToRtf" runat="server" Text="Export to RTF" OnClick="btnExportToRtf_Click" meta:resourcekey="btnExportToRtfResource1" />
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" DataSourceID="SqlDataSource1" meta:resourcekey="ASPxGridView1Resource1">
                            <TotalSummary>
                                <dx:ASPxSummaryItem ShowInColumn="Depit Amount" FieldName="DepitAmount" ShowInGroupFooterColumn="Depit Amount" SummaryType="Sum" meta:resourcekey="ASPxSummaryItemResource1" />
                                <dx:ASPxSummaryItem meta:resourcekey="ASPxSummaryItemResource2" />
                                <dx:ASPxSummaryItem ShowInColumn="Credit Amount" FieldName="CreditAmount" ShowInGroupFooterColumn="Credit Amount" SummaryType="Sum" meta:resourcekey="ASPxSummaryItemResource3" />
                                <dx:ASPxSummaryItem meta:resourcekey="ASPxSummaryItemResource4" />
                            </TotalSummary>
                            <GroupSummary>
                                <dx:ASPxSummaryItem FieldName="DepitAmount" ShowInGroupFooterColumn="Depit Amount" SummaryType="Sum" DisplayFormat="Sum Of Depit ####.###" ValueDisplayFormat="#####.###" meta:resourcekey="ASPxSummaryItemResource5" />
                                <dx:ASPxSummaryItem FieldName="CreditAmount" ShowInGroupFooterColumn="CreditAmount" SummaryType="Sum" DisplayFormat="Sum Of Credit ####.###" ValueDisplayFormat="#####.###" meta:resourcekey="ASPxSummaryItemResource6" />
                            </GroupSummary>
                            <Columns>
                                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataDateColumn FieldName="Date" VisibleIndex="1" Width="150px" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2" Caption="Account Name" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CreditAmount" Settings-GroupInterval="Value" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource2">
                                    <Settings GroupInterval="Value"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DepitAmount" Settings-GroupInterval="Value" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource3">
                                    <Settings GroupInterval="Value"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Memo" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="AcctBalance" Caption="Account Balance" VisibleIndex="6" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                            <SettingsPager NumericButtonCount="50" PageSize="50" Visible="true">
                            </SettingsPager>
                            <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" ShowFooter="true" />
                            <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFooter="True" />
                            <Settings ShowFilterRow="True" ShowGroupFooter="VisibleAlways" />
                            <Styles>
                                <GroupRow Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle">
                                </GroupRow>
                                <GroupFooter Font-Bold="True">
                                </GroupFooter>
                                <GroupPanel Font-Bold="True">
                                </GroupPanel>
                            </Styles>
                        </dx:ASPxGridView>
                    </div>
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT Fin_JournalEntryRows.CreationDate AS Date, Fin_GLAccount.Name, Fin_JournalEntryRows.CreditAmount, Fin_JournalEntryRows.DepitAmount, Fin_JournalEntryRows.Memo, Fin_JournalEntryRows.AcctBalance, Fin_JournalEntry.Description FROM Fin_JournalEntryRows INNER JOIN Fin_GLAccount ON Fin_JournalEntryRows.GLAccountID = Fin_GLAccount.ID INNER JOIN Fin_JournalEntry ON Fin_JournalEntryRows.JournalEntryID = Fin_JournalEntry.ID"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>