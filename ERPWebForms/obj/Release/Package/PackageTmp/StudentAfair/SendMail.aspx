<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="ERPWebForms.StudentAfair.SendMail" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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
                            <asp:Label ID="Label3" runat="server" Text="Send Email" meta:resourcekey="Label3Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Send Email" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Subject" meta:resourcekey="Label2Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_8 alpha">
                                                    <asp:TextBox ID="txtSubject" placeholder="Subject" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtSubjectResource1"></asp:TextBox>
                                                </div>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="To" meta:resourcekey="Label4Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_8 alpha">
                                                    <asp:TextBox ID="txtTo" placeholder="To" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtToResource1"></asp:TextBox>
                                                </div>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="Message" meta:resourcekey="Label5Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_8 alpha">
                                                    <asp:TextBox ID="txtMessage" placeholder="Message" TextMode="MultiLine" Rows="10" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtMessageResource1"></asp:TextBox>
                                                </div>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnSend" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Sending...';" UseSubmitBehavior="False" runat="server" Text="Send" class="btn_small btn_blue" meta:resourcekey="btnSendResource1" />
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
