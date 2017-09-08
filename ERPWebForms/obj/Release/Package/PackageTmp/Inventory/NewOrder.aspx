<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/InventoryMasterPage.Master" AutoEventWireup="true" CodeBehind="NewOrder.aspx.cs" Inherits="ERPWebForms.Inventory.NewOrder" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Purchase Order Items" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblProductInformation" runat="server" Text="Order Information" meta:resourcekey="lblProductInformationResource1"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <fieldset style="border: 1px solid">
                                            <legend>
                                                <asp:Label ID="lblWearhousesHeader" runat="server" Text="Products" meta:resourcekey="lblWearhousesHeaderResource1"></asp:Label></legend>
                                            <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID" OnRowDeleting="grid_RowDeleting"
                                                OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource1" EnableCallBacks="False">
                                                <TotalSummary>
                                                    <dx:ASPxSummaryItem FieldName="Total" ShowInColumn="Total" ShowInGroupFooterColumn="Total" SummaryType="Sum" meta:resourcekey="ASPxSummaryItemResource1" />
                                                    <dx:ASPxSummaryItem FieldName="Cost" ShowInColumn="Unit Cost" ShowInGroupFooterColumn="Unit Cost" SummaryType="Sum" meta:resourcekey="ASPxSummaryItemResource2" />
                                                    <dx:ASPxSummaryItem FieldName="Quantity" ShowInColumn="Product Quantity" ShowInGroupFooterColumn="Product Quantity" SummaryType="Sum" meta:resourcekey="ASPxSummaryItemResource3" />
                                                    <dx:ASPxSummaryItem FieldName="ID" ShowInColumn="ID" ShowInGroupFooterColumn="ID" SummaryType="Count" meta:resourcekey="ASPxSummaryItemResource4" />
                                                </TotalSummary>
                                                <Columns>
                                                    <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" Caption="New" meta:resourcekey="GridViewCommandColumnResource1">
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="8" Caption="Edit / Delete" meta:resourcekey="GridViewCommandColumnResource2">
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="true" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Product &amp; Warehouse" FieldName="ProductID" VisibleIndex="3" Width="150px" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                                        <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="Name" ValueField="ProductID" EnableCallbackMode="True">
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Cost" Caption="Unit Cost" UnboundType="Decimal" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource2">
                                                        <PropertiesTextEdit>
                                                            <ValidationSettings>
                                                                <RegularExpression ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ErrorText="Amount Not valid" />
                                                            </ValidationSettings>
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Quantity" UnboundType="Integer" Caption="Product Quantity" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource3">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsPager NumericButtonCount="1000" PageSize="1000" Visible="False">
                                                </SettingsPager>
                                                <Settings ShowFooter="True" />
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
                                        </fieldset>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label2" runat="server" Text="Supplier" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                        <div class="form_input">

                                            <div class="form_grid_4 alpha">
                                                <asp:DropDownList ID="ddlSupplier" runat="server" class="chzn-select" AppendDataBoundItems="True" TabIndex="13" Width="100%" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlSupplierResource1">
                                                    <asp:ListItem meta:resourcekey="ListItemResource1">Choose Supplier</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString2 %>" SelectCommand="SELECT [ID], [Name] FROM [Inv_Supplier] WHERE ([Active] = @Active)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="1" Name="Active" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="ddlSupplier" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator7Resource1"></asp:RequiredFieldValidator>
                                            </div>

                                            <label class="field_title">
                                                &nbsp;&nbsp;
                                                <asp:Label ID="Label3" runat="server" Text="Delivery Date" meta:resourcekey="Label3Resource1"></asp:Label></label>

                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtDeliveryDate" placeholder="Delivery Date" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtDeliveryDateResource1"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDeliveryDate" BehaviorID="CalendarExtender1" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtDeliveryDate" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="Label1" runat="server" Text="Status" meta:resourcekey="Label1Resource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_4 alpha">
                                                <asp:DropDownList ID="ddlStatus" runat="server" class="chzn-select" AppendDataBoundItems="True" TabIndex="13" Width="100%" meta:resourcekey="ddlStatusResource1">
                                                    <asp:ListItem meta:resourcekey="ListItemResource2">Choose Status</asp:ListItem>
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource3">Awaiting Approval</asp:ListItem>
                                                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource4">Approved</asp:ListItem>
                                                    <asp:ListItem Value="3" meta:resourcekey="ListItemResource5">Rejected</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="ddlStatus" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="field_title">
                                                &nbsp;&nbsp;
                                                <asp:Label ID="Label4" runat="server" Text="Rejection Reason" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_grid_4">
                                                <asp:TextBox ID="txtRejectionReason" placeholder="Rejection Reason" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtRejectionReasonResource1"></asp:TextBox>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblRemarks" runat="server" Text="Remarks" meta:resourcekey="lblRemarksResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_10 alpha">
                                                <asp:TextBox TextMode="MultiLine" ID="txtRemarks" placeholder="Remarks" Columns="5" Rows="5" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtRemarksResource1"></asp:TextBox>
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
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" meta:resourcekey="btnEditResource1" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" meta:resourcekey="btnSaveResource1" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" CausesValidation="False" meta:resourcekey="btnCancelResource1" />
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT Inv_ProductWearhous.ID AS ProductID, 'W: ' + Inv_Warehouse.Name + ' P: ' + Inv_Products.Name AS Name FROM Inv_Products INNER JOIN Inv_ProductWearhous ON Inv_Products.ID = Inv_ProductWearhous.ProductID INNER JOIN Inv_Warehouse ON Inv_ProductWearhous.WarehouseID = Inv_Warehouse.ID WHERE (Inv_Products.Active = @Active)">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
