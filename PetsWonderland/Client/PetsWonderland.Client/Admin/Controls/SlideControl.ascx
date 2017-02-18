<%@ Control Language="C#" 
            AutoEventWireup="true" 
            CodeBehind="SlideControl.ascx.cs" 
            Inherits="PetsWonderland.Client.Admin.Controls.SlideControl" %>


<div class="form-group label-floating is-empty">
    <label class="control-label">Slide title:</label>                              
    <asp:TextBox runat="server"  ID="SlideTitle" name="slideTitle" CssClass="form-control"> </asp:TextBox>
    <span class="material-input"></span>
</div>
                       
                       
<div class="form-group label-floating is-empty">
    <label class="control-label">Slide caption:</label>                              
    <asp:TextBox runat="server" ID="SlideCaption"  name="slideCaption"  CssClass="form-control"> </asp:TextBox>
    <span class="material-input"></span>
</div>      

<div class="form-group label-floating is-empty">
    <label class="control-label">Image:</label>                              
    <asp:FileUpload runat="server" ID="SlideImage" name="slideImage" CssClass="form-control" />
    <span class="material-input"></span>
</div>

