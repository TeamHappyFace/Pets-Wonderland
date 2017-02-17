<%@ Control Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="ApproveHotelRequest.ascx.cs" 
	Inherits="PetsWonderland.Client.Admin.Controls.ApproveHotelRequest" %>

<asp:Button ID="ApproveRequest" runat="server" Text="Approve" CommandName="Approve" OnClick="OnApprove_Click" />