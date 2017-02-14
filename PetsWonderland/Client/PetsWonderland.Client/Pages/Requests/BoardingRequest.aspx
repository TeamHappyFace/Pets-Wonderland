<%@ Page Language="C#" 
		AutoEventWireup="true" 
		MasterPageFile="../../Site.Master"
		CodeBehind="BoardingRequest.aspx.cs" Inherits="PetsWonderland.Client.Pages.Requests.BoardingRequest" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <p class="text-danger">
    <asp:Literal runat="server" ID="ErrorMessage" />
  </p>

    <div class="form-horizontal">
        <h4>Register your pet to our hotel </h4>
        <hr />

		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PetName" CssClass="col-md-2 control-label">Pet name *</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PetName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate= "PetName"
                    CssClass="text-danger" ErrorMessage="The PetName field is required." />
            </div>
        </div>
		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Breed" CssClass="col-md-2 control-label">Breed *</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Breed" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Breed"
                    CssClass="text-danger" ErrorMessage="The Breed field is required." />
            </div>
        </div>
		<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Age" CssClass="col-md-2 control-label">Age *</asp:Label>
            <div class="col-md-10">
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
