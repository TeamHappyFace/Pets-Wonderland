<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="PetsWonderland.Client.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<%@ Register Src="~/PageControls/Account/ChangePasswordControl.ascx" TagPrefix="uc" TagName="ChangePasswordControl" %>
<%@ Register Src="~/PageControls/Account/ChangeImageControl.ascx" TagPrefix="uc" TagName="ChangeImageControl" %>
<%@ Register Src="~/PageControls/Account/AllBoardingRequests.ascx" TagPrefix="uc" TagName="BoardingRequests" %>

<asp:Content ContentPlaceHolderID="CustomStylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Pages/profile.css") %>" rel="stylesheet" type="text/css" />       
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<section id="profile" class="col-md-4">
        <div class="form-box">
	        <div class="form-top">
	            <div class="form-top-left">
	                <h3>Account setting</h3>
	            </div>
	            <div class="form-top-right">
	                <i class="fa fa-user"></i>
	            </div>
	        </div>
		</div>
        <div class="form-bottom">
			<asp:UpdatePanel runat="server">
				<ContentTemplate>
					<asp:Label runat="server" ID="Buttons">
						<asp:Button Text="Profile avatar" BorderStyle="None" ID="ImageButton" CssClass="btn" runat="server"
							OnClick="ImageButton_Click" />
						<asp:Button Text="Password" BorderStyle="None" ID="PasswordButton" CssClass="btn" runat="server"
							OnClick="PasswordButton_Click" />
						<asp:Button Text="Boarding Requests" BorderStyle="None" ID="RequestsButton" CssClass="btn special" runat="server"
							OnClick="RequestsButton_Click" Visible ="false"/>
					</asp:Label>

					<asp:MultiView ID="MultiView" runat="server">
						<asp:View runat="server" ID="ChangeImageView">
							<uc:ChangeImageControl runat="server" />
						</asp:View>
						<asp:View runat="server" ID="ChangePasswordView">
							<uc:ChangePasswordControl runat="server"/>
						</asp:View>
						<asp:View runat="server" ID="ViewBoardingRequests">
							<uc:BoardingRequests runat="server" />
						</asp:View>
					</asp:MultiView>
				</ContentTemplate>

				<Triggers>
					<asp:PostBackTrigger ControlID = "ImageButton" />
				</Triggers>
			</asp:UpdatePanel>
        </div>
	</section>
</asp:Content>
