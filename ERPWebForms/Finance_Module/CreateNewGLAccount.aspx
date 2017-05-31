<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="CreateNewGLAccount.aspx.cs" Inherits="ERPWebForms.Finance_Module.CreateNewGLAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                                            <asp:Label ID="Label8" runat="server" Text="Account Name" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:TextBox ID="txtAcctName" placeholder="Account Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtAcctNameResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAcctName"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Account Status" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:DropDownList ID="lstAcctStatus" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="lstAcctStatusResource1">
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource1">Active</asp:ListItem>
                                                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource7">InActive</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="lstAcctStatus"></asp:RequiredFieldValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label9" runat="server" Text="Balance" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtBalance" placeholder="Balance" runat="server" type="text" TabIndex="1" class="limiter required" Enabled="False" Text="0" meta:resourcekey="txtBalanceResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtBalance"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Parent GL Account" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlParentGL" runat="server" Columns="5" AppendDataBoundItems="true" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlAcctTypeResource1" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID">
                                                        <asp:ListItem Value="0">Choose Parent GL Account</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Fin_GLAccount]"></asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" InitialValue="0" ForeColor="Red" ControlToValidate="txtacctcode"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Account Code" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtacctcode" placeholder="Account Code" runat="server" type="number" Width="100%" TabIndex="1" class="limiter required" meta:resourcekey="txtacctcodeResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtacctcode"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Account Type" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlAcctType" runat="server" Columns="5" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlAcctTypeResource1">
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">Asset</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">Liability</asp:ListItem>
                                                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource4">Equity</asp:ListItem>
                                                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource5">Income</asp:ListItem>
                                                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource6">Expense</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlAcctType"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Description" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_8 alpha">
                                                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Columns="5" TabIndex="4" meta:resourcekey="txtDescResource1"></asp:TextBox>
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
                                            <asp:Button ID="btnEdit" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
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
