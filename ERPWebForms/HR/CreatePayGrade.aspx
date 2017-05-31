<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="CreatePayGrade.aspx.cs" Inherits="ERPWebForms.HR.CreatePayGrade" %>

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
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label5" runat="server" Text="Create Pay Grade" meta:resourcekey="Label5Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;<asp:Label ID="Label1" runat="server" Text="Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Pay Grade" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtPayGrade" placeholder="Pay Grade" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtPayGradeResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtPayGrade" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                                <asp:Button ID="btnCancel" CausesValidation="false" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset id="Fieldset2" title="" runat="server">
                                <legend>
                                    <asp:Label ID="Label7" runat="server" Text="Pay Grades Sallary" meta:resourcekey="Label7Resource1"></asp:Label></legend>
                                <p>
                                    <asp:Label ID="Label8" runat="server" Text="Add Pay Grades Sallary for this Pay Grade ." meta:resourcekey="Label8Resource1"></asp:Label>
                                </p>
                                <div>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID" OnRowDeleting="grid_RowDeleting"
                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="payGradesSallaryID" VisibleIndex="1" Caption="ID" UnboundType="Integer" meta:resourcekey="GridViewDataTextColumnResource1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Name" FieldName="Name" VisibleIndex="2">
                                            <PropertiesComboBox DataSourceID="NameDS" ValueField="ID" TextField="Name">
                                                <ValidationSettings>
                                                    <RequiredField ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="8" meta:resourcekey="GridViewCommandColumnResource2">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="Value" VisibleIndex="3" Caption="Value" UnboundType="String" meta:resourcekey="GridViewDataTextColumnResource3">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Nature" FieldName="Nature" Name="Nature" VisibleIndex="4" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                            <EditFormSettings Visible="False" />
                                            <PropertiesComboBox DataSourceID="NatureDS" ValueField="ID" TextField="Name"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Type" FieldName="type" Name="Type" VisibleIndex="5" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                            <EditFormSettings Visible="False" />
                                            <PropertiesComboBox DataSourceID="TypeDS" ValueField="ID" TextField="Name"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataCheckColumn Caption="Percentage" FieldName="Percentage" Name="Percentage" VisibleIndex="6" meta:resourcekey="GridViewDataCheckColumnResource1">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Source" FieldName="source" Name="Source" VisibleIndex="7" meta:resourcekey="GridViewDataComboBoxColumnResource3">
                                            <PropertiesComboBox DataSourceID="SourceDS" ValueField="ID" TextField="Name"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
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
                                <asp:SqlDataSource runat="server" ID="TypeDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [HR_LUTType]"></asp:SqlDataSource>
                                <asp:SqlDataSource runat="server" ID="NatureDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [HR_LUTNature] "></asp:SqlDataSource>
                                <asp:SqlDataSource runat="server" ID="SourceDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [HR_LUTSource]"></asp:SqlDataSource>
                                <asp:SqlDataSource runat="server" ID="NameDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [SallarySheetItemID] as ID, [Name] FROM [HR_SallarySheetItems]"></asp:SqlDataSource>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
