<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="birthdays.aspx.cs" Inherits="birthdays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Birthdays</p>
    <strong>
    <asp:Label ID="Labelq" runat="server" Text="Label" CssClass="auto-style1"></asp:Label>
    </strong>
    <p>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped">
        </asp:GridView>
    </p>
</asp:Content>

