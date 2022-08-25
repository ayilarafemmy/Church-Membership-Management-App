<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="forgotps.aspx.cs" Inherits="forgotps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td class="auto-style1" colspan="4">
                <asp:TextBox ID="TextBox1" runat="server" Placeholder="Enter Phone" CssClass="form-control" Width="250px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Get Password" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" Width="200px" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
           
                <asp:Label ID="Label3" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label" Visible="false"></asp:Label>
              <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

