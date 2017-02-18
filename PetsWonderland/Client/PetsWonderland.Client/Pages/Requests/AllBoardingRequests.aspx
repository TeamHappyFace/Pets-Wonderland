<%@ Page Language="C#" 
	AutoEventWireup="true" 
	MasterPageFile="../../Site.Master"
	CodeBehind="AllBoardingRequests.aspx.cs" 
	Inherits="PetsWonderland.Client.Pages.Requests.AllBoardingRequests" %>

<asp:Content ContentPlaceHolderID="CustomStylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Pages/allBoardingRequests.css") %>" rel="stylesheet" type="text/css" />       
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<asp:ListView runat="server" ID="Hotels" 
	ItemType="PetsWonderland.Business.Models.Requests.UserBoardingRequest" 
	SelectMethod="ListViewRequests_GetData">

	<GroupTemplate>
		<div class="row">
			<asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
		</div>
	</GroupTemplate>

	<ItemTemplate>
	<div class="section-content">
		<div class="hotels-list grid">
			<div class="gutter-sizer"></div>
			<div class="grid-item col-sm-12 col-md-4">
				<div class="wrapper">
					<div class="title">
						<h3>Pet namge - <%#: Item.PetName %></h3>
					</div>
					<div class="breed">
						<p>Breed - <%#: Item.PetBreed %></p>
					</div>
					<div class="image">
						<asp:Image runat="server" ImageUrl='<%# Item.ImageUrl %>'/>
					</div>
					<div class="age">
						<p>Age - <%#: Item.Age %></p>
					</div>
					<div class="dates">
						<p>
							Dates: <%#: Item.FromDate %> - <%# Item.ToDate %>
						</p>
					</div>
				</div>                
			</div>
		</div>
	</div>
	</ItemTemplate>
</asp:ListView>
</asp:Content>
