<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCustomerItem.aspx.cs" Inherits="ERPWebForms.Finance_Module.CreateCustomerItem" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" runat="server" dir="<%$ Resources:layoutDirection %>">
<head id="Head1" runat="server">
    <title></title>
    <link rel="icon" type="image/x-icon" href="../images/madares_logo.gif" />
    <link id="Link1" href="<%$ Resources:reset.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link2" href="<%$ Resources:layout.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link3" href="<%$ Resources:themes.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link4" href="<%$ Resources:typography.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link5" href="<%$ Resources:styles.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link6" href="<%$ Resources:shCore.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link7" href="<%$ Resources:bootstrap.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link8" href="<%$ Resources:jquery.jqplot.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link9" href="<%$ Resources:jquery-ui-1.8.18.custom.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link10" href="<%$ Resources:data-table.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link11" href="<%$ Resources:form.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link12" href="<%$ Resources:ui-elements.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link13" href="<%$ Resources:wizard.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link14" href="<%$ Resources:sprite.css %>" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link15" href="<%$ Resources:gradient.css %>" runat="server" rel="stylesheet" type="text/css" />
    <script>
        function colse() {
            form1.Hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="content">
                <div class="grid_container">
                    <div class="grid_12">
                        <div class="widget_wrap">
                            <div class="widget_top">
                                <span class="h_icon list"></span>
                                <h6>
                                    <asp:Label ID="Label5" runat="server" Text="Customer Item Details" meta:resourcekey="Label5Resource1"></asp:Label></h6>
                            </div>
                            <div class="widget_content">
                                <div id="form103" class="form_container left_label valid_tip">
                                    <div>
                                        <br />
                                    </div>
                                    <fieldset style="border: 1px solid">
                                        <legend>
                                            <asp:Label ID="Label1" runat="server" Text="Customer Item Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                        <ul>
                                            <li>
                                                <div class="form_grid_12">
                                                    <label class="field_title">
                                                        <asp:Label ID="lblCustomer" Text="Customer Name" runat="server" meta:resourcekey="lblCustomerResource1"></asp:Label></label>
                                                    <div class="form_input">

                                                        <div class="form_grid_4 alpha">
                                                            <dx:ASPxComboBox ID="ddlCustomer" AppendDataBoundItems="True" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlCustomerResource1" DataSourceID="SqlDataSource1" TextField="Name" ValueField="ID">
                                                            </dx:ASPxComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlCustomer" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [ID], [Name] FROM [Fin_Customer]"></asp:SqlDataSource>
                                                        </div>
                                                        <label class="field_title">
                                                            &nbsp;&nbsp;
                                                            <asp:Label ID="lblProduct" Text="Product Name" runat="server" meta:resourcekey="lblProductResource1"></asp:Label></label>
                                                        <div class="form_grid_4">
                                                            <dx:ASPxComboBox ID="ddlProduct" AppendDataBoundItems="True" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlProductResource1" DataSourceID="SqlDataSource2" TextField="Name" ValueField="ID" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                                            </dx:ASPxComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlProduct" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [ID], [Name] FROM [Fin_Product]"></asp:SqlDataSource>
                                                        </div>
                                                        <span class="clear"></span>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="form_grid_12">
                                                    <label class="field_title">
                                                        <asp:Label ID="lblPrice" Text="Price" runat="server" meta:resourcekey="lblPriceResource1"></asp:Label></label>
                                                    <div class="form_input">

                                                        <div class="form_grid_4 alpha">
                                                            <asp:TextBox ID="txtPrice" placeholder="Price" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtBankNameResource1"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPrice" runat="server" ErrorMessage="*" meta:resourcekey="RequiredFieldValidator1Resource1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form_grid_4">
                                                        </div>
                                                        <span class="clear"></span>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="form_grid_12">
                                                    <div class="form_input">
                                                        <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
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
        </div>
    </form>
</body>
</html>
