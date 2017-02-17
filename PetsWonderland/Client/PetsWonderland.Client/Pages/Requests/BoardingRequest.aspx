<%@ Page Language="C#" 
		AutoEventWireup="true" 
		MasterPageFile="../../Site.Master"
		CodeBehind="BoardingRequest.aspx.cs" Inherits="PetsWonderland.Client.Pages.Requests.BoardingRequest" %>

<asp:Content ContentPlaceHolderID="CustomStylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Pages/boardingRequest.css") %>" rel="stylesheet" type="text/css" />       
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal boarding-request parallax">
        <h3>Register your pet to our hotel </h3>
        <hr />

		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PetName" CssClass="col-md-2 control-label">Pet name *</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="PetName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate= "PetName"
                    CssClass="text-danger" ErrorMessage="The PetName field is required." />
            </div>
        </div>
		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Breed" CssClass="col-md-2 control-label">Breed *</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Breed" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Breed"
                    CssClass="text-danger" ErrorMessage="The Breed field is required." />
            </div>
        </div>
		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Age" CssClass="col-md-2 control-label">Age *</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Age" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Age"
                    CssClass="text-danger" ErrorMessage="The Age field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Gender" CssClass="col-md-2 control-label">Gender</asp:Label>
			<asp:CheckBox runat="server" ID="Gender" CssClass="col-md-1 control-label" Text="Male"/>
			<asp:CheckBox runat="server" ID="Gender1" CssClass="col-md-1 control-label" Text="Female"/>
        </div>
		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ImageUrl" CssClass="col-md-2 control-label">Insert animal image link</asp:Label>
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
            <asp:Label runat="server" AssociatedControlID="BehavioralConcerns" CssClass="col-md-2 control-label">
				Are there any behavioral concerns we should be aware of?</asp:Label>
			<asp:TextBox ID="BehavioralConcerns" TextMode="multiline" Columns="50" Rows="5" runat="server" />
		</div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUserRequest_Click" Text="Send your request" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
