<%@ Control Language="C#" 
            AutoEventWireup="true"
            CodeBehind="HomepageHotelsListControl.ascx.cs" 
            Inherits="PetsWonderland.Client.PageControls.Homepage.HomepageHotelsListControl" %>


<section id="hotels" class="hp-hotels generic-section container">
    <div class="section-title">
        <h2>Hotels..</h2>
    </div>
<asp:UpdatePanel ID="HotelsListUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">
    <ContentTemplate>
	    <asp:ListView runat="server" ID="Hotels" 
		    ItemType="PetsWonderland.Business.Models.Hotels.Hotel"                    	
		    OnItemCreated="Hotels_ItemCreated">              
            <LayoutTemplate>
                <div class="section-content">
			        <div id="hotels-list-iso" class="hotels-list grid"> 
                        <div class="gutter-sizer"></div>           
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    </div>
                    <div class="hotels-list-load-more">
                        <asp:LinkButton  ID="LoadMoreHotelsBtn" runat="server" OnClientClick="reloadGrid();" OnClick="btnLoadMoreHotels_Click" CssClass="prism-button" Text="Load more">
                            <div class="prism-wrap">
                                <span>Want to view more hotels ?</span>
                                <span>
                                    <i class="fa fa-chevron-down"></i>
                                    Show more
                                    <i class="fa fa-chevron-down"></i>
                                </span>
                            </div>     
                        </asp:LinkButton>
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
							    NavigateUrl='<%# $"../../Pages/Requests/BoardingRequest.aspx?id={Item.HotelManagerId}" %>'>
							    <h4 runat="server">Accomodate your pet</h4>
						    </asp:HyperLink>
					    </div>
				    </div>                
			    </div>	               
		    </ItemTemplate>
	    </asp:ListView>
     </ContentTemplate>
    
    </asp:UpdatePanel>

</section>
