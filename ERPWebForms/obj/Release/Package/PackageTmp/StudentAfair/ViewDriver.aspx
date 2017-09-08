<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewDriver.aspx.cs" Inherits="ERPWebForms.StudentAfair.ViewDriver" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                            <asp:Label ID="Label3" runat="server" Text="Driver Details" meta:resourcekey="Label3Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Driver Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Name" meta:resourcekey="Label2Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtDriverName" Enabled="False" placeholder="Driver Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtDriverNameResource1"></asp:TextBox>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Phone" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtPhone" Enabled="False" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtPhoneResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                              
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="License Number" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtLicenseNumber"  Enabled="False" placeholder="Email" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtLicenseNumberResource1"></asp:TextBox>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label6" runat="server" Text="LicenseEndDate" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtLicenseEndDate" Enabled="False" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtLicenseEndDateResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Hiring Date" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtDateHiring" Enabled="False" placeholder="Hiring Date" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtDateHiringResource1"></asp:TextBox>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label8" runat="server" Text="End Hiring" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtEndHiring"  Enabled="False" placeholder="End Hiring" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtEndHiringResource1"></asp:TextBox>
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
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
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
