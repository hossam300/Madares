<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ERPWebForms.Default" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width" />
    <title>مدارس الحرية للغات</title>
    <link rel="icon" type="image/x-icon" href="../images/madares_logo.gif" />
    <link href="css/reset.css" rel="stylesheet" type="text/css">
    <link href="css/layout.css" rel="stylesheet" type="text/css">
    <link href="css/themes.css" rel="stylesheet" type="text/css">
    <link href="css/typography.css" rel="stylesheet" type="text/css">
    <link href="css/styles.css" rel="stylesheet" type="text/css">
    <link href="css/shCore.css" rel="stylesheet" type="text/css">
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="css/jquery.jqplot.css" rel="stylesheet" type="text/css">
    <link href="css/jquery-ui-1.8.18.custom.css" rel="stylesheet" type="text/css">
    <link href="css/data-table.css" rel="stylesheet" type="text/css">
    <link href="css/form.css" rel="stylesheet" type="text/css">
    <link href="css/ui-elements.css" rel="stylesheet" type="text/css">
    <link href="css/sprite.css" rel="stylesheet" type="text/css">
    <link href="css/gradient.css" rel="stylesheet" type="text/css">
    <!--[if IE 7]>
<link rel="stylesheet" type="text/css" href="css/ie/ie7.css" />
<![endif]-->
    <!--[if IE 8]>
<link rel="stylesheet" type="text/css" href="css/ie/ie8.css" />
<![endif]-->
    <!--[if IE 9]>
<link rel="stylesheet" type="text/css" href="css/ie/ie9.css" />
<![endif]-->
    <!-- Jquery -->
    <asp:PlaceHolder runat="server">
        <%: System.Web.Optimization.Scripts.Render("~/bundles/js") %>
    </asp:PlaceHolder>
    <script type="text/javascript">
        $(function () {
            $(window).resize(function () {
                $('.login_container').css({
                    position: 'absolute',
                    left: ($(window).width() - $('.login_container').outerWidth()) / 2,
                    top: ($(window).height() - $('.login_container').outerHeight()) / 2
                });
            });
            // To initially run the function:
            $(window).resize();
        });
    </script>
</head>
<body id="theme-default" class="full_block">
    <div id="login_page">
        <div class="login_container">
            <div class="login_header blue_lgel">
                <ul class="login_branding">
                    <li>
                        <div class="logo_small">
                            <img src="images/madares_logo.gif" width="100" height="50" alt="bingo">
                        </div>
                        <h1 style="margin-left: 150px; font-family: 'Lucida Calligraphy'; font-size: larger"><span style="margin-left: 150px;">مدارس الحرية للغات</span></h1>
                    </li>
                    <li class="right go_to"><a href="#" title="Go to Main Site" class="home">Go To Main Site</a></li>
                </ul>
            </div>
            <div class="login_success" style="display: none">
                <span class="icon"></span>Login Successfully
            </div>
            <div class="login_invalid" style="display: none">
                <span class="icon"></span>Invalid Username/Password
            </div>
            <form runat="server">
                <div class="login_form">
                    <h3 class="blue_d">Madares Login</h3>
                    <ul>
                        <li class="login_user">
                            <asp:TextBox ID="UserName" runat="server" CssClass="limiter required" />
                        </li>
                        <li class="login_pass">
                            <asp:TextBox ID="Password" type="password" runat="server" CssClass="limiter required" />
                        </li>
                    </ul>
                </div>
                <asp:Button ID="btnlongin" runat="server" Text="Login" CssClass="login_btn blue_lgel" OnClick="btnlongin_Click" />
            </form>
        </div>
    </div>
</body>
</html>
