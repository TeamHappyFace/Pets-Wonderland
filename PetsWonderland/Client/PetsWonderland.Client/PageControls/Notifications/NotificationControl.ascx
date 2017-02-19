<%@ Control Language="C#" 
            AutoEventWireup="true" 
            CodeBehind="NotificationControl.ascx.cs" 
            Inherits="PetsWonderland.Client.PageControls.Notifications.NotificationControl" %>

<asp:Panel  runat="server" ID="NotificationPanel" CssClass="">
    <button class="close" type="button" aria-hidden="true"></button>
    <asp:Label ID="NotificationMessage" runat="server"></asp:Label>
</asp:Panel>
