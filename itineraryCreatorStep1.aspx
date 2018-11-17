<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="itineraryCreatorStep1.aspx.cs" Inherits="itineraryCreatorStep1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="templateContent" Runat="Server">
<div class="section1">
    <div class="container">
        <ul class="progressbar">
            <li class="active">Information</li>
            <li>Create Itinerary</li>
            <li>Confirm With Agency</li>
            <li>Done</li>
        </ul>
    </div>
</div>
<form method="get">
    <div class="form-group">
        <label for="exampleInputEmail1">Email address</label>
        <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" />
        <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
    </div>
    <div class="form-group">
        <label for="exampleInputPassword1">Password</label>
        <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password" />
    </div>
    <div class="form-check">
        <input type="checkbox" class="form-check-input" id="exampleCheck1" />
        <label class="form-check-label" for="exampleCheck1">Check me out</label>
    </div>
    <asp:Button ID="Submit" runat="server" Text="Button" class="btn btn-primary" />
</form>
</asp:Content>


