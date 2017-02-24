<%@ Page Title="Event Details"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="EventDetails.aspx.cs"
    Inherits="PlusOne.WebForms.EventDetails" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="FormViewEventDetails" ItemType="PlusOne.Data.Models.Event" SelectMethod="FormViewEventDetails_GetItem">
        <ItemTemplate>
            <header>
                <h1><%: Title %></h1>
                <p><%#: Item.Type.Name %></p>
                <p><i>start <%#: Item.Start %></i></p>
                <p><i>end <%#: Item.End %></i></p>
            </header>
            <div>
                <p>location <%#: Item.Location.Address %></p>
                <a class="btn btn-default" target="blank" href="http://maps.google.com/?q=<%# Item.Location.Latitude %>,<%# Item.Location.Longitude %>">Show on map</a>
            </div>

        </ItemTemplate>
    </asp:FormView>

    <div class="back-link">
        <a class="btn btn-primary" href="/events">Back to events</a>
    </div>

</asp:Content>
