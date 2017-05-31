<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="ViewEmployee.aspx.cs" Inherits="ERPWebForms.HR.ViewEmployee" Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

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
                            <asp:Label ID="Label1" runat="server" Text="View Employee" meta:resourcekey="Label1Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;<asp:Label ID="Label2" runat="server" Text="Information" meta:resourcekey="Label2Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Employee ID" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">

                                                <div class="form_grid_2 alpha">
                                                    <asp:Label ID="txtEmpID" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtEmpIDResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                                <fieldset style="border: 1px solid">
                                    <legend>
                                        <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Name %>" meta:resourcekey="Label13Resource1"></asp:Label></legend>
                                    <ul>
                                        <li>
                                            <div class="form_grid_12">
                                                <label class="field_title">
                                                    <asp:Label ID="Label4" runat="server" Text="Frist Name" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_input">
                                                    <div class="form_grid_4 alpha">
                                                        <asp:Label ID="txtfname" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtfnameResource1"></asp:Label>
                                                    </div>
                                                    <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Middle Name" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                    <div class="form_grid_4">
                                                        <asp:Label ID="txtmname" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtmnameResource1"></asp:Label>
                                                    </div>
                                                    <span class="clear"></span>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="form_grid_12">
                                                <label class="field_title">
                                                    <asp:Label ID="Label6" runat="server" Text="Last Name" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_input">
                                                    <div class="form_grid_4">
                                                        <asp:Label ID="txtlname" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtlnameResource1"></asp:Label>
                                                    </div>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </li>
                                    </ul>
                                </fieldset>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Employee Code" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtEmpCode" placeholder="Employee Code" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtEmpCodeResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label8" runat="server" Text="Sallary" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txtSallary" placeholder="Sallary" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtSallaryResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label9" runat="server" Text="Specialty" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtSpecialty" placeholder="Specialty" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtSpecialtyResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label10" runat="server" Text="ReportTo" meta:resourcekey="Label10Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="ddlReportTo" runat="server" Style="width: 100%" class="limiter required" TabIndex="1" meta:resourcekey="ddlReportToResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label11" runat="server" Text="Nationality" meta:resourcekey="Label11Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="ddlNationality" runat="server" Style="width: 100%" class="limiter required" TabIndex="1" meta:resourcekey="ddlNationalityResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label12" runat="server" Text="Hiring Date" meta:resourcekey="Label12Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txthirngdate" placeholder="Hiring Date" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txthirngdateResource1"></asp:Label>
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
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="lblBonce" runat="server" Text="Bonuses" meta:resourcekey="lblBonceResource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" DataSourceID="SqlDataSource1" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="BonceID" Caption="ID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1">
                                            <EditFormSettings Visible="False"></EditFormSettings>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Value" Caption="Value" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Month" Caption="Month" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Year" Caption="Year" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" Caption="View" meta:resourcekey="GridViewCommandColumnResource2">
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
                                </dx:ASPxGridView>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT BonceID, Value, Month, Year FROM HR_Bonces WHERE (Nature = 1) AND (EmpID = @ID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="id" Name="ID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label14" runat="server" Text="Deductions" meta:resourcekey="Label14Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView2" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView2_CustomButtonCallback" DataSourceID="SqlDataSource2" meta:resourcekey="ASPxGridView2Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="BonceID" Caption="ID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource5">
                                            <EditFormSettings Visible="False"></EditFormSettings>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Value" Caption="Value" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Month" Caption="Month" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Year" Caption="Year" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource8"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" Caption="View" meta:resourcekey="GridViewCommandColumnResource1">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview3" meta:resourcekey="GridViewCommandColumnCustomButtonResource2">
                                                    <Image IconID="actions_show_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="999999999" PageSize="999999999" Visible="False">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True"></Settings>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT BonceID, Value, Month, Year FROM HR_Bonces WHERE (Nature = 2) AND (EmpID = @ID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="id" Name="ID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label15" runat="server" Text="Leaves" meta:resourcekey="Label15Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView3" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView3_CustomButtonCallback" KeyFieldName="LeaveID" PreviewFieldName="LeaveID" meta:resourcekey="ASPxGridView1Resource1" DataSourceID="SqlDataSource3">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="LeaveID" Caption="LeaveID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource9">
                                            <EditFormSettings Visible="False"></EditFormSettings>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="FromDate" Caption="FromDate" VisibleIndex="4" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="ToDate" Caption="ToDate" VisibleIndex="5" meta:resourcekey="GridViewDataDateColumnResource2"></dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="Comment" Caption="Comment" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource10"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Days" Caption="Days" ReadOnly="True" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource11"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="LeaveType" Caption="Leave Type" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                            <PropertiesComboBox DataSourceID="SqlDataSource13" TextField="LeaveType" ValueField="LeaveType">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8" Caption="View/Edit" meta:resourcekey="GridViewCommandColumnResource3">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview2" meta:resourcekey="GridViewCommandColumnCustomButtonResource3">
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
                                <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT HR_Leaves.LeaveID, HR_LeaveType.LeaveType, HR_Leaves.FromDate, HR_Leaves.ToDate, HR_Leaves.Comment, DATEDIFF(day, HR_Leaves.FromDate, HR_Leaves.ToDate) AS Days FROM HR_Leaves INNER JOIN HR_LeaveType ON HR_Leaves.LeaveTypeID = HR_LeaveType.LeaveTypeID WHERE (HR_Leaves.EmpID = @ID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="id" Name="ID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label16" runat="server" Text="Review" meta:resourcekey="Label16Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView4" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" DataSourceID="SqlDataSource4" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView4_CustomButtonCallback" KeyFieldName="ReviewID" PreviewFieldName="ReviewID" meta:resourcekey="ASPxGridView4Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ReviewID" Caption="ReviewID" ReadOnly="True" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource12">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Supervisor" Caption="Supervisor" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource13">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="StartDate" Caption="Start Date" VisibleIndex="4" meta:resourcekey="GridViewDataDateColumnResource3">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="EndDate" Caption="End Date" VisibleIndex="5" meta:resourcekey="GridViewDataDateColumnResource4">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="DueDate" Caption="Due Date" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource5">
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="Status" Caption="Status" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource14">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8" Caption="View/Edit" meta:resourcekey="GridViewCommandColumnResource5">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview1" meta:resourcekey="GridViewCommandColumnCustomButtonResource4">
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
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT HR_Review.ReviewID, Supervisor.EmpName AS Supervisor, HR_Review.StartDate, HR_Review.EndDate, HR_Review.DueDate, HR_Review.Status FROM HR_Review INNER JOIN HR_Employees ON HR_Review.EmpID = HR_Employees.EmpID INNER JOIN HR_Employees AS Supervisor ON HR_Review.SupervisorID = Supervisor.EmpID WHERE (HR_Review.EmpID = @ID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="id" Name="ID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:SqlDataSource runat="server" ID="SqlDataSource13" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [LeaveTypeID], [LeaveType] FROM [HR_LeaveType]"></asp:SqlDataSource>
    </div>
</asp:Content>
