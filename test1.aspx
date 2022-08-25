<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test1.aspx.cs" Inherits="test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <table>
            <tr><td>To</td><td><asp:TextBox ID="txtmobileno" runat="server"></asp:TextBox></td></tr>
            <tr><td>Message</td><td> <asp:TextBox ID="txtmsg" runat="server"></asp:TextBox></td></tr>
            <tr><td>Status</td><td><asp:Label ID="Label1" runat="server" ></asp:Label></td></tr>
            <tr><td>Name</td><td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td></tr>
            <tr><td>Phone Number</td><td><asp:TextBox ID="txtphone" runat="server"></asp:TextBox></td></tr>
            <tr><td>Password</td><td><asp:TextBox ID="txtpass" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td></tr>
        </table></div>
    </form>
</body>
</html>
