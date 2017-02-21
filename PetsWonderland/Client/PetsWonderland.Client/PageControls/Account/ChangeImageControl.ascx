<%@ Control Language="C#"
	 AutoEventWireup="true" 
	CodeBehind="ChangeImageControl.ascx.cs" 
	Inherits="PetsWonderland.Client.PageControls.Account.ChangeImageControl" %>

<%@ Register Src="../Notifications/NotificationControl.ascx" TagPrefix="notifier" TagName="NotificationsControl" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
		<div>
			<notifier:NotificationsControl runat="server" ID="Notifier" />
		</div>
        <div class="form-group col-md-12 text-center">
            <asp:Image Width="200" Height="220" runat="server" ID="Image" />
            <asp:FileUpload ID="ImageUpload" runat="server" AllowMultiple="true" />
        </div>
	    <div class="form-group">
            <div class="text-center col-md-12">
				<asp:Button ID="UploadBtn" runat="server" CssClass="btn" Text="Upload" OnClick="UploadBtn_Click"/>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="UploadBtn" />
    </Triggers>
</asp:UpdatePanel>