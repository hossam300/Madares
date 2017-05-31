<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="ViewWorkShift.aspx.cs" Inherits="ERPWebForms.HR.ViewWorkShift" %>

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
                            <asp:Label ID="Label1" runat="server" Text="View Work Shift" meta:resourcekey="Label1Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;<asp:Label ID="Label2" runat="server" Text="Information" meta:resourcekey="Label2Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Shift Name" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_7 alpha">
                                                    <asp:Label ID="txtShiftName" placeholder="Shift Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtShiftNameResource1"></asp:Label>
                                                </div>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                </ul>
                                <fieldset style="border: 1px solid">
                                    <legend>
                                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Time %>"></asp:Label></legend>
                                    <ul>
                                        <li>
                                            <div class="form_grid_12">
                                                <label class="field_title">
                                                    <asp:Label ID="Label4" runat="server" Text="From" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_input">
                                                    <div class="form_grid_2 alpha">
                                                        <asp:Label ID="ddlFrom" runat="server" type="text" TabIndex="1" Style="width: 100%" meta:resourcekey="ddlFromResource1"></asp:Label>
                                                    </div>
                                                    <label class="field_title">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="Label5" runat="server" Text="To" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                    <div class="form_grid_2">
                                                        <asp:Label ID="ddlTo" runat="server" type="text" TabIndex="1" Style="width: 100%" meta:resourcekey="ddlToResource1"></asp:Label>
                                                    </div>
                                                    <span class="clear"></span>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="form_grid_12">
                                                <label class="field_title">
                                                    <asp:Label ID="Label6" runat="server" Text="Duration" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_input">
                                                    <div class="form_grid_2">
                                                        <asp:Label ID="txtDuration" placeholder="Duration" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtDurationResource1"></asp:Label>
                                                    </div>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </li>
                                    </ul>
                                </fieldset>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Employees List" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <label>
                                                    <asp:Label ID="Label9" runat="server" Text="Assigned Employees:" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                                &nbsp;
                                            </div>
                                            <asp:ListBox ID="box2View" runat="server" Width="100%" multiple="multiple" class="multiple_list" Enabled="False" meta:resourcekey="box2ViewResource1"></asp:ListBox>
                                            <div class="list_itemcount">
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="False" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
