<%@ Page Language="C#" 
         MasterPageFile="~/Admin/Admin.Master"
         AutoEventWireup="true" 
         CodeBehind="ContentPages.aspx.cs" 
         Inherits="PetsWonderland.Client.Admin.ContentPages" %>

<%@ Register Src="~/Admin/Controls/AdminSlidersListControl.ascx" TagPrefix="acc" TagName="SliderListControl" %>
<%@ Register Src="~/Admin/Controls/AdminEditSliderFormControl.ascx" TagPrefix="acc" TagName="EditSliderControl" %>
<%@ Register Src="~/Admin/Controls/AdminNewSliderFormControl.ascx" TagPrefix="acc" TagName="NewSliderControl" %>

<asp:Content ID="HomepageContent" ContentPlaceHolderID="DashboardMainContent" runat="server">
     <h1>Content Pages</h1>
    
     <div class="row">
         <div class="col-md-12">
             <div class="card card-nav-tabs">
                 <div class="card-header" data-background-color="blue">
                     <div class="nav-tabs-navigation">
                         <div class="nav-tabs-wrapper">
                             <span class="nav-tabs-title">Modules:</span>
                             <ul class="nav nav-tabs" data-tabs="tabs">
                                 <li class="active">
                                     <a href="#sliders" data-toggle="tab" aria-expanded="true">
                                         <i class="fa fa-sliders"></i>
                                         Sliders
                                         <div class="ripple-container"></div>
                                     </a>
                                 </li>
                                 <li>
                                     <a href="#quotes" data-toggle="tab" aria-expanded="true">
                                         <i class="fa fa-file-text"></i>
                                         Quotes of the day
                                         <div class="ripple-container"></div>
                                     </a>
                                 </li>
                                 <li>
                                     <a href="#hotels" data-toggle="tab" aria-expanded="true">
                                         <i class="fa fa-hotel"></i>
                                         Hotels
                                         <div class="ripple-container"></div>
                                     </a>
                                 </li>
                             </ul>
                         </div>
                     </div>                     
                 </div>
                 <div class="card-content table-responsive">
                     <div class="tab-content">
                         <div id="sliders" class="tab-pane active">                             
                              <acc:SliderListControl runat="server"/>                              
                              <acc:EditSliderControl runat="server"/>
                              <acc:NewSliderControl runat="server"/>
                         </div>
                         <div id="quotes" class="tab-pane">quotes list</div>
                         <div id="hotels" class="tab-pane">hotels list</div>
                     </div>
                 </div>
             </div>
         </div>
     </div>
    
    
</asp:Content>
