<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="CreateBonus.aspx.cs" Inherits="ERPWebForms.HR.CreateBonus" %>

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
                            <asp:Label ID="Label6" runat="server" Text="Create bonus" meta:resourcekey="Label6Resource1"></asp:Label></h6>
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
                                                <asp:Label ID="Label1" runat="server" Text="Employee" meta:resourcekey="Label1Resource1"></asp:Label></label>
                                            <div class="form_input">

                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlEmp" runat="server" class="chzn-select" AppendDataBoundItems="True" TabIndex="13" Width="100%" DataSourceID="SqlDataSource1" DataTextField="EmpName" DataValueField="EmpID" meta:resourcekey="ddlEmpResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1">Choose Employee</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="<%$ Resources:ListItemResource1.Text %>" runat="server" ForeColor="Red" ControlToValidate="ddlEmp" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator4Resource1"></asp:RequiredFieldValidator>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [EmpID], [EmpName] FROM [HR_Employees]"></asp:SqlDataSource>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Type %>" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlType" runat="server" class="chzn-select" TabIndex="13" Width="100%" meta:resourcekey="ddlTypeResource1">
                                                        <asp:ListItem Value="" meta:resourcekey="ListItemResource2" Selected="True">Choose Type</asp:ListItem>
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource3">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource4">Value</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="ddlType" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Month %>" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlMonthResource1">
                                                        <asp:ListItem Value="" meta:resourcekey="ListItemResource5">Choose Month</asp:ListItem>
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource6">January</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource7">February</asp:ListItem>
                                                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource8">March</asp:ListItem>
                                                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource9">April</asp:ListItem>
                                                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource10">May</asp:ListItem>
                                                        <asp:ListItem Value="6" meta:resourcekey="ListItemResource11">June</asp:ListItem>
                                                        <asp:ListItem Value="7" meta:resourcekey="ListItemResource12">July</asp:ListItem>
                                                        <asp:ListItem Value="8" meta:resourcekey="ListItemResource13">August</asp:ListItem>
                                                        <asp:ListItem Value="9" meta:resourcekey="ListItemResource14">September</asp:ListItem>
                                                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource15">October</asp:ListItem>
                                                        <asp:ListItem Value="11" meta:resourcekey="ListItemResource16">November</asp:ListItem>
                                                        <asp:ListItem Value="12" meta:resourcekey="ListItemResource17">December</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="ddlMonth" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:Year %>" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlYearResource1">
                                                        <asp:ListItem Value="" meta:resourcekey="ListItemResource18">Choose Year</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource19">2015</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource20">2016</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource21">2017</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource22">2018</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource23">2019</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource24">2020</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource25">2021</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource26">2022</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource27">2023</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource28">2024</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource29">2025</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource30">2026</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource31">2027</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource32">2028</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource33">2029</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource34">2030</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource35">2031</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource36">2032</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource37">2033</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource38">2034</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource39">2035</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource40">2036</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource41">2037</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource42">2038</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource43">2040</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource44">2041</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource45">2042</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource46">2043</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource47">2044</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource48">2045</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource49">2046</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource50">2047</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource51">2048</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource52">2049</asp:ListItem>
                                                        <asp:ListItem meta:resourcekey="ListItemResource53">2050</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="ddlYear" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator5Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Amount" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtAmount" placeholder="Amount" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtAmountResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtAmount" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                                <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>