<%@ Page Language="C#"
		MasterPageFile="../../Site.Master"
		AutoEventWireup="true" 
		CodeBehind="HotelRequest.aspx.cs" 
		Inherits="PetsWonderland.Client.Pages.Requests.HotelRequest" %>

<asp:Content ContentPlaceHolderID="CustomStylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Pages/hotelRequest.css") %>" rel="stylesheet" type="text/css" />       
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal hotel-request parallax">
        <h3>Register your hotel </h3>
        <hr />

		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="HotelName" CssClass="col-md-2 control-label">Hotel name *</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="HotelName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" CssClass="col-md-offset-2 col-md-10" ControlToValidate= "HotelName"
                    ErrorMessage="The Hotel name field is required." />
            </div>
        </div>
		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Location" CssClass="col-md-2 control-label">Location *</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Location" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" CssClass="col-md-offset-2 col-md-10" ControlToValidate="Location"
                   ErrorMessage="The Location field is required." />
            </div>
        </div>
		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Hotel description</asp:Label>
			<asp:TextBox ID="Description" TextMode="multiline" Columns="37" Rows="5" runat="server" />
		</div>
		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ImageUrl" CssClass="col-md-2 control-label">Insert hotel image link</asp:Label>
			<asp:TextBox runat="server" ID="ImageUrl" CssClass="form-control"/>
		</div>
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="Image"  CssClass="col-md-2 control-label">Or choose one </asp:Label>
			<div class="col-md-2">
                <asp:FileUpload runat="server" ID="Image"></asp:FileUpload>
            </div>
			<asp:Label ID="FileUploadedLabel" runat="server" CssClass="col-md-2 control-label"/>
		</div>
        <div class="form-group">
            <div class="col-md-offset-2">
                <asp:Button runat="server" OnClick="CreateUserRequest_Click" Text="Send your request" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>