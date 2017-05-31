<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="ViewJobtitle.aspx.cs" Inherits="ERPWebForms.HR.ViewJobtitle" %>

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
                            <asp:Label ID="Label6" runat="server" Text="View Job Title" meta:resourcekey="Label6Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;<asp:Label ID="Label1" runat="server" Text="Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Job Title" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtJobTitle" placeholder="Job Title" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtJobTitleResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Job Description" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtJobDescription" placeholder="Job Description" TextMode="MultiLine" Columns="3" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtJobDescriptionResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label5" runat="server" Text="Note" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txtNote" placeholder="Note" TextMode="MultiLine" Columns="3" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtNoteResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label3" runat="server" Text="Employees" meta:resourcekey="Label3Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" PreviewFieldName="EmpID" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" EnableCallBacks="False" DataSourceID="SqlDataSource1" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="EmpID" Caption="ID" VisibleIndex="0" ReadOnly="True" meta:resourcekey="GridViewDataTextColumnResource1">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmpName" Caption="Employee Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Sallary" Caption="Sallary" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource3">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Specialty" Caption="Specialty" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource4">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ReportTo" Caption="ReportTo" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource5">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Nationality" Caption="Nationality" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource6">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="HiringDate" Caption="Hiring Date" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource1">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmpCode" Caption="Employee Code" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource7">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Settings ShowFilterRow="True" ShowFooter="True"></Settings>
                                    <SettingsCommandButton>
                                        <NewButton>
                                            <Image IconID="actions_add_16x16">
                                            </Image>
                                        </NewButton>
                                        <UpdateButton>
                                            <Image IconID="actions_apply_16x16">
                                            </Image>
                                        </UpdateButton>
                                        <CancelButton>
                                            <Image IconID="edit_delete_16x16">
                                            </Image>
                                        </CancelButton>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [EmpID], [EmpName], [Sallary], [Specialty], [ReportTo], [Nationality], [HiringDate], [EmpCode] FROM [HR_Employees] WHERE ([JobTitleID] = @JobTitleID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="JobTitleID" QueryStringField="id" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
