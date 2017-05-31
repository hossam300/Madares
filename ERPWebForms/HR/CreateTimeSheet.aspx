<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="CreateTimeSheet.aspx.cs" Inherits="ERPWebForms.HR.CreateTimeSheet" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function OnNewClick(s, e) {
            grid.AddNewRow();
        }
        function OnEditClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.StartEditRow(index);
        }
        function OnSaveClick(s, e) {
            grid.UpdateEdit();
        }
        function OnCancelClick(s, e) {
            grid.CancelEdit();
        }
        function OnDeleteClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.DeleteRow(index);
        }
    </script>
    <script type="text/javascript">
        function ShowLoginWindow() {
            pcLogin.Show();
        }
        function ShowCreateAccountWindow() {
            pcCreateAccount.Show();
            tbUsername.Focus();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12 full_block">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Add New Time Sheet" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                        <div id="top_tabby">
                        </div>
                    </div>
                    <div class="widget_content">
                        <h3>
                            <asp:Label ID="Label9" runat="server" Text="Time Sheet" meta:resourcekey="Label9Resource1"></asp:Label></h3>
                        <div id="form103" class="form_container left_label valid_tip">
                            <fieldset id="Fieldset1" title="" style="border: 1px solid" runat="server">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Time Sheet Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <p>
                                    <asp:Label ID="Label2" runat="server" Text="Fill out the required fields to help identify the Time Sheet Information." meta:resourcekey="Label2Resource1"></asp:Label>
                                </p>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Month" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlMonthResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1" Value="">Choose Month</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource2">January</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource3">February</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource4">March</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource5">April</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource6">May</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource7">June</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource8">July</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource9">August</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource10">September</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource11">October</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource12">November</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource13">December</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="ddlMonth" InitialValue="<%$ Resources:ListItemResource1.Text %>" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="Year" meta:resourcekey="Label10Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlYearResource1">
                                                        <asp:ListItem Value="" meta:resourcekey="ListItemResource14">Choose Year</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource15">2015</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource16">2016</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource17">2017</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource18">2018</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource19">2019</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource20">2020</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource21">2021</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource22">2022</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource23">2023</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource24">2024</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource25">2025</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource26">2026</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource27">2027</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource28">2028</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource29">2029</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource30">2030</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource31">2031</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource32">2032</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource33">2033</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource34">2034</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource35">2035</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource36">2036</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource37">2037</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource38">2038</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource39">2040</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource40">2041</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource41">2042</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource42">2043</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource43">2044</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource44">2045</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource45">2046</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource46">2047</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource47">2048</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource48">2049</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource49">2050</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="ddlYear" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset id="Fieldset2" title="" runat="server">
                                <legend>
                                    <asp:Label ID="Label7" runat="server" Text="Attends" meta:resourcekey="Label7Resource1"></asp:Label></legend>
                                <asp:Button ID="btnImport" runat="server" Text="<%$ Resources:Import %>" CausesValidation="false" OnClick="btnImport_Click" />
                                <iframe id="MyIframe" runat="server" visible="false" width="350" height="300" scrolling="no"
                                    src="Import.aspx"></iframe>
                                <asp:Button ID="btnLoad" runat="server" Text="<%$ Resources:Load %>" CausesValidation="false" Visible="false" OnClick="btnLoad_Click" />
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID" OnRowDeleting="grid_RowDeleting"
                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmpTimeSheetID" VisibleIndex="1" Caption="ID" UnboundType="Integer" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="EmpID" VisibleIndex="2" Caption="Employee" UnboundType="String" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                            <PropertiesComboBox DataSourceID="SqlDataSource4" TextField="EmpName" ValueField="EmpID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="6" meta:resourcekey="GridViewCommandColumnResource2">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataDateColumn Caption="Date" FieldName="Date" UnboundType="DateTime" VisibleIndex="3" meta:resourcekey="GridViewDataDateColumnResource1">
                                            <PropertiesDateEdit DisplayFormatString="">
                                            </PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTimeEditColumn Caption="Attend Time" FieldName="AttendTime" UnboundType="Integer" VisibleIndex="4" meta:resourcekey="GridViewDataTimeEditColumnResource1">
                                            <PropertiesTimeEdit DisplayFormatString="">
                                            </PropertiesTimeEdit>
                                        </dx:GridViewDataTimeEditColumn>
                                        <dx:GridViewDataTimeEditColumn Caption="Leave Time" FieldName="LeaveTime" UnboundType="String" VisibleIndex="5" meta:resourcekey="GridViewDataTimeEditColumnResource2">
                                            <PropertiesTimeEdit DisplayFormatString="">
                                            </PropertiesTimeEdit>
                                        </dx:GridViewDataTimeEditColumn>
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
                            <asp:Button runat="server" ID="btnEdit" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" Text="Edit" CssClass="finish" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="finish" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CausesValidation="false" CssClass="finish" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT Fin_GLAccount.ID As GLAccountID, Fin_GLAccount.Name FROM Fin_GLAccount "></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [EmpID], [EmpName] FROM [HR_Employees]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>