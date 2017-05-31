<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="ViewExam.aspx.cs" Inherits="ERPWebForms.StudentAfair.ViewExam" %>

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
                            <asp:Label ID="lblHeader" runat="server" Text="View Exam" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Exam Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Class Exam" meta:resourcekey="Label2Resource1"></asp:Label>
                                            </label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtExamName" placeholder="Exam Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtExamNameResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Type" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlType" Enabled="False" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlTypeResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1">Choose Type </asp:ListItem>
                                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource2">Final</asp:ListItem>
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource3">Quiz</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource4">Midterm</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Description" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtDescription" placeholder="Description" TextMode="MultiLine" Columns="4" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtDescriptionResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Nature" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlNature" Enabled="False" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlNatureResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource5">Choose Nature </asp:ListItem>
                                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource6">Writen</asp:ListItem>
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource7">Oral</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label6" runat="server" Text="Exam Date" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtExamDate" placeholder="Exam Date" Columns="4" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtExamDateResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text="Educational Year" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlEdYear" AutoPostBack="True" DataSourceID="EdyDS" DataTextField="YearName" DataValueField="ID" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" Enabled="False" meta:resourcekey="ddlEdYearResource1">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="EdyDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] FROM [Std_EducationalYear]"></asp:SqlDataSource>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <div class="form_grid_12 alpha">
                                                    <div class="form_grid_4 alpha">
                                                        <fieldset>
                                                            <legend>
                                                                <asp:Label ID="Label8" runat="server" Text="Classes" meta:resourcekey="Label8Resource1"></asp:Label></legend>
                                                            <asp:CheckBoxList ID="cblClasses" Enabled="False" runat="server" meta:resourcekey="cblClassesResource1">
                                                            </asp:CheckBoxList>
                                                        </fieldset>
                                                    </div>
                                                    <div class="form_grid_4 alpha">
                                                        <fieldset>
                                                            <legend>
                                                                <asp:Label ID="Label9" runat="server" Text="Courses" meta:resourcekey="Label9Resource1"></asp:Label></legend>
                                                            <asp:CheckBoxList ID="cblCourses" Enabled="False" runat="server" meta:resourcekey="cblCoursesResource1">
                                                            </asp:CheckBoxList>
                                                        </fieldset>
                                                    </div>
                                                    <span class="clear"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <div class="form_input">
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
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
