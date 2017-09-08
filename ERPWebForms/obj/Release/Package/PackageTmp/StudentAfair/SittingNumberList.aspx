<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="SittingNumberList.aspx.cs" Inherits="ERPWebForms.StudentAfair.SittingNumberList" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12 full_block">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label3" runat="server" Text="Sitting Numbers" meta:resourcekey="Label3Resource1"></asp:Label></h6>
                    </div>
                    <div>
                         <dx:aspxbutton id="btnRefresh" runat="server" text="Refresh" usesubmitbehavior="False" theme="PlasticBlue" OnClick="btnRefresh_Click" meta:resourcekey="btnRefreshResource1"></dx:aspxbutton>
                        <dx:aspxbutton id="btnExportDriverx" runat="server" text="Export To Excel" usesubmitbehavior="False" theme="PlasticBlue" onclick="btnExportDriverx_Click" meta:resourcekey="btnExportDriverxResource1" ></dx:aspxbutton>
                        <dx:aspxbutton id="btnExportDriverw" runat="server" text="Export To Word" usesubmitbehavior="False" theme="PlasticBlue" onclick="btnExportDriverw_Click" meta:resourcekey="btnExportDriverwResource1" ></dx:aspxbutton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView id="ASPxGridView1" runat="server" autogeneratecolumns="False" width="100%" enabletheming="True" theme="Moderno" keyfieldname="ID" previewfieldname="ID" enablecallbacks="False"  datasourceid="SqlDataSource1" meta:resourcekey="ASPxGridView1Resource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="True" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False"></EditFormSettings>
                                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataComboBoxColumn FieldName="StudentId" Caption="Student" VisibleIndex="1" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                    <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="Name" ValueField="StudentId">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="Number" Caption="Sitting Number" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                            </Columns>
                             <SettingsPager NumericButtonCount="50" PageSize="50" Visible="true">
                            </SettingsPager>
                            <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" ShowFooter="true" />
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [StudentId], [Number] FROM [SittingNumbers] WHERE ([Active] = @Active)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID] as StudentId, [Name] FROM [Std_Student]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
