<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="ERPWebForms.HR.Import" %>

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
            <div>
                <div id="content">
                    <div class="grid_container">
                        <div class="grid_12">
                            <div class="widget_wrap">
                                <div class="widget_top">
                                    <span class="h_icon list"></span>
                                    <h6>
                                        <asp:Label ID="Label5" runat="server" Text="Import Attend From Excel" meta:resourcekey="Label5Resource1"></asp:Label></h6>
                                </div>
                                <div class="widget_content">
                                    <div id="form103" class="form_container left_label valid_tip">
                                        <div>
                                            <br />
                                        </div>
                                        <fieldset style="border: 1px solid">
                                            <legend>
                                                <asp:Label ID="Label1" runat="server" Text="Import Attend From Excel" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                            <ul>
                                                <li>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" meta:resourcekey="FileUpload1Resource1" />
                                                    <asp:DropDownList ID="ddlStyle" runat="server" AppendDataBoundItems="True" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" DataSourceID="SqlDataSource1" DataTextField="SheetStyleName" DataValueField="SheetStyleID" meta:resourcekey="ddlStyleResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1">Choose Excel Style</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [SheetStyleID], [SheetStyleName] FROM [HR_ExcelSheetStyle]"></asp:SqlDataSource>
                                                </li>
                                                <li>
                                                    <asp:Button runat="server" ID="btnImport" Text="Import" class="btn_small btn_blue" OnClick="btnImport_Click" OnClientClick="colse();" meta:resourcekey="btnImportResource1" />
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
        </div>
    </form>
</body>
</html>