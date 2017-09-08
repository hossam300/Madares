<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="ERPWebForms.HR.Reviews" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12 full_block">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label2" runat="server" Text="Reviews" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Create New Review" Theme="PlasticBlue" OnClick="ASPxButton3_Click" meta:resourcekey="ASPxButton3Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" OnClick="ASPxButton1_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" OnClick="ASPxButton2_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1" DataMember="ReviewID" KeyFieldName="ReviewID" PreviewFieldName="ReviewID">
                            <Columns>
                                <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowClearFilterButton="True" ShowSelectCheckbox="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="ReviewID" Caption="ReviewID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EmpName" Caption="Employee Name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Supervisor" Caption="Supervisor" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="StartDate" Caption="Start Date" VisibleIndex="4" meta:resourcekey="GridViewDataDateColumnResource1">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="EndDate" Caption="End Date" VisibleIndex="5" meta:resourcekey="GridViewDataDateColumnResource2">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="DueDate" Caption="Due Date" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource3">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Status" Caption="Status" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource2">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                            <Image IconID="actions_show_16x16">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsPager NumericButtonCount="999999999" PageSize="999999999" Visible="False">
                            </SettingsPager>
                            <Settings ShowFilterRow="True"></Settings>
                            <SettingsCommandButton>
                                <EditButton ButtonType="Image">
                                    <Image IconID="edit_edit_16x16">
                                    </Image>
                                </EditButton>
                            </SettingsCommandButton>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT HR_Review.ReviewID, HR_Employees.EmpName, Supervisor.EmpName AS Supervisor, HR_Review.StartDate, HR_Review.EndDate, HR_Review.DueDate, HR_Review.Status FROM HR_Review INNER JOIN HR_Employees ON HR_Review.EmpID = HR_Employees.EmpID INNER JOIN HR_Employees AS Supervisor ON HR_Review.SupervisorID = Supervisor.EmpID"></asp:SqlDataSource>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>