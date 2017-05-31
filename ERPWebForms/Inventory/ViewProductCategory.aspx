<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory/InventoryMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewProductCategory.aspx.cs" Inherits="ERPWebForms.Inventory.ViewProductCategory" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
      <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="lblHeader" runat="server" Text="Create Product Category" meta:resourcekey="lblHeaderResource1"></asp:Label></h6>
                    </div>
                </div>
                <div class="widget_content">
                    <div id="form103" class="form_container left_label valid_tip">
                        <div>
                            <br />
                        </div>
                        <fieldset style="border: 1px solid">
                            <legend>
                                <asp:Label ID="lblProductCategoryInformation" runat="server" Text="Product Category Information" meta:resourcekey="lblProductCategoryInformationResource1"></asp:Label></legend>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblProductCategory" Text="Product Category" runat="server" meta:resourcekey="lblProductCategoryResource1"></asp:Label></label>
                                        <div class="form_input">
                                            <div class="form_grid_6 alpha">
                                                <asp:Label ID="txtProductCategory" placeholder="Product Category" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtProductCategoryResource1"></asp:Label>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="form_grid_12">
                                        <label class="field_title">
                                            <asp:Label ID="lblCategoryDescription" Text="Category Description" runat="server" meta:resourcekey="lblCategoryDescriptionResource1"></asp:Label>
                                        </label>
                                        <div class="form_input">
                                            <div class="form_grid_10 alpha">
                                                <asp:Label TextMode="MultiLine" ID="txtCategoryDescription" placeholder="Description" Columns="5" Rows="5" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtCategoryDescriptionResource1"></asp:Label>
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
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="False" meta:resourcekey="btnEditResource1" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" CausesValidation="False" meta:resourcekey="btnCancelResource1" />
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
