<%@ Control Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="ChangePasswordControl.ascx.cs" 
	Inherits="PetsWonderland.Client.PageControls.Account.ChangePasswordControl" %>

<%@ Register Src="../Notifications/NotificationControl.ascx" TagPrefix="notifier" TagName="NotificationsControl" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="form-horizontal">
			<div>
				<notifier:NotificationsControl runat="server" ID="Notifier" />
			</div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CurrentPassword" CssClass="control-label">Current password </asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                        CssClass="text-danger" ErrorMessage="Fill in your current password!"/>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="NewPassword" CssClass="control-label">New password </asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                        CssClass="text-danger" ErrorMessage="Fill in your new password!"/>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ConfirmNewPassword" CssClass="control-label">
					Confirm new password</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmNewPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Fill in the new one again!"/>
                    <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Passwords do not match!" />
                </div>
            </div>
            <div class="form-group">
                <div class="text-center col-md-12">
                    <asp:Button runat="server" Text="Change password" ID="ChangePasswordButton" ValidationGroup="ChangePassword" 
						OnClick="ChangePasswordButton_Click" CssClass="btn" />
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>