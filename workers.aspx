<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="workers.aspx.cs" Inherits="allmembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        All Workers

    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Download"  CssClass="btn btn-primary btn-block" Visible="false" OnClick="Button1_Click" Width="250px"/>
        <asp:Button ID="Button2" runat="server" Text="Send Message to Workers"  CssClass="btn btn-primary btn-block" Visible="false" Width="250px" OnClick="Button2_Click"/>
      <p>
          <asp:TextBox ID="TextBox1" runat="server" Height="69px" Visible="False" Width="272px" MaxLength="142" TextMode="MultiLine"></asp:TextBox>
          <strong>
          <asp:Button ID="Button3" runat="server" BorderStyle="None" CssClass="auto-style1" OnClick="Button3_Click" Text="Submit" Visible="False" Width="159px" BorderWidth="0px" style="font-weight: bold; color: #FFFFFF; background-color: #D2323B" />
          </strong>
      <div style="width: 100%; height: 500px; overflow: scroll "
        <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-striped">
       
        </asp:GridView></div>

    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>

    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

