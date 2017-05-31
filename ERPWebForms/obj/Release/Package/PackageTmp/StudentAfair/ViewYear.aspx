<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="ViewYear.aspx.cs" Inherits="ERPWebForms.StudentAfair.ViewYear" %>

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
                            <asp:Label ID="Label2" runat="server" Text="Education Year Details" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Education Year Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="ID" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblEducationYearID" class="limiter required" meta:resourcekey="lblEducationYearIDResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label4" runat="server" Text="Education Year Name" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblEducationYearName" class="limiter required" meta:resourcekey="lblEducationYearNameResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label5" runat="server" Text="Creation Date" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblCreationDate" class="limiter required" meta:resourcekey="lblCreationDateResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label6" runat="server" Text="Last Modified Date" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblLastModifiedDate" class="limiter required" meta:resourcekey="lblLastModifiedDateResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="No of Lectures" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtNoOfLec" placeholder="Class Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtNoOfLecResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label8" runat="server" Text="Lecture Time in min" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txtLecTime" runat="server" type="text" TabIndex="1" Style="width: 100%" class="limiter required" meta:resourcekey="txtLecTimeResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label9" runat="server" Text="Break Time From" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtBreakFrom" placeholder="Break Time From" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBreakFromResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">
                                                    <asp:Label ID="Label10" runat="server" Text="Break Time To" meta:resourcekey="Label10Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txtBreakTo" runat="server" type="text" TabIndex="1" Style="width: 100%" class="limiter required" meta:resourcekey="txtBreakToResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label11" runat="server" Text="Rank" meta:resourcekey="Label11Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblRank" class="limiter required" meta:resourcekey="lblRankResource1"></asp:Label>
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
                                    <asp:Label ID="Label12" runat="server" Text="Classes" meta:resourcekey="Label12Resource1"></asp:Label></legend>
                                <div>
                                    <br />
                                </div>
                                <div>
                                    <dx:ASPxButton ID="btnExportClassx" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportClassx_Click" meta:resourcekey="btnExportClassxResource1"></dx:ASPxButton>
                                    <dx:ASPxButton ID="btnExportClassw" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportClassw_Click" meta:resourcekey="btnExportClasswResource1"></dx:ASPxButton>
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView2" runat="server" Width="100%" EnableTheming="True" Theme="Moderno" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView2_CustomButtonCallback" OnStartRowEditing="ASPxGridView2_StartRowEditing" AutoGenerateColumns="False" meta:resourcekey="ASPxGridView2Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" Caption="ID" UnboundType="Integer" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2" Caption="Classes Name" UnboundType="String" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Supervisor" VisibleIndex="4" Caption="Supervisor" UnboundType="String" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource1">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="GridViewCommandColumnCustomButton1" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                                    <Image IconID="actions_show_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" />
                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label13" runat="server" Text="Courses" meta:resourcekey="Label13Resource1"></asp:Label></legend>
                                <div>
                                    <dx:ASPxButton ID="btnNewCourses" runat="server" Text="Create New Course" Theme="PlasticBlue" OnClick="btnNewCourses_Click" meta:resourcekey="btnNewCoursesResource1"></dx:ASPxButton>
                                    <dx:ASPxButton ID="btnExportCoursesx" runat="server" Text="Export To Excel" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportCoursesx_Click" meta:resourcekey="btnExportCoursesxResource1"></dx:ASPxButton>
                                    <dx:ASPxButton ID="btnExportCoursesw" runat="server" Text="Export To Word" UseSubmitBehavior="False" Theme="PlasticBlue" OnClick="btnExportCoursesw_Click" meta:resourcekey="btnExportCourseswResource1"></dx:ASPxButton>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" ReadOnly="True" meta:resourcekey="GridViewDataTextColumnResource4">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" Caption="Course name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" Caption="Course description" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="min" Caption="Min" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="max" Caption="Max" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource8"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="6" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource2">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource2">
                                                    <Image IconID="actions_show_16x16">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="true">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" />
                                    <SettingsCommandButton>
                                        <EditButton ButtonType="Image">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </EditButton>
                                    </SettingsCommandButton>
                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server"></dx:ASPxGridViewExporter>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
