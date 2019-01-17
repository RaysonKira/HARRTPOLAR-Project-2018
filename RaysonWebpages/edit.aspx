<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="RaysonWebpages_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="images" Runat="Server">
    <img src="../images/logo.PNG" class="nav-logo"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="templateContent" Runat="Server">
            <asp:HiddenField ID="travelDetailsIdHidden" runat="server" />
            <div class="content-wrapper">
            <div class="site-content" style="border: inherit">
                <h1 style="text-align: center;text-transform: uppercase;">Editing Travel details</h1>
                <br />
                <div class="form-group">
                    <label for="tripName">Trip Name</label>
                    <asp:textbox runat="server" class="form-control" id="tripNameDetailsTextBox" placeholder="Enter Trip Name"></asp:textbox>
                </div>
                <div class="form-group">
                    <label for="startDateInput">Start Date</label>
                    <div class='input-group date' id='datetimepickerStart'>
                        <asp:textbox runat="server" type="date" class="form-control" id="startDateInput" placeholder="Enter Date"></asp:textbox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="endDateInput">End Date</label>
                    <div class='input-group date' id='datetimepickerEnd'>
                        <asp:textbox runat="server" type="date" class="form-control" id="endDateInput" placeholder="Enter Date"></asp:textbox>
                        <div class="input-group-append">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </div>
                    </div>
                </div>
                <div class="form-row align-items-center">
                    <div class="col-auto my-1">
                        <label class="mr-sm-2" for="countryTextBox">Country</label>
                        <asp:textbox id="countryTextBox" class="form-control" placeholder="Enter Country" runat="server" autocompletetype="BusinessCountryRegion"></asp:textbox>
                    </div>
                </div>
                <div class="form-row align-items-center">
                    <div class="col-auto my-1">
                        <label class="mr-sm-2" for="countryTextBox">Country</label>
                        <asp:textbox id="stateTextBox" class="form-control" placeholder="Enter State" runat="server" autocompletetype="BusinessCountryRegion"></asp:textbox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="description">Description</label>
                    <textarea cols="20" class="form-control" id="descriptionDetails" rows="3" runat="server"></textarea>
                </div>
                <asp:label id="errorMessageDetails" runat="server"></asp:label>
                <asp:scriptmanager id="ScriptManager1" runat="server">
                </asp:scriptmanager>
                <asp:updateprogress id="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img class="auto-style2" src="../Images/Pacman-1s-200px.gif" />
                        Please Wait...<br />
                    </ProgressTemplate>
                </asp:updateprogress>
                <asp:updatepanel id="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="status" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="editTravelDetailsButton" runat="server" class="btn btn-info btn-lg btn-block"  text="Save Travel Details" OnClick="editTravelDetailsButton_Click" />
                    </ContentTemplate>
                </asp:updatepanel>
                <br />
                <br />
            </div> 
                <div class="sidebar">
        <div class="widget">
            <div class="toolBox">
                <h4 style="text-align: center;text-transform: uppercase;">Current Data</h4>
                <hr style="width:100%;"/>
                <p><strong>Trip Name:</strong></p>
                <asp:Label ID="tripNameLbl" runat="server" Text=""></asp:Label>
                <br />
                <hr style="width:100%;"/>
                <p><strong>Start Date:</strong></p>
                <asp:Label ID="startDateLblVer2" runat="server" Text=""></asp:Label>
                <br />
                <hr style="width:100%;"/>
                <p><strong>End Date:</strong></p>
                <asp:Label ID="endDateLbl" runat="server" Text=""></asp:Label>
                <br />
                <hr style="width:100%;"/>
                <p><strong>Country:</strong></p>
                <asp:Label ID="countryLbl" runat="server" Text=""></asp:Label>
                <br />
                <hr style="width:100%;"/>
                <p><strong>State:</strong></p>
                <asp:Label ID="stateLbl" runat="server" Text=""></asp:Label>
                <br />
                <hr style="width:100%;"/>
                <p><strong>Description:</strong></p>
                <asp:Label ID="descriptionLbl" runat="server" Text=""></asp:Label>
                <br />
                <hr style="width:100%;"/>
            </div>
            <br />
            <br />
        </div>
    </div>        
    </div>
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="loadJavaScript" Runat="Server">

</asp:Content>

