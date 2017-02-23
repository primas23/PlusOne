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
                <p>location <%#: Item.Location %></p>
            </div>

        </ItemTemplate>
    </asp:FormView>

    <div class="back-link">
        <a href="/events">Back to books</a>
    </div>

</asp:Content>
