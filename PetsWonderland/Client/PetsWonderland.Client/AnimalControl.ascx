<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnimalControl.ascx.cs" Inherits="PetsWonderland.Client.AnimalControl" %>

<div>
<fieldset><legend>Enter Animal Id</legend>
	<asp:TextBox runat="server" ID="studentId" MaxLength="9" />
	<p>
		<asp:Button ID="Button1" runat="server" Text="Find By Id"  OnClick="FindClick" />
		<asp:Button ID="Button2" runat="server" Text="Get All" OnClick = "FindAll"/>
	</p>
</fieldset>
<div>
	<asp:DetailsView ID="results" runat="server" ItemType=""/>
</div>
	<asp:GridView ID="GridView1" runat="server"></asp:GridView>
</div>