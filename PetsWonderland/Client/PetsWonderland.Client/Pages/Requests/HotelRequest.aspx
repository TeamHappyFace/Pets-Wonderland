<%@ Page Language="C#"
		MasterPageFile="../../Site.Master"
		AutoEventWireup="true" 
		CodeBehind="HotelRequest.aspx.cs" 
		Inherits="PetsWonderland.Client.Pages.Requests.HotelRequest" %>

<asp:Content ContentPlaceHolderID="CustomStylesheets" runat="server">
    <link href="<%= ResolveUrl("../../Content/Pages/hotelRequest.css") %>" rel="stylesheet" type="text/css" />       
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<section id="registerHotelForm" class="col-md-4">
    <div class="form-box">
	    <div class="form-top">
	        <div class="form-top-left">
				<h3>Register your hotel </h3>
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
					<asp:Label runat="server" AssociatedControlID="HotelName" CssClass="control-label">Hotel name *</asp:Label>
					<div>
						<asp:TextBox runat="server" ID="HotelName" CssClass="form-control"/>
						<asp:RequiredFieldValidator runat="server" CssClass="col-md-offset-2 col-md-10" ControlToValidate= "HotelName"
							ErrorMessage="The Hotel name field is required." />
					</div>
				</div>
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="Location" CssClass="control-label">Location *</asp:Label>
					<div>
						<asp:TextBox runat="server" ID="Location" CssClass="form-control"/>
						<asp:RequiredFieldValidator runat="server" CssClass="col-md-offset-2 col-md-10" ControlToValidate="Location"
						   ErrorMessage="The Location field is required." />
					</div>
				</div>
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="Description" CssClass="control-label">Hotel description</asp:Label>
					<asp:TextBox ID="Description" TextMode="multiline" Columns="33" Rows="8" runat="server" />
				</div>
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="ImageUrl" CssClass="control-label">Insert hotel image link</asp:Label>
					<asp:TextBox runat="server" ID="ImageUrl" CssClass="form-control"/>
				</div>
				<div class="form-group col-md-12">
					<asp:Label runat="server" AssociatedControlID="Image"  CssClass="control-label">Or choose one </asp:Label>
					<div >
						<asp:FileUpload runat="server" ID="Image"></asp:FileUpload>
					</div>
					<asp:Label ID="FileUploadedLabel" runat="server" CssClass="control-label col-md-12"/>
				</div>
				<div class="form-group col-md-12">
					<div class="col-md-offset-2">
						<asp:Button runat="server" OnClick="CreateUserRequest_Click" Text="Send your request" CssClass="btn btn-default" />
					</div>
				</div>
			</div>
		</div>
    </div>
</section>
</asp:Content>