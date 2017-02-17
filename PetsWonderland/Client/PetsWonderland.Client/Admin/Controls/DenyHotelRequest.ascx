<%@ Control Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="DenyHotelRequest.ascx.cs" 
	Inherits="PetsWonderland.Client.Admin.Controls.DenyHotelRequest" %>

<asp:Button ID="DenyRequest" Text="Deny" runat="server" CommandName="Deny" OnClick="OnDeny_Click"/>