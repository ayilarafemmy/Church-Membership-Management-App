<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Events : Upcoming Events and their Handlers</p>
    <table class="w-100">
        <tr>
            <td colspan="3">Events Upload</td>
            <td class="text-right">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:FileUpload ID="FileUpload1" runat="server" BackColor="#FFCCFF"/>
                <asp:Button ID="Button2" runat="server" Height="40px" Text="Preview" Width="180px" OnClick="PopulateGrid" />
                <asp:Button ID="Button1" runat="server" Text="Upload" BackColor="#0000CC" BorderStyle="None" ForeColor="White" Width="180px" Height="40px" OnClick="Button1_Click" Visible="False" />
            </td>
            <td class="text-right"><strong>
                <asp:LinkButton ID="LinkButton1" runat="server">Download Template</asp:LinkButton>
                </strong></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblConfirm" runat="server" Text="*"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2"><strong>Upcoming Events</strong></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-striped">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

