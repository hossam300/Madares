<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="AddExam.aspx.cs" Inherits="ERPWebForms.StudentAfair.AddExam" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        checkboxlist {
            background-color: #bb0909;
        }

        .checkboxlist input {
            font: inherit;
            font-size: 1em; /* 14px / 16px */
            width: 20px;
            height: 20px;
            padding-left: 40px;
            top: 6px;
            right: -21px;
        }

        .checkboxlist label {
            font: inherit;
            font-weight: bolder;
            font-size: 1.2em; /* 14px / 16px */
            background-color: #ffffff;
            text-align: center;
            width: 80%;
            /*   margin-top:10px;*/
            /*border:double ;*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label3" runat="server" Text="Create Exam" meta:resourcekey="Label3Resource1"></asp:Label></h6>
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
                                                <asp:Label ID="Label2" runat="server" Text="Exam Name" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtExamName" placeholder="Exam Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtExamNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtExamName" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Type" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlType" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlTypeResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1">Choose Type </asp:ListItem>
                                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource2">Final</asp:ListItem>
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource3">Quiz</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource4">Midterm</asp:ListItem>
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
                                                <asp:Label ID="Label5" runat="server" Text="Description" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtDescription" placeholder="Description" TextMode="MultiLine" Columns="4" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtDescriptionResource1"></asp:TextBox>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Nature" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlNature" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlNatureResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource5">Choose Nature </asp:ListItem>
                                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource6">Writen</asp:ListItem>
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource7">Oral</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="ddlNature" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Exam Date" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtExamDate" placeholder="Exam Date" Columns="4" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtExamDateResource1"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExamDate" BehaviorID="CalendarExtender1" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtExamDate" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Educational Year" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlEdYear" AutoPostBack="True" AppendDataBoundItems="true" DataSourceID="EdyDS" DataTextField="YearName" DataValueField="ID" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" OnSelectedIndexChanged="ddlEdYear_SelectedIndexChanged" meta:resourcekey="ddlEdYearResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource8">Choose Year </asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="EdyDS" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] FROM [Std_EducationalYear]"></asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="<%$ Resources:ListItemResource8.Text %>" ForeColor="Red" ControlToValidate="ddlEdYear" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
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
                                                                <asp:Label ID="Label9" runat="server" Text="Classes" meta:resourcekey="Label9Resource1"></asp:Label></legend>
                                                            <asp:CheckBoxList ID="cblClasses" runat="server" meta:resourcekey="cblClassesResource1">
                                                            </asp:CheckBoxList>
                                                        </fieldset>
                                                    </div>
                                                    <div class="form_grid_8 alpha">
                                                        <fieldset>
                                                            <legend>
                                                                <asp:Label ID="Label10" runat="server" Text="Courses" meta:resourcekey="Label10Resource1"></asp:Label>
                                                            </legend>
                                                            <div class="form_grid_4">
                                                                <asp:CheckBoxList ID="cblCourses" CssClass="checkboxlist" runat="server" meta:resourcekey="cblCoursesResource1">
                                                                </asp:CheckBoxList>
                                                            </div>
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
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
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
