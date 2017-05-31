<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="GLAccounts.aspx.cs" Inherits="ERPWebForms.Finance_Module.GLAccounts" %>

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
                            <asp:Label ID="Label2" runat="server" Text="GLAccounts" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="btnGLAccount" runat="server" Text="Create GL Account" Theme="PlasticBlue" OnClick="btnGLAccount_Click" meta:resourcekey="btnGLAccountResource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1" OnClick="ASPxButton1_Click"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1" OnClick="ASPxButton2_Click"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataMember="ID" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" EnableCallBacks="False" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1">
                            <Columns>
                                <dx:GridViewCommandColumn VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" ShowClearFilterButton="True" ButtonType="Image" meta:resourcekey="GridViewCommandColumnResource1"></dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="Status" Caption="Account Status" VisibleIndex="4" Width="100px" meta:resourcekey="GridViewDataTextColumnResource1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" Caption="Description" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Account ID" FieldName="ID" VisibleIndex="1" Width="50px" meta:resourcekey="GridViewDataTextColumnResource3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Balance" FieldName="Balance" VisibleIndex="5" Width="100px" meta:resourcekey="GridViewDataTextColumnResource4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColumn Caption="Account Code" FieldName="AcctCode" VisibleIndex="6" Width="50px" meta:resourcekey="GridViewDataColumnResource1">
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Account Type" FieldName="AcctType" VisibleIndex="6" Width="50px" meta:resourcekey="GridViewDataColumnResource1">
                                </dx:GridViewDataColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" ShowEditButton="true" meta:resourcekey="GridViewCommandColumnResource2">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                            <Image IconID="actions_show_16x16">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Account Name" FieldName="Name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource5">
                                </dx:GridViewDataTextColumn>
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
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
