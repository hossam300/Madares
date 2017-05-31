<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="Document.aspx.cs" Inherits="ERPWebForms.StudentAfair.Documents" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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
                            <asp:Label ID="Label2" runat="server" Text="Documents" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                                <div>
                                    <dx:ASPxButton ID="btnNewDocuments" runat="server" Text="Create New Documents" Theme="PlasticBlue" OnClick="btnNewDocuments_Click" meta:resourcekey="btnNewDocumentsResource1"></dx:ASPxButton>
                                    <dx:ASPxButton ID="btnExportCoursex" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportCoursex_Click" meta:resourcekey="btnExportCoursexResource1"></dx:ASPxButton>
                                    <dx:ASPxButton ID="btnExportCoursew" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportCoursew_Click" meta:resourcekey="btnExportCoursewResource1"></dx:ASPxButton>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView2_CustomButtonCallback" OnStartRowEditing="ASPxGridView2_StartRowEditing" meta:resourcekey="ASPxGridView2Resource1" KeyFieldName="ID">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="True" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                            <EditFormSettings Visible="False"></EditFormSettings>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="CourseID" Caption="Cource Name" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                            <PropertiesComboBox DataSourceID="SqlDataSource1" ValueField="ID" TextField="Name"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="ClassID" Caption="Class Name" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                            <PropertiesComboBox DataSourceID="SqlDataSource2" ValueField="ID" TextField="Name"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataDateColumn FieldName="CreationDate" Caption="Creation Date" VisibleIndex="4" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="11" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource1">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                    <Image IconID="actions_show_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <%-- </dx:GridViewCommandColumn>
                                        <dx:GridViewDataHyperLinkColumn FieldName="URl" VisibleIndex="2">
                                            <PropertiesHyperLinkEdit Target="_blank" Text="Document">
                                            </PropertiesHyperLinkEdit>
                                        </dx:GridViewDataHyperLinkColumn>--%>
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
                            </div>
                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Std_Course]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Std_Class]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
