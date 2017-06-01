<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="AllGLAccounts.aspx.cs" Inherits="ERPWebForms.Finance_Module.AllGLAccounts" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
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
                            <asp:Label ID="lblHeader" runat="server" Text="GLAccounts" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="btnExportToXlsx" runat="server" Text="Export to XLSX" OnClick="btnExportToXlsx_Click" meta:resourcekey="btnExportToXlsxResource1" />
                        <dx:ASPxButton ID="btnExportToRtf" runat="server" Text="Export to RTF" OnClick="btnExportToRtf_Click" meta:resourcekey="btnExportToRtfResource1" />
                        <br />
                    </div>
                    <div>
                        <dx:ASPxTreeList ID="ASPxTreeList1" KeyFieldName="ID" ParentFieldName="ParentAcctID" runat="server" AutoGenerateColumns="False" OnCustomDataCallback="treeList_CustomDataCallback" OnHtmlDataCellPrepared="treeList_HtmlDataCellPrepared" OnSelectionChanged="ASPxTreeList1_SelectionChanged" meta:resourcekey="ASPxTreeList1Resource1">
                            <Columns>
                                <dx:TreeListTextColumn ReadOnly="True" FieldName="ID" Visible="False" meta:resourcekey="TreeListTextColumnResource1"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="Name" VisibleIndex="0" Caption="Account Name" meta:resourcekey="TreeListTextColumnResource2"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="Balance" VisibleIndex="2" meta:resourcekey="TreeListTextColumnResource3"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="Description" VisibleIndex="3" meta:resourcekey="TreeListTextColumnResource4"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="ParentAcctID" VisibleIndex="4" Visible="false" meta:resourcekey="TreeListTextColumnResource5"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="AcctCode" VisibleIndex="1" meta:resourcekey="TreeListTextColumnResource6"></dx:TreeListTextColumn>
                            </Columns>
                            <Settings ShowTreeLines="False" SuppressOuterGridLines="true" />
                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" />
                            <ClientSideEvents CustomDataCallback="function(s, e) { document.getElementById('messageText').innerHTML = e.result; }"
                                FocusedNodeChanged="function(s, e) { 
            var key = treeList.GetFocusedNodeKey();
            treeList.PerformCustomDataCallback(key); 
        }" />
                            <Border BorderStyle="Solid" />
                        </dx:ASPxTreeList>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name], [Balance], [Description], [ParentAcctID], [AcctType], [AcctCode] FROM [Fin_GLAccount]"></asp:SqlDataSource>
                    </div>
                    <dx:ASPxTreeListExporter ID="treeListExporter" runat="server" TreeListID="ASPxTreeList1" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>