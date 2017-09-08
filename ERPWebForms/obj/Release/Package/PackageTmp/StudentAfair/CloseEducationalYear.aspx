<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="CloseEducationalYear.aspx.cs" Inherits="ERPWebForms.StudentAfair.CloseEducationalYear" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="Close Educational Year" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                        <div id="top_tabby">
                        </div>
                    </div>
                    <div class="widget_content">
                        <h3>
                            <asp:Label ID="Label9" runat="server" Text="Educational Year" meta:resourcekey="Label9Resource1"></asp:Label></h3>
                        <div id="form103" class="form_container left_label">
                            <fieldset id="Fieldset1" style="border: 1px solid" runat="server">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Educational Year Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Educational Year" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlOldEdyYear" runat="server" Enabled="False" TabIndex="1" Style="width: 100%" class="chzn-select" AutoPostBack="True" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged" meta:resourcekey="ddlClassesResource1">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] As Name FROM [Std_EducationalYear]"></asp:SqlDataSource>
                                                </div>
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlNewYear" runat="server" TabIndex="1" Style="width: 100%" class="chzn-select" AutoPostBack="True" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged" meta:resourcekey="ddlClassesResource1">
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset id="Fieldset2" runat="server">
                                <legend>
                                    <asp:Label ID="Label7" runat="server" Text="New Educational Year" meta:resourcekey="Label7Resource1"></asp:Label></legend>
                                <div>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID"
                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource1" OnStartRowEditing="grid_StartRowEditing" Style="direction: ltr">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="10" meta:resourcekey="GridViewCommandColumnResource2">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Old Class" Name="OldClass" FieldName="oldClass" VisibleIndex="0" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="New Class" Name="NewClass" FieldName="newClass" VisibleIndex="9" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                        </dx:GridViewDataComboBoxColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
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
                                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                                </dx:ASPxGridView>
                            </fieldset>
                            <fieldset id="Fieldset3" runat="server">
                                <legend>
                                    <asp:Label ID="Label2" runat="server" Text="Student didn't Pay fees" meta:resourcekey="StudentNotPaid"></asp:Label></legend>
                                <div>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="studentnotPaid" ClientInstanceName="studentnotPaid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="StudentID" KeyFieldName="StudentID" PreviewFieldName="StudentID"
                                    meta:resourcekey="gridResource2" Style="direction: ltr" Visible="false">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowEditButton="false" VisibleIndex="10" meta:resourcekey="GridViewCommandColumnResource2">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Student Name" Name="StudentName" FieldName="StudentName" VisibleIndex="0" meta:resourcekey="ColumnStudentName">
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Parent Name" Name="ParentName" FieldName="ParentName" VisibleIndex="0" meta:resourcekey="ColumnParentName">
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Remaining Amount" Name="RemainingAmount" FieldName="RemainingAmount" VisibleIndex="0" meta:resourcekey="ColumnRemainingAmount">
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Phone" Name="Phone" FieldName="Phone" VisibleIndex="0" meta:resourcekey="ColumnPhone">
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Student ID" Name="StudentID" FieldName="StudentID" Visible="false" VisibleIndex="9" meta:resourcekey="StudentID">
                                        </dx:GridViewDataComboBoxColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="50" PageSize="50" Visible="true">
                                    </SettingsPager>

                                    <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" ShowFooter="true" />
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
                                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                                </dx:ASPxGridView>
                            </fieldset>
                            <asp:Button runat="server" ID="btnSave" Text="Post" CssClass="finish" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
