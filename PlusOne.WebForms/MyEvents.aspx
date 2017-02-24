<%@ Page Title="My events"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="MyEvents.aspx.cs"
    Inherits="PlusOne.WebForms.MyEvents" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView runat="server"
        ID="ListViewEvents"
        ItemType="PlusOne.Data.Models.Event"
        SelectMethod="MyListViewEvents_GetData">

        <LayoutTemplate>
            <table class="gridview" cellspacing="0" rules="all" border="1" id="MainContent_GridViewEvent" style="border-collapse: collapse;">
                <tbody>
                    <tr>
                        <th scope="col">
                            <asp:LinkButton Text="Date" runat="server" ID="LinkButtonSortByDate" CommandName="Sort" CommandArgument="Start" />
                        </th>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    <tr>
                        <td colspan="2">
                            <asp:DataPager runat="server" ID="DataPagerMyEvents" PageSize="5">
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
                <td>
                    <asp:HyperLink
                        NavigateUrl='<%# string.Format("~/eventdetails.aspx?id={0}", Item.Id) %>'
                        runat="server"
                        Text='<%# string.Format(@"""{0}"" at <i>{1}</i> <b>{2}</b>", Item.Type.Name,Item.Start.ToShortDateString(), Item.Start.ToLongTimeString()) %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
