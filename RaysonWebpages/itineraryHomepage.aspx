<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="itineraryHomepage.aspx.cs" Inherits="RaysonWebpages_itineraryHomepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="images" Runat="Server">
    <img src="../images/logo.PNG" class="nav-logo"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="templateContent" Runat="Server">
    <div class="limiter">
        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" CellPadding="4" class="table100" ForeColor="#333333" GridLines="None" OnRowCommand="deleteAndEditRow" OnSelectedIndexChanged="gv1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Date Created" ReadOnly="True" DataField="currentTimeClass" NullDisplayText="Nil" />
                <asp:BoundField DataField="travelDetailsId" HeaderText="Itinerary ID" ReadOnly="True" />
                <asp:BoundField DataField="tripNameClass" HeaderText="Itinerary Name" ReadOnly="True" />
                <asp:BoundField DataField="startDateClass" HeaderText="Start Date" ReadOnly="True" />
                <asp:BoundField DataField="endDateClass" HeaderText="End Date" ReadOnly="True" />
                <asp:BoundField DataField="countryClass" HeaderText="Country" ReadOnly="True" />
                <asp:BoundField DataField="stateClass" HeaderText="State" ReadOnly="True" />
                <asp:ButtonField CommandName="editButton" HeaderText="Edit Travel Details" Text="Edit">
                <ItemStyle Height="80px" Width="80px" Wrap="False" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="editItinerary" HeaderText="Edit Itinerary" Text="Edit" />
                <asp:ButtonField CommandName="deleteButton" HeaderText="Remove" Text="Delete">
                <ItemStyle Height="80px" Width="80px" />
                </asp:ButtonField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" BorderColor="Black" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" BorderColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="loadJavaScript" Runat="Server">
    <script src="../javascript/main.js"></script>
    <script src="../javascript/step1.js"></script>
<!--===============================================================================================-->
	<script src="../vendor/bootstrap/js/popper.js"></script>
<!--===============================================================================================-->
	<script src="../vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="../javascript/mainTable.js"></script>
</asp:Content>

