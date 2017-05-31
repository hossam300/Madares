<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="ViewPayGrade.aspx.cs" Inherits="ERPWebForms.HR.ViewPayGrade" %>

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
                            <asp:Label ID="Label5" runat="server" Text="View Pay Grade" meta:resourcekey="Label5Resource1"></asp:Label></h6>
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
                                                <asp:Label ID="Label2" runat="server" Text="Pay Grade" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtPayGrade" placeholder="Pay Grade" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtPayGradeResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset id="Fieldset2" title="" runat="server">
                                <legend>
                                    <asp:Label ID="Label7" runat="server" Text="Pay Grade Sallary" meta:resourcekey="Label7Resource1"></asp:Label></legend>
                                <p>
                                    <asp:Label ID="Label8" runat="server" Text="Add Pay Grade Sallary for this Pay Grade  ." meta:resourcekey="Label8Resource1"></asp:Label>
                                </p>
                                <div>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID" meta:resourcekey="gridResource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="0" Caption="ID" UnboundType="Integer" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1" Caption="Name" UnboundType="String" meta:resourcekey="GridViewDataTextColumnResource2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Value" VisibleIndex="2" Caption="Value" UnboundType="String" meta:resourcekey="GridViewDataTextColumnResource3">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Nature" FieldName="Nature" Name="Nature" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource4">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="type" FieldName="type" Name="type" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource5">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Percentage" FieldName="Percentage" Name="Percentage" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource6">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="source" FieldName="source" Name="source" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource7">
                                        </dx:GridViewDataTextColumn>
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
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label3" runat="server" Text="Employees" meta:resourcekey="Label3Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" KeyFieldName="EmpID" PreviewFieldName="EmpID" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" EnableCallBacks="False" DataSourceID="SqlDataSource1" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" ShowClearFilterButton="True" ButtonType="Image" meta:resourcekey="GridViewCommandColumnResource1"></dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmpName" Caption="Employee Name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource8">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Specialty" Caption="Specialty" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource9">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Sallary" Caption="Sallary" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource10">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ReportTo" Caption="Report To" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource11">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="CreationDate" Caption="Date Created" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource12">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmpID" Caption="Employee ID" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource13">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource2">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                    <Image IconID="actions_show_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [EmpID], [EmpName], [Sallary], [Specialty], [ReportTo], [Nationality], [HiringDate], [CreationDate], [EmpCode] FROM [HR_Employees] WHERE ([PayGradeID] = @PayGradeID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="PayGradeID" QueryStringField="id" Type="Int32" />
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
