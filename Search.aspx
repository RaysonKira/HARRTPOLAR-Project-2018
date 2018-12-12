<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="templateContent" Runat="Server">
            
            <asp:TextBox ID="searchBox" runat="server" ></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" />
            <br>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Selected="True">--Please Select a trip code --</asp:ListItem>
                <asp:ListItem>EMR-1920</asp:ListItem>
                <asp:ListItem>INT-9018</asp:ListItem>
            </asp:DropDownList>
    
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">No</td>
            <td class="auto-style1">Name</td>
            <td class="auto-style3">Adminssion No</td>
            <td class="auto-style4">Contact No</td>
            <td>Course</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="loadJavaScript" Runat="Server">
</asp:Content>



