<%@ Control Language="C#" 
            AutoEventWireup="true"
            CodeBehind="HomepageHotelsListControl.ascx.cs" 
            Inherits="PetsWonderland.Client.PageControls.Homepage.HomepageHotelsListControl" %>

<section id="hotels" class="hp-hotels generic-section container">
    <div class="section-title">
        <h2>Hotels..</h2>
    </div>
    <div class="section-content">
        <div class="hotels-list grid">
            <div class="gutter-sizer"></div>
           <div class="grid-item col-sm-12 col-md-4">
                <div class="wrapper">
                    <div class="image">
						<img src="~/Images/Pages/Homepage/Hotels/dog_hotel.jpg" runat="server"/>
                    </div>
                    <div class="title">
                        <a href="#"><h3>D.O.G Premium Hotel</h3></a>
                    </div>
                    <div class="description">
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam lobortis et quam
                            nec volutpat. Nam aliquet at lectus id viverra. Suspendisse potenti. Ut dictum 
                            imperdiet augue, a dictum mi sagittis sed. Duis ac ligula nunc.
                        </p>
						<a href="../../Pages/Requests/BoardingRequest.aspx"><h4>Accomodate your pet</h4></a>
                    </div>
                </div>                
            </div>
            <div class="grid-item col-sm-12 col-md-4">
                <div class="wrapper">
                    <div class="image">
						<img src="~/Images/Pages/Homepage/Hotels/dog_hotel_2.jpg" runat="server"/>
                    </div>
                    <div class="title">
                        <a href="#"><h3>D.O.G Premium Hotel</h3></a>
                    </div>
                    <div class="description">
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam lobortis et quam
                            nec volutpat. Nam aliquet at lectus id viverra. Suspendisse potenti. Ut dictum 
                            imperdiet augue, a dictum mi sagittis sed. Duis ac ligula nunc.
                        </p>
                    </div>
                </div>
               
            </div>
            <div class="grid-item col-sm-12 col-md-4">
                <div class="wrapper">
                    <div class="image">
						<img src="~/Images/Pages/Homepage/Hotels/dog_hotel.jpg" runat="server"/>
                    </div>
                    <div class="title">
                        <a href="#"><h3>D.O.G Premium Hotel</h3></a>
                    </div>
                    <div class="description">
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam lobortis et quam
                            nec volutpat. Nam aliquet at lectus id viverra. Suspendisse potenti. Ut dictum 
                            imperdiet augue, a dictum mi sagittis sed. Duis ac ligula nunc.
                        </p>
                    </div>
                </div>                
            </div>
        </div>
    </div>
	<asp:ListView runat="server" ID="Hotels" 
		ItemType="PetsWonderland.Business.Models.Hotels.Hotel" 
		SelectMethod="ListViewHotels_GetData">

		<GroupTemplate>
			<div class="row">
				<asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
			</div>
		</GroupTemplate>

		<ItemTemplate>
		<div class="section-content">
			<div class="hotels-list grid">
				<div class="gutter-sizer"></div>
				<div class="grid-item col-sm-12 col-md-4">
					<div class="wrapper">
						<div class="image">
							<asp:Image runat="server" ImageUrl='<%# Item.ImageUrl %>'/>
						</div>
						<div class="title">
							<a href="#"><h3><%#: Item.Name %></h3></a>
						</div>
						<div class="description">
							<p>
								<%#: Item.Description %>
							</p>
							<asp:HyperLink ID="boardingRequest" runat="server" NavigateUrl="../../Pages/Requests/BoardingRequest.aspx">
								<h4>Accomodate your pet</h4>
							</asp:HyperLink>
						</div>
					</div>                
				</div>
			 </div>
		</div>
		</ItemTemplate>
	</asp:ListView>
</section>
