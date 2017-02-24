<%@ Control Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="AllBoardingRequests.ascx.cs" 
	Inherits="PetsWonderland.Client.PageControls.Account.AllBoardingRequests" %>

	<asp:ListView runat="server" ID="BoardingRequests" 
	ItemType="PetsWonderland.Business.Models.Requests.UserBoardingRequest" 
	SelectMethod="ListViewRequests_GetData">
	<EmptyDataTemplate>
        <div class="title text-center">
            <h2>No boarding requests found!</h2>
        </div>
    </EmptyDataTemplate>
    <EmptyItemTemplate>
		<div>

		</div>
    </EmptyItemTemplate>

	<GroupTemplate>
		<div class="row">
			<asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
		</div>
	</GroupTemplate>

	<ItemTemplate>
	<div class="section-content text-center">
		<div class="hotels-list grid">
			<div class="gutter-sizer"></div>
			<div class="grid-item col-sm-12">
				<div class="wrapper">
					<div class="title">
						<h4>Pet name - <%#: Item.PetName %></h4>
					</div>
					<div class="breed">
						<h4>Breed - <%#: Item.PetBreed %></h4>
					</div>
					<div class="image">
						<asp:Image runat="server" Width="150px" Height="120px" ImageUrl='<%# Item.ImageUrl %>'/>
					</div>
					<div class="age">
						<h4>Age - <%#: Item.Age %></h4>
					</div>
					<div class="dates">
						<h4>
							Dates: <%#: Item.FromDate %> - <%# Item.ToDate %>
						</h4>
					</div>
				</div>                
			</div>
		</div>
	</div>
	</ItemTemplate>
</asp:ListView>
<div class="text-center">
	<asp:DataPager ID="DataPager2" runat="server"
		PagedControlID="BoardingRequests" PageSize="1"
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
