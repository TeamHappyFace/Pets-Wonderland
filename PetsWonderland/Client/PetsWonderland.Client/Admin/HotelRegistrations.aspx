 <%@ Page Language="C#" 
		MasterPageFile="~/Admin/Admin.Master"
		AutoEventWireup="true" 
		CodeBehind="HotelRegistrations.aspx.cs" 
		Inherits="PetsWonderland.Client.Admin.HotelRegistrations" %>

<%@ Register Src="~/Admin/Controls/AllHotelRequests.ascx" TagPrefix="acc" TagName="AllHotelRequests" %>

<asp:Content ID="HotelRegistrations" ContentPlaceHolderID="DashboardMainContent" runat="server">
	<div class="title">
		<h1>Hotel requests</h1>

		<div class="row">
			 <div class="col-md-12">
				 <div class="card">
					<acc:AllHotelRequests runat="server"/>
				 </div>
			 </div>
		</div>
	</div>
</asp:Content>
