﻿<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="AddFloor.aspx.cs" Inherits="ERPWebForms.StudentAfair.AddFloor" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label3" runat="server" Text="Create Floor" meta:resourcekey="Label3Resource1" ></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Floor Information" meta:resourcekey="Label1Resource1" ></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Name" meta:resourcekey="Label2Resource1" ></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtName" placeholder="Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator4Resource1" ></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Supervisor" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlSupervisor" runat="server" type="text" TabIndex="1" Style="width: 100%;" class="chzn-select" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlSupervisorResource1"></asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [supervisors] WHERE ([Active] = @Active)">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="ddlSupervisor" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ></asp:RequiredFieldValidator>
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
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" Height="26px" meta:resourcekey="btnEditResource1" />
                                            <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1"  />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1"/>
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
