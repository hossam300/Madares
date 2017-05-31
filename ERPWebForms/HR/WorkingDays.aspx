<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="WorkingDays.aspx.cs" Inherits="ERPWebForms.HR.WorkingDays" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="Create Leave" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;
                                    <asp:Label ID="Label1" runat="server" Text="Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Saturday" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddSaturday" runat="server" Enabled="False" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" meta:resourcekey="ddSaturdayResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1">Choose Type</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource2">Full Day</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource3">Half Day</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Sunday" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlSunday" runat="server" Enabled="False" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" meta:resourcekey="ddlSundayResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource4">Choose Type</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource5">Full Day</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource6">Half Day</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Monday" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlMonday" runat="server" Enabled="False" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" meta:resourcekey="ddlMondayResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource7">Choose Type</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource8">Full Day</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource9">Half Day</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="Tuesday" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlTuesday" runat="server" Enabled="False" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" meta:resourcekey="ddlTuesdayResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource10">Choose Type</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource11">Full Day</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource12">Half Day</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label6" runat="server" Text="Wednesday" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlWednesday" runat="server" Enabled="False" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" meta:resourcekey="ddlWednesdayResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource13">Choose Type</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource14">Full Day</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource15">Half Day</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Thursday" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlThursday" runat="server" Enabled="False" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" meta:resourcekey="ddlThursdayResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource16">Choose Type</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource17">Full Day</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource18">Half Day</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label8" runat="server" Text="Friday" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlFriday" runat="server" Enabled="False" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" meta:resourcekey="ddlFridayResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource19">Choose Type</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource20">Full Day</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource21">Half Day</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" UseSubmitBehavior="False" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                                <asp:Button ID="btnSave" runat="server" Text="Update" class="btn_small btn_blue" Visible="False" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                                <asp:Button ID="btnCancel" runat="server" UseSubmitBehavior="False" Text="Cancel" class="btn_small btn_orange" Visible="False" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
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
