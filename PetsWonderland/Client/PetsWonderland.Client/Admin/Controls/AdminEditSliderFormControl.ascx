<%@ Control Language="C#" 
            AutoEventWireup="true"
            CodeBehind="AdminEditSliderFormControl.ascx.cs"
            Inherits="PetsWonderland.Client.Admin.Controls.AdminEditSliderFormControl" %>

<div class="modal modal-lg fade" id="editSliderModal" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="editSliderModalPanel" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Edit slider data</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-md-12">                            
                            <div class="row">
                                <div class="form-group label-floating is-empty">
                                    <label class="control-label">Image:</label>
                                    <input class="form-control" type="file" />
                                    <span class="material-input"></span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group label-floating is-empty">
                                    <label class="control-label">Title:</label>
                                    <input class="form-control" type="text" />
                                    <span class="material-input"></span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group label-floating is-empty">
                                    <label class="control-label">Caption:</label>
                                    <input class="form-control" type="text" />
                                    <span class="material-input"></span>
                                </div>
                            </div>                            
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-primary" type="submit">Update</button>
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
