<%@ Control Language="C#" 
            AutoEventWireup="true" 
            CodeBehind="AdminNewSliderFormControl.ascx.cs" 
            Inherits="PetsWonderland.Client.Admin.Controls.AdminNewSliderFormControl" %>

<div id="newSliderModal">
    
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
                                <label class="control-label">Slider name:</label>                              
                                <asp:TextBox runat="server" ID="SliderName" CssClass="form-control"> </asp:TextBox>
                                <span class="material-input"></span>
                            </div>
                       
                       
                            <div class="form-group label-floating is-empty">
                                <label class="control-label">Slider position:</label>                              
                                <asp:TextBox runat="server" ID="SliderPostion" CssClass="form-control"> </asp:TextBox>
                                <span class="material-input"></span>
                            </div>                                                                           
                        </div>
                        
                        <asp:Panel runat="server" id="SlidesList" CssClass="stack-group">
                            <label>
                                Slides: 

                            </label>                                                                                                                
                                <asp:Button ID="AddNewSlideBtn" runat="server" Text="Add" onclick="addNewSlide_Click"/>
                          
                                <asp:PlaceHolder ID="SliderSlidesPlaceholder2" runat="server"> </asp:PlaceHolder>

                        </asp:Panel>                                        
                    </div>
                </div>
                <div class="buttons">
                    <asp:Button
                        runat="server"
                        Text="Create slider"
                        ID="CreateSliderBtn"
                        CssClass="btn btn-primary"
                        OnClick="CreateSliderBtn_Click">
                    </asp:Button>                                         
                </div>
            </div>
   
</div>
