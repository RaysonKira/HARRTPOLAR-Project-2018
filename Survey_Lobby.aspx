<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Survey_Lobby.aspx.cs" Inherits="Survey_Lobby" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
        .auto-style1 {
            width: 87%;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="templateContent" Runat="Server">

<%--Survey Lobby Title and content --%>
<h2>Your Surveys &nbsp;
    <asp:ImageButton ID="btn_addSurvey" runat="server" AlternateText="add" Height="20px" ImageUrl="~/Images/img_154383.png" />
</h2>
   
   

           <div id="content" class="auto-style1">
                 <%--
        <nav class="surveyContent  navbar-light bg-light">
            <div class="container-fluid">
             
                
                <asp:Table runat="server" Font-Size="Large" CellPadding="10">
                    <asp:TableRow>
                        <asp:TableCell Font-Size="Larger" >Survey_1</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell >Survey_1</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell >Survey_1</asp:TableCell>
                    </asp:TableRow>
                    


                </asp:Table>

                    
             </div>
            </nav>
                     --%>

 <%--Display Survey Info with gridview http://www.dotnetlearners.com/blogs/view/20/Aspnet-Gridview-basic-example-for-insert-update-and-delete-the-records.aspx --%>
                 <asp:GridView ID="gvSurveyContent" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Surveys" GridLines="Both"  EmptyDataRowStyle-ForeColor="Red">
                     <Columns>
                         <asp:TemplateField HeaderText ="Customer Name">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_custName" runat="server" Text="TEST_1"></asp:Label>

                             </ItemTemplate>

                         </asp:TemplateField>

                     </Columns>
                      

                 </asp:GridView>

    </div>
        

</asp:Content>

