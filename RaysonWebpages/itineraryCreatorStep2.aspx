<%@ Page Title="" Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="itineraryCreatorStep2.aspx.cs" Inherits="itineraryCreatorStep1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="images" Runat="Server">
    <img src="../images/logo.PNG" class="nav-logo"/>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="loadJavaScript" runat="Server">
    <script>
        var count = 1;

        $("#addNewActivity").click(function (e) {
            e.preventDefault();
            count++;
            var div = document.getElementById('activity1'),
            clone = div.cloneNode(true); // true means clone all childNodes and all event handlers
                
            clone.id = "activity" + count;
            document.querySelector(".travelItineraryDiv").appendChild(clone);
            document.querySelector(".travelItineraryDiv").appendChild(document.createElement("br"));
            //document.body.appendChild(clone);
        })
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="templateContent" Runat="Server">
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
        <div class="columnRight">
                <div class="travelItineraryDiv" contenteditable="true" style="border:solid;">
                    <div id="activity1" style="padding-bottom: 100px;">
                        <div id="itineraryActivity" style="border:dotted; width: 75%; float:left; height: 100px" >
                            <p style="text-align:center">This text is editable!</p>
                        </div>
                        <div id="itineraryTime" style="border:dotted; width: 15%; float:right; height: 100px">
                            <p style="text-align:center">Enter Time Here</p>
                        </div>
                    </div>
                    <br/>
                </div>
                <br/>
                <%--<asp:Button id="addNewActivity" runat="server" class="btn btn-info" style="text-align:center;" Text="Add New Activity"/>--%>
                <button id="addNewActivity" class="btn btn-info" style="text-align:center;">Add New Activity</button>
<%--                <div class="sliderContainer">
                    <p>Change Your Days Using This Slider:</p>
                    <input type="range" min="1" max="100" value="50" class="slider" id="myRange"/>
                </div>--%>
        </div>
        <div class="sidebar">
            <div class="widget">
                    <div class="toolBox">
                        <label for="dialog_state"><i class="icon ion-ios-upload-outline"></i>Your Tools:</label>
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
                                <div style="text-align:center">Enable/Disable Auto-Complete?<asp:Button ID="autoCompleteButton" class ="removeButtons btn btn-danger" runat="server" Text="X"/>
                                </div>
                            </div>
                             <hr style="width:100%;"/>
                            <p>

                            </p>
                             <hr style="width:100%;"/>
                        </div>
                    </div>
                    <br />
                    <br />
            <br />
            <br />
            </div>
            <div class="widget">
                <h3 class="widget-header">Sidebar Section</h3>
                <p>Sit amet tootsie roll I love I love I love carrot cake. Cupcake candy icing wafer apple pie muffin powder sugar plum. Marzipan lollipop cake icing.</p>
            </div>
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
</asp:Content>


