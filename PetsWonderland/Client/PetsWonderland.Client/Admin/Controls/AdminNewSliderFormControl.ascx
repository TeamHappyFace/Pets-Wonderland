<%@ Control Language="C#" 
            AutoEventWireup="true" 
            CodeBehind="AdminNewSliderFormControl.ascx.cs" 
            Inherits="PetsWonderland.Client.Admin.Controls.AdminNewSliderFormControl" %>

<%@ Register Src="~/PageControls/Notifications/NotificationControl.ascx" TagPrefix="nf" TagName="NotificationsControl" %>

<div id="newSliderModal">   
    <nf:NotificationsControl ID="Notificator" runat="server" /> 
    <div class="content">               
        <div class="card">
            <div class="card-header" data-background-color="blue">
                <h4 class="title">Create new slider</h4>
                <p>Fill the form below...</p>
            </div>
            <div class="card-contnent col-md-12">                            
                <div class="stack-group">
                    <label>Slider main data:</label>
                            
                    <div class="form-group label-floating is-empty">
                        <label class="control-label">Slider name: <span class="text-danger">*</span></label>                              
                        <asp:TextBox runat="server" ID="SliderName" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate= "SliderName" CssClass="text-danger" ErrorMessage="Slider name is required." />
                        <span class="material-input"></span>
                    </div>
                       
                       
                    <div class="form-group label-floating is-empty">
                        <label class="control-label">Slider position:<span class="text-danger">*</span></label>                              
                        <asp:TextBox runat="server" ID="SliderPostion" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate= "SliderPostion" CssClass="text-danger" ErrorMessage="Slider position is required." />
                        <span class="material-input"></span>
                    </div>                                                                           
                </div>
                        
                <asp:Panel runat="server" id="SlidesList" CssClass="stack-group">
                    <div class="header">
                        <label> Slides:</label>                                                                                                                
                        <asp:Button ID="AddNewSlideBtn" CssClass="btn btn-primary" runat="server" Text="Add" onclick="addNewSlide_Click"/>                          
                    </div>
                    
                    <asp:PlaceHolder ID="SliderSlidesPlaceholder2" runat="server"> </asp:PlaceHolder>
                </asp:Panel>                                        
            </div>
        </div>
        <div class="buttons">
            <asp:Button
                runat="server"
                Text="Create slider"
                ID="CreateSliderBtn"
                CssClass="btn btn-info"
                OnClick="CreateSliderBtn_Click">
            </asp:Button>                                         
        </div>
    </div>
   
</div>

