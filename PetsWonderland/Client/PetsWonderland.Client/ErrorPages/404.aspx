<%@ Page Language="C#"
         AutoEventWireup="true"
         MasterPageFile="../Site.Master" 
         CodeBehind="404.aspx.cs" 
         Inherits="PetsWonderland.Client.ErrorPages._404" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<div ID="ErrorPage404">
		<a href='../../Default.aspx'>
			<div>
				<img src="../../Images/Errors/404_page_cover.png"  />
			</div>
		</a>
	</div>
</asp:Content>