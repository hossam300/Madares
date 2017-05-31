<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewFollowup.aspx.cs" Inherits="ERPWebForms.StudentAfair.ViewFollowup" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12 full_block">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label3" runat="server" Text="Replays" meta:resourcekey="Label3Resource1"></asp:Label></h6>
                    </div>
                    <fieldset style="border: 1px solid">
                        <legend>
                            <asp:Label ID="Label1" runat="server" Text="Replay" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                        <ul>
                            <li>
                                <div class="form_grid_12">
                                    <div class="form_input">
                                        <div class="form_grid_8 alpha">
                                            <dx:ASPxMemo ID="ASPxMemo1" runat="server" CssClass="disableWrapping" Columns="60" Rows="10" meta:resourcekey="ASPxMemo1Resource1"></dx:ASPxMemo>
                                        </div>
                                        <span class="clear"></span>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="form_grid_12">
                                    <div class="form_input">
                                        <asp:Button ID="btnreplay" runat="server" Text="Replay" class="btn_small btn_blue" OnClick="btnreplay_Click" meta:resourcekey="btnreplayResource1" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </fieldset>
                    <fieldset>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" meta:resourcekey="ASPxGridView1Resource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" Visible="False" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Operator" FieldName="Operator" VisibleIndex="1" Width="100" meta:resourcekey="GridViewDataTextColumnResource2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColumn Caption="Replay" FieldName="Replay" VisibleIndex="2" Width="70%" meta:resourcekey="GridViewDataColumnResource1">
                                    <DataItemTemplate>
                                        <div class="wrapEmail" style="width: 100%">
                                            <%# Eval("Replay") %>
                                        </div>
                                    </DataItemTemplate>
                                    <CellStyle CssClass="wrapEmail"></CellStyle>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataTextColumn Caption="Date Time" FieldName="CreationDate" meta:resourcekey="GridViewDataTextColumnResource3" ShowInCustomizationForm="True" UnboundType="DateTime" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                            </SettingsPager>
                        </dx:ASPxGridView>
                    </fieldset>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT ID, CreationDate, Operator, Replay FROM Std_FollowUp_Replays WHERE (FollowUpID = @FollowUpID) ORDER BY CreationDate">
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="id" Name="FollowUpID" Type="Int32"></asp:QueryStringParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
