<%@ Control Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="AllHotelRequests.ascx.cs" 
	Inherits="PetsWonderland.Client.Admin.Controls.AllHotelRequests" %>

<!DOCTYPE html>

<asp:ListView runat="server"  
	ID="HotelRequests" 
    ItemType="PetsWonderland.Business.Models.Requests.UserHotelRegistrationRequest" 
    SelectMethod="ListViewHotelRequests_GetData">
	
	<EmptyDataTemplate>
        <div>
            <h2>No hotel requests found!</h2>
        </div>
    </EmptyDataTemplate>
    <EmptyItemTemplate>
		<div></div>
    </EmptyItemTemplate>

    <LayoutTemplate>
        <div class="row">
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
        </div>
    </LayoutTemplate>

    <ItemTemplate>
        <div>
            <h2><%#: Item.HotelName %></h2>
        </div>
		<div>
            <div class="wrapper">
				<div class="location">
					<p>Location: <%#: Item.HotelLocation %></p>
                </div>
                <div class="image">
					<asp:Image runat="server" Height="300px" ImageUrl='<%# Item.HotelImageUrl %>'/>
                </div>
                <div class="description">
					<p><%#: Item.HotelDescription %></p>
                </div>
            </div>                
        </div>
		<div>
			<asp:HyperLink ID="ApproveHotelRequest" CssClass="col-md-3" runat="server" Visible="true"
				 NavigateUrl='<%# String.Format("../ApproveHotelRequest.aspx?name={0}&description={1}&image={2}&location={3}&id={4}", 
					Item.HotelName, Item.HotelDescription, Item.HotelImageUrl, Item.HotelLocation, Item.Id) %>'>
				<h4 runat="server">Approve hotel request</h4>
			</asp:HyperLink>
			<asp:HyperLink ID="DenyHotelRequest" CssClass="col-md-3" runat="server" Visible="true"
				 NavigateUrl='<%# String.Format("../DenyHotelRequest.aspx?id={0}", Item.Id) %>'>
				<h4 runat="server">Deny hotel request</h4>
			</asp:HyperLink>
		</div>
    </ItemTemplate>
</asp:ListView>
<asp:DataPager ID="DataPagerCustomers" runat="server"
    PagedControlID="HotelRequests" PageSize="1"
    QueryStringField="page">
    <Fields>
        <asp:NextPreviousPagerField  ShowFirstPageButton="false"
            ShowNextPageButton="false" ShowPreviousPageButton="true" />
		<asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="false"
            ShowNextPageButton="true" ShowPreviousPageButton="false" />
    </Fields>
</asp:DataPager>