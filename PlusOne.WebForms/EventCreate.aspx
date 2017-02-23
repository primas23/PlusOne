<%@ Page
    Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="EventCreate.aspx.cs"
    Inherits="PlusOne.WebForms.EventCreate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 750px; height: 500px;" id="map"></div>
    
    <script src="Scripts/google.maps.helpers.js"></script>
    <script>
        function initMap() {
            var sofiaLocation = { lat: 42.6967353, lng: 23.3258133 };
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 14,
                center: sofiaLocation
            });
            var oldMarker = null;

            map.addListener('click', function (event) {
                var location = event.latLng;

                setLocationOnMap(map, location, oldMarker, function (marker, locationDetails) {
                    oldMarker = marker;

                    // Fill the hidden input with the location details.
                    $('#FullAddress').val(locationDetails.fullAddress);
                    $('#Latitude').val(locationDetails.latitude);
                    $('#Longitude').val(locationDetails.longitude);
                    $('#Neighbourhood_Name').val(locationDetails.neighbourhood);
                    $('#PlaceId').val(locationDetails.placeId);
                });
            });
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?signed_in=true&callback=initMap&language=en&key=AIzaSyA4CUyJiJds_IZEMv-r8zZXGdyP9VbTqig" async defer></script>
</asp:Content>