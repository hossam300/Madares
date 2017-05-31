<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="ViewParent.aspx.cs" Inherits="ERPWebForms.StudentAfair.ViewParent" Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
                            <asp:Label ID="lblHeader" runat="server" Text="Create Parent" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Parent Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Parent name" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtParentName" placeholder="Parent Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtParentNameResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Job" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txtjob" placeholder="Job" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtjobResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Email" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtEmail" placeholder="Email" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtEmailResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label5" runat="server" Text="Phone" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txtPhone" placeholder="Phone" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtPhoneResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label6" runat="server" Text="Address" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_8">
                                                    <asp:Label ID="txtAddress" placeholder="Address" Width="100%" TextMode="MultiLine" Columns="6" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtAddressResource1"></asp:Label>
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
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <fieldset style="border: 1px solid">
                                        <legend>
                                            <asp:Label ID="lblStudentsHeader" runat="server" Text="Students" meta:resourcekey="lblStudentsHeaderResource1"></asp:Label></legend>
                                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" DataSourceID="SqlDataSource1" OnCustomButtonCallback="ASPxGridView2_CustomButtonCallback" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" meta:resourcekey="ASPxGridView1Resource1">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="True" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                                    <EditFormSettings Visible="False"></EditFormSettings>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="BirthDate" Caption="BirthDate" VisibleIndex="2" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                                                <dx:GridViewDataTextColumn FieldName="Address" Caption="Address" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ClassName" Caption="Class Name" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="11" Caption="View" meta:resourcekey="GridViewCommandColumnResource1">
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                            <Image IconID="actions_show_16x16">
                                                            </Image>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <%-- </dx:GridViewCommandColumn>
                                        <dx:GridViewDataHyperLinkColumn FieldName="URl" VisibleIndex="2">
                                            <PropertiesHyperLinkEdit Target="_blank" Text="Document">
                                            </PropertiesHyperLinkEdit>
                                        </dx:GridViewDataHyperLinkColumn>--%>
                                            </Columns>
                                            <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                                            </SettingsPager>
                                            <Settings ShowFilterRow="True" />
                                            <SettingsCommandButton>
                                                <EditButton ButtonType="Image">
                                                    <Image IconID="edit_edit_16x16">
                                                    </Image>
                                                </EditButton>
                                            </SettingsCommandButton>
                                        </dx:ASPxGridView>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT Std_Student.ID, Std_Student.Name, Std_Student.BirthDate, Std_Student.Address, Std_Class.Name AS ClassName FROM Std_Student INNER JOIN Std_Class ON Std_Student.StudClassID = Std_Class.ID WHERE (Std_Student.ParentID = @ID)">
                                            <SelectParameters>
                                                <asp:QueryStringParameter QueryStringField="id" Name="id"></asp:QueryStringParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </fieldset>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
