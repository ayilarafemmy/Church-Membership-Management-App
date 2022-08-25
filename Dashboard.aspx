<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
    <tr>
        <td style="height: 22px">
            <asp:DropDownList ID="DropDownList13" runat="server" Height="35px" Width="139px">
                <asp:ListItem Value="Null">Select Salutation</asp:ListItem>
                <asp:ListItem>Bro</asp:ListItem>
                <asp:ListItem>Sister</asp:ListItem>
                <asp:ListItem>Pastor</asp:ListItem>
                <asp:ListItem>Deacon</asp:ListItem>
                <asp:ListItem>Prof</asp:ListItem>
                <asp:ListItem>Dr.</asp:ListItem>
                <asp:ListItem>Chief</asp:ListItem>
                <asp:ListItem>Evangelist</asp:ListItem>
                <asp:ListItem>Deaconness</asp:ListItem>
                <asp:ListItem>A/P</asp:ListItem>
                <asp:ListItem>Mr</asp:ListItem>
                <asp:ListItem>Mrs</asp:ListItem>
                <asp:ListItem>Miss</asp:ListItem>
                <asp:ListItem>Rev.</asp:ListItem>
                <asp:ListItem>Master</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server" Placeholder="First Name" Required="" CssClass="input-field" BorderColor="#3333CC" BorderStyle="Outset" BorderWidth="1px" Height="35px" Width="180px"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" Placeholder="Last Name" required="" CssClass="input-field" Height="35px" Width="180px" BorderColor="#3333CC" BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
        </td>
        <td style="height: 22px"></td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" Placeholder="Phone" TextMode="Number" required="" Height="35px" Width="180px" BorderColor="#3333CC" BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" Placeholder="email" TextMode="Email" Height="35px" Width="180px" BorderColor="#3333CC" BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" Placeholder="Birthday e.g 1,2" TextMode="Number" required="" Height="35px" Width="180px" BorderColor="#3333CC" BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
            <asp:DropDownList ID="DropDownList2" runat="server" Height="35px" Width="180px">
                <asp:ListItem>Select Birth Month</asp:ListItem>
                <asp:ListItem Value="1">January</asp:ListItem>
                <asp:ListItem Value="2">February</asp:ListItem>
                <asp:ListItem Value="3">March</asp:ListItem>
                <asp:ListItem Value="4">April</asp:ListItem>
                <asp:ListItem Value="5">May</asp:ListItem>
                <asp:ListItem Value="6">June</asp:ListItem>
                <asp:ListItem Value="7">July</asp:ListItem>
                <asp:ListItem Value="8">August</asp:ListItem>
                <asp:ListItem Value="9">September</asp:ListItem>
                <asp:ListItem Value="10">October</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="180px">
                <asp:ListItem>Select Sex</asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList3" runat="server" Height="35px" Width="180px">
                <asp:ListItem>Select Position</asp:ListItem>
                <asp:ListItem>Full Pastor</asp:ListItem>
                <asp:ListItem>A/P</asp:ListItem>
                <asp:ListItem>Pastor</asp:ListItem>
                <asp:ListItem>Deacon/Deaconness</asp:ListItem>
                <asp:ListItem>Member</asp:ListItem>
                <asp:ListItem>Worker</asp:ListItem>
                <asp:ListItem>Minister</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="DropDownList4" runat="server" Height="35px" Width="180px">
                <asp:ListItem Value="Null">Select Unit1</asp:ListItem>
                <asp:ListItem>Minister</asp:ListItem>
                <asp:ListItem>Ushering</asp:ListItem>
                <asp:ListItem>Sanitation</asp:ListItem>
                <asp:ListItem>Media</asp:ListItem>
                <asp:ListItem>Technical</asp:ListItem>
                <asp:ListItem>FollowUp</asp:ListItem>
                <asp:ListItem>Protocol</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Security</asp:ListItem>
                <asp:ListItem>Junior Church</asp:ListItem>
                <asp:ListItem>Prayer</asp:ListItem>
                <asp:ListItem>Sunday School</asp:ListItem>
                <asp:ListItem>Choir</asp:ListItem>
                <asp:ListItem>Welfare</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList5" runat="server" Height="35px" Width="180px">
                <asp:ListItem Value="Null">Select Unit2</asp:ListItem>
                <asp:ListItem>Minister</asp:ListItem>
                <asp:ListItem>Ushering</asp:ListItem>
                <asp:ListItem>Sanitation</asp:ListItem>
                <asp:ListItem>Media</asp:ListItem>
                <asp:ListItem>Technical</asp:ListItem>
                <asp:ListItem>FollowUp</asp:ListItem>
                <asp:ListItem>Protocol</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Security</asp:ListItem>
                    <asp:ListItem>Junior Church</asp:ListItem>
                <asp:ListItem>Prayer</asp:ListItem>
                <asp:ListItem>Sunday School</asp:ListItem>
                <asp:ListItem>Choir</asp:ListItem>
                <asp:ListItem>Welfare</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList6" runat="server" Height="35px" Width="180px">
                <asp:ListItem Value="Null">Select Unit3</asp:ListItem>
                <asp:ListItem>Minister</asp:ListItem>
                <asp:ListItem>Ushering</asp:ListItem>
                <asp:ListItem>Sanitation</asp:ListItem>
                <asp:ListItem>Media</asp:ListItem>
                <asp:ListItem>Technical</asp:ListItem>
                <asp:ListItem>FollowUp</asp:ListItem>
                <asp:ListItem>Protocol</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Security</asp:ListItem>
                    <asp:ListItem>Junior Church</asp:ListItem>
                <asp:ListItem>Prayer</asp:ListItem>
                <asp:ListItem>Sunday School</asp:ListItem>
                <asp:ListItem>Choir</asp:ListItem>
                <asp:ListItem>Welfare</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox7" runat="server" Placeholder="Alternate Phone" TextMode="Number" required="" Height="35px" Width="180px" BorderColor="#3333CC" BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
            <asp:TextBox ID="TextBox8" runat="server" Placeholder="Occupation" required="" Height="35px" Width="180px" BorderColor="#3333CC" BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox9" runat="server" TextMode="MultiLine" Placeholder="Office Address" Height="70px" Width="180px" BorderColor="#3333CC" BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
            <asp:TextBox ID="TextBox6" runat="server" Placeholder="Home Address" TextMode="MultiLine" required="" Height="70px" Width="180px" BorderColor="#3333CC" BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="DropDownList7" runat="server" Height="35px" Width="448px">
                <asp:ListItem Value="Null">Employment Status</asp:ListItem>
                <asp:ListItem>Employed</asp:ListItem>
                <asp:ListItem>Student</asp:ListItem>
                <asp:ListItem>Unemployed</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="DropDownList8" runat="server" Height="35px" Width="180px">
                <asp:ListItem Value="Null">Born Again</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList9" runat="server" Height="35px" Width="180px">
                <asp:ListItem Value="Null">Baptised</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList14" runat="server" Height="35px" Width="180px">
                <asp:ListItem>Are You Joining Us</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Undecided</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="DropDownList10" runat="server" Height="35px" Width="180px">
                <asp:ListItem Value="Null">Worker</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList11" runat="server" Height="35px" Width="180px">
                <asp:ListItem Value="Null">Marital Status</asp:ListItem>
                <asp:ListItem>Married</asp:ListItem>
                <asp:ListItem>Single</asp:ListItem>
                <asp:ListItem>Widower</asp:ListItem>
                <asp:ListItem>Separated</asp:ListItem>
                <asp:ListItem>Complicated</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList12" runat="server" Height="35px" Width="180px">
                <asp:ListItem>Member</asp:ListItem>
                <asp:ListItem>Pastor</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Super Admin</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Register Member" CssClass="btn btn-default" Width="363px" OnClick="Button1_Click" />
                      <%--<a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>--%>
                    <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br /></td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

