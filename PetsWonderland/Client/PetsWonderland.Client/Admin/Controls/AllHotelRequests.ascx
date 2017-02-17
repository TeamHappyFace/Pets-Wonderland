<%@ Control Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="AllHotelRequests.ascx.cs" 
	Inherits="PetsWonderland.Client.Admin.Controls.AllHotelRequests" %>

<asp:ListView runat="server"  
	ID="HotelRequests" 
    ItemType="PetsWonderland.Business.Models.Requests.UserHotelRegistrationRequest" 
    SelectMethod="ListViewHotelRequests_GetData">

    <GroupTemplate>
        <div class="row">
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
        </div>
    </GroupTemplate>

    <ItemTemplate>
        <div>
            <h2><%#: Item.HotelName %></h2>
        </div>
		<div>
            <div class="wrapper">
				<div class="location">
					<p><%#: Item.HotelLocation %></p>
                </div>
                <div class="image">
					<asp:Image runat="server" ImageUrl='<%# Item.HotelImageUrl %>'/>
                </div>
                <div class="description">
					<p><%#: Item.HotelDescription %></p>
                </div>
            </div>                
        </div>
		<div>
			<asp:Button OnClick="OnDeny_Click" Text="Deny" runat="server" CommandArgument='<%# Item.Id %>'/>
		</div>
    </ItemTemplate>
</asp:ListView>