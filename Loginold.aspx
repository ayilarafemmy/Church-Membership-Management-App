<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Loginold.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>CMMS</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
     <style type="text/css">
         .auto-style1 {
             font-weight: bold;
         }
         .auto-style2 {
             color: #F62C34;
             font-size: medium;
         }
     </style>
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div>
          <div class="login-box">
  <div class="login-logo">
    <asp:Image ID="Image1" runat="server"  ImageUrl="~/logo.jpg" Height="76px" Width="81px"/>
      <br />
      <span class="auto-style2"><strong class="auto-style1">Church Membership Management System</strong></span></div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg">Sign in to start your session</p>

      
        <div class="input-group mb-3">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Phone No"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-phone"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            <div class="icheck-primary">
              <input type="checkbox" id="remember">
              <label for="remember">
                Remember Me
              </label>
            </div>
          </div>
          <!-- /.col -->
          <div class="col-4">
                <asp:Button ID="Button1" runat="server" Text="Sign In" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" />
          </div>
          <!-- /.col -->
        </div>
      

      <p class="mb-1">
        <a href="forgotps.aspx">I forgot my password</a>
      </p>
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
<!-- /.login-box -->

<!-- jQuery -->
<script src="../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
        </div>
    </form>
</body>
</html>
