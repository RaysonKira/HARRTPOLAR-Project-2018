  <%@ Page Title="" Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="itineraryCreatorStep1.aspx.cs" Inherits="itineraryCreatorStep1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        
        .auto-style2 {
            width: 109px;
            height: 97px;
        }

        * {
            box-sizing: border-box;
        }

        .mySlides {
            display: none;
        }

        img {
            vertical-align: middle;
        }

        /* Slideshow container */
        .slideshow-container {
            max-width: 1000px;
            position: relative;
            margin: auto;
        }

        /* Next & previous buttons */
        .prev, .next {
            cursor: pointer;
            position: absolute;
            top: 50%;
            width: auto;
            padding: 16px;
            margin-top: -22px;
            color: white;
            font-weight: bold;
            font-size: 18px;
            transition: 0.6s ease;
            border-radius: 0 3px 3px 0;
            user-select: none;
        }

        /* Position the "next button" to the right */
        .next {
            right: 0;
            border-radius: 3px 0 0 3px;
        }

            /* On hover, add a black background color with a little bit see-through */
            .prev:hover, .next:hover {
                background-color: rgba(0,0,0,0.8);
            }

        /* Caption text */
        .text {
            color: #f2f2f2;
            font-size: 15px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
        }

        /* Number text (1/3 etc) */
        .numbertext {
            color: #f2f2f2;
            font-size: 12px;
            padding: 8px 12px;
            position: absolute;
            top: 0;
        }

        /* The dots/bullets/indicators */
        .dot {
            cursor: pointer;
            height: 15px;
            width: 15px;
            margin: 0 2px;
            background-color: #bbb;
            border-radius: 50%;
            display: inline-block;
            transition: background-color 0.6s ease;
        }

            .active1, .dot:hover {
                background-color: #717171;
            }

        /* Fading animation */
        .fade {
            -webkit-animation-name: fade;
            -webkit-animation-duration: 1.5s;
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @-webkit-keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        /* On smaller screens, decrease text size */
        @media only screen and (max-width: 300px) {
            .prev, .next, .text {
                font-size: 11px;
            }
        }

        .instructionsText
        {
            width:100%;
            height:100%;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="images" Runat="Server">
    <img src="../images/logo.PNG" class="nav-logo"/>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="loadJavaScript" runat="Server">
    <script>
        jQuery(function () {
            jQuery('#popButton').click();
        });
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

<asp:Content ID="Content3" ContentPlaceHolderID="templateContent" runat="Server">

    <div class="section1">
        <div class="container">
            <ul class="progressbar">
                <li class="active">Information</li>
                <li>Create Itinerary</li>
                <li>Confirm With Agency</li>
                <li>Done</li>
            </ul>
        </div>
        <br />
        <br />
        <br />
        <br />
        <div class="content-wrapper">
            <div class="site-content" style="border: inherit">
                <div class="form-group">
                    <label for="tripName">Trip Name</label>
                    <asp:textbox runat="server" class="form-control" id="tripNameDetails" placeholder="Enter Trip Name"></asp:textbox>
                </div>
                <div class="form-group">
                    <label for="emailDetails">Email address</label>
                    <asp:textbox runat="server" type="email" class="form-control" id="emailDetails" aria-describedby="emailHelp" placeholder="Enter email"></asp:textbox>
                    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
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
                        <asp:Button ID="addTravelDetails" runat="server" class="btn btn-info btn-lg btn-block" OnClick="addTravelDetails_Click" text="Add Travel Details" />
                    </ContentTemplate>
                </asp:updatepanel>
                <br />
                <br />
            </div>
            <div class="sidebar">
                <div class="widget">
                    <div class="toolBox">
                        <label for="dialog_state"><i class="icon ion-ios-upload-outline"></i>Your Tools:</label><label style="float:right" class="button" id="settingButton" data-toggle="modal" data-target="#myModal"><i class="icon ion-ios-upload-outline"></i><img style="width:20px; height:20px;" class="auto-style2" src="../Images/Gear-1s-200px.gif" /></label>
                        <br />
                        <asp:Label ID="userNameLbl" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="emailLbl" runat="server" Text=""></asp:Label>
                        <hr style="width:100%;"/>
                        <div class = "eachTools" id="readInstructions">
                            <div class ="toolsName">
                                <div style="text-align:center">Read Instructions
                                </div>
                            </div>
                            <hr style="width:100%;"/>
                            <div class='center'>
                                <label class="button" id="popButton" for="dialog_state"><i class="icon ion-ios-upload-outline"></i>Open Instruction</label>
                            </div>
                            <div id='console'></div>
                        </div>
                        <div class="eachTools" runat="server" id="autoComplete">
                             <hr style="width:100%;"/>
                            <div class="toolsName">
                                <div style="text-align:center">Enable/Disable Auto-Complete?<asp:Button ID="autoCompleteButton" class ="removeButtons btn btn-danger" runat="server" Text="X" OnClick="autoCompleteButton_Click" />
                                </div>
                            </div>
                             <hr style="width:100%;"/>
                            <p>
                                <asp:button runat="server" text="Enable" class="btn btn-info" id="enableAutoButton" OnClick="enableAutoButton_Click" />
                                <asp:button runat="server" text="Disable" class="btn btn-info" id="disableAutoButton" onclick="disableAutoButton_Click" />
                            </p>
                             <hr style="width:100%;"/>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
            </div>
            <div class="widget">
                <h3 class="widget-header">Sidebar Section</h3>
                <p>Sit amet tootsie roll I love I love I love carrot cake. Cupcake candy icing wafer apple pie muffin powder sugar plum. Marzipan lollipop cake icing.</p>
            </div>
        </div>
    </div>

    <input type="checkbox" name="dialog_state" id="dialog_state" class="dialog_state" />
    <div id='dialog'>
        <label id="dlg-back" for="dialog_state"></label>
        <div id='dlg-wrap'>
            <label id="dlg-close" for="dialog_state"><i class="icon ion-ios-close-empty"></i></label>
            <h2 id='dlg-header'>Instructions:</h2>
            <div id='dlg-content'>
                <p>Step 1: Enter Travel Details</p><br />
                <p>Step 2: Create Itinerary</p> <br />
                <p>Step 3: Collaborate With Travel Agency</p>
            </div>
            <div id='dlg-prompt'>
                <div class='button positive'><i class="icon ion-ios-checkmark-empty"></i>Yes, I understood!</div>
                <div class='button'><i class="icon ion-ios-close-empty"></i>No, I'll reconsider</div>
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
              <asp:button runat="server" class = "btn btn-info" id="autoCompleteSettingsActivate" Text="Activate" OnClick="autoCompleteSettingsActivate_Click"></asp:button>
              <asp:button runat="server" class = "btn btn-info" id="autoCompleteSettingsDeactivate" Text="Deactivate"></asp:button>
            </div>

            <div>
              <p>Importancy Icon Color Tool</p>
              <asp:button runat="server" class = "btn btn-info" id="importancyColorSettingActivate" Text="Activate"></asp:button>
              <asp:button runat="server" class = "btn btn-info" id="importancyColorSettingDeactivate" Text="Deactivate"></asp:button>
            </div>

            <div>
              <p>Place Suggestion Tool</p>
              <asp:button runat="server" class = "btn btn-info" id="placeSuggestSettingActivate" Text="Activate"></asp:button>
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


