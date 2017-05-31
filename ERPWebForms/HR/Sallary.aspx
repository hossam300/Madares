<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="Sallary.aspx.cs" Inherits="ERPWebForms.HR.Sallary" %>

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
                            <asp:Label ID="Label5" runat="server" Text="Salary" meta:resourcekey="Label5Resource2"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <h3>
                            <asp:Label ID="Label9" runat="server" Text="Salary" meta:resourcekey="Label9Resource1"></asp:Label></h3>
                        <div id="form103" class="form_container left_label valid_tip">
                            <fieldset id="Fieldset1" title="" style="border: 1px solid" runat="server">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Salary Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Month" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlMonth" AutoPostBack="True" runat="server" AppendDataBoundItems="True" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" meta:resourcekey="ddlMonthResource1">
                                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">Choose Month</asp:ListItem>
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">January</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">February</asp:ListItem>
                                                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource4">March</asp:ListItem>
                                                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource5">April</asp:ListItem>
                                                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource6">May</asp:ListItem>
                                                        <asp:ListItem Value="6" meta:resourcekey="ListItemResource7">June</asp:ListItem>
                                                        <asp:ListItem Value="7" meta:resourcekey="ListItemResource8">July</asp:ListItem>
                                                        <asp:ListItem Value="8" meta:resourcekey="ListItemResource9">August</asp:ListItem>
                                                        <asp:ListItem Value="9" meta:resourcekey="ListItemResource10">September</asp:ListItem>
                                                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource11">October</asp:ListItem>
                                                        <asp:ListItem Value="11" meta:resourcekey="ListItemResource12">November</asp:ListItem>
                                                        <asp:ListItem Value="12" meta:resourcekey="ListItemResource13">December</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="ddlMonth" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Year" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlYear" AutoPostBack="True" runat="server" AppendDataBoundItems="True" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlYearResource1" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
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
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="ddlYear" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator4Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset id="Fieldset2" title="" runat="server">
                                <div>
                                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" OnClick="ASPxButton1_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1"></dx:ASPxButton>
                                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" OnClick="ASPxButton2_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1"></dx:ASPxButton>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" EnableTheming="True" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" Theme="Moderno" meta:resourcekey="ASPxGridView1Resource2" AutoGenerateColumns="False">
                                    <Settings HorizontalScrollBarMode="Visible" ShowGroupPanel="true" />
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" meta:resourcekey="GridViewCommandColumnResource1">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton Text="تم الصرف" ID="btnPay" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="999999999" PageSize="999999999" Visible="False">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" ShowGroupPanel="True"></Settings>
                                    <SettingsCommandButton>
                                        <EditButton ButtonType="Image">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </EditButton>
                                    </SettingsCommandButton>
                                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                                </dx:ASPxGridView>
                            </fieldset>
                            <asp:Button runat="server" ID="btnEdit" Text="Edit" CssClass="finish" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="finish" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="finish" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                        </div>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
