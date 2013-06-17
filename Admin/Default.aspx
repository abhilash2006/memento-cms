<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="utf-8">
    <title>sysTEKNIK | Login - KOINONIA Shrajah</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <!-- Styles -->

    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/bootstrap-responsive.css" rel="stylesheet">
    <link href="css/bootstrap-overrides.css" rel="stylesheet">
    <link href="css/ui-lightness/jquery-ui-1.8.21.custom.css" rel="stylesheet">
    <link href="css/slate.css" rel="stylesheet">
    <link href="css/components/signin.css" rel="stylesheet" type="text/css">
    <link href="js/plugins/msgAlert/css/msgAlert.css" rel="stylesheet" />
    <!-- Javascript -->

    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/jquery-ui-1.8.18.custom.min.js"></script>
    <script src="js/jquery.ui.touch-punch.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/demos/signin.js"></script>
    <script src="js/plugins/msgAlert/js/msgAlert.js"></script>


</head>

<body>

    <form id="form1" runat="server">


        <span style="text-align: center">
            <center><img src="img/logoAdminLogin.png" /></center>
        </span>

        <div class="account-container login">

            <div class="content clearfix">

                <h1>Admin Login In</h1>

                <div class="login-fields">

                    <p>Sign in using your Login Name & Password:</p>

                    <div class="field">
                        <label for="username">Username:</label>
                        <asp:TextBox ID="txtLoginName" placeholder="Username" CssClass="login username-field" runat="server"></asp:TextBox>


                    </div>
                    <!-- /field -->

                    <div class="field">
                        <label for="password">Password:</label>
                        <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Password" CssClass="login password-field" runat="server"></asp:TextBox>

                    </div>
                    <!-- /password -->

                </div>
                <!-- /login-fields -->

                <div class="login-actions">

                    <span class="login-checkbox">
                        <input id="Field" name="Field" type="checkbox" class="field login-checkbox" value="First Choice" tabindex="4" runat="server" />

                        <label class="choice" for="Field">Keep me signed in</label>
                    </span>
                    <asp:LinkButton ID="lbLogin" runat="server" CssClass="button btn btn-secondary btn-large" OnClick="lbLogin_Click">Sign In</asp:LinkButton>

                </div>
                <!-- .actions -->

                <div class="login-social" style="display: none;">
                    <p>Sign in using social network:</p>

                    <div class="twitter">
                        <a href="#" class="btn_1">Login with Twitter</a>
                    </div>

                    <div class="fb">
                        <a href="#" class="btn_2">Login with Facebook</a>
                    </div>
                </div>
            </div>
            <!-- /content -->

        </div>
        <!-- /account-container -->

        <!-- Text Under Box -->
        <div class="login-extra" style="display: none">
            Don't have an account? <a href="signup.aspx">Sign Up</a><br />
            Remind <a href="#">Password</a>
        </div>
        <!-- /login-extra -->

        <script type="text/javascript">
            function jQueryErrorMessage(e) {
                $.msgAlert({
                    type: 'error',
                    title: 'Koinonia Sharjah',
                    text: e
                });
            }
        </script>

    </form>

</body>
</html>
