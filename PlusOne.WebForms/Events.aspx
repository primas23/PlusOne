﻿<%@ Page Title="Events"
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
                    <asp:TextBox runat="server" ID="TextBoxSearchParamEvent" type="text" name="event" class="col-md-3 search-query" placeholder="Type ..."></asp:TextBox>
                </div>
                <div class="input-append">
                    <asp:TextBox runat="server" ID="TextBoxSearchParamLocation" type="text" name="location" class="col-md-3 search-query" placeholder="Where ..."></asp:TextBox>
                </div>
                <div class="input-append">
                    <asp:TextBox runat="server" ID="TextBoxSearchParamStartData" TextMode="Date" name="StartData" class="col-md-3 search-query"></asp:TextBox>
                </div>
                <div class="input-append">
                    <asp:TextBox runat="server" ID="TextBoxSearchParamEndData" TextMode="Date" name="EndData" class="col-md-3 search-query"></asp:TextBox>
                </div>
                <asp:LinkButton runat="server" ID="LinkButtonSearch" OnClick="ButtonSearch_Click" CssClass="btn  btn-primary" Text="Search"></asp:LinkButton>
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
