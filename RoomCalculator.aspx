<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RoomCalculator.aspx.cs" Inherits="RoomCalculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="templateContent" Runat="Server">
    <div>
        <asp:Label ID="Label2" runat="server" Text="Trip Code"></asp:Label>
    
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Selected="True">--Choose a trip--</asp:ListItem>
            <asp:ListItem Value="Intern1902">Intern1902</asp:ListItem>
            <asp:ListItem>Immer0192</asp:ListItem>
            <asp:ListItem>Study1890</asp:ListItem>
        </asp:DropDownList>       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
        <br />
        <asp:Label ID="Label1" runat="server" Text="No of people per room: "></asp:Label>&nbsp;
        <asp:TextBox ID="numberStudent" runat="server" CssClass="auto-style1"  placeholder="No of student in a room" ></asp:TextBox>
        <br />

        <br />
        <asp:Label ID="result" runat="server" Text="Results: " Visible="False"></asp:Label>

        <asp:Label ID="resultLabel" runat="server"></asp:Label>

        <br />
        <asp:Button ID="Button1" runat="server" Text="Calculate" OnClick="Button1_Click" />
    
        <br />
    
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="loadJavaScript" Runat="Server">
</asp:Content>

