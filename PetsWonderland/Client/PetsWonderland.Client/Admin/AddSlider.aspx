<%@ Page Language="C#"
         MasterPageFile="~/Admin/Admin.Master"
         AutoEventWireup="true" 
         CodeBehind="AddSlider.aspx.cs" 
         Inherits="PetsWonderland.Client.Admin.AddSlider" %>

<%@ Register Src="~/Admin/Controls/AdminNewSliderFormControl.ascx" TagPrefix="acc" TagName="NewSliderControl" %>
<%@ Register Src="~/Admin/Controls/SlideControl.ascx" TagPrefix="acc" TagName="SlideControl" %>

<asp:Content ID="HomepageContent" ContentPlaceHolderID="DashboardMainContent" runat="server">    
    <acc:NewSliderControl runat="server"/>
</asp:Content>