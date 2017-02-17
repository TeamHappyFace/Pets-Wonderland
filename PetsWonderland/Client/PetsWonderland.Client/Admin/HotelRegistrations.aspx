<%@ Page Language="C#" 
		MasterPageFile="~/Admin/Admin.Master"
		AutoEventWireup="true" 
		CodeBehind="HotelRegistrations.aspx.cs" 
		Inherits="PetsWonderland.Client.Admin.HotelRegistrations" %>

<%@ Register Src="~/Admin/Controls/AllHotelRequests.ascx" TagPrefix="acc" TagName="AllHotelRequests" %>

<asp:Content ID="HotelRegistrations" ContentPlaceHolderID="DashboardMainContent" runat="server">
	<div class="title">
		<h2>Hotel requests</h2>

		<div>
			<acc:AllHotelRequests runat="server"/>
		</div>
	</div>
</asp:Content>
