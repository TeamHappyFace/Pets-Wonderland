<%@ Control Language="C#" 
            AutoEventWireup="true"
            CodeBehind="AdminSlidersListControl.ascx.cs" 
            Inherits="PetsWonderland.Client.Admin.Controls.AdminSlidersListControl" %>

<a class="create-slider-btn" runat="server" href="~/Admin/AddSlider.aspx">
    <i class="fa fa-plus-square-o fa-2x"></i>    
    <span>Create new slider</span>                      
</a>

<table class="table table-hover">
    <thead class="text-primary">
        <th>#</th>
        <th>Name</th>
        <th>Position</th>        
        <th>Number of slides</th>        
        <th>Options</th>
    </thead>
    <tbody>
     <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:Repeater ID="AllSlidersTableRepeater" runat="server" ItemType="PetsWonderland.Business.Models.Pages.Slider">
                <ItemTemplate>                       
                    <tr>
                        <td><%# Container.ItemIndex + 1 %></td>
                        <td><%#: Eval("Name") %></td>
                        <td><%#: Eval("Position") %></td>
                        <td><%#: Eval("Slides.Count") %></td>
                        <td>                                                                                                         
                            <asp:LinkButton                                 
                                ID="btnDeleteSlider"  
                                runat="server" 
                                CssClass="btn btn-primary btn-simple btn-xs"
                                OnClick="btnDeleteSlider_Click">
                                <i class="fa fa-trash text-danger" data-toggle="tooltip" title="Delete this slider" data-placement="bottom"></i>
                            </asp:LinkButton>                  
                        </td>
                    </tr>                          
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
    </tbody>            
</table> 

