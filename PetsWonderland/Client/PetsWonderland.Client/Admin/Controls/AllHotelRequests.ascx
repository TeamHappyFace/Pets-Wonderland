<%@ Control Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="AllHotelRequests.ascx.cs" 
	Inherits="PetsWonderland.Client.Admin.Controls.AllHotelRequests" %>

<!DOCTYPE html>

<asp:ListView runat="server"  
	ID="HotelRequests" 
    ItemType="PetsWonderland.Business.Models.Requests.UserHotelRegistrationRequest" 
    SelectMethod="ListViewHotelRequests_GetData"
	OnItemCommand ="HotelRequests_ItemCommand">
	
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
		<asp:HiddenField runat="server" ID="hidden" Value="<%#: Item.Id %>"/>
        <div>
			<asp:Label runat="server" ID="hotelName" Text="<%#: Item.HotelName %>"></asp:Label>
        </div>
		<div>
            <div class="wrapper">
				<div class="location">
					<asp:Label runat="server" ID="location" Text="<%#: Item.HotelLocation %>"/>
                </div>
                <div class="image">
					<asp:Image runat="server" ID="image" Height="300px" ImageUrl='<%# Item.HotelImageUrl %>'/>
                </div>
                <div class="description">
					<asp:TextBox runat="server" ID="description" Text="<%#: Item.HotelDescription %>"/>
                </div>
            </div>                
        </div>
		<div>
			<asp:LinkButton ID="ApproveHotelRequest" CssClass="col-md-3" runat="server" Visible="true">
				<h4 runat="server">Approve hotel request</h4>
			</asp:LinkButton>
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