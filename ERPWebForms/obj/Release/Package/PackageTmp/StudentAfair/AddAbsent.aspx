<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="AddAbsent.aspx.cs" Inherits="ERPWebForms.StudentAfair.AddAbsent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function OnEditClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.StartEditRow(index);
        }
        function OnUpdateClick(s, e) {
            grid.UpdateEdit();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Create Absent" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Absent Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Date" meta:resourcekey="Label2Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtDate" placeholder="Date" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtDateResource1"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" BehaviorID="CalendarExtender1" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtDate" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Class" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="True" ID="ddlClasses" DataSourceID="ClassDS" DataTextField="Name" DataValueField="ID" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged" meta:resourcekey="ddlClassesResource1">
                                                        <asp:ListItem Value="" meta:resourcekey="ListItemResource1">Select Class</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="ClassDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [Name]  FROM [Std_Class]"></asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="<%$ Resources:ListItemResource1.Text %>" runat="server" ForeColor="Red" ControlToValidate="ddlClasses" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label4" runat="server" Text="Create Absent" meta:resourcekey="Label4Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="grid" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" DataMember="ID" OnRowUpdating="ASPxGridView1_RowUpdating" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="7" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataCheckColumn FieldName="first" Name="first" VisibleIndex="2" meta:resourcekey="GridViewDataCheckColumnResource1">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataCheckColumn FieldName="second" Name="second" VisibleIndex="3" meta:resourcekey="GridViewDataCheckColumnResource2">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataCheckColumn FieldName="third" Name="third" VisibleIndex="4" meta:resourcekey="GridViewDataCheckColumnResource3">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataCheckColumn FieldName="fourth" Name="fourth" VisibleIndex="5" meta:resourcekey="GridViewDataCheckColumnResource4">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataCheckColumn FieldName="fifth" Name="fifth" VisibleIndex="6" meta:resourcekey="GridViewDataCheckColumnResource5">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="0" ReadOnly="true" meta:resourcekey="GridViewDataTextColumnResource1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Name" FieldName="Name" Name="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                                    </SettingsPager>
                                    <SettingsCommandButton>
                                        <EditButton ButtonType="Image">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </EditButton>
                                    </SettingsCommandButton>
                                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                                </dx:ASPxGridView>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>