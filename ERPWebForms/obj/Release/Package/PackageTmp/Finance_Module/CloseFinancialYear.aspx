<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="CloseFinancialYear.aspx.cs" Inherits="ERPWebForms.Finance_Module.CloseFinancialYear" %>

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
                            <asp:Label ID="Label5" runat="server" Text="View Financial Year" meta:resourcekey="Label5Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label6" runat="server" Text="Financial Year Information" meta:resourcekey="Label6Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Financial Year ID" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">

                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblYearID" class="limiter required" meta:resourcekey="Label4Resource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label8" runat="server" Text="Year Name" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblYearName" class="limiter required" meta:resourcekey="lblCustomerIDResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label9" runat="server" Text="Year Start Date" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblYearStartDate" class="limiter required" meta:resourcekey="Label1Resource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label10" runat="server" Text="Year End Date" meta:resourcekey="Label10Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblYearEndDate" class="limiter required" meta:resourcekey="Label2Resource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label12" runat="server" Text="Description" meta:resourcekey="Label12Resource1"></asp:Label></label>
                                                <div class="form_input">
                                                    <div class="form_grid_4 alpha">
                                                        <asp:Label TextMode="MultiLine" ID="lblDes" Columns="5" runat="server" Enabled="False" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtlnameResource1"></asp:Label>
                                                    </div>
                                                    <span class="clear"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <div>
                                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataMember="ID" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" EnableCallBacks="False" meta:resourcekey="ASPxGridView1Resource1">
                                                <Columns>
                                                    <dx:GridViewCommandColumn VisibleIndex="0" SelectAllCheckboxMode="None" ShowSelectCheckbox="False" ShowClearFilterButton="True" ButtonType="Image" meta:resourcekey="GridViewCommandColumnResource1"></dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn FieldName="AcctCode" Caption="Account Code" VisibleIndex="1" Width="100px" meta:resourcekey="GridViewDataTextColumnResource1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Name" Caption="Account Name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Initial Balance" FieldName="InitBalance" VisibleIndex="3" Width="50px" meta:resourcekey="GridViewDataTextColumnResource3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Depit Balance" FieldName="DepitBalance" VisibleIndex="5" Width="100px" meta:resourcekey="GridViewDataTextColumnResource4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Credit Balance" FieldName="CreditBalance" VisibleIndex="6" Width="100px" meta:resourcekey="GridViewDataTextColumnResource4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Current Balance" FieldName="CurrentBalance" VisibleIndex="7" Width="100px" meta:resourcekey="GridViewDataTextColumnResource4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8" ShowEditButton="true" meta:resourcekey="GridViewCommandColumnResource2">
                                                        <CustomButtons>
                                                            <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                                <Image IconID="actions_show_16x16">
                                                                </Image>
                                                            </dx:GridViewCommandColumnCustomButton>
                                                        </CustomButtons>
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Name="id" Visible="False" VisibleIndex="9" meta:resourcekey="GridViewDataTextColumnResource5">
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
                                                    <DeleteButton ButtonType="Image">
                                                        <Image IconID="actions_cancel_16x16">
                                                        </Image>
                                                    </DeleteButton>
                                                </SettingsCommandButton>
                                            </dx:ASPxGridView>
                                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <div class="form_input">
                                            <asp:Button ID="btnClose" runat="server" Text="Close" class="btn_small btn_blue" OnClick="btnClose_Click" meta:resourcekey="btnEditResource1" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" CausesValidation="False" />
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>