<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="UsersNotExist.aspx.cs" Inherits="ERPWebForms.StudentAfair.UsersNotExist" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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
                            <asp:Label ID="Label3" runat="server" Text="Students" meta:resourcekey="Label3Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="btnNewStudent" runat="server" Text="Create New Student" Theme="PlasticBlue" OnClick="btnNewStudent_Click" meta:resourcekey="btnNewStudentResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportStudentx" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportStudentx_Click" meta:resourcekey="btnExportStudentxResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportStudentw" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportStudentw_Click" meta:resourcekey="btnExportStudentwResource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" DataMember="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1">
                            <Settings ShowFilterRow="True" />
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="ID" ShowInColumn="ID" ShowInGroupFooterColumn="ID" SummaryType="Count" meta:resourcekey="ASPxSummaryItemResource1" />
                            </TotalSummary>
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" VisibleIndex="0" ReadOnly="True" meta:resourcekey="GridViewDataTextColumnResource1" Width="50px">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Student name" VisibleIndex="1" Width="150px" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ParentName" Caption="Parent name" VisibleIndex="4" Width="150px" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Address" Caption="Address" VisibleIndex="11" Width="200px" meta:resourcekey="GridViewDataTextColumnResource5" Visible="False"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Phone" Caption="Phone" VisibleIndex="10" Width="100px" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="StdType" Caption="Type" VisibleIndex="9" Width="100px" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="12" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource1">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                            <Image IconID="actions_show_16x16">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Class" FieldName="ClassName" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource8" Width="75px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Educational Year" FieldName="EducationalYear" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource9" Width="130px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Birth Date" FieldName="BirthDate" VisibleIndex="7" Width="100px" meta:resourcekey="GridViewDataTextColumnResource11">
                                    <PropertiesDateEdit DisplayFormatString="">
                                    </PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Age 1/10" FieldName="age110" UnboundType="String" VisibleIndex="8" meta:resourcekey="GridViewDataTextColumnResource10" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Gender" FieldName="Gender" Name="Gender" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Religion" FieldName="Religion" Name="Religion" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource12">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                            </SettingsPager>
                            <Settings HorizontalScrollBarMode="Visible" ShowGroupPanel="True" ShowFooter="True" />
                            <SettingsCommandButton>
                                <EditButton ButtonType="Image">
                                    <Image IconID="edit_edit_16x16">
                                    </Image>
                                </EditButton>
                            </SettingsCommandButton>
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
