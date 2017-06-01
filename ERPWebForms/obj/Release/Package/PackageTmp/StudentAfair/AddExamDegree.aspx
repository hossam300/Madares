<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="AddExamDegree.aspx.cs" Inherits="ERPWebForms.StudentAfair.AddExamDegree" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12 full_block">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Exam Degree" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                        <div id="top_tabby">
                        </div>
                    </div>
                    <div class="widget_content">
                        <h3>
                            <asp:Label ID="Label9" runat="server" Text="Exam" meta:resourcekey="Label9Resource1"></asp:Label></h3>
                        <div id="form103" class="form_container left_label">
                            <fieldset id="Fieldset1" style="border: 1px solid" runat="server">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Exam Degrees" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Exam" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlEmaxName" runat="server" TabIndex="1" Style="width: 100%" class="chzn-select" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged" meta:resourcekey="ddlClassesResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource2" Value="0"> Choose Exam</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="ddlEmaxName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label2" runat="server" InitialValue="<%$ Resources:ListItemResource2.Text %>" Text="Class" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_input">
                                                    <div class="form_grid_4 alpha">
                                                        <asp:DropDownList ID="ddlClassName" runat="server" TabIndex="1" AppendDataBoundItems="true" Style="width: 100%" class="chzn-select" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlClassesResource1" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged">
                                                            <asp:ListItem meta:resourcekey="ListItemResource1"> All Classes</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT Std_Class.ID, Std_Class.Name FROM Std_ExamClasses INNER JOIN Std_Class ON Std_ExamClasses.ClassID = Std_Class.ID WHERE (Std_ExamClasses.ExamID = @ExamID)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="ddlEmaxName" PropertyName="SelectedValue" Name="ExamID"></asp:ControlParameter>
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="<%$ Resources:ListItemResource1.Text %>" ForeColor="Red" ControlToValidate="ddlClassName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <span class="clear"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset id="Fieldset2" runat="server">
                                <legend>
                                    <asp:Label ID="Label7" runat="server" Text="Degrees" meta:resourcekey="Label7Resource1"></asp:Label></legend>
                                <div>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" AutoGenerateColumns="False" DataMember="ID" KeyFieldName="ID" PreviewFieldName="ID"
                                    OnRowInserting="grid_RowInserting" OnRowUpdating="grid_RowUpdating" OnInitNewRow="grid_InitNewRow" meta:resourcekey="gridResource1" OnCommandButtonInitialize="grid_CommandButtonInitialize">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Name="ID" FieldName="ID" VisibleIndex="1" Caption="ID" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="StudentName" FieldName="StudentName" VisibleIndex="2" Caption="Student" ReadOnly="true" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ShowEditButton="True" Name="Edit" Caption="Edit" VisibleIndex="15" meta:resourcekey="GridViewCommandColumnResource2">
                                        </dx:GridViewCommandColumn>

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
                                    <SettingsBehavior ColumnResizeMode="Control" AllowDragDrop="true" />
                                </dx:ASPxGridView>
                            </fieldset>
                            <asp:Button runat="server" ID="btnSave" Text="Save" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" CssClass="finish" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [ID], [Name] FROM [Std_Course]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>