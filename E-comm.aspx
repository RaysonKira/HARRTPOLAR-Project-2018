<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="E-comm.aspx.cs" Inherits="E_comm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="templateContent" Runat="Server">
        <div>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Clothings"></asp:Label>
        <br />
        <img alt="" class="auto-style1" src="Images/winter%20clothes.jpg" /><br />
        <asp:Label ID="Label2" runat="server" Text="Price:"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="$9.99"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Purchase" />
    
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="loadJavaScript" Runat="Server">
</asp:Content>

