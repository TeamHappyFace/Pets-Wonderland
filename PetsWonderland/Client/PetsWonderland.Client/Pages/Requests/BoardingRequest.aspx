<%@ Page Language="C#" 
		AutoEventWireup="true" 
		MasterPageFile="../../Site.Master"
		CodeBehind="BoardingRequest.aspx.cs" Inherits="PetsWonderland.Client.Pages.Requests.BoardingRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ContentPlaceHolderID="CustomStylesheets" runat="server">
    <link href="<%= ResolveUrl("../../Content/Pages/hotelRequest.css") %>" rel="stylesheet" type="text/css" />       
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<section id="accomodatePetForm" class="col-md-4">
    <div class="form-box">
	    <div class="form-top">
	        <div class="form-top-left">
				<h3>Register your pet to our hotel </h3>
				<p>Fill in the form below</p>
	        </div>
			<div class="form-top-right">
				<i class="fa fa-pencil"></i>
			</div>
		</div>
		<div class="form-bottom">
			<p class="text-danger">
				<asp:Literal runat="server" ID="ErrorMessage" />
			</p>
			<div class="form-horizontal"> 
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="PetName" CssClass="control-label">Pet name *</asp:Label>
					<asp:TextBox runat="server" ID="PetName" CssClass="form-control"/>
					<asp:RequiredFieldValidator runat="server" ControlToValidate= "PetName"
						CssClass="text-danger" ErrorMessage="The PetName field is required." />
				</div>
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="Breed" CssClass="control-label">Breed *</asp:Label>
					<asp:TextBox runat="server" ID="Breed" CssClass="form-control"/>
					<asp:RequiredFieldValidator runat="server" ControlToValidate="Breed"
						CssClass="text-danger" ErrorMessage="The Breed field is required." />
				</div>
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="Age" CssClass="control-label">Age *</asp:Label>
					<asp:TextBox runat="server" ID="Age" CssClass="form-control"/>
					<asp:RequiredFieldValidator runat="server" ControlToValidate="Age"
						CssClass="text-danger" ErrorMessage="The Age field is required." />
				</div>
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="Gender" CssClass="control-label">Gender: </asp:Label>
					<asp:CheckBox runat="server" ID="Gender" CssClass="control-label" Text="Male"/>
					<asp:CheckBox runat="server" ID="Gender1" CssClass="control-label" Text="Female"/>
				</div>
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="ImageUrl" CssClass="control-label">Insert animal image link</asp:Label>
					<asp:TextBox runat="server" ID="ImageUrl" CssClass="form-control"/>
				</div>
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="Image"  CssClass="control-label">Or choose one </asp:Label>
					<div>
						<asp:FileUpload runat="server" ID="Image"></asp:FileUpload>
					</div>
					<asp:Label ID="FileUploadedLabel" runat="server" CssClass="control-label"/>
				</div>
				<div class="dates-wrapper">
					<div class="form-group col-md-12">
						<asp:Label runat="server" AssociatedControlID="txtFrom"  CssClass="control-label">From </asp:Label>
						<asp:TextBox ID="txtFrom" runat="server" CssClass="form-control"></asp:TextBox>
						<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"></ajaxToolkit:CalendarExtender>	
					</div>
					<br />
					<div class="form-group col-md-12">
						<asp:Label runat="server" AssociatedControlID="txtTo" CssClass="control-label">To </asp:Label>
						<asp:TextBox ID="txtTo" runat="server" CssClass="form-control"></asp:TextBox>
						<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"></ajaxToolkit:CalendarExtender>	
					</div>
				</div>			
				<div class="form-group col-md-12">
					<div class="col-md-offset-4">
						<br />
						<asp:Button runat="server" OnClick="CreateUserRequest_Click" Text="Send your request" CssClass="btn btn-default" />
					</div>
				</div>
			</div>
		</div>
    </div>
</section>
</asp:Content>