<%@ Control Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="AllHotelRequests.ascx.cs" 
	Inherits="PetsWonderland.Client.Admin.Controls.AllHotelRequests" %>

<!DOCTYPE html>

<asp:ListView runat="server"  
	ID="HotelRequests" 
    ItemType="PetsWonderland.Business.Models.Requests.UserHotelRegistrationRequest" 
    SelectMethod="ListViewHotelRequests_GetData"
	OnItemCommand ="HotelRequests_ItemCommand" 
	OnItemCreated="HotelRequests_ItemCreated">
	
	<EmptyDataTemplate>
		<div class="col-md-12" data-background-color="blue">
            <h3 class="col-md-12">No hotel requests found!</h3>
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
		<asp:HiddenField runat="server" ID="hotelManagerId" Value="<%#: Item.HotelManagerId %>" />

		<div class="card-header text-center" data-background-color="blue">                         
			<h5>Hotel name: 
				<asp:Label runat="server" ID="hotelName" Text="<%#: Item.HotelName %>"></asp:Label>
			</h5> 
			<h5>Location:
				<asp:Label runat="server" ID="location" Text="<%#: Item.HotelLocation %>"/>
			</h5>
		</div> 
		<div class="card-content text-center image">
			<asp:Image runat="server" ID="image" Height="400" Width="80%" ImageUrl='<%# Item.HotelImageUrl %>'/>
		</div>
		<div class="card-content text-center">             
			<div class="card-header" data-background-color="blue">
				<h5 class="title">Description</h5>			                         
				<div class="stack-group description">
					<asp:TextBox runat="server" ID="TextBox1" Text="<%#: Item.HotelDescription %>"/>                                                                      
				</div>                                                       
			</div>
		</div>
		<div class="card-content text-center">
			<asp:LinkButton ID="ApproveHotelRequest" CssClass="col-md-6" runat="server" Visible="true">
				<h5 runat="server">Approve hotel request</h5>
			</asp:LinkButton>
			<asp:HyperLink ID="DenyHotelRequest" CssClass="col-md-6" runat="server" Visible="true"
				 NavigateUrl='<%# String.Format("../DenyHotelRequest.aspx?id={0}", Item.Id) %>'>
				<h5 runat="server">Deny hotel request</h5>
			</asp:HyperLink>
		</div>
    </ItemTemplate>
</asp:ListView>
<div class="text-center">
	<asp:DataPager ID="DataPager" runat="server"
		PagedControlID="HotelRequests" PageSize="1"
		QueryStringField="page">
		<Fields >
			<asp:NextPreviousPagerField  ShowFirstPageButton="false"
				ShowNextPageButton="false" ShowPreviousPageButton="false" />
			<asp:NumericPagerField/>
			<asp:NextPreviousPagerField ShowLastPageButton="false"
				ShowNextPageButton="false" ShowPreviousPageButton="false" />
		</Fields>
	</asp:DataPager>
</div>