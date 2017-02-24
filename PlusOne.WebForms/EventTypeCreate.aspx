<%@ Page
    Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="EventTypeCreate.aspx.cs"
    Inherits="PlusOne.WebForms.EventTypeCreate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventType" CssClass="col-md-2 control-label">Event Type</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventType" CssClass="form-control" />
            </div>
        </div>

    <asp:LinkButton runat="server" ID="SaveButton" OnClick="SaveButton_Click" CssClass="btn  btn-primary" Text="Save"></asp:LinkButton>
</asp:Content>
