<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="allmembers.aspx.cs" Inherits="allmembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            font-weight: bold;
            background-color: #F33533;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        All Members

    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Download"  CssClass="btn btn-primary btn-block" Visible="false" OnClick="Button1_Click" Width="250px"/>
        <asp:Button ID="Button2" runat="server" Text="Send Message"  CssClass="btn btn-primary btn-block" Width="250px" OnClick="Button2_Click"/>
      <p>
          <asp:TextBox ID="TextBox1" runat="server" Height="69px" Visible="False" Width="272px" MaxLength="142" TextMode="MultiLine"></asp:TextBox>
          <strong>
          <asp:Button ID="Button3" runat="server" BorderStyle="None" CssClass="auto-style1" OnClick="Button3_Click" Text="Submit" Visible="False" Width="159px" />
          </strong>
      <p>
          &nbsp;<div style="width: 100%; height: 500px; overflow: scroll "
        <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-striped">
       
        </asp:GridView></div>

    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

