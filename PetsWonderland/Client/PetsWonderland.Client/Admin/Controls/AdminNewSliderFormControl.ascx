<%@ Control Language="C#" 
            AutoEventWireup="true" 
            CodeBehind="AdminNewSliderFormControl.ascx.cs" 
            Inherits="PetsWonderland.Client.Admin.Controls.AdminNewSliderFormControl" %>

<div class="modal modal-lg fade" id="newSliderModal" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="newSliderModalPanel" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">New slider</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-md-12">                            
                            <div class="row">
                                <div class="form-group label-floating is-empty">
                                    <label class="control-label">Slider name:</label>                              
                                    <asp:TextBox runat="server" ID="SliderName" CssClass="form-control"> </asp:TextBox>
                                    <span class="material-input"></span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group label-floating is-empty">
                                    <label class="control-label">Slider position:</label>                              
                                    <asp:TextBox runat="server" ID="SliderPostion" CssClass="form-control"> </asp:TextBox>
                                    <span class="material-input"></span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group label-floating is-empty">
                                    <label class="control-label">Image:</label>                              
                                    <asp:FileUpload ID="SliderImage" runat="server" CssClass="form-control" />
                                    <span class="material-input"></span>
                                </div>
                            </div>                                                
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button
                            runat="server"
                            Text="Create slider"
                            ID="CreateSliderBtn"
                            CssClass="btn btn-primary"
                            OnClick="CreateSliderBtn_Click">
                        </asp:Button>                      
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                    <asp:PostBackTrigger ControlID="CreateSliderBtn" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
