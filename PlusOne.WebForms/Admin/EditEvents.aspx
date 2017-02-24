<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="EditEvents.aspx.cs"
    Inherits="PlusOne.WebForms.Admin.EditEvents" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListView1"
        runat="server"
        ItemType="PlusOne.Data.Models.Event"
        SelectMethod="ListViewEvents_GetData"
        DeleteMethod="ListView1_DeleteItem"
        UpdateMethod="ListView1_UpdateItem"
        DataKeyNames="Id">
        <LayoutTemplate>
            <table class="gridview" cellspacing="0" rules="all" border="1" id="MainContent_GridViewCategories" style="border-collapse: collapse;">
                <tbody>
                    <tr>
                        <th scope="col">
                            <asp:LinkButton Text="Event" runat="server" ID="LinkButtonSortByData" CommandName="Sort" CommandArgument="Start" />
                        </th>
                        <th scope="col">Start Date</th>
                        <th scope="col">End Date</th>
                        <th scope="col">Created on</th>
                        <th scope="col">Is Deleted</th>
                        <th scope="col">Owner Id</th>
                        <th scope="col">Comments</th>
                        <th scope="col">Max Participants</th>
                        <th scope="col">Location Name</th>
                        <th scope="col">Location Latitude</th>
                        <th scope="col">Location Longitude</th>
                        <th scope="col">Address</th>
                        <th scope="col">Actions</th>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    <tr>
                        <td colspan="2">
                            <asp:DataPager runat="server" ID="DataPagerCategories" PageSize="5">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Type.Name %></td>
                <td><%#: Item.Start %></td>
                <td><%#: Item.End %></td>
                <td><%#: Item.CreatedOn %></td>
                <td><%#: Item.IsDeleted %></td>
                <td><%#: Item.OwnerId %></td>
                <td><%#: Item.Comments %></td>
                <td><%#: Item.MaxParticipants %></td>
                <td><%#: Item.Location.Name %></td>
                <td><%#: Item.Location.Latitude %></td>
                <td><%#: Item.Location.Longitude %></td>
                <td><%#: Item.Location.Address %></td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Type.Name %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxStart" Text="<%#: BindItem.Start %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxEnd" Text="<%#: BindItem.End %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxCreatedOn" Text="<%#: BindItem.CreatedOn %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxIsDeleted" Text="<%#: BindItem.IsDeleted %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxOwnerId" Text="<%#: BindItem.OwnerId %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxComments" Text="<%#: BindItem.Comments %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxMaxParticipants" Text="<%#: BindItem.MaxParticipants %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxLocationName" Text="<%#: BindItem.Location.Name %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxLocationLatitude" Text="<%#: BindItem.Location.Latitude %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxLocationLongitude" Text="<%#: BindItem.Location.Longitude %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxAddress" Text="<%#: BindItem.Location.Address %>" />
                </td>

                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Save" CommandName="Update" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
