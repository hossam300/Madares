<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="ERPWebForms.StudentAfair.AddCourse" %>

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
                            <asp:Label ID="Label3" runat="server" Text="Create Course" meta:resourcekey="Label3Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Course Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Course name" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtCourseName" placeholder="Course Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtCourseNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtCourseName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Course description" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox TextMode="MultiLine" ID="txtDescription" Columns="5" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtDescriptionResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="Min" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtMin" placeholder="Min" TextMode="Number" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtMinResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtMin" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Max" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtMax" runat="server" TextMode="Number" Width="100%" TabIndex="1" class="limiter required" meta:resourcekey="txtMaxResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtMax" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Educational years" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_12 alpha">
                                                    <div class="form_grid_4 alpha">
                                                        <fieldset>
                                                            <legend>
                                                                <asp:Label ID="Label8" runat="server" Text="KG" meta:resourcekey="Label8Resource1"></asp:Label></legend>
                                                            <asp:CheckBoxList ID="cblKg" runat="server" meta:resourcekey="cblKgResource1">
                                                            </asp:CheckBoxList>
                                                            <%--   <asp:SqlDataSource runat="server" ID="DataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] FROM [Std_EducationalYear] where Rank = 1"></asp:SqlDataSource>--%>
                                                        </fieldset>
                                                    </div>
                                                    <div class="form_grid_4 alpha">
                                                        <fieldset>
                                                            <legend>
                                                                <asp:Label ID="Label9" runat="server" Text="Primary" meta:resourcekey="Label9Resource1"></asp:Label></legend>
                                                            <asp:CheckBoxList ID="cblPri" runat="server" meta:resourcekey="cblPriResource1">
                                                            </asp:CheckBoxList>
                                                            <%--   <asp:SqlDataSource runat="server" ID="DataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] FROM [Std_EducationalYear] where Rank = 2"></asp:SqlDataSource>--%>
                                                        </fieldset>
                                                    </div>
                                                    <div class="form_grid_4 alpha">
                                                        <fieldset>
                                                            <legend>
                                                                <asp:Label ID="Label10" runat="server" Text="Preparatory" meta:resourcekey="Label10Resource1"></asp:Label></legend>
                                                            <asp:CheckBoxList ID="cblPre" runat="server" meta:resourcekey="cblPreResource1">
                                                            </asp:CheckBoxList>
                                                            <%--<asp:SqlDataSource runat="server" ID="DataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] FROM [Std_EducationalYear] where Rank = 3"></asp:SqlDataSource>--%>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <div class="form_input">
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                            <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
