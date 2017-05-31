<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAfair/SFMasterPage.master" AutoEventWireup="true" CodeBehind="ViewCourse.aspx.cs" Inherits="ERPWebForms.StudentAfair.ViewCourse" %>

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
                            <asp:Label ID="Label2" runat="server" Text="View Course" meta:resourcekey="Label2Resource1"></asp:Label></h6>
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
                                                <asp:Label ID="Label3" runat="server" Text="Course name" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label ID="txtCourseName" placeholder="Course Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtCourseNameResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Course description" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label TextMode="MultiLine" ID="txtDescription" Columns="5" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtDescriptionResource1"></asp:Label>
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
                                                    <asp:Label ID="txtMin" placeholder="Branch Name" Width="100%" runat="server" TabIndex="1" class="limiter required" meta:resourcekey="txtMinResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Max" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label ID="txtMax" runat="server" Width="100%" TabIndex="1" class="limiter required" meta:resourcekey="txtMaxResource1"></asp:Label>
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
                                                                <asp:Label ID="Label11" runat="server" Text="KG" meta:resourcekey="Label11Resource1"></asp:Label></legend>
                                                            <asp:CheckBoxList ID="cblKg" runat="server" DataSourceID="DataSource1" DataTextField="YearName" DataValueField="ID" Enabled="False" meta:resourcekey="cblKgResource1">
                                                            </asp:CheckBoxList>
                                                            <asp:SqlDataSource runat="server" ID="DataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] FROM [Std_EducationalYear] where Rank = 1"></asp:SqlDataSource>
                                                        </fieldset>
                                                    </div>
                                                    <div class="form_grid_4 alpha">
                                                        <fieldset>
                                                            <legend>
                                                                <asp:Label ID="Label8" runat="server" Text="Primary" meta:resourcekey="Label8Resource1"></asp:Label></legend>
                                                            <asp:CheckBoxList ID="cblPri" runat="server" DataSourceID="DataSource2" DataTextField="YearName" DataValueField="ID" Enabled="False" meta:resourcekey="cblPriResource1">
                                                            </asp:CheckBoxList>
                                                            <asp:SqlDataSource runat="server" ID="DataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] FROM [Std_EducationalYear] where Rank = 2"></asp:SqlDataSource>
                                                        </fieldset>
                                                    </div>
                                                    <div class="form_grid_4 alpha">
                                                        <fieldset>
                                                            <legend>
                                                                <asp:Label ID="Label9" runat="server" Text="Preparatory" meta:resourcekey="Label9Resource1"></asp:Label></legend>
                                                            <asp:CheckBoxList ID="cblPre" runat="server" DataSourceID="DataSource3" DataTextField="YearName" DataValueField="ID" Enabled="False" meta:resourcekey="cblPreResource1">
                                                            </asp:CheckBoxList>
                                                            <asp:SqlDataSource runat="server" ID="DataSource3" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [ID], [YearName] FROM [Std_EducationalYear] where Rank = 3"></asp:SqlDataSource>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label12" runat="server" Text="Documents" meta:resourcekey="Label12Resource1"></asp:Label></legend>
                                <dx:ASPxButton ID="btnNewDocuments" runat="server" Text="Create New Documents" Theme="PlasticBlue" OnClick="btnNewDocuments_Click" meta:resourcekey="btnNewDocumentsResource1"></dx:ASPxButton>
                                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView2_CustomButtonCallback" OnStartRowEditing="ASPxGridView2_StartRowEditing" DataSourceID="SqlDataSource1" meta:resourcekey="ASPxGridView2Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1">
                                            <EditFormSettings Visible="False"></EditFormSettings>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="URl" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="CreationDate" VisibleIndex="3" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="11" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource1">
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
                                    <SettingsCommandButton>
                                        <EditButton ButtonType="Image">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </EditButton>
                                    </SettingsCommandButton>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT Std_CourseDocuments.ID, Std_CourseDocuments.Name, Std_CourseDocuments.URl, Std_CourseDocuments.CreationDate FROM Std_CourseDocuments INNER JOIN Std_Course ON Std_CourseDocuments.CourseID = Std_Course.ID WHERE (Std_Course.ID = @ID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="ID" Name="ID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label10" runat="server" Text="Teachers" meta:resourcekey="Label10Resource1"></asp:Label></legend>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="0" ReadOnly="True" meta:resourcekey="GridViewDataTextColumnResource4">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Phone" Caption="Phone" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="address" Caption="Address" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Email" Caption="Email" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource8"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="11" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource2">
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
                            </fieldset>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <div class="form_input">
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
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
