<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 40px;
        }
        .auto-style2 {
            color: #FFFFFF;
            background-color: #C34E5A;
            font-weight: bold;
        }
        .auto-style3 {
            color: #A6CE47;
        }
        .auto-style4 {
            color: #FFFFFF;
            font-weight: bold;
            background-color: #A6CE47;
        }
        .auto-style5 {
            color: #FFFFFF;
            font-weight: bold;
            background-color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td colspan="2"><strong>General Messaging</strong></td>
            <td><strong></strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><strong>Total Number of Subscribers: </strong>
                <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
                <br />
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="40px" Width="250px">
                    <asp:ListItem>Defined Messages</asp:ListItem>
                    <asp:ListItem Value="1">Message1</asp:ListItem>
                    <asp:ListItem Value="3">Message3</asp:ListItem>
                    <asp:ListItem Value="4">Message4</asp:ListItem>
                    <asp:ListItem Value="5">Message5</asp:ListItem>
                </asp:DropDownList>
                <strong>
                <asp:Button ID="Button1" runat="server" BorderStyle="None" CssClass="auto-style2" Height="40px" OnClick="Button1_Click" Text="Edit /Send Message" Width="250px" />
                </strong></td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4"><strong>
                <asp:Label ID="Label2" runat="server" CssClass="auto-style3" Text="*"></asp:Label>
                </strong></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" MaxLength="140" Visible="False"></asp:TextBox>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><strong>
                <asp:Button ID="Button2" runat="server" BorderStyle="None" CssClass="auto-style4" Height="40px" OnClick="Button2_Click" Text="Update Message" Visible="False" Width="250px" required="" />
                <asp:Button ID="Button3" runat="server" BorderStyle="None" CssClass="auto-style5" Height="40px" Text="Send Message" Visible="False" Width="250px" required="" OnClick="Button3_Click" />
                </strong></td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

