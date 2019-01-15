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
		<div class="container-table1000">
			<div class="wrap-table1000">
				<div class="table100">
					<table>
						<thead>
							<tr class="table100-head">
								<th class="column1">Date Created</th>
								<th class="column2">Itinerary ID</th>
								<th class="column3">Itinerary Name</th>
								<th class="column4">Start Date</th>
								<th class="column5">End Date</th>
                                <th class="column6">Country</th>
                                <th class="column7">State</th>
                                <th class="column8">Action</th>
							</tr>
						</thead>
						<tbody runat="server" id="tableBody">
                            <% foreach (var x in details())
                                { %>
                               <tr>
                                   <th class="column1">20/10/2000</th>
                                   <th class="column2"><%= x.travelDetailsId %></th>
                                   <th class="column3"><%= x.tripNameClass %></th>
                                   <th class="column4"><%= x.startDateClass %></th>
                                   <th class="column5"><%= x.endDateClass %></th>
                                   <th class="column6"><%= x.countryClass %></th>
                                   <th class="column7"><%= x.stateClass %></th>
                                   <th class="column8">
                                       <asp:Button ID="edit" value="<%= x.travelDetailsId %>" class="btn btn-info editButton" runat="server" Text="Edit" />
                                       <asp:Button ID="delete" value="<%= x.travelDetailsId %>" class="btn btn-info my-button" runat="server" Text="Delete" />
                                   </th>
                               </tr>
                            <% } %>
						</tbody>
					</table>
				</div>
			</div>
		</div>
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

