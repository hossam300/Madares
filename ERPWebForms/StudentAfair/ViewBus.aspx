<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewBus.aspx.cs" Inherits="ERPWebForms.StudentAfair.ViewBus" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                            <asp:Label ID="Label3" runat="server" Text="Bus Details" meta:resourcekey="Label3Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Bus Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="BusNumber" meta:resourcekey="Label2Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtBusNumber" Enabled="False" placeholder="Bus Number" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBusNumberResource1"></asp:TextBox>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="End License Date" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtEndLicenseDate" Enabled="False" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtEndLicenseDateResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                              
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="Number Of Seats" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtNumberOfSeats" Enabled="False" TextMode="Number" placeholder="Number Of Seats" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtNumberOfSeatsResource1"></asp:TextBox>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label6" runat="server" Text="Bus Condition" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlBusCondition" Enabled="False" runat="server" type="text" TabIndex="1" Style="width: 100%;" class="chzn-select" meta:resourcekey="ddlBusConditionResource1">
                                                        <asp:ListItem Value="" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                         <asp:ListItem Value="Bad" meta:resourcekey="ListItemResource2">Bad</asp:ListItem>
                                                         <asp:ListItem Value="Good" meta:resourcekey="ListItemResource3">Good</asp:ListItem>
                                                         <asp:ListItem Value="V.Good" meta:resourcekey="ListItemResource4">V.Good</asp:ListItem>
                                                        <asp:ListItem Value="Excelent" meta:resourcekey="ListItemResource5">Excelent</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Driver" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlDriver" Enabled="False" runat="server" type="text" TabIndex="1" Style="width: 100%;" class="chzn-select" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlDriverResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource6"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name] FROM [Drivers] WHERE ([Active] = @Active)">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="1" Name="Active" Type="Int32"></asp:Parameter>
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
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
