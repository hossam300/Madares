<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="FloorList.aspx.cs" Inherits="ERPWebForms.StudentAfair.FloorList" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                            <asp:Label ID="Label3" runat="server" Text="Floors" meta:resourcekey="Label3Resource1" ></asp:Label></h6>
                    </div>
                    <div>
                        <dx:aspxbutton id="btnNewFloor" runat="server" text="Create New Floor" theme="PlasticBlue"  OnClick="btnNewFloor_Click" meta:resourcekey="btnNewFloorResource1"></dx:aspxbutton>
                        <dx:aspxbutton id="btnExportDriverx" runat="server" text="Export To Excel" usesubmitbehavior="False" theme="PlasticBlue" onclick="btnExportDriverx_Click" meta:resourcekey="btnExportDriverxResource1"></dx:aspxbutton>
                        <dx:aspxbutton id="btnExportDriverw" runat="server" text="Export To Word" usesubmitbehavior="False" theme="PlasticBlue" onclick="btnExportDriverw_Click" meta:resourcekey="btnExportDriverwResource1" ></dx:aspxbutton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView id="ASPxGridView1" runat="server" autogeneratecolumns="False" width="100%" enabletheming="True" theme="Moderno" keyfieldname="ID" previewfieldname="ID" enablecallbacks="False" oncustombuttoncallback="ASPxGridView1_CustomButtonCallback" onstartrowediting="ASPxGridView1_StartRowEditing" datasourceid="SqlDataSource1" meta:resourcekey="ASPxGridView1Resource1" >
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="True" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False"></EditFormSettings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                 <dx:GridViewDataComboBoxColumn FieldName="SupervisorId" Caption="Supervisor" VisibleIndex="2" meta:resourcekey="GridViewDataComboBoxColumnResource1" >
                                    <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="Name" ValueField="SupervisorId">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                              <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource1">
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
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name], [SupervisorId] FROM [floors] WHERE ([Active] = @Active)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID] as SupervisorId, [Name] FROM [supervisors] WHERE ([Active] = @Active)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
