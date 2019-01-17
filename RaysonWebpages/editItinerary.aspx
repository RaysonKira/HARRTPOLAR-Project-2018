<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" validateRequest="false"  CodeFile="editItinerary.aspx.cs" Inherits="RaysonWebpages_editItinerary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="images" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="templateContent" Runat="Server">
    <div class="section1">
    <div class="container">
        <ul class="progressbar">
            <li class="active">Information</li>
            <li class="active">Create Itinerary</li>
            <li>Confirm With Agency</li>
            <li>Done</li>
        </ul>
    </div>
    <br />
    <br />
    <br />
    <br />
    <div class="row" style="margin: 0;"  align-self: center">
        <div class="columnRight" runat="server">
                <asp:HiddenField ID="travelId" runat="server" />
                <asp:HiddenField ID="travellID" runat="server" />
                <div id="myId" class ="travelItineraryDiv" style="border:solid;">
                    <%= postingHtml() %>
                </div>
                <br/>
                <button id="addNewActivity" class="btn btn-info" style="text-align:center;">Add New Activity</button>
                <button id="save" class="btn btn-info" style="text-align:center;">Save All Changes</button>
                <br />
                <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="saveBtn" runat="server" class="btn btn-info" OnClick="saveBtn_Click" style="text-align:center;" text="Save to Database" Width="181px" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <p id ="savingText"></p>
            <asp:updateprogress id="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img class="auto-style2" src="../Images/Pacman-1s-200px.gif" />
                        Saving Into Database...<br />
                    </ProgressTemplate>
            </asp:updateprogress>
        </div>
        <div class="sidebar">
            <div class="widget">
                    <div class="toolBox">
                    <label for="dialog_state"><i class="icon ion-ios-upload-outline"></i>Your Tools:</label><label style="float:right" class="button" id="settingButton" data-toggle="modal" data-target="#myModal"><i class="icon ion-ios-upload-outline"></i><img style="width:20px; height:20px;" class="auto-style2" src="../Images/Gear-1s-200px.gif" /></label>
                        <br />
                        <asp:Label ID="userNameLbl" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="emailLbl" runat="server" Text=""></asp:Label>
                        <div class="eachTools" runat="server" id="changeImportancy">
                             <hr style="width:100%;"/>
                            <div class="toolsName">
                                <div style="text-align:center">Change Importancy<asp:Button ID="importancyIconRemove" class ="removeButtons btn btn-danger" runat="server" Text="X" OnClick="importancyIconRemove_Click"/>
                                </div>
                                <br />
                                <center>
                                    <small><strong>Steps to change importancy icon color:</strong></small>
                                    <ol>
                                        <li>Check the color you want to change your importancy icon.</li>
                                        <li>Click on the importancy icon you want to change.</li>
                                        <li>Tadaa! Importancy icon color changed!</li>
                                    </ol> 
                                </center>
                                <center>
                                <table style="border:none;">
                                    <tr>
                                        <td><span class="dot" style="background-color:red"></span></td>  
                                        <td>Red</td>      
                                        <td><input type="radio" name="color" value="red"/></td>                             
                                    </tr>
                                    <tr>
                                        <td><span class="dot" style="background-color:yellow"></span></td>
                                        <td>Yellow</td>
                                        <td><input type="radio" name="color" value="yellow"/></td>
                                    </tr>
                                    <tr>
                                        <td><span class="dot" style="background-color:green"></span></td>
                                        <td>Green</td>
                                        <td><input type="radio" name="color" value="green"/></td>
                                    </tr>
                                </table>
                                <p id="currentlyDot"><small><strong>Currently Selected: None</strong></small></p>
                                </center>
                            </div>
                             <hr style="width:100%;"/>
                        </div>
                        <div class = "eachTools" runat="server" id="placeSuggestions">
                            <div class ="toolsName">
                                <div style="text-align:center">Place Suggestion<asp:Button ID="placeSuggestionRemove" class ="removeButtons btn btn-danger" runat="server" Text="X"/>
                                </div>
                                <br />
                                <hr style="width:100%;"/>
                                <div class="input-group mb-3">
                                  <input id="box" type="text" class="form-control" placeholder="Enter A Service" aria-label="Recipient's username" aria-describedby="basic-addon2"/>
                                  <div class="input-group-append">
                                    <button class="btn btn-outline-secondary" type="button">Button</button>
                                  </div>
                                </div>
                                <small><strong>Example: </strong>Cafe, Restaurant</small>
                                <p id="currentlyService"><small><strong>Currently Suggested Service: None</strong></small></p>
                                <hr style="width:100%;"/>
                                <div id="map" style="width:100%;height:300px; border:solid;"></div>
                                <script>
                                    var map;
                                    var infowindow;

                                    function initMap() {

                                        document.getElementById('currentlyService').innerHTML = "Currently Suggested Service: Cafe";

                                        var areaPlace = { lat: 1.3767, lng: 103.7535 }
                                        map = new google.maps.Map(document.getElementById('map'), {
                                            center: areaPlace,
                                            zoom: 15
                                        });

                                        infowindow = new google.maps.InfoWindow();
                                        var service = new google.maps.places.PlacesService(map);
                                        service.nearbySearch({
                                            location: areaPlace,
                                            radius: 500,
                                            type: ['cafe']
                                        }, callback);
                                    }

                                    function callback(results, status) {
                                        if (status === google.maps.places.PlacesServiceStatus.OK) {
                                            for (var i = 0; i < results.length; i++) {
                                                createMarker(results[i]);
                                            }
                                        }
                                    }

                                    function createMarker(place) {
                                        var placeLoc = place.geometry.location;
                                        var marker = new google.maps.Marker({
                                            map: map,
                                            position: place.geometry.location
                                        });

                                        google.maps.event.addListener(marker, 'click', function () {
                                            infowindow.setContent(place.name);
                                            infowindow.open(map, this);
                                        });
                                    }
                                </script>
                                <br />
                            </div>
                            <hr style="width:100%;"/>
                        </div>
                    </div>
                    <br />
                    <br />
            <br />
            <br />
            </div>
            <div class="widget">
                <asp:HiddenField runat="server" id="html"/>
                <asp:HiddenField runat="server" ID="travelDetailsId"/>
            </div>
        </div>
    </div>
</div>
    <%-- Settings Modal --%>
     <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">ToolBox Settings</h4>
        </div>
        <div class="modal-body">
            <div>
              <p>Auto Complete Tool</p>
              <asp:button runat="server" class = "btn btn-info" id="autoCompleteSettingsActivate" Text="Activate"></asp:button>
              <asp:button runat="server" class = "btn btn-info" id="autoCompleteSettingsDeactivate" Text="Deactivate"></asp:button>
            </div>

            <div>
              <p>Importancy Icon Color Tool</p>
              <asp:button runat="server" class = "btn btn-info" id="importancyColorSettingActivate" Text="Activate" OnClick="importancyColorSettingActivate_Click"></asp:button>
              <asp:button runat="server" class = "btn btn-info" id="importancyColorSettingDeactivate" Text="Deactivate"></asp:button>
            </div>

            <div>
              <p>Place Suggestion Tool</p>
              <asp:button runat="server" class = "btn btn-info" id="placeSuggestSettingActivate" Text="Activate" OnClick="placeSuggestSettingActivate_Click"></asp:button>
              <asp:button runat="server" class = "btn btn-info" id="placeSuggestSettingDeactivate" Text="Deactivate"></asp:button>
            </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="loadJavaScript" Runat="Server">
        <script>
        var count = 1;

        $("#addNewActivity").click(function (e) {
            e.preventDefault();
            count++;
            var div = document.getElementById('things'),
            clone = div.cloneNode(true); // true means clone all childNodes and all event handlers
                
            clone.id = "things" + count;
            $(clone).find("#dot1").attr("id", "dot" + count);
            $(clone).find("#dot" + count).css("background-color" , "#bbb");
            document.querySelector(".activities").appendChild(clone);
        })

        function myFunc(id) {
            document.getElementById("currentlyDot").innerHTML = "Currently Selected: " + id;

            //Set timer to simulate a delay
            setTimeout(changeColorFunc(id), 5000);
        }

        function changeColorFunc(id) {
            $(document).ready(function () {
                var radioValue = $("input[name='color']:checked").val();
                if (radioValue == "green") {
                    $("#" + id).css("background-color", "green");
                }
                else if (radioValue == "red") {
                    $("#" + id).css("background-color", "red");
                }
                else if (radioValue == "yellow")
                {
                    $("#" + id).css("background-color", "yellow");
                }
                else
                {
                    alert("Not selected!" + radioValue);
                }
            })
        }

        $("#save").click(function (e) {
            e.preventDefault();
            var htmlData = document.getElementById("myId").innerHTML;
            $('#<%=html.ClientID %>').val(htmlData);
            $('#savingText').text("Saved HTML!");
            setTimeout(timeoutFunction, 2000)
        })

        function timeoutFunction() {
            $('#savingText').text("");
        }
    </script>
    <script src="../javascript/main.js"></script>
    <script src="../javascript/step1.js"></script>
<!--===============================================================================================-->
	<script src="../vendor/bootstrap/js/popper.js"></script>
<!--===============================================================================================-->
	<script src="../vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="../javascript/mainTable.js"></script>
</asp:Content>

