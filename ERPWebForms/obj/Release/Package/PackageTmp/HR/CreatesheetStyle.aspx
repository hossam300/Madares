<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="CreatesheetStyle.aspx.cs" Inherits="ERPWebForms.HR.CreatesheetStyle" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function OnNewClick(s, e) {
            grid.AddNewRow();
        }

        function OnEditClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.StartEditRow(index);
        }

        function OnSaveClick(s, e) {
            grid.UpdateEdit();
        }

        function OnCancelClick(s, e) {
            grid.CancelEdit();
        }

        function OnDeleteClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.DeleteRow(index);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12 full_block">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Add New Sheet Style" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                        <div id="top_tabby">
                        </div>
                    </div>
                    <div class="widget_content">
                        <h3>
                            <asp:Label ID="Label9" runat="server" Text="Sheet Style" meta:resourcekey="Label9Resource1"></asp:Label></h3>

                        <div id="form103" class="form_container left_label valid_tip">
                            <fieldset id="Fieldset1" title="" style="border: 1px solid" runat="server">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Sheet Style Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Style Name" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtName" placeholder="Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <asp:Button runat="server" ID="btnEdit" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" Text="Edit" CssClass="finish" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="finish" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                        <asp:Button runat="server" ID="btnCancel" CausesValidation="False" Text="Cancel" CssClass="finish" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset id="Fieldset2" title="" runat="server">
                                <legend>
                                    <asp:Label ID="Label7" runat="server" Text="Sheet Items" meta:resourcekey="Label7Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" PreviewFieldName="ID" OnRowDeleting="grid_RowDeleting"
                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" Caption="ID" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ItemName" VisibleIndex="2" Caption="Item Name" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ItemOrder" VisibleIndex="3" Caption="Item Order" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="4" meta:resourcekey="GridViewCommandColumnResource2">
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="False">
                                    </SettingsPager>
                                    <SettingsCommandButton>
                                        <NewButton ButtonType="Image">
                                            <Image IconID="actions_add_16x16">
                                            </Image>
                                        </NewButton>
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
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [ItemName], [ItemOrder] FROM [HR_SheetItems]"></asp:SqlDataSource>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>