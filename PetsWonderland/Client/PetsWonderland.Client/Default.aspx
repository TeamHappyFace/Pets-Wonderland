<%@ Page Title="Home Page" 
    Language="C#" 
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="PetsWonderland.Client._Default" %>

<%@ Register Src="~/PageControls/Homepage/HomepageSliderControl.ascx" TagPrefix="hpc" TagName="SliderControl" %>

<asp:Content ContentPlaceHolderID="CustomStylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/External/RevSlider/revslider.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveUrl("~/Content/Pages/homepage.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="OuterContent" runat="server">
    <hpc:SliderControl runat="server"/>
</asp:Content>

<asp:Content ID="HomepageContent" ContentPlaceHolderID="MainContent" runat="server">
    
</asp:Content>

<asp:Content ContentPlaceHolderID="CustomScripts" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/External/RevSlider/jquery.themepunch.plugins.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/External/RevSlider/jquery.themepunch.revolution.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/Pages/homepage.js") %>" type="text/javascript"></script>
</asp:Content>
