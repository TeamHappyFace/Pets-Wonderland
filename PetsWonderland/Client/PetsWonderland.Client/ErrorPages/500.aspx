<%@ Page Language="C#" 
         AutoEventWireup="true" 
         MasterPageFile="../Site.Master" 
         CodeBehind="500.aspx.cs" 
         Inherits="PetsWonderland.Client.ErrorPages._500" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<div ID="ErrorPage505">
		<a href='../../Default.aspx'>
			<div>
				<img src="../../Images/Errors/500_page_cover.png"  />
			</div>
		</a>
        
        <div class="buttons">
            <div class="container">
                <div class="col-sm-6 prism-button reversed pull-left" onclick="window.history.back(1);">
                    <div class="prism-wrap">
                        <span>Want to go back?</span>
                        <span>Return me to previous page</span>
                    </div>
                </div>
                <div class="col-sm-6 prism-button reversed pull-right">
                    <a href="~/Default.aspx" runat="server">
                        <div class="prism-wrap">
                            <span>Want to go to the homepage?</span>
                            <span>Send me to the homepage</span>
                        </div>
                    </a>                
                </div>
            </div>
            
        </div>
	</div>
</asp:Content>
