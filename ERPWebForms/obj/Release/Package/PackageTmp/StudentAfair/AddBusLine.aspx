﻿<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="AddBusLine.aspx.cs" Inherits="ERPWebForms.StudentAfair.AddBusLine" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                            <asp:Label ID="Label3" runat="server" Text="Create Bus Line" meta:resourcekey="Label3Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Bus Line Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Name" meta:resourcekey="Label2Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtName" placeholder="Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator4Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="StartStation" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlStartStation" runat="server" type="text" TabIndex="1" Style="width: 100%;" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="ID" class="chzn-select" meta:resourcekey="ddlStartStationResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Stations] WHERE ([Active] = @Active)">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="ddlStartStation" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>

                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="Supervisor" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlSupervisorId" runat="server" type="text" TabIndex="1" Style="width: 100%;" DataSourceID="SqlDataSource3" DataTextField="EmpName" DataValueField="EmpID" class="chzn-select" meta:resourcekey="ddlSupervisorIdResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                     <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT EmpID, EmpName FROM [HR_Employees] ">
                                                       
                                                    </asp:SqlDataSource>
                                                </div>
                                               
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                   
                                </ul>
                            </fieldset>
                              <fieldset title="<%$ Resources:Label7Resource1.Text %>" runat="server">
                                <legend>
                                    <asp:Label ID="Label7" runat="server" Text="Stations" meta:resourcekey="Label7Resource1" ></asp:Label></legend>
                                <p>
                                    <asp:Label ID="Label8" runat="server" Text="Add Station for this Bus Line Information " meta:resourcekey="Label8Resource1" ></asp:Label>
                                </p>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID" OnRowDeleting="grid_RowDeleting"
                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" EnableCallBacks="False" meta:resourcekey="gridResource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" Caption="ID" UnboundType="Integer"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="StationID"  VisibleIndex="2" Caption="Station" UnboundType="Integer"  Width="100px" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                             <PropertiesComboBox DataSourceID="SqlDataSource1" TextField="Name" ValueField="StationID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="Time" VisibleIndex="3" Caption="Time" UnboundType="String"  Width="250px" meta:resourcekey="GridViewDataTextColumnResource1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="OrderOnLine" VisibleIndex="4" Caption="OrderOnLine" UnboundType="Integer"  Width="150px" meta:resourcekey="GridViewDataTextColumnResource2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ShowDeleteButton="True" Caption="Edit/Delete" ShowEditButton="True" VisibleIndex="5" meta:resourcekey="GridViewCommandColumnResource2" >
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
                            </fieldset>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT ID AS StationID, Name FROM Stations Where Active=1"></asp:SqlDataSource>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <div class="form_input">
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click"   OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" meta:resourcekey="btnEditResource1" />
                                            <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1"  />
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