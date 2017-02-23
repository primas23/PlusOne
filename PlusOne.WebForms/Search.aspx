<%@ Page Language="C#"
    Title="Search"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Search.aspx.cs"
    Inherits="PlusOne.WebForms.Search" %>

<asp:Content ID="SearchContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12">
        <h1><%: Title %>
            <asp:Literal runat="server" ID="LiteralSearchQuery" Mode="Encode"></asp:Literal>
        </h1>
    </div>

    <asp:Repeater runat="server" ID="Reapeater" ItemType="PlusOne.Data.Models.Event" SelectMethod="Reapeater_GetData">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink 
                    NavigateUrl='<%# string.Format("~/eventdetails.aspx?id={0}", Item.Id) %>' 
                    runat="server" Text='<%# string.Format(@"""{0}"" at <i>{1}</i> <b>{2}</b>", Item.Type.Name,Item.Start.ToShortDateString(), Item.Start.ToLongTimeString()) %>' />
                <br/>
                (Event type: <%#: Item.Type.Name %>)
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

    <div class="back-link">
        <a href="/events">Back to events</a>
    </div>
</asp:Content>
