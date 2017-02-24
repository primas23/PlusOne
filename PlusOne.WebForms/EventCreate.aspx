<%@ Page
    Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="EventCreate.aspx.cs"
    Inherits="PlusOne.WebForms.EventCreate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 750px; height: 500px;" id="map"></div>
    
    <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DropDownListEventType" CssClass="col-md-2 control-label">Event Type</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="DropDownListEventType" 
                    runat="server"
                    DataValueField="Id"
                    DataTextField="Name">
                </asp:DropDownList>
            </div>
        </div>

    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LocationName" CssClass="col-md-2 control-label">Location name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LocationName" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="StartDate" CssClass="col-md-2 control-label">Start Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="StartDate" TextMode="Date" name="StartDate" class="col-md-3"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EndDate" CssClass="col-md-2 control-label">End Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EndDate" TextMode="Date" name="StartDate" class="col-md-3"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Latitude" CssClass="col-md-2 control-label">Latitude</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Latitude" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Longitude" CssClass="col-md-2 control-label">Longitude</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Longitude" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LocationAddress" CssClass="col-md-2 control-label">Location address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LocationAddress" CssClass="form-control" />
            </div>
        </div>
        
    </div>

    <asp:LinkButton runat="server" ID="SaveButton" OnClick="SaveButton_Click" CssClass="btn  btn-primary" Text="Save"></asp:LinkButton>

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
                    $('#<%= LocationAddress.ClientID %>').val(locationDetails.fullAddress);
                    $('#<%= Latitude.ClientID %>').val(locationDetails.latitude);
                    $('#<%= Longitude.ClientID %>').val(locationDetails.longitude);
                    //$('#Neighbourhood_Name').val(locationDetails.neighbourhood);
                    //$('#PlaceId').val(locationDetails.placeId);
                });
            });
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?signed_in=true&callback=initMap&language=en&key=AIzaSyA4CUyJiJds_IZEMv-r8zZXGdyP9VbTqig" async defer></script>
</asp:Content>
