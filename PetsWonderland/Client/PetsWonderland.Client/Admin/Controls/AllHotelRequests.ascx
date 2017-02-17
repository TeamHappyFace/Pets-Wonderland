<%@ Control Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="AllHotelRequests.ascx.cs" 
	Inherits="PetsWonderland.Client.Admin.Controls.AllHotelRequests" %>

<%@ Register src="~/Admin/Controls/DenyHotelRequest.ascx" tagname="DenyHotelRequest" tagprefix="ucc" %>
<%@ Register src="~/Admin/Controls/ApproveHotelRequest.ascx" tagname="ApproveHotelRequest" tagprefix="ucc" %>

<!DOCTYPE html>

<asp:ListView runat="server"  
	ID="HotelRequests" 
    ItemType="PetsWonderland.Business.Models.Requests.UserHotelRegistrationRequest" 
    SelectMethod="ListViewHotelRequests_GetData">

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
		<div>
			<ucc:ApproveHotelRequest runat="server"/>
			<ucc:DenyHotelRequest runat="server" />

<%--			<ucc:ApproveHotelRequest runat="server" ID="ApproveRequest"
 				HotelName = <%# Item.HotelName %>
 				Description = <%# Item.HotelDescription %>
 				ImageUrl = <%# Item.HotelImageUrl %> />

			<ucc:DenyHotelRequest runat="server" RequestId ="<%# Item.Id %>"/>--%>

		</div>
    </ItemTemplate>
</asp:ListView>
<asp:DataPager ID="DataPagerCustomers" runat="server"
    PagedControlID="HotelRequests" PageSize="1"
    QueryStringField="page">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="false"
            ShowNextPageButton="false" ShowPreviousPageButton="true" />
		<asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="false"
            ShowNextPageButton="true" ShowPreviousPageButton="false" />
    </Fields>
</asp:DataPager>