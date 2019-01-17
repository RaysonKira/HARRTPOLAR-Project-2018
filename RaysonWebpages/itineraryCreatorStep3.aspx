<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="itineraryCreatorStep3.aspx.cs" Inherits="RaysonWebpages_itineraryCreatorStep3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        div.transbox {
          margin: 30px;
          background-color: #ffffff;
          border: 1px solid black;
          opacity: 0.6;
          filter: alpha(opacity=60); /* For IE8 and earlier */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="images" Runat="Server">
    <img src="../images/logo.PNG" class="nav-logo"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="templateContent" Runat="Server">
    <div class="container">
        <h1 style="text-align: center;text-transform: uppercase;">End Of Travel Itinerary Creation!</h1>
        <center>
        <p><small>Please Proceed To Your Itinerary Manager Page To See <br /> Your Creation Travel Details And Travel Itinerary!</small></p>
            <br />
        <div class="btn-group" role="group" aria-label="Basic example">
          <asp:button id="itineraryManagerButton" type="button" runat="server" class="btn btn-secondary btn btn-info" Text="View Itinerary Manager" OnClick="itineraryManagerButton_Click"/>&nbsp&nbsp
          <button type="button" class="btn btn-secondary btn btn-info">Back To Homepage</button>&nbsp&nbsp
          <button type="button" class="btn btn-secondary btn btn-info">Log-Out</button>
        </div>
        </center>
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

