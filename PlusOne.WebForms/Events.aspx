<%@ Page Title="Events"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Events.aspx.cs"
    Inherits="PlusOne.WebForms.Events" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" DefaultButton="LinkButtonSearch" CssClass="row">
        <h1><%: this.Title %></h1>
        <div class="search-button">
            <div class="form-search">
                <div class="input-append">
                    <asp:TextBox runat="server" ID="TextBoxSearchParam" type="text" name="q" class="col-md-3 search-query" placeholder="Search type event / data..."></asp:TextBox>
                    <asp:LinkButton runat="server" ID="LinkButtonSearch"
                        OnClick="LinkButtonSearch_Click" CssClass="btn  btn-primary" Text="Search"></asp:LinkButton>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:ListView runat="server"
        ID="ListViewEvents"
        ItemType="PlusOne.Data.Models.Event"
        SelectMethod="ListViewEvents_GetData"
        GroupItemCount="3">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>

        <ItemTemplate>
            <li>
                <asp:HyperLink NavigateUrl='<%# string.Format("~/eventdetails.aspx?id={0}", Item.Id) %>' runat="server" Text='<%# string.Format(@"""{0}"" at <i>{1}</i> <b>{2}</b>", Item.Type.Name,Item.Start.ToShortDateString(), Item.Start.ToLongTimeString()) %>' />
            </li>
        </ItemTemplate>
    </asp:ListView>


</asp:Content>
