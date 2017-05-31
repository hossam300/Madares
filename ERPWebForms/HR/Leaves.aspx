<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="Leaves.aspx.cs" Inherits="ERPWebForms.HR.Leaves" %>

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
                            <asp:Label ID="Label2" runat="server" Text="Leaves" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Create New Leave" Theme="PlasticBlue" OnClick="ASPxButton3_Click" meta:resourcekey="ASPxButton3Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" OnClick="ASPxButton1_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" OnClick="ASPxButton2_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1"></dx:ASPxButton>
                        <br />
                    </div>
                    <div>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" KeyFieldName="LeaveID" PreviewFieldName="LeaveID" meta:resourcekey="ASPxGridView1Resource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="LeaveID" Caption="LeaveID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1">
                                    <EditFormSettings Visible="False"></EditFormSettings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="FromDate" Caption="FromDate" VisibleIndex="4" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="ToDate" Caption="ToDate" VisibleIndex="5" meta:resourcekey="GridViewDataDateColumnResource2"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Comment" Caption="Comment" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Days" Caption="Days" ReadOnly="True" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="EmpName" Caption="Employee Name" VisibleIndex="2" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                    <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="EmpName" ValueField="EmpName">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="LeaveType" Caption="Leave Type" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                    <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="LeaveType" ValueField="LeaveType">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowSelectCheckbox="True" meta:resourcekey="GridViewCommandColumnResource1">
                                </dx:GridViewCommandColumn>
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
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT        HR_Leaves.LeaveID, HR_Employees.EmpName, HR_LeaveType.LeaveType, HR_Leaves.FromDate, HR_Leaves.ToDate, HR_Leaves.Comment, DATEDIFF(day, HR_Leaves.FromDate, HR_Leaves.ToDate) AS Days FROM HR_Leaves INNER JOIN HR_LeaveType ON HR_Leaves.LeaveTypeID = HR_LeaveType.LeaveTypeID INNER JOIN HR_Employees ON HR_Leaves.EmpID = HR_Employees.EmpID"></asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [EmpID], [EmpName] FROM [HR_Employees]"></asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [LeaveTypeID], [LeaveType] FROM [HR_LeaveType]"></asp:SqlDataSource>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
