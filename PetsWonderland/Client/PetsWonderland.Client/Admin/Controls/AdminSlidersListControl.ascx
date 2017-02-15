<%@ Control Language="C#" 
            AutoEventWireup="true"
            CodeBehind="AdminSlidersListControl.ascx.cs" 
            Inherits="PetsWonderland.Client.Admin.Controls.AdminSlidersListControl" %>

<asp:LinkButton 
    ID="btnNewSlider"  
    runat="server" 
    CssClass="btn btn-primary btn-simple btn-xs"
    OnClientClick="$('#newSliderModal').appendTo('body').modal();return false;">
    <i class="fa fa-plus-square-o"></i>
</asp:LinkButton>

<asp:Repeater ID="AllSlidersTableRepeater" runat="server" ItemType="PetsWonderland.Business.Models.Pages.Slider">
        <ItemTemplate>          
             <table class="table table-hover">
                 <thead class="text-primary">
                    <th>#</th>
                    <th>Name</th>
                    <th>Position</th>        
                    <th>Number of slides</th>        
                    <th>Options</th>
                 </thead>
                <tr>
                    <td>1</td>
                    <td><%#: Eval("Name") %></td>
                    <td><%#: Eval("Position") %></td>
                    <td><%#: Eval("Slides.Count") %></td>
                    <td>      
                         <asp:LinkButton ID="btnEditSlider"  
                                     runat="server" 
                                     CssClass="btn btn-primary btn-simple btn-xs"                            
                                     OnClientClick="$('#editSliderModal').appendTo('body').modal();return false;">
                             <i class="fa fa-pencil"></i>
                         </asp:LinkButton>
                         <asp:LinkButton ID="btnDeleteSlider"  
                                     runat="server" 
                                     CssClass="btn btn-primary btn-simple btn-xs"
                                     OnClick="btnDeleteSlider_Click">
                             <i class="fa fa-trash"></i>
                         </asp:LinkButton>                  
                    </td>
                </tr>  
            </table> 
        </ItemTemplate>
</asp:Repeater>

