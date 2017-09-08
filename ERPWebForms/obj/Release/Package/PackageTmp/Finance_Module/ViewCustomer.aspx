<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="ViewCustomer.aspx.cs" Inherits="ERPWebForms.Finance_Module.ViewCustomer" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label5" runat="server" Text="Customer Details" meta:resourcekey="Label5Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label1" runat="server" Text="Customer Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label2" runat="server" Text="Customer ID" meta:resourcekey="Label2Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblCustomerID" class="limiter required" meta:resourcekey="lblCustomerIDResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Customer Name" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblCustomerName" class="limiter required" meta:resourcekey="lblCustomerNameResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="Total Balance" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblTotalBalance" class="limiter required" meta:resourcekey="lblTotalBalanceResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;<asp:Label ID="Label6" runat="server" Text="Total Buyed Amount" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblTotalBuyedAmount" class="limiter required" meta:resourcekey="lblTotalBuyedAmountResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Creation Date" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:Label runat="server" ID="lblCreationDate" class="limiter required" meta:resourcekey="lblCreationDateResource1"></asp:Label>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Last Modified Date" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:Label runat="server" ID="lblLastModifiedDate" class="limiter required" meta:resourcekey="lblLastModifiedDateResource1"></asp:Label>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" OnClick="Button3_Click" meta:resourcekey="btnEditResource1" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="Button2_Click" meta:resourcekey="btnCancelResource1" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset style="border: 1px solid">
                                <legend>
                                    <asp:Label ID="Label9" runat="server" Text="Customer Items" meta:resourcekey="Label9Resource1"></asp:Label></legend>
                                <div>
                                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Create New Customer Item" Theme="PlasticBlue" meta:resourcekey="ASPxButton3Resource1">
                                        <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export To Excel" OnClick="ASPxButton1_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton1Resource1"></dx:ASPxButton>
                                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export To Word" OnClick="ASPxButton2_Click" UseSubmitBehavior="False" Theme="PlasticBlue" meta:resourcekey="ASPxButton2Resource1"></dx:ASPxButton>

                                    <dx:ASPxPopupControl ID="pcLogin2" runat="server" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcLogin" Width="750px" Height="400px"
                                        HeaderText="Create New Customer Item" AllowDragging="True" PopupAnimationType="None" EnableViewState="False" ContentUrl="~/Finance_Module/CreateCustomerItem.aspx">

                                        <ContentStyle>
                                            <Paddings PaddingBottom="5px" />
                                        </ContentStyle>
                                        <ContentCollection>
                                            <dx:PopupControlContentControl runat="server">
                                            </dx:PopupControlContentControl>
                                        </ContentCollection>
                                    </dx:ASPxPopupControl>
                                    <br />
                                </div>
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" EnableTheming="True" Theme="Moderno" KeyFieldName="ID" PreviewFieldName="ID" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Price" Caption="Price" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Balance" Caption="Balance" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn Caption="Select" ShowSelectCheckbox="True" VisibleIndex="0" ShowClearFilterButton="True" meta:resourcekey="GridViewCommandColumnResource1">
                                        </dx:GridViewCommandColumn>
                                        <%--<dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="7" Caption="View/Edit" ShowEditButton="True" meta:resourcekey="GridViewCommandColumnResource2">--%>
                                        <%--<CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="btnview" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                        <Image IconID="actions_show_16x16">
                                        </Image>
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                            </dx:GridViewCommandColumn>--%>
                                    </Columns>
                                    <SettingsPager NumericButtonCount="100" PageSize="100" Visible="False">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" />
                                    <SettingsCommandButton>
                                        <EditButton ButtonType="Image">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </EditButton>
                                    </SettingsCommandButton>
                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString2 %>' SelectCommand="SELECT Fin_Product.Name, Fin_Product.Cost, Fin_Product.Price, Fin_CustomerItems.Balance, Fin_CustomerItems.ID FROM Fin_Product INNER JOIN Fin_CustomerItems ON Fin_Product.ID = Fin_CustomerItems.ProductID WHERE (Fin_CustomerItems.CustomerID = @CustomerID)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter QueryStringField="CustomerID" Name="CustomerID"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>