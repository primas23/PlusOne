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
                <p></p>
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
    <div class="back-link">
        <asp:LinkButton runat="server" ID="JoinButton" Text="Join" CommandArgument="<%#: this.Model.Event.Id %>" CssClass="btn btn-default" OnCommand="JoinButton_OnClick"/>
    </div>
    <div class="back-link">
        <asp:LinkButton runat="server" ID="LeaveButton" Text="Leave" CommandArgument="<%#: this.Model.Event.Id %>" CssClass="btn btn-default" OnCommand="LeaveButton_OnClick"/>
    </div>

</asp:Content>
