<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="ViewGLAccount.aspx.cs" Inherits="ERPWebForms.Finance_Module.ViewGLAccount" %>

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
                            <asp:Label ID="Label5" runat="server" Text="Create GL Account" meta:resourcekey="Label5Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="GL Account Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <label class="field_title">
                                            <asp:Label ID="Label2" runat="server" Text="Account Name" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:Label runat="server" ID="lblAccountName" class="limiter required" meta:resourcekey="lblAccountNameResource1"></asp:Label>
                                            </div>
                                            <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Account Status" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:Label runat="server" ID="lblAcctStatus" class="limiter required" meta:resourcekey="lblAcctStatusResource1"></asp:Label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Balance" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblBalance" class="limiter required" meta:resourcekey="lblBalanceResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Parent GL Account" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblParentGL" class="limiter required" meta:resourcekey="lblParentGLResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Account Code" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblacctcode" class="limiter required" meta:resourcekey="lblacctcodeResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Account Type" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList runat="server" ID="ddlAcctType" Enabled="false" class="limiter required" meta:resourcekey="ddlAcctTypeResource1">
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">Asset</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">Liability</asp:ListItem>
                                                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource4">Equity</asp:ListItem>
                                                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource5">Income</asp:ListItem>
                                                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource6">Expense</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label12" runat="server" Text="Description" meta:resourcekey="lblDescResource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox TextMode="MultiLine" ID="lblDesc" Columns="5" runat="server" Enabled="False" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtlnameResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <div class="form_input">
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                        </div>
                                    </div>
                                </li>
                            </ul>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label9" runat="server" Text="Sub GL Accounts" meta:resourcekey="Label9Resource1"></asp:Label></legend>
                                <div>
                                    <dx:ASPxButton ID="btncreateGlAcct" runat="server" Text="Create New Sub GL Account" Theme="PlasticBlue" OnClick="btncreateGlAcct_Click" meta:resourcekey="btncreateGlAcctResource1"></dx:ASPxButton>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" Caption="Description" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Balance" Caption="Balance" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Status" Caption="Status" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AcctCode" Caption="Account Code" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource6">
                                            <EditFormSettings Visible="False"></EditFormSettings>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn Caption="Select" ShowSelectCheckbox="True" VisibleIndex="0" ShowClearFilterButton="True" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource2">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                    <Image IconID="actions_show_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <Settings ShowFilterRow="True" ShowFooter="True" />
                                    <SettingsCommandButton>
                                        <EditButton ButtonType="Image">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </EditButton>
                                    </SettingsCommandButton>
                                </dx:ASPxGridView>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label10" runat="server" Text="GL Account Transactions" meta:resourcekey="Label10Resource1"></asp:Label></legend>
                                <div>
                                    <dx:ASPxButton ID="btncreateAccttrans" runat="server" Text="Create New  GL Account Transactions" Theme="PlasticBlue" OnClick="btncreateAccttrans_Click" meta:resourcekey="btncreateAccttransResource1"></dx:ASPxButton>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView2" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" AutoGenerateColumns="False" meta:resourcekey="ASPxGridView2Resource1">
                                    <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="DepitAmount" ShowInColumn="Depit" ShowInGroupFooterColumn="Depit" SummaryType="Sum" meta:resourcekey="ASPxSummaryItemResource1" />
                                        <dx:ASPxSummaryItem FieldName="CreditAmount" ShowInColumn="Credit" ShowInGroupFooterColumn="Credit" SummaryType="Sum" meta:resourcekey="ASPxSummaryItemResource2" />
                                    </TotalSummary>
                                    <Columns>
                                        <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowClearFilterButton="True" ShowSelectCheckbox="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource3">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="JournalEntryID" VisibleIndex="1" Width="30px" Caption="ID" meta:resourcekey="GridViewDataTextColumnResource7">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="CreationDate" VisibleIndex="2" Width="150px" Caption="Date" meta:resourcekey="GridViewDataDateColumnResource1">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="Memo" VisibleIndex="3" Width="300px" Caption="Memo" meta:resourcekey="GridViewDataTextColumnResource8">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="DepitAmount" VisibleIndex="4" Width="90px" Caption="Depit" meta:resourcekey="GridViewDataTextColumnResource9">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="CreditAmount" VisibleIndex="5" Width="90px" Caption="Credit" meta:resourcekey="GridViewDataTextColumnResource10">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AcctBalance" VisibleIndex="6" Width="90px" Caption="Balance" meta:resourcekey="GridViewDataTextColumnResource11">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Settings ShowFooter="True" ShowFilterRow="True" />
                                </dx:ASPxGridView>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>