<%@ Control Language="C#" 
            AutoEventWireup="true"
            CodeBehind="HomepageHotelsListControl.ascx.cs" 
            Inherits="PetsWonderland.Client.PageControls.Homepage.HomepageHotelsListControl" %>

<section id="hotels" class="hp-hotels generic-section container">
    <div class="section-title">
        <h2>Hotels..</h2>
    </div>
	<asp:ListView runat="server" ID="Hotels" 
		ItemType="PetsWonderland.Business.Models.Hotels.Hotel" 
		SelectMethod="ListViewHotels_GetData" 
		OnItemCreated="Hotels_ItemCreated">
              
        <LayoutTemplate>
            <div class="section-content">
			    <div class="hotels-list grid"> 
                    <div class="gutter-sizer"></div>           
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </div>
            </div>
        </LayoutTemplate>

		<ItemTemplate>		          
			<div class="grid-item  col-sm-12 col-md-4">
				<div class="wrapper">
					<div class="image">
						<asp:Image runat="server" Height="130px" ImageUrl='<%# Item.ImageUrl %>'/>
					</div>
					<div class="title">
						<a href="#"><h3><%#: Item.Name %></h3></a>
					</div>
					<div class="description">
						<p>
							<%#: Item.Description %>
						</p>
						<asp:HyperLink ID="boardingRequest" runat="server"
							NavigateUrl='<%# String.Format("../../Pages/Requests/BoardingRequest.aspx?id={0}", Item.HotelManagerId) %>'>
							<h4 runat="server">Accomodate your pet</h4>
						</asp:HyperLink>
					</div>
				</div>                
			</div>	               
		</ItemTemplate>

	</asp:ListView>
</section>
