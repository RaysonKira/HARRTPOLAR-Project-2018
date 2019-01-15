$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });
});

var service;

$(function () {
    $(document).keypress(function (e) {
        cwrite(e.which, 'Keypress event');
        if (e.which == 120) custom_dialog_toggle('Keypress x', 'You opened this window by pressing x');
    });
});
function custom_dialog_toggle(title, text, buttons) {
    if (typeof title !== 'undefined') $('#dlg-header').html(title);
    if (typeof text !== 'undefined') $('#dlg-content').html(text);
    cwrite('Current state: ' + $('#dialog_state').prop("checked"), 'custom_dialog_toggle');
    $('#dialog_state').prop("checked", !$('#dialog_state').prop("checked"));
}
// Console logging function for debugging
// cwrite(str, title)
//      str:              string to be appended to console
//      title (optional): title of the string
// (c)  Tuomas Hatakka 2015
//      http://tuomashatakka.fi
function cwrite(str, title) {
    var ce = $('#console');
    var sg = "<p>";
    if (typeof title !== 'undefined') sg = sg + "<em>" + title + "</em> ";
    sg = sg + str + "</p>";
    ce.prepend(sg);
    //if(ce.children("p").length>6) ce.children("p").first().remove();
}

//Places 
//var map;
//var infowindow;

//function initMap() {

//    map = new google.maps.Map(document.getElementById('map'), {
//        center: { lat: -33.867, lng: 151.195 },
//        zoom: 15
//    });

//    infowindow = new google.maps.InfoWindow();
//    var service = new google.maps.places.PlacesService(map);
//    service.nearbySearch({
//        location: { lat: -33.867, lng: 151.195 },
//        radius: 500,
//        type: ['store']
//    }, callback);
//}

//function callback(results, status) {
//    if (status === google.maps.places.PlacesServiceStatus.OK) {
//        for (var i = 0; i < results.length; i++) {
//            createMarker(results[i]);
//        }
//    }
//}

//function createMarker(place) {
//    var placeLoc = place.geometry.location;
//    var marker = new google.maps.Marker({
//        map: map,
//        position: place.geometry.location
//    });

//    google.maps.event.addListener(marker, 'click', function () {
//        infowindow.setContent(place.name);
//        infowindow.open(map, this);
//    });
//}