<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="JournalEntries.aspx.cs" Inherits="ERPWebForms.Finance_Module.JournalEntries" %>

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
                            <asp:Label ID="Label2" runat="server" Text="Journal Entries" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="btnAddJournalEntry" runat="server" Text="Create Journal Entry" Theme="PlasticBlue" OnClick="btnAddJournalEntry_Click" meta:resourcekey="btnAddJournalEntryResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1" OnClick="ASPxButton1_Click"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1" OnClick="ASPxButton2_Click"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" DataSourceID="SqlDataSource1" EnableCallBacks="False" meta:resourcekey="ASPxGridView1Resource1">
                            <Columns>
                                <dx:GridViewCommandColumn VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" ShowClearFilterButton="True" ButtonType="Image" meta:resourcekey="GridViewCommandColumnResource1"></dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="1" Width="50px" meta:resourcekey="GridViewDataTextColumnResource1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Amount" Caption="Amount" VisibleIndex="4" Width="100px" meta:resourcekey="GridViewDataTextColumnResource2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" Caption="Description" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource2">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                            <Image IconID="actions_show_16x16">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataDateColumn Caption="Date" FieldName="Date" VisibleIndex="3" Width="150px" meta:resourcekey="GridViewDataDateColumnResource1">
                                    <PropertiesDateEdit DisplayFormatString="">
                                    </PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                            </Columns>
                            <SettingsPager NumericButtonCount="50" PageSize="50" Visible="true">
                            </SettingsPager>
                            <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" ShowFooter="true" />
                            <Settings ShowFilterRow="True" ShowFooter="True"></Settings>
                            <SettingsCommandButton>
                                <NewButton>
                                    <Image IconID="actions_add_16x16">
                                    </Image>
                                </NewButton>
                                <UpdateButton>
                                    <Image IconID="actions_apply_16x16">
                                    </Image>
                                </UpdateButton>
                                <CancelButton>
                                    <Image IconID="edit_delete_16x16">
                                    </Image>
                                </CancelButton>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [ID], [Description] , [Amount], [CreationDate] as Date FROM [Fin_JournalEntry]"></asp:SqlDataSource>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>