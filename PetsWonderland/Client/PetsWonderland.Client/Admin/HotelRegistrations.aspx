<%@ Page Language="C#" 
		MasterPageFile="~/Admin/Admin.Master"
		AutoEventWireup="true" 
		CodeBehind="HotelRegistrations.aspx.cs" 
		Inherits="PetsWonderland.Client.Admin.HotelRegistrations" %>

<asp:Content ContentPlaceHolderID="AdminStyleSheets" runat="server">
	<link href="<%= ResolveUrl("~/Content/External/FontAwesome/font-awesome.css") %>" rel="stylesheet" type="text/css" />   
    <link href="<%= ResolveUrl("~/Content/Admin/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />   
	<link href="<%= ResolveUrl("~/Content/Admin/hotelRegistrations.css") %>" rel="stylesheet" type="text/css" />  
    <link href="<%= ResolveUrl("~/Content/Admin/material-dashboard.css") %>" rel="stylesheet" type="text/css" />     
</asp:Content>

<asp:Content ID="HotelRegistrations" ContentPlaceHolderID="DashboardMainContent" runat="server">
	<div class="title">
		<h2>Hotel requests</h2>
	</div>

	<asp:ListView runat="server"  
		ID="HotelRequests" 
        ItemType="PetsWonderland.Business.Models.Requests.UserHotelRegistrationRequest" 
        SelectMethod="ListViewHotelRequests_GetData">

        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>

        <ItemTemplate>
            <div>
                <h2><%#: Item.HotelName %></h2>
            </div>
			<div>
                <div class="wrapper">
					<div class="location">
						<p><%#: Item.HotelLocation %></p>
                    </div>
                    <div class="image">
						<asp:Image runat="server" ImageUrl='<%# Item.HotelImageUrl %>'/>
                    </div>
                    <div class="description">
						<p><%#: Item.HotelDescription %></p>
                    </div>
                </div>                
            </div>
			<asp:Button Text="Approve" runat="server"/>
			<asp:Button Text="Deny"  runat="server" CommandArgument='<%# Item.Id %>' />
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
